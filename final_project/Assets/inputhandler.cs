using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputhandler : MonoBehaviour
{
    public character main;
    // Update is called once per frame
    void FixedUpdate()
    {
        main.Move(new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"),0));
    }
}
