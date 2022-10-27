using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mortal
{
    float movX;
    float movZ;
    Rigidbody rigidbodyPlayer;
    public float speed;
    Ray ray;
    bool isHitting;
    public float rayDistance;
    public LayerMask layerFloor;
    RaycastHit hit;

    Animator animator;


    protected override void Awake()
    {
        base.Awake();
        rigidbodyPlayer = this.GetComponent<Rigidbody>();
        animator = this.GetComponent<Animator>();
        ray = new Ray();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movimiento();
        MouseRotation();
    }


    private void Movimiento()
    {
        // transform.Translate(Input.GetAxis("Horizontal") / 15f, 0, Input.GetAxis("Vertical") / 15f);
        movX = Input.GetAxis("Horizontal");
        movZ = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(movX,0,movZ);

        if (direction.magnitude > 1)
        {
            direction.Normalize();
        }
        
        
        
        rigidbodyPlayer.velocity = direction * speed;
        animator.SetBool("isMoving", direction != Vector3.zero);
    }

    private void MouseRotation()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawLine(ray.origin, ray.GetPoint(rayDistance),Color.cyan);
        isHitting = Physics.Raycast(ray, out hit, rayDistance, layerFloor);
        if (isHitting)
        {
            Vector3 aim = hit.point;
            aim.y = 0;
            this.transform.LookAt(aim);
        }
    }

    protected override void Morir()
    {
        animator.SetTrigger("Die");
        base.Morir();
        rigidbodyPlayer.velocity = Vector3.zero;
        this.GetComponentInChildren<Gun>().enabled = false;
        this.enabled = false;

    }

}
