using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buynewWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            GameObject player = GameObject.FindWithTag("Player");
            character scriptA = player.GetComponent<character>();
            int myValue = scriptA.points;


            if(myValue > 9){
                myValue -=10;
                scriptA.points = myValue;
            }

        }
    }
}
