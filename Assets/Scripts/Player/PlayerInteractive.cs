using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractive : MonoBehaviour
{
    public float distance = 1f;
    GameObject currentItem;
    bool canPickUp;


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E)) PickUp();
        if (Input.GetKeyUp(KeyCode.Q)) Drop();
        DebugRay();
    }

    void DebugRay()
    {
        Debug.DrawRay(
            gameObject.transform.position + new Vector3(0, 1, 0),
            gameObject.transform.forward * distance,
            Color.red);
    }

    void PickUp()
    {
        RaycastHit hit;

        if(Physics.Raycast(gameObject.transform.position + new Vector3(0, 1, 0), gameObject.transform.forward, out hit, distance))
        {   
            if (canPickUp) Drop();

            if (hit.transform.GetComponent<Container>())
            {
                Container container = hit.transform.GetComponent<Container>();
                currentItem = container.GetItemFromContainer();
            }
            
            if (hit.transform.tag == "Item")
            {
                currentItem = hit.transform.gameObject;
            }

            currentItem.GetComponent<Rigidbody>().isKinematic = true;
            currentItem.transform.parent = transform;
            currentItem.transform.localPosition = new Vector3(0, 1, 1.2f);
            currentItem.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            currentItem.GetComponent<Collider>().enabled = false;
            canPickUp = true;

            print(hit.transform.gameObject);
        }
    }

    void Drop()
    {
        currentItem.GetComponent<Collider>().enabled = true;
        currentItem.transform.parent = null;
        currentItem.GetComponent<Rigidbody>().isKinematic = false;
        canPickUp = false;
        currentItem = null;
    }
}
