using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHat : Enemy
{
    [SerializeField] SEnemy enemy;
    [SerializeField] GameObject hat;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        animator.speed = 0.5f;
        canWalk = true;
        Begin(enemy);
    }

    // Update is called once per frame
    void Update()
    {
        if (die)
            return;
        
        if (canWalk)
        {
            Walking();
            transform.Translate(Vector3.right * Speed * Time.deltaTime, Space.World);
        }
        if (towerTarget == null)
            canWalk = true;

        CanAttack();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<GeneralTower>())
        {
            towerTarget = other.GetComponent<GeneralTower>();
            canWalk = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<GeneralTower>())
        {
            CanAttack();
        }
    }


    /// Enemy

    public override void GetDamage(float getdamage)
    {
        base.GetDamage(getdamage);
        if (Life <= enemy.Life*0.5)
        {
            hat.SetActive(false);
        }
    }
    public override void Attack()
    {
        base.Attack();
    }

    public override void Die()
    {
        base.Die();
        gameObject.GetComponent<Collider>().enabled = false;
        Destroy(this.gameObject, 4);
    }
}
