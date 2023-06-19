using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Static reference to the Player (can be used in other scripts).
    public static Player instance = null;
    // Player health.
    public int player_Health = 1;

    // Reference to the Shield GameObject.
    public GameObject obj_Shield;
    // Shield health.
    public int shield_Health = 1;

    private void Awake()
    {
        // Setting up the references.
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // If the shield has life...
        if (shield_Health != 0)
        {
            //Show shield.
            obj_Shield.SetActive(true);
        }
        // If the shield has no life...
        else
        {
            // Hide shield.
            obj_Shield.SetActive(false);
        }
    }

    // Method of taking damage by the shield
    public void GetDamageShield(int damage)
    {
        // Reduce the shield health by the damage amount.
        shield_Health -= damage;

        // If the shield does not have a health...
        if (shield_Health <= 0)
        {
            // Hide shield.
            obj_Shield.SetActive(false);
        }
    }

    // Method of taking damage by the player
    public void GetDamage(int damage)
    {
        // Reduce the health by the damage amount.
        player_Health -= damage;

        // If the player does not have a health...
        if (player_Health <= 0)
        {
            // Call the player destruction method
            Destruction();
        }
    }
    // Method destruction player.
    void Destruction()
    {
        // Destroy the current player object.
        Destroy(gameObject);
    }
}
