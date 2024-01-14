using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreparedIngredient : MonoBehaviour
{
    [SerializeField] private IngredientOrder order = IngredientOrder.DEFAULT;
    [SerializeField] private float yUp = 0.1f;
    [SerializeField] private float yDown = 0.1f;
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
