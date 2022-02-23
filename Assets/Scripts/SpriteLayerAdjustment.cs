using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLayerAdjustment : MonoBehaviour
{
    public bool keepUpdating;
    public SpriteRenderer renderer;
    void Start()
    {
        UpdateSpriteLayer();
    }

    // Update is called once per frame
    void Update()
    {
        if(keepUpdating)
        {
            UpdateSpriteLayer();
        }
    }

    void UpdateSpriteLayer()
    {
        float pos = transform.position.y;
        renderer.sortingOrder = -(int)(pos * 16);
    }
}
