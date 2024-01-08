using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoard : MonoBehaviour
{
    public List<GameObject> GetItemsFromIngredient(Ingredient ingredient)
    {
        List<GameObject> createdItems = new List<GameObject>();
        Vector3 ingredientPos = ingredient.transform.position;
        foreach (GameObject item in ingredient.GetSlicedItems())
        {
            GameObject currentItem = Instantiate(item);
            currentItem.transform.position = ingredientPos;
            createdItems.Add(currentItem);
        }
        return createdItems;
    }
}
