using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //static reference to the Player
    public static Player instance = null;
    //Player health
    public int PlayerHealth = 1;

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
    }
    //method of takin damage by the Player
    public void GetDamage(int damage)
    {
        PlayerHealth -= damage;
        if (PlayerHealth <= 0)
        {
            Destruction();
        }
    }

    void Destruction()
    {
        Destroy(gameObject);
    }

}
