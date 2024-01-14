using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [SerializeField] private List<GameObject> preparedIngredientPrefabs;

    protected List<GameObject> GetPreparedIngredients()
    {
        return preparedIngredientPrefabs;
    }
}
