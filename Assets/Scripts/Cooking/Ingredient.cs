using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour, IOutlinable
{
    [SerializeField] private List<GameObject> preparedIngredientPrefabs;

    [SerializeField] private Color defaultColor = Color.black;
    [SerializeField] private Color interactColor = Color.cyan;
    public Outline outline => GetComponent<Outline>();

    public Color defaultColorImpl => defaultColor;

    public Color interactColorImpl => interactColor;

    protected List<GameObject> GetPreparedIngredients()
    {
        return preparedIngredientPrefabs;
    }
}
