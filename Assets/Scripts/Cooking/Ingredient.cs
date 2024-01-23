using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : IOutlinableImpl
{
    [SerializeField] private List<GameObject> preparedIngredientPrefabs;
    [SerializeField] private float preparingTime = 5f;

    protected List<GameObject> GetPreparedIngredients()
    {
        return preparedIngredientPrefabs;
    }

    public float getPreparingTime()
    {
        return preparingTime;
    }
}
