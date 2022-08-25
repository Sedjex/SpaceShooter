using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //enemy health
    public int EnemyHealth;
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
