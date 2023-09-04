using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStates : CharacterStats
{
    [SerializeField] private int damage;
    public float attackSpeed;
    [SerializeField] private bool canAttack;
    public GameObject DieExplosion;
    public Transform dieExplosionTransform;

    private void Start()
    {
        IntVariable();
    }

    public void DealDamage(CharacterStats statestodamage)
    {
        statestodamage.TakeDamage(damage);
      //  FindObjectOfType<audioManager>().play("playerhit");
    }
    public override void die()
    {
        base.die();

    }
    public override void IntVariable()
    { 
        maxHealth = 10;
        setHealthto(maxHealth);
        isDead = false;
        


        damage = 1;
        attackSpeed = 2f;
        canAttack = true;
    }
    private void Update()
    {
        if (health <= 0)
        {
            health = 0;
            isDead = true;
            Destroy(gameObject, 0.2f);
            GameObject afterdeth = Instantiate(DieExplosion, dieExplosionTransform.transform.position, Quaternion.identity);
            Destroy(afterdeth, 2f);
        }
    }
    
}
