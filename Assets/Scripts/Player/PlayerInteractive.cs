using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractive : MonoBehaviour
{
    [SerializeField] private float distance = 1f;

    GameObject currentItem;
    bool canPickUp = true;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E)) PickUp();
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

    void PickUp()
    {
        RaycastHit hit;

        if(Physics.Raycast(gameObject.transform.position + new Vector3(0, 1.2f, 0), gameObject.transform.forward, out hit, distance))
        {
            if (hit.transform.tag == "Item" && canPickUp)
            {
                currentItem = hit.transform.gameObject;
                canPickUp = false;
            }

            if (hit.transform.GetComponent<Container>() && canPickUp)
            {
                Container container = hit.transform.GetComponent<Container>();
                currentItem = container.GetItemFromContainer();
                canPickUp = false;
            }

            if (hit.transform.GetComponent<CuttingBoard>() && currentItem.GetComponent<Ingredient>())
            {
                CuttingBoard cutting = hit.transform.GetComponent<CuttingBoard>();
                GameObject previousItem = currentItem;
                currentItem = null;
                cutting.GetItemsFromIngredient(previousItem.GetComponent<Ingredient>());
                Destroy(previousItem);
                canPickUp = true;

            }
/*            if (canPickUp) Drop();*/
            if(currentItem != null)
            {
                currentItem.GetComponent<Rigidbody>().isKinematic = true;
                currentItem.transform.parent = transform;
                currentItem.transform.localPosition = new Vector3(0, 1, 1.2f);
                currentItem.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                currentItem.GetComponent<Collider>().enabled = false;
            }


/*            canPickUp = true;*/
        }
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
