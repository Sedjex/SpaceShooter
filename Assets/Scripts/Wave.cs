using System.Collections;
using UnityEngine;

[System.Serializable]
public class ShootSetting
{
    [Range(0, 100)]
    public int ShotChance;
    public float ShotTimeMin, ShotTimeMax;
}

public class Wave : MonoBehaviour
{
    public ShootSetting shootSetting;
    [Space]


    public GameObject ObjEnemy;
    public int CountInWave;
    public float SpeedEnemy;
    public float TimeSpawn;
    public Transform[] PathPoints;

    public bool IsReturn;
    [Header("Teast wave")]
    public bool IsTestWave;

    private FollowThePath FollowComponent;

    private Enemy enemyComponentScript; 

    private void Start()
    {
        StartCoroutine(CreateEnemyWave());
    }

    IEnumerator CreateEnemyWave()
    {
        for (int i = 0;i<CountInWave; i++)
        {
            GameObject newEnemy = Instantiate(ObjEnemy, ObjEnemy.transform.position, Quaternion.identity);

            FollowComponent = newEnemy.GetComponent<FollowThePath>();
            FollowComponent.PathPoints = PathPoints;
            FollowComponent.SpeedEnemy = SpeedEnemy;
            FollowComponent.IsReturn = IsReturn;

            enemyComponentScript = newEnemy.GetComponent<Enemy>();
            enemyComponentScript.shot_Chance = shootSetting.ShotChance;

            enemyComponentScript.shot_Time_Min = shootSetting.ShotTimeMin;
            enemyComponentScript.shot_Time_Max = shootSetting.ShotTimeMax;

            newEnemy.SetActive(true);

            yield return new WaitForSeconds(TimeSpawn);
        }

       if(IsTestWave)
        {
            yield return new WaitForSeconds(5f);
            StartCoroutine(CreateEnemyWave());
        }

       if(!IsReturn)
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        NewPositionByPath(PathPoints);
    }

    void NewPositionByPath(Transform[] path)
    {
        Vector3[] pathPositions = new Vector3[path.Length];
        for (int i = 0; i < path.Length; i++)
        {
            pathPositions[i] = path[i].position;
        }

        //pathPositions = Smoothing(pathPositions);
        //pathPositions = Smoothing(pathPositions);

        for (int i = 0; i < pathPositions.Length; i++)
        {
            Gizmos.DrawLine(pathPositions[i], pathPositions[i + 1]);
        }
    }

    //Vector3[] Smoothing(Vector3[] pathPositions)
    //{
    //    Vector3[] newPathPosition = new Vector3[(pathPositions.Length - 2) * 2 + 2];
    //    newPathPosition[0] = pathPositions[0];
    //    newPathPosition[newPathPosition.Length - 1] = pathPositions[pathPositions.Length - 1];
    //    int j = 1;
    //    for (int i = 0; i < pathPositions.Length -2; i++)
    //    {
    //        newPathPosition[j] = pathPositions[i] + (pathPositions[i + 1] - pathPositions[i]) * 0.75f;

    //        pathPositions[j + 1] = pathPositions[i + 1] + (pathPositions[i + 2] - pathPositions[i + 1]) * 0.25f;
    //        j += 2;
    //    }
    //    return newPathPosition;
    //}
}
