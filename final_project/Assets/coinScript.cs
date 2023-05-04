using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void getCoin(){
        GetComponent<AudioSource>().Play();
        transform.position = new Vector3(500,0,0);
        Destroy(this.gameObject,5);
    }
}
