using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceHolder : MonoBehaviour
{
    [HideInInspector]
    public STower sTower;

    public bool IsEmpty { get; set; } = true;

    GameObject tower;
  
    public void CreateTower(STower nTower)
    {
        tower= Instantiate(nTower.TowerPrefab,transform.position,Quaternion.Euler(0f,270f,0f));// Rotation Correction
        tower.transform.SetParent(transform); // set after to get the same aspect
        sTower = nTower;
        IsEmpty = false;
        HidePlaceHolder();
    }

    void HidePlaceHolder()
    {
        GetComponent<MeshRenderer>().enabled = IsEmpty;

    }
    public void ShowPlaceHolder()
    {
        IsEmpty = true;
        GetComponent<MeshRenderer>().enabled = IsEmpty;
    }
}
