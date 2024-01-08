using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoard : BaseEntity
{

    public override GameObject GetItemFromContainer()
    {
        return null;
    }

    public override GameObject GetItemFromContainer(Ingredient ingredient)
    {
        GameObject currentItem = Instantiate(ingredient.GetSlicedItem());
        print("–¿¡Œ“¿≈“");
        return currentItem;
    }
}
