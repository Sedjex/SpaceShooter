using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    //static reference to PlayerMoving
    public static PlayerMoving instance;
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

    private void Update()
    {
        // if the mouse button is down

        if (Input.GetMouseButton(0))
        {
            //get 2D coordinates click on screen
            _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            //move player to coordinates click at given speed
            transform.position = Vector2.MoveTowards(transform.position, _mousePosition, SpeedPlayer * Time.deltaTime);
        }
    }
}
