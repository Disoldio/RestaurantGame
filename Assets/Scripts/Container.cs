using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public GameObject item;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetItemFromContainer()
    {
        GameObject currentItem = Instantiate(item);
        print("this used");
        return currentItem;
    }
}
