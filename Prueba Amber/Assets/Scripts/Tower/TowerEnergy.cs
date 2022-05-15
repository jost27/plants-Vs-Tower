using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEnergy : GeneralTower
{

    [SerializeField] STower Tower;

    ShopTowers shop;
    bool firsttime;
    public override void Die()
    {
        transform.parent.GetComponent<PlaceHolder>().ShowPlaceHolder();
        Destroy(this.gameObject);
    }

    public override void Shoot()
    {
        if(firsttime)
        {
            firsttime = false;
            return;
        }
        shop.Addsuncoins((int)Damage);
    }



    // Start is called before the first frame update
    void Start()
    {
        shop = FindObjectOfType<ShopTowers>();

        firsttime = true;
        Begin(Tower);
        
    }

    private void LateUpdate()
    {
        CanShoot();
    }
  

}
