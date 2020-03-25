using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public GameObject ball;
    Vector3 distanceball;
    void Start()
    {
        distanceball = transform.position - ball.transform.position;
        
    }

    void LateUpdate()
    {
        transform.position = ball.transform.position + distanceball;
    }
}
