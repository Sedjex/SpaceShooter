using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBG : MonoBehaviour
{
    // vertical sprite size in pixels
    // for the clear operation, height of the sprite must be bigger then height of the camera
    // you can use the Box collider 2D to measure the height of the sprite

    public float VerticalSize;

    // sprite up offset 
    private Vector2 _offsetUp;

    private void Update()
    {
        // if the sprite lower its height
        if (transform.position.y < -VerticalSize)
        {
            RepeatBackground();
        }
    }

    // method RepeatBackground
    // moves two sprites one after other for endless background
    void RepeatBackground()
    {
        // set the offset twice the height of the sprite
        _offsetUp = new Vector2(0, VerticalSize * 2f);
        // set a new position for the sprite
        transform.position = (Vector2)transform.position + _offsetUp;
    }
}
