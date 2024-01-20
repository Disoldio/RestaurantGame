using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttableIngredient : Ingredient, IOutlinable
{
    public List<GameObject> GetSlicedIngredients()
    {
        return GetPreparedIngredients();
    } 
}
