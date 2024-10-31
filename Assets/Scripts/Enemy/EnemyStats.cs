using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObject enemyData;

    float currentMoveSpeed;
    float currentHealth;
    float currentDamage;
    

    // Awake calls before start and is more reliable
    void Awake()
    {
        currentMoveSpeed = enemyData.MoveSpeed;
        currentHealth = enemyData.MaxHealth;
        currentDamage = enemyData.Damage;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Kill(); //kills the enemy if their current health is less than or equal to 0, kill() is called when enemy meets the certain requirements
        }
    }
    public void Kill()
    {
        Destroy(gameObject); //destroys the enemy 
    }
}
