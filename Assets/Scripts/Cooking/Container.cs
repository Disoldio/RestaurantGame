using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour, IOutlinable
{
    public GameObject item;

    [SerializeField] private Color defaultColor = Color.black;
    [SerializeField] private Color interactColor = Color.cyan;
    public Outline outline => GetComponent<Outline>();

    public Color defaultColorImpl => defaultColor;

    public Color interactColorImpl => interactColor;

    public GameObject GetItemFromContainer()
    {
        GameObject currentItem = Instantiate(item);
        return currentItem;
    }
}
