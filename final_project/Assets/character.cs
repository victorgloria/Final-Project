using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")) * Time.fixedDeltaTime * speed);
    }
}
