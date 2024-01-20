using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttableIngredient : Ingredient
{
    public List<GameObject> GetSlicedIngredients()
    {
        return GetPreparedIngredients();
    } 
}
