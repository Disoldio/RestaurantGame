using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public List<GameObject> plate;
    private GameObject placement;

    public void SetPlacement(GameObject newPlacement)
    {
        placement = newPlacement;
    }

    public GameObject GetPlacement()
    {
        return placement;
    }

    public void Use()
    {
        print("“¿–≈À‹ ¿");
    }
}
