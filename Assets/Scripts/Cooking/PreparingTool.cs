using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PreparingTool<T> where T : Ingredient
{
    List<GameObject> MakeItemsFromIngredient(T ingredient);
}
