using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : BaseEntity
{
    public GameObject item;

    public override GameObject GetItemFromContainer()
    {
        GameObject currentItem = Instantiate(item);
        return currentItem;
    }

    public override GameObject GetItemFromContainer(Ingredient ingredient)
    {
        return null;
    }
}
