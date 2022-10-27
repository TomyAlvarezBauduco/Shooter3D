using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Mortal
{
    NavMeshAgent agent;
    public Player player;
    public float damage;
    Animator animator;

 
    protected override void Awake()
    {
        animator = this.GetComponent<Animator>();
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
      animator.SetBool("isMoving", agent.velocity != Vector3.zero);
    }

    protected override void Morir()
    {

        animator.SetTrigger("Die");

        base.Morir();
        this.GetComponent<NavMeshAgent>().enabled = false;
        this.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
       if (other.CompareTag("Player") && player.isAlive && this.isAlive)
       {
            player.RecibirAtaque(damage);
       } 
    }


}
