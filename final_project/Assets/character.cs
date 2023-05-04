using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

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

    
    public bool randomizeAttributes = false;
    public bool randomizeSeed = false;
    public int seed = 123;

    public UnityEvent myevent;
    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        myevent.AddListener(pointEvent);
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
    private bullet b;
    public void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "coin"){
            other.GetComponent<coinScript>().getCoin();
            points+=10;
            scoreText.text = "$ "+ points.ToString();
        }

        if(other.tag == "buy"){


            if(points > 9){
                points-=10;
                scoreText.text = "$ "+ points.ToString();
                seed = Random.Range(int.MinValue,int.MaxValue);
                Random.InitState(seed);
                GameObject Bullet = GameObject.Find("Bullet");
                b = Bullet.GetComponent<bullet>();
                b.speed = Random.Range(5,50);
                b.damageAmount = Random.Range(10,100);
                b.color = new Color(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f));
            }
        }
    }

    public void pointEvent(){
        
    }
}