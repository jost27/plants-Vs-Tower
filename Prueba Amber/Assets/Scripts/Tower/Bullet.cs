using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    // misil bullet for tower rocket
     Transform target;
    float damage;

    public float speed = 20f;
    [SerializeField] LayerMask layer;
    Collider[] hitColliders;
    public void GetTarget(Transform _target, float _damage)
    {
        target = _target;
        damage = _damage;
    }
   

    //move Proyectile  to the target
    void Update()
    {
        if (target == null)// if target die before misil explotion
        {
            gameObject.SetActive(false);
            return;
        }

       
        float distanceperframe = speed * Time.deltaTime;
        Vector2 misilpos = Vector2.up * transform.position.z + Vector2.right * transform.position.x;
        Vector2 targetpos= Vector2.up * target.transform.position.z + Vector2.right * target.transform.position.x;
        float distnace = Vector2.Distance(misilpos,targetpos );
      
        if(Mathf.Abs(distnace)<1.5f)
        {

            HitTarget();
            return;
        }
        transform.Translate(Vector3.right*-1 * distanceperframe,Space.World);
        hitColliders = Physics.OverlapSphere(gameObject.transform.position, 3,layer);
    }

    void HitTarget()
    {
       
        ExplosionDamage();
        gameObject.SetActive(false);
        target = null;
    }

    void ExplosionDamage()
    {
        
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider == null)
                continue;
            
            if(hitCollider.GetComponent<Enemy>()!=null)
                hitCollider.GetComponent<Enemy>().GetDamage(damage);
        }
    }
}
