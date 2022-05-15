using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewTower", menuName = "ScriptableObjects/Towers", order = 1)]
public class STower : ScriptableObject
{
    [Header("Tower Info")]
    public string TowerName;
    public float Life;
    public float Damage;
    public int SunCoinsCost;
    [Tooltip("Time to shoot in seconds")]
    public float Cadence;
    [Range(3,15)]
    public float MaxRangeShoot;
    [Header("UI")]

    public Sprite cardImage;

    [Header("Tower")]

    public GameObject TowerPrefab;

   
}
