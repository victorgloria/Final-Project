using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybullet : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform target;
    public float shootingRate = 1f;
    public GameObject projectilePrefab;

    private Rigidbody2D rb;

    public float speed = 10;

    private float nextShootTime;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 playerPosition = target.position;
        rb = GetComponent<Rigidbody2D>();
        Vector3 direction = playerPosition - transform.position;
        rb.velocity = new Vector2(direction.x,direction.y).normalized * speed;
    }

    void Update()
    {
        if (Time.time > nextShootTime && Vector2.Distance(transform.position, target.position) < 10f)
        {
            Shoot();
            nextShootTime = Time.time + shootingRate;
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        // Set the projectile's velocity and direction here
    }
    }
