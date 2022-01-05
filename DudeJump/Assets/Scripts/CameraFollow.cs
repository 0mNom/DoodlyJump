using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed;

    private Vector3 currentVelocity;
    void LateUpdate()
    {
        if (target.position.y > this.transform.position.y)
        {
            Vector3 newPos = new Vector3(this.transform.position.x, target.position.y, this.transform.position.z);
            transform.position = newPos;
        }
        
    }
}
