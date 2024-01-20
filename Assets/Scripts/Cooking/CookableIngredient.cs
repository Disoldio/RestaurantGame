using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookableIngredient : Ingredient
{
    public List<GameObject> GetCookedIngredients()
    {
        return GetPreparedIngredients();
    }
}
