using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Borders
{
    // offset from the left border
    public float MinXOffset = 1.1f;
    // offset from the right border
    public float MaxXOffset = 1.1f;
    // offset from the down border
    public float MinYOffset = 1.1f;
    // offset from the down border
    public float MaxYOffset = 1.1f;

    // create boundaries that the player cannot leave
    [HideInInspector]
    public float MinX, MaxX, MinY, MaxY;
}


public class PlayerMoving : MonoBehaviour
{
    //static reference to PlayerMoving
    public static PlayerMoving instance;

    // reference to borders
    public Borders borders;

    // speed of player moving
    public int SpeedPlayer = 5;
    //reference to Camera
    private Camera _camera;
    // saving 2D coordinates of player moving
    private Vector2 _mousePosition;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
        _camera = Camera.main;
    }

    private void Start()
    {
        // call the Borders method
        ResizeBorders();
    }

    private void Update()
    {
        // if the mouse button is down

        if (Input.GetMouseButton(0))
        {
            //get 2D coordinates click on screen
            _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            _mousePosition.y += 1.5f;
            //move player to coordinates click at given speed
            transform.position = Vector2.MoveTowards(transform.position, _mousePosition, SpeedPlayer * Time.deltaTime);
        }

        // if player is trying to go abroad, dont let him
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, borders.MinX, borders.MaxX), Mathf.Clamp(transform.position.y, borders.MinY, borders.MaxY));
    }

    // method resize Borders
    // calculation depends on the size of the camera and the specified offset in the Borders class 
    private void ResizeBorders()
    {
        // border left
        borders.MinX = _camera.ViewportToWorldPoint(Vector2.zero).x + borders.MinXOffset;
        //borders down
        borders.MinY = _camera.ViewportToWorldPoint(Vector2.zero).y + borders.MinYOffset;

        //border right 
        borders.MaxX = _camera.ViewportToWorldPoint(Vector2.right).x - borders.MaxXOffset;
        //borders up
        borders.MaxY = _camera.ViewportToWorldPoint(Vector2.up).y - borders.MaxYOffset;
    }
}
