using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IOutlinableImpl : MonoBehaviour, IOutlinable
{
    [SerializeField] protected Color defaultColor = Color.black;
    [SerializeField] protected Color interactColor = Color.cyan;
    public Outline outline => GetComponent<Outline>();

    public Color defaultColorImpl => defaultColor;

    public Color interactColorImpl => interactColor;
}
