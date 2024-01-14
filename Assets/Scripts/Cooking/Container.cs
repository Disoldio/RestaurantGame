using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public GameObject item;

    public GameObject GetItemFromContainer()
    {
        GameObject currentItem = Instantiate(item);
        return currentItem;
    }
}
