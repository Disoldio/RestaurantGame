using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    private GameObject placement;
    private GameObject lastItem;
    private float currentYDelta;

    public void SetPlacement(GameObject newPlacement)
    {
        placement = newPlacement;
    }

    public GameObject GetPlacement()
    {
        return placement;
    }

    public GameObject GetLastItem()
    {
        return lastItem;
    }

    public void PutItem(GameObject item)
    {
        print("Placing item on plate from plate");

        float nextYDelta = item.GetComponent<PreparedIngredient>().getYUp() - item.GetComponent<PreparedIngredient>().getYDown();

        item.transform.parent = transform;
        item.transform.position = transform.position + new Vector3(0, currentYDelta, 0);
        item.GetComponent<Collider>().enabled = false;
        item.GetComponent<Rigidbody>().isKinematic = true;

        lastItem = item;
        currentYDelta += nextYDelta;
    }
}
