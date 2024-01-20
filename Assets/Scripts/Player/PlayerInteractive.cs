using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerInteractive : MonoBehaviour
{
    [SerializeField] private float distance = 1f;
    [SerializeField] private bool debug = false;
    [SerializeField] private Vector3 rayPosition = new Vector3(0, 1.2f, 0);

    GameObject currentItem;
    bool canPickUp = true;
    IOutlinable currentOutlinable;

    List<string> tagsAllowedToPickUp = new List<string>() { 
        "Item", 
        "PreparedIngredient",                                   // Tags that player can pick up
        "Dish" 
    };
    void Update()
    {
        RayInteract();

        if (Input.GetKeyUp(KeyCode.Q)) 
            Drop();
    }

    void DebugRay()
    {
        Debug.DrawRay(
            gameObject.transform.position + rayPosition,
            gameObject.transform.forward * distance,
            Color.red);
    }

    void RayInteract()
    {
        RaycastHit hit;

        if (debug)
            DebugRay();

        if (Physics.Raycast(gameObject.transform.position + rayPosition, gameObject.transform.forward, out hit, distance))
        {
            if (hit.transform.GetComponent<IOutlinableImpl>())
            {
                if (currentOutlinable != null)
                    currentOutlinable.SetColorForOutline(currentOutlinable.defaultColorImpl);

                currentOutlinable = hit.transform.GetComponent<IOutlinable>();
                currentOutlinable.SetColorForOutline(currentOutlinable.interactColorImpl);
            }

            if (Input.GetKeyUp(KeyCode.E)) 
                InteractWith(hit);
        }
        else if(currentOutlinable != null)
        {
            currentOutlinable.SetColorForOutline(currentOutlinable.defaultColorImpl);
            currentOutlinable = null;
        }
    }

    void InteractWith(RaycastHit hit)
    {

        if (tagsAllowedToPickUp.Contains(hit.transform.tag) && canPickUp)
        {
            PickUp(hit.transform.gameObject);
        }

        if (hit.transform.GetComponent<Container>() && canPickUp)
        {
            Container container = hit.transform.GetComponent<Container>();
            PickUp(container.GetItemFromContainer());
        }

        if (!canPickUp && hit.transform.GetComponent<CuttingBoard>() && currentItem.GetComponent<CuttableIngredient>())
        {
            CuttingBoard board = hit.transform.GetComponent<CuttingBoard>();
            CutIngredient(board, currentItem.GetComponent<CuttableIngredient>());
        }

        if (canPickUp && hit.transform.GetComponent<Pan>() && hit.transform.GetComponent<Pan>().HasItem())
        {
            Pan pan = hit.transform.GetComponent<Pan>();

            PickUp(pan.GetItem());
            pan.OnItemRemove();
        }

        if (!canPickUp && hit.transform.GetComponent<Pan>() && currentItem.GetComponent<CookableIngredient>() && !hit.transform.GetComponent<Pan>().HasItem())
        {
            Pan pan = hit.transform.GetComponent<Pan>();
            GameObject previousItem = currentItem;

            Drop();

            pan.MakeItemFromIngredient(previousItem.GetComponent<CookableIngredient>());
            pan.OnItemPlace();

            Destroy(previousItem);
        }

        if(currentItem != null && hit.transform.CompareTag("Placement") && currentItem.GetComponent<Plate>() && !currentItem.CompareTag("Dish"))
        {
            GameObject placement = hit.transform.gameObject;
            Plate plate = currentItem.GetComponent<Plate>();

            PlacePlateAt(plate, placement);
        }

        if (!canPickUp && hit.transform.GetComponent<Plate>() && currentItem.CompareTag("PreparedIngredient"))
        {
            Plate plate = hit.transform.GetComponent<Plate>();
            PlaceItemOnPlate(currentItem, plate);
        }
    }

    void PickUp(GameObject item)
    {
        currentItem = item;

        print("Picking up");
        currentItem.GetComponent<Rigidbody>().isKinematic = true;
        currentItem.transform.parent = transform;
        currentItem.transform.localPosition = new Vector3(0, 1, 1.2f);
        currentItem.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        currentItem.GetComponent<Collider>().enabled = false;

        canPickUp = false;
    }

    void CutIngredient(CuttingBoard board, CuttableIngredient ingredient)
    {
        Drop();

        board.MakeItemsFromIngredient(ingredient);

        Destroy(ingredient.gameObject);
    }

    void PlacePlateAt(Plate plate, GameObject placement)
    {
        Drop();

        plate.transform.parent = placement.transform;
        plate.transform.localPosition = new Vector3(0, 0.2f, 0);

        plate.GetComponent<Rigidbody>().isKinematic = true;
        placement.GetComponent<Collider>().enabled = false;
        plate.tag = "Plate";
        plate.SetPlacement(placement);
    }

    void PlaceItemOnPlate(GameObject item, Plate plate)
    {
        IngredientOrder itemOrder = item.GetComponent<PreparedIngredient>().GetOrder();

        bool isDefault = plate.GetLastItem() != null && itemOrder.Equals(IngredientOrder.DEFAULT);
        bool isFirst = plate.GetLastItem() == null && itemOrder.Equals(IngredientOrder.FIRST);
        bool isLast = plate.GetLastItem() != null && itemOrder.Equals(IngredientOrder.LAST);

        if (isLast)
        {
            Drop();

            PlaceLastItemOnPlate(item, plate);
        }

        if (isFirst || isDefault)
        {
            Drop();

            plate.PutItem(item);
        }
    }

    void PlaceLastItemOnPlate(GameObject item, Plate plate)
    {
        GameObject placement = plate.GetPlacement();

        plate.PutItem(item);
        plate.transform.parent = null;

        plate.GetComponent<Rigidbody>().isKinematic = false;
        placement.GetComponent<Collider>().enabled = true;
        plate.tag = "Dish";
    }

    void Drop()
    {
        currentItem.GetComponent<Collider>().enabled = true;
        currentItem.transform.parent = null;
        currentItem.GetComponent<Rigidbody>().isKinematic = false;

        currentItem = null;
        canPickUp = true;
    }
}
