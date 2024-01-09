using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerInteractive : MonoBehaviour
{
    [SerializeField] private float distance = 1f;

    GameObject currentItem;
    bool canPickUp = true;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E)) Interract();
        if (Input.GetKeyUp(KeyCode.Q)) Drop();
        DebugRay();
    }

    void DebugRay()
    {
        Debug.DrawRay(
            gameObject.transform.position + new Vector3(0, 1.2f, 0),
            gameObject.transform.forward * distance,
            Color.red);
    }

    void Interract()
    {
        RaycastHit hit;

        if(Physics.Raycast(gameObject.transform.position + new Vector3(0, 1.2f, 0), gameObject.transform.forward, out hit, distance))
        {
            if (hit.transform.tag == "Item" && canPickUp)
            {
                PickUp(hit.transform.gameObject);
            }

            if (hit.transform.GetComponent<Container>() && canPickUp)
            {
                Container container = hit.transform.GetComponent<Container>();
                PickUp(container.GetItemFromContainer());
            }

            if (hit.transform.GetComponent<CuttingBoard>() && currentItem.GetComponent<Ingredient>())
            {
                CuttingBoard board = hit.transform.GetComponent<CuttingBoard>();
                CutIngredient(board, currentItem.GetComponent<Ingredient>());
            }

            if(currentItem != null && hit.transform.CompareTag("Dish") && currentItem.GetComponent<Plate>())
            {
                Transform dish = hit.transform;
                Plate plate = currentItem.GetComponent<Plate>();

                PlacePlateAt(plate, dish);
            }

            if (hit.transform.GetComponent<Plate>())
            {
                Plate plate = hit.transform.GetComponent<Plate>();
                plate.Use();
            }
        }
    }

    void PickUp(GameObject item)
    {
        currentItem = item;
        currentItem.GetComponent<Rigidbody>().isKinematic = true;
        currentItem.transform.parent = transform;
        currentItem.transform.localPosition = new Vector3(0, 1, 1.2f);
        currentItem.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        currentItem.GetComponent<Collider>().enabled = false;
        canPickUp = false;
    }

    void CutIngredient(CuttingBoard board, Ingredient ingredient)
    {
        Drop();
        board.GetItemsFromIngredient(ingredient);
        Destroy(ingredient.gameObject);
    }

    void PlacePlateAt(Plate plate, Transform placement)
    {
        Drop();

        plate.transform.parent = placement;
        plate.transform.localPosition = new Vector3(0, 0.2f, 0);

        plate.GetComponent<Rigidbody>().isKinematic = true;
        placement.GetComponent<Collider>().enabled = false;
        plate.tag = "Plate";
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
