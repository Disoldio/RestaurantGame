using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookableIngredient : Ingredient, IOutlinable
{
    public List<GameObject> GetCookedIngredients()
    {
        return GetPreparedIngredients();
    }
}
