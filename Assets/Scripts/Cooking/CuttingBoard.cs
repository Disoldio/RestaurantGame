using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoard : IOutlinableImpl, PreparingTool<CuttableIngredient>
{
    private CuttableIngredient currentIngredient;
    private float currentCookingTime = 0f;
    private PlayerInteractive player;
    public List<GameObject> MakeItemsFromIngredient(CuttableIngredient ingredient)
    {
        currentIngredient = ingredient;

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

    public void StartSlicingIngredient(CuttableIngredient ingredient, PlayerInteractive player)
    {
        currentIngredient = ingredient;
        player.enabled = false;
        player.GetComponent<PlayerController>().enabled = false;
        this.player = player;
        print($"Started preparing {ingredient}");
    }

    void Update()
    {
        if(currentIngredient != null)
        {
            float cookingTime = currentIngredient.getPreparingTime();
            if(currentCookingTime >= cookingTime) {
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
