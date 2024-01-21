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
        for (int i = 0; i < outline.transform.childCount; i++)
        {
            if (outline.transform.GetChild(i).GetComponent<IOutlinableImpl>())
                outline.transform.GetChild(i).GetComponent<IOutlinable>().SetColorForOutline(color);
        }
    }
}
