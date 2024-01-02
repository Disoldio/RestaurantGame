using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractive : MonoBehaviour
{
    public float distance = 15f;
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
        Debug.DrawRay(gameObject.transform.position + new Vector3(0, 1, 0), gameObject.transform.forward, Color.red, distance);
    }

    void PickUp()
    {
        RaycastHit hit;

        if(Physics.Raycast(gameObject.transform.position + new Vector3(0, 1, 0), gameObject.transform.forward, out hit, distance))
        {
            if(hit.transform.tag == "Item")
            {
                if (canPickUp) Drop();
                currentItem = hit.transform.gameObject;
                currentItem.GetComponent<Rigidbody>().isKinematic = true;
                currentItem.transform.parent = transform;
                currentItem.transform.localPosition = new Vector3(0, 1, 1.2f);
                currentItem.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                canPickUp = true;
            }
            print(hit.transform.gameObject);
        }
    }

    void Drop()
    {
        currentItem.transform.parent = null;
        currentItem.GetComponent<Rigidbody>().isKinematic = false;
        canPickUp = false;
        currentItem = null;
    }
}
