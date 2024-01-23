using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PreparingToolImpl<T> : IOutlinableImpl, PreparingTool<T> where T : Ingredient
{
    protected T currentIngredient;
    protected float currentCookingTime;
    protected PlayerInteractive player;
    public T currentIngredientImpl { get => currentIngredient; set => currentIngredient = value; }
    public float currentCookingTimeImpl { get => currentCookingTime; set => currentCookingTime = value; }
    public PlayerInteractive playerImpl { get => player; set => player = value; }

    public abstract List<GameObject> MakeItemsFromIngredient(T ingredient);

    public abstract void OnIngredientReady(T ingredient);
    void Update()
    {
        if (currentIngredientImpl != null)
        {
            float cookingTime = currentIngredientImpl.getPreparingTime();
            if (currentCookingTimeImpl >= cookingTime)
            {
                OnIngredientReady(currentIngredient);

                return;
            }
            currentCookingTimeImpl += Time.deltaTime;
        }
    }
}
