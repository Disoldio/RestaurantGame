using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan : IOutlinableImpl, PreparingTool<CookableIngredient>
{
    private GameObject currentItem;
    public List<GameObject> MakeItemsFromIngredient(CookableIngredient ingredient)
    {
        List<GameObject> createdItems = new List<GameObject>();
        foreach (GameObject item in ingredient.GetCookedIngredients())
        {
            currentItem = Instantiate(item);
            currentItem.transform.parent = transform;
            currentItem.transform.localPosition = Vector3.zero;
        }
        return createdItems;
    }    
    public GameObject MakeItemFromIngredient(CookableIngredient ingredient)
    {
        MakeItemsFromIngredient(ingredient);
        return currentItem;
    }
    public bool HasItem()
    {
        return currentItem != null;
    }
    public GameObject GetItem()
    {
        return currentItem;
    }
    public void OnItemPlace()
    {
        currentItem.GetComponent<Collider>().enabled = false;
        currentItem.GetComponent<Rigidbody>().isKinematic = true;
    }    
    public void OnItemRemove()
    {
        currentItem = null;
    }
}
