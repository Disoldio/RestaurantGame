using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreparedIngredient : MonoBehaviour, IOutlinable
{
    [SerializeField] private IngredientOrder order = IngredientOrder.DEFAULT;
    [SerializeField] private float yUp = 0.1f;
    [SerializeField] private float yDown = 0.1f;
    [SerializeField] private Color defaultColor = Color.black;
    [SerializeField] private Color interactColor = Color.cyan;
    public Outline outline => GetComponent<Outline>();

    public Color defaultColorImpl => defaultColor;

    public Color interactColorImpl => interactColor;

    public float getYUp()
    {
        return yUp;
    }
    public float getYDown()
    {
        return yDown;
    }
    public IngredientOrder GetOrder()
    {
        return order;
    }
}
