using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class   GeneralTower : MonoBehaviour
{
    public float Life { get; set; }
    public float Damage { get; set;}



    public float Cadence { get; set; }
    public float MaxRange { get; set; }



    bool canShoot;



    #region  Abstract Methods

    public abstract void Shoot();
    public abstract void Die();
    #endregion

    #region Virtual Methods

    public virtual void Begin(STower tower)
    {
        Life = tower.Life;
        Damage = tower.Damage;
        Cadence = tower.Cadence;
        MaxRange = tower.MaxRangeShoot;
        canShoot = true;
    }
    public virtual void CanShoot()
    {
        
        if (canShoot )
        {
            StartCoroutine(ShootWithCadence(Cadence));
        }
    }
    public  virtual void GetDamage(float getdamage)
    {
        Life -= getdamage;
        if (Life <= 0)
            Die();
    }
    #endregion


    #region private Methods
    public IEnumerator ShootWithCadence(float cadence)
    {

        canShoot = false;
        Shoot();
        yield return new WaitForSeconds(cadence);
        canShoot = true;
    }
    #endregion
}
