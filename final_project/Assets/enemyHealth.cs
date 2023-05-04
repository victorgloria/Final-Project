using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public GameObject coin;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void Damage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {   
            Vector3 position = transform.position; 
            Instantiate(coin,position,Quaternion.identity);
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
