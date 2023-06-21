using System.Collections;
using UnityEngine;

[System.Serializable]
public class EnemyWaves
{
    // Time when the wave will appear on the stage
    public float timeToStart;
    // The Enemy Wave prefab to be spawned.
    public GameObject wave;
    // This wave after which the game will end.
    public bool is_Last_Wave;
}

public class LevelController : MonoBehaviour
{
    // Static reference to the LevelController (can be used in other scripts).
    public static LevelController instance;
    //Array of player ships
    public GameObject[] playerShip;
    // Reference to the EnemyWaves.
    public EnemyWaves[] enemyWaves;
    // Finish the game or not
    private bool is_Final = false;

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
        // Create all enemy waves...
        for (int i = 0; i < enemyWaves.Length; i++)
        {
            // Start CreateEnemyWave as a coroutine.
            StartCoroutine(CreateEnemyWave(enemyWaves[i].timeToStart, enemyWaves[i].wave, enemyWaves[i].is_Last_Wave));
        }
    }

    private void Update()
    {

        // If is_Final = true, there are no objects with the Enemy tag left...
        if (is_Final == true && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            // You win game!
            Debug.Log("Win");
        }
        if (Player.instance == null)
        {
            // You lose game!
            Debug.Log("Lose");
        }
    }
    IEnumerator CreateEnemyWave(float delay, GameObject Wave, bool Final)
    {
        // if creation wave time ! = 0 and player is alive ...create a wave
        if (delay != 0)
            yield return new WaitForSeconds(delay);
        if (Player.instance != null)
            Instantiate(Wave);
        // If this wave is the last...
        if (Final == true)
            is_Final = true;
    }
}