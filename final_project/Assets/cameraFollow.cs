using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    // Start is called before the first frame updatepublic Transform target;
public Transform target;
public float depth = -10;
private void LateUpdate()
{
    transform.position = new Vector3(
        target.position.x,
        target.position.y,
        depth
        );
}
}
