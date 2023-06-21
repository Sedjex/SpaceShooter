using UnityEngine;

public class ObjMoving : MonoBehaviour
{
    // speed objects moves
    public float Speed;

    private void Update()
    {
        // move the object vertically with a given speed
        transform.Translate(Vector3.up * Speed * Time.deltaTime);
    }
}
