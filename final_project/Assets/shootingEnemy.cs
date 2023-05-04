using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float shootingRate = 1f;
    public GameObject projectilePrefab;

    private float nextShootTime;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
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
    }
}
