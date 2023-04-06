using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class shooting : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform pointFire;
    public GameObject projectile;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.spaceKey.wasPressedThisFrame){
            Instantiate(projectile,pointFire.position, transform.rotation);
        }
    }
}
