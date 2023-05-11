using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAll : MonoBehaviour
{
    //ref to the BoxCollider2D component
    private BoxCollider2D _boundareCollider;
    //vector for the sawing sizes Camera
    private Vector2 _viewportSize;

    private void Awake()
    {
        //setting up the references
        //in the current object find BoxCollider2D component
        _boundareCollider = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        //call the method ResizeCollider
        ResizeCollider();
    }

    void ResizeCollider()
    {
        //get size of the upper right corner and multiply it by 2
        _viewportSize = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)) * 2;
        //increase the width by 1.5
        _viewportSize.x *= 1.5f;
        //increase the height by 1.5
        _viewportSize.y *= 1.5f;
        //change the size
        _boundareCollider.size = _viewportSize;
    }

    public void OnTriggerExit2D(Collider2D coll)
    {
        //destroy the collider if it has a tag ..
        switch (coll.tag)
        {
            case "Planet":
                Destroy(coll.gameObject);
                break;
            case "Bullet":
                Destroy(coll.gameObject);
                break;
        }
    }

}
