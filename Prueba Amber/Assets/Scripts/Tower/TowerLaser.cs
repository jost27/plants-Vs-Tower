using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLaser : GeneralTower
{

    [SerializeField] STower Tower;
    [SerializeField] Transform lasershot;
    [SerializeField] LayerMask layer;
    LineRenderer line;
    RaycastHit hit;
    public override void Die()
    {
        transform.parent.GetComponent<PlaceHolder>().ShowPlaceHolder();
        Destroy(this.gameObject);
    }

    public override void Shoot()
    {
        line.enabled = true;
        line.SetPosition(0, lasershot.transform.position);
        line.SetPosition(1, hit.point);
        Invoke("OffLaser", 0.5f);
        hit.transform.GetComponent<Enemy>().GetDamage(Damage);
        
    }

    void OffLaser()
    {
        line.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        Begin(Tower);
        line = GetComponent<LineRenderer>();
    }
    private void Update()
    {
        
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(lasershot.transform.position, transform.TransformDirection(Vector3.forward), out hit, MaxRange, layer))
        {
            Debug.DrawRay(lasershot.transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            
            CanShoot();
        }
     
    }
}








