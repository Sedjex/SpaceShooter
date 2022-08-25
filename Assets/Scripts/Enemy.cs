using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //enemy health
    public int EnemyHealth;

    [Space]
    // bullet prefab to be spawned
    public GameObject ObjBullet;
    //interval within which the shot occurs
    public float ShotTimeMin, ShotTimeMax;
    //the probability of the shot
    public int ShotChance;

    private void Start()
    {
        Invoke("OpenFire", Random.Range(ShotTimeMin, ShotTimeMax));
    }

    private void OpenFire()
    {
        if (Random.value < (float)ShotChance / 100)
        {
            //create an instance of bullet in the enemy position
            Instantiate(ObjBullet, transform.position, Quaternion.identity);
        }
    }

    //taking damage
    public void GetDamage(int damage)
    {
        EnemyHealth -= damage;
        if (EnemyHealth <= 0)
        {
            Destruction();
        }
    }

    private void Destruction()
    {
        Destroy(gameObject);
    }

    //if eneme collides player - gets the damage
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            GetDamage(1);
            Player.instance.GetDamage(1);
        }
    }
}
