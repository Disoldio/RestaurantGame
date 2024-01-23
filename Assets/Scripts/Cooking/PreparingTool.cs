using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PreparingTool<T> where T : Ingredient
{
    T currentIngredientImpl { get; set; }
    float currentCookingTimeImpl { get; set; }
    PlayerInteractive playerImpl {  get; set; }
    List<GameObject> MakeItemsFromIngredient(T ingredient);
    abstract void OnIngredientReady(T ingredient);
}
