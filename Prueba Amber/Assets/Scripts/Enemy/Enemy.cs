using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    
    // enemy
    public float Life { get; set; }
    public float Damage { get; set; }


    public float Speed { get; set; }
    public float Cadence { get; set; }

    [HideInInspector]
    public Animator animator;

    public bool canWalk,die;

    // tower
    //[HideInInspector]
    public GeneralTower towerTarget; // attack this tower

    bool canAttack =true;
    

    #region Virtual Methods

    public virtual void Begin(SEnemy enemy)
    {
        Life = enemy.Life;
        Damage = enemy.Damage;
        Cadence = enemy.Cadence;
        Speed = enemy.Speed;
        canAttack = true;
    }
    public virtual void CanAttack()
    {
        if (canAttack)
        {
            StartCoroutine(Attacktime(Cadence));
        }
    }
    public virtual void GetDamage(float getdamage)
    {
        Life -= getdamage;
        if (Life <= 0)
            Die();
    }
    public virtual void Attack()
    {
        if (towerTarget == null)
            return;
        animator.SetFloat("Blend", 1); // value blend  walk=0, idle=0.5, attack=1
        towerTarget.GetDamage(Damage);
    }
    public virtual void Walking()
    {
        animator.SetFloat("Blend", 0);
       
    }
    public virtual void Die() 
    {
        animator.SetBool("Die", true);
        FindObjectOfType<GameManager>().UpdateZombies();
        die = true;

    }

    #endregion


    #region private Methods
    public IEnumerator Attacktime(float cadence)
    {

        canAttack = false;
        Attack();
        yield return new WaitForSeconds(cadence);
        canAttack = true;
    }
    #endregion
}
