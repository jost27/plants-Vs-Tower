using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCraw : Enemy
{
    [SerializeField] SEnemy enemy;
    CapsuleCollider enemyCol;
    
   
    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        enemyCol = gameObject.GetComponent<CapsuleCollider>();
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
            enemyCol.height = 0.1f;
            enemyCol.center = Vector3.zero;

        }
        else
        {
            enemyCol.height = 1.9f;
            enemyCol.center = Vector3.up;
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

    public override void Attack()
    {
        
        Debug.Log("attack");
        base.Attack();

    }

    public override void Die()
    {
        base.Die();
        gameObject.GetComponent<Collider>().enabled = false;
        
        Destroy(this.gameObject, 4);
    }
}
