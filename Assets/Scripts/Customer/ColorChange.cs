using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    [SerializeField] Texture texture;
    [SerializeField] List<GameObject> exception;
    [SerializeField] List<Color> colorList;
    void Start()
    {
        SwitchShader();
    }

    void SwitchShader()
    {
        Color currentColor = colorList[Random.Range(0, colorList.Count)];
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<Renderer>() && !exception.Contains(transform.GetChild(i).gameObject))
            {
                Renderer rend = transform.GetChild(i).GetComponent<Renderer>();
                rend.material.color = currentColor;
                rend.material.mainTexture = texture;
                print(transform.GetChild(i));
            }
        }
    }
}
