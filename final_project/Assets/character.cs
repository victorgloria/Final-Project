using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class character : MonoBehaviour
{
    Rigidbody2D rb;

    private Animator anim;

    public float Speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        if(moveInput == 0){
            anim.SetBool("CharMove",false);
        }
        else{
            anim.SetBool("CharMove",true);
        }
        rb.MovePosition(transform.position + new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")) * Time.fixedDeltaTime * Speed);

        if(Keyboard.current.aKey.wasPressedThisFrame){
            transform.Rotate(0, 180, 0);
        }
    }
}
