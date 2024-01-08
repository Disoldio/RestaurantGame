using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEntity : MonoBehaviour
{
    public abstract GameObject GetItemFromContainer();
    public abstract GameObject GetItemFromContainer(Ingredient ingredient);
}
