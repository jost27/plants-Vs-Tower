using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRocket : GeneralTower
{
    [SerializeField] STower Tower;
    [SerializeField] Transform Cannon;
    [SerializeField] GameObject EnemyTarget;
    [SerializeField] LayerMask layer;

    RaycastHit hit;
    public override void Die()
    {
        transform.parent.GetComponent<PlaceHolder>().ShowPlaceHolder();
        Destroy(this.gameObject);
    }

    public override void Shoot()// misil object pooled
    {
        GameObject bullet =ObjectPooling.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = Cannon.position;
            bullet.transform.rotation = Cannon.rotation;
            bullet.GetComponent<Bullet>().GetTarget(hit.transform,Damage);
            bullet.SetActive(true);
        }
              
    }



    // Start is called before the first frame update
    void Start()
    {
        Begin(Tower);
    }

    private void Update()
    {

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(Cannon.position, transform.TransformDirection(Vector3.forward), out hit, MaxRange, layer))
        {
            EnemyTarget = hit.transform.gameObject;
            CanShoot();
        }
        else
        {
            Debug.DrawRay(Cannon.position, transform.TransformDirection(Vector3.forward) * MaxRange, Color.yellow);
        }

    }
}
