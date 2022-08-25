using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    //debug all
    public GameObject ObjBullet;
    public float TimeBulletSpawn = 0.3f;
    //timer to shoot
    [HideInInspector]
    public float TimerShot;

    private void Update()
    {
        if (Time.time > TimerShot)
        {
            TimerShot = Time.time + TimeBulletSpawn;
            // create bullet
            Instantiate(ObjBullet, transform.position, Quaternion.identity);
        }
    }
}
