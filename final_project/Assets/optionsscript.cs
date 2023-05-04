using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class optionsscript : MonoBehaviour
{
    // Start is called before the first frame update
    public void openMenu(){
        GetComponent<Canvas>().enabled = true;
    }

    public void closeMenu(){
        GetComponent<Canvas>().enabled = false;
    }
}
