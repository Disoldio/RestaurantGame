using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : IOutlinableImpl
{
    public GameObject item;

    public GameObject GetItemFromContainer()
    {
        GameObject currentItem = Instantiate(item);
        return currentItem;
    }
}
