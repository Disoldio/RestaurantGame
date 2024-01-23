using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan : IOutlinableImpl, PreparingTool<CookableIngredient>
{
    private GameObject currentItem;
    private CookableIngredient currentIngredient;
    private float currentCookingTime = 0f;
    private PlayerInteractive player;
    public List<GameObject> MakeItemsFromIngredient(CookableIngredient ingredient)
    {
        List<GameObject> createdItems = new List<GameObject>();
        foreach (GameObject item in ingredient.GetCookedIngredients())
        {
            currentItem = Instantiate(item.gameObject);
            currentItem.transform.parent = transform;
            currentItem.transform.localPosition = Vector3.zero;
            currentItem.GetComponent<Collider>().enabled = false;
            currentItem.GetComponent<Rigidbody>().isKinematic = true;
        }
        return createdItems;
    }    
    public bool HasItem()
    {
        return currentItem != null;
    }
    public bool HasIngredient()
    {
        return currentIngredient != null;
    }
    public GameObject GetItem()
    {
        return currentItem.gameObject;
    }
    public void OnItemPlace(CookableIngredient ingredient, PlayerInteractive player)
    {
        StartCookingIngredient(ingredient, player);
        currentIngredient.GetComponent<Collider>().enabled = false;
        currentIngredient.GetComponent<Rigidbody>().isKinematic = true;
    }    
    public void OnItemRemove()
    {
        currentItem = null;
    }
    public void StartCookingIngredient(CookableIngredient ingredient, PlayerInteractive player)
    {
        currentIngredient = ingredient;
        currentIngredient.transform.parent = transform;
        currentIngredient.transform.localPosition = Vector3.zero;
        player.enabled = false;
        player.GetComponent<PlayerController>().enabled = false;
        this.player = player;
        print($"Started preparing {ingredient}");
    }
    void Update()
    {
        if (currentIngredient != null)
        {
            float cookingTime = currentIngredient.getPreparingTime();
            if (currentCookingTime >= cookingTime)
            {
                print($"{currentIngredient} is ready!");
                MakeItemsFromIngredient(currentIngredient);
                Destroy(currentIngredient.gameObject);
                currentIngredient = null;
                player.enabled = true;
                player.GetComponent<PlayerController>().enabled = true;
                currentCookingTime = 0f;

                return;
            }
            currentCookingTime += Time.deltaTime;
        }
    }
}
