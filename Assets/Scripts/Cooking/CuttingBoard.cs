using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoard : IOutlinableImpl, PreparingTool<CuttableIngredient>
{
    public List<GameObject> MakeItemsFromIngredient(CuttableIngredient ingredient)
    {
        List<GameObject> createdItems = new List<GameObject>();
        Vector3 ingredientPos = ingredient.transform.position;
        foreach (GameObject item in ingredient.GetSlicedIngredients())
        {
            GameObject currentItem = Instantiate(item);
            currentItem.transform.position = ingredientPos;
            createdItems.Add(currentItem);
        }
        return createdItems;
    }
}
