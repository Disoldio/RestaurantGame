using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOutlinable
{
    Outline outline { get; }
    Color defaultColorImpl { get; }
    Color interactColorImpl { get; }

    public void SetColorForOutline(Color color)
    {
        outline.OutlineColor = color;
    }
}
