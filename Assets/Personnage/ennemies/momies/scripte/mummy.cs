using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class mummy : MonoBehaviour
{
    [SerializeField] Transform player;
    NavMeshAgent agent;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    private void Update()
    {
        agent.SetDestination(player.position);
        anim.SetBool("move", true);
        anim.SetFloat("velx", (player.position.x - transform.position.x));
        anim.SetFloat("vely", (player.position.y - transform.position.y));
    }
}
