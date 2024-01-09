using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [SerializeField] private List<GameObject> slicedItems;

    public List<GameObject> GetSlicedItems()
    {
        return slicedItems;
    }
}
