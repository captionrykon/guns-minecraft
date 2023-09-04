using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollider : MonoBehaviour
{
    public float moveSpeed, lifeTime;

    public Rigidbody theRB;

    public GameObject impactEffect;
    public GameObject BloodEffect;

    public int damage = 1;

    public bool damageEnemy, damagePlayer;



    void Update()
    {
        theRB.velocity = transform.forward * moveSpeed;

        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }



    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy" )
        {
           

            CharacterStats enemyStates = other.gameObject.GetComponent<CharacterStats>();

            enemyStates.TakeDamage(damage);
            Instantiate(BloodEffect, transform.position + (transform.forward * (-moveSpeed * Time.deltaTime)), transform.rotation);
            //other.gameObject.GetComponent<EnemyHealthController>().DamageEnemy(damage);
            //other.gameObject.GetComponent<EnemyHealthController>().DamageEnemy(damage);
            Destroy(gameObject);
        }
        else
        {
            Instantiate(impactEffect, transform.position + (transform.forward * (-moveSpeed * Time.deltaTime)), transform.rotation);
            Destroy(gameObject);
            
        }

       
      

       
    }
}
