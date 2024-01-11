using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    [SerializeField] private List<GameObject> plate;
    [SerializeField] private float yDelta = 0.35f;
    [SerializeField] private float startYDelta = 0.1f;

    private GameObject placement;
    private GameObject lastItem;
    private float currentYDelta;

    private void Start()
    {
        currentYDelta = startYDelta;
    }

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
        item.transform.parent = transform;
        item.transform.position = transform.position + new Vector3(0, currentYDelta, 0);
        item.GetComponent<Collider>().enabled = false;
        item.GetComponent<Rigidbody>().isKinematic = true;
        float nextYDelta = item.GetComponent<PreparedIngredient>().getYUp() - item.GetComponent<PreparedIngredient>().getYDown();

        lastItem = item;
        currentYDelta += nextYDelta;

        print($"Put {item} in {gameObject}");
    }
}
