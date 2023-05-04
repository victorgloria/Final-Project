using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float speed = 10;
    public int damageAmount = 20;
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x,direction.y).normalized * speed;
        float rot = Mathf.Atan2(rotation.y,rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot);
    }
    void OnTriggerEnter2D(Collider2D other){
        enemyHealth enemy = other.gameObject.GetComponent<enemyHealth>();
        if (enemy != null)
        {
            // Deal damage to the enemy
            enemy.Damage(damageAmount);
            // Destroy the projectile
            Destroy(gameObject);
        }

        if(other.tag == "wall"){
        Destroy(gameObject);
        }
    }
}
