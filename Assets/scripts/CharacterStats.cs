 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterStats : MonoBehaviour
{
     public int health;
     public int maxHealth;
     public bool isDead;

    public static event Action onPlayerdamage;
    public static event Action onPlayerDeath;
    private void Start()
    {
        IntVariable();
    }

    public virtual void CheckHealth()
    {
       
        if(health >= maxHealth)
        {
            health = maxHealth;
        }
    }
    
    public virtual void die()
    {
        isDead = true;
        onPlayerDeath?.Invoke();
    }

    public void setHealthto(int healthToSetTo)
    {
        health = healthToSetTo;
        CheckHealth();
    }

    public void TakeDamage(int damage)
    {
        int healthAfterDamage = health - damage;
        setHealthto(healthAfterDamage);
        onPlayerdamage?.Invoke();
    }

    public void Heal (int Heal)
    {
        int HealthAfterHeal = health + Heal;
        setHealthto(HealthAfterHeal);
    }

    public bool IsDead()
    {
        return isDead;
    }

    public virtual void IntVariable()
    {
        maxHealth = 10;
        setHealthto(maxHealth);
        isDead = false;
    }
}
