using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class character : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    public float speed = 5f;
    public animationScript asc;

    public Text scoreText;

    public int points = 0;

    public bool platformingCreature = false; //when true, change behavior to work like 2D platformer char

    public float jumpVel = 5;
    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }


    public void Move(Vector3 offset){
        if(offset != Vector3.zero){
            offset.Normalize();
            //offset *= Time.fixedDeltaTime;
            //rb.MovePosition(transform.position + ((offset)*speed));
            Vector3 vel = offset *= speed;
            if(platformingCreature){
                rb.velocity = new Vector2(vel.x,rb.velocity.y);
            }else{
                rb.velocity = vel;
            }
            
            
            asc.ChangeAnimationState("Walking");
            if(offset.x < 0){
                spriteRenderer.flipX = true;
            }else{
                spriteRenderer.flipX = false;
            }
        }else{
            Stop(); 
        }
    }

    public void Stop(){
        //return;
        if(platformingCreature){
            rb.velocity = new Vector2(0,rb.velocity.y);
        }else{
            rb.velocity = Vector3.zero;
        }
        asc.ChangeAnimationState("Idle");
        
        
    }

    public void MoveToward(Vector3 position){
        Move(position - transform.position);
    }

    public void Jump(){
        if(!platformingCreature){
            return;
        }
        rb.velocity = new Vector2(rb.velocity.x,jumpVel);

    }

    public void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "coin"){
            other.GetComponent<coinScript>().getCoin();
            points+=10;
            scoreText.text = "$ "+ points.ToString();
        }
    }
}