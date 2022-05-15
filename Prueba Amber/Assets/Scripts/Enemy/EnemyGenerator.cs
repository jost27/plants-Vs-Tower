using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public SEnemy[] enemies;
  
    [SerializeField] float timebetweenWaves = 5f;

    [Tooltip ("enemies spawn per wave")]
    public int enemyInstances;

    [SerializeField] Transform spawnEnemy;

    public Transform parentEnemy;

    Transform[] spawnsEnemies;
    float coundown = 2f;
    int enemiesSpawned = 0;
    GameObject pivot;
    // Start is called before the first frame update
    void Start()
    {
        spawnsEnemies = new Transform[spawnEnemy.transform.childCount ];
        for (int i = 0; i < spawnEnemy.transform.childCount; i++)
        {
            spawnsEnemies[i] = spawnEnemy.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyInstances <= enemiesSpawned)
            return;
        if (coundown <= 0f)
        {
            SpawnEnemy();
            coundown =Random.Range( 0,timebetweenWaves);
        }
        coundown -= Time.deltaTime;
    }
    void SpawnEnemy()
    {
        int way = Random.Range(0, spawnsEnemies.Length );
        int typeEnemy = Random.Range(0, enemies.Length);
        Debug.Log("tipes number: "+enemies.Length);
        pivot = Instantiate(enemies[typeEnemy].EnemyPrefab);
        pivot.transform.SetParent(parentEnemy);
        pivot.transform.position = spawnsEnemies[way].position;
        pivot.transform.rotation =Quaternion.Euler(0f,90,0f);
        enemiesSpawned++;
    }
}
