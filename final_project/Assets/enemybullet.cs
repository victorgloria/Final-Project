using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class enemybullet : MonoBehaviour
{    
    private Rigidbody2D rb;
    public float speed = 10;
    public int damageAmount = 20;
    void Start()
    {
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

        rb = GetComponent<Rigidbody2D>();
        Vector3 direction = playerPosition - transform.position;
        rb.velocity = new Vector2(direction.x,direction.y).normalized * speed;
    }
    void OnTriggerEnter2D(Collider2D other){
        PlayerHealth enemy = other.gameObject.GetComponent<PlayerHealth>();
        if (enemy != null)
        {
            // Deal damage to the enemy
            enemy.Damage(damageAmount);
            // Destroy the projectile
            Destroy(gameObject);
        }

        if(other.tag == "wall"){
        Destroy(this.gameObject);
        }
    }
}
