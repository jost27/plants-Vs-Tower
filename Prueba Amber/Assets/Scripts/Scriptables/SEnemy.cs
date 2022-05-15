using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewEnemy", menuName = "ScriptableObjects/Enemy" , order = 1)]

public class SEnemy : ScriptableObject
{
    public string EnemyName;
    public float Life;
    public float Damage;
    public float Speed;

    [Tooltip("Time to shoot in seconds")]
    public float Cadence;

    [Header("Enemy")]

    public GameObject EnemyPrefab;

}
