 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    Ray ray;
    Transform firePoint;
    public float rayDistance;
    public LayerMask layerHit;
    bool isHitting;
    RaycastHit hit;

    LineRenderer lineGraphics;
    public Light muzzleFlash;

    public float fireRate;
    float timer;

    public float gunDamage;

    void Start()
    {
        firePoint = this.transform.GetChild(0);
        ray = new Ray();
        lineGraphics = this.GetComponent<LineRenderer>();
    }


    void Update()
    {
        FireTrigger();
    }


    void FireTrigger()
    {
        if (Input.GetMouseButtonDown(0))
        {
            timer = fireRate;
        }
        if (Input.GetMouseButton(0))
        {
            timer += Time.deltaTime;
            Shoot(timer > fireRate);
        
        }
        if (Input.GetMouseButtonUp(0))
        {

        }
    }

    void Shoot(bool isShooting)
    {
        if (isShooting)
        {
            timer -= fireRate;
        }


        ray.origin = firePoint.position;
        ray.direction = firePoint.forward;

       isHitting = Physics.Raycast(ray, out hit, rayDistance, layerHit);
       // Debug.DrawLine(ray.origin, ray.GetPoint(rayDistance),Color.green);
       
        if (isHitting)
        {
            ShootGraphics(isShooting);
            if (hit.transform.CompareTag("Enemy"))
            {
                hit.transform.GetComponent<Enemy>().RecibirAtaque(gunDamage);
            }
        }
        else
        {
            ShootGraphics(false);
        }


    }


    void ShootGraphics(bool status)
    {
        //lineGraphics.enabled = status;
        muzzleFlash.enabled = status;

        lineGraphics.SetPosition(0, firePoint.position);
        lineGraphics.SetPosition(1, hit.point);
    }

}
