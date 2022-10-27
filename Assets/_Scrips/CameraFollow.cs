using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    Vector3 distance;
    [Range(0,1)]public float speed;


    void Start()
    {
        distance = target.position - this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posFinal = target.position - distance;
        transform.position = Vector3.Lerp(transform.position,posFinal,speed);
    }
}
