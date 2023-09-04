using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStates : CharacterStats
{
    public PlayerHUD HUD;

    private void Start()
    {
        Getreferences();
        IntVariable();
    }
    private void Getreferences()
    {
        HUD = GetComponent<PlayerHUD>();
    }
    public override void CheckHealth()
    {
        base.CheckHealth();
        HUD.UpdateHealth(health, maxHealth);
    }
    private void Update()
    {
        if (health <= 0)
        {
            health = 0;
            isDead = true;

        }

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "enemyBullet")
        {
            TakeDamage(1);
        }
    }
}
