using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage;
    //it's bullet of enemy or player
    public bool IsEnemyBullet;

    // method of distruction bullet
    private void Destruction()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        //if the bullet enemys
        if (IsEnemyBullet && coll.tag == "Player")
        {
            Player.instance.GetDamage(Damage);
            Destruction();
        }

        //it the players bullet
        else if (!IsEnemyBullet && coll.tag == "Enemy")
        {
            coll.GetComponent<Enemy>().GetDamage(Damage);
            Destruction();
        }
    }
}
