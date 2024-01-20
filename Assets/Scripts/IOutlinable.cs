using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOutlinable
{
    Outline outline { get; }
    [SerializeField] Color defaultColorImpl { get; }
    [SerializeField] Color interactColorImpl { get; }

    void SetColorForOutline(Color color)
    {
        outline.OutlineColor = color;
    }
}
