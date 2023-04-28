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
    public float speed;
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

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "wall"){
        Destroy(gameObject);
        }
    }
}
