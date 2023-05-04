using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Text Hp;

    public GameObject coin;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void Damage(int amount)
    {
        currentHealth -= amount;
        Hp.text = "HP: "+ currentHealth.ToString();
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
