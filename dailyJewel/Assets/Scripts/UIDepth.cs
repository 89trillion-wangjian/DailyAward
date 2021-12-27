using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDepth : MonoBehaviour
{
    public int order;
    public bool isUI = true;

    void Start()
    {
        if (isUI)
        {
            Image render = GetComponentInChildren<Image>();
            var newMaterial = Object.Instantiate(render.material);
            newMaterial.renderQueue = order;
            render.material = newMaterial;
        }
        else
        {
            Renderer[] renders = GetComponentsInChildren<Renderer>();

            foreach (Renderer render in renders)
            {
                var newMaterial = Object.Instantiate(render.material);
                newMaterial.renderQueue = order;
                render.material = newMaterial;
            }
        }
    }
}
