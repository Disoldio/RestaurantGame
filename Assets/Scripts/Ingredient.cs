using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [SerializeField] private GameObject slicedItem;

    public GameObject GetSlicedItem()
    {
        return slicedItem;
    }
}
