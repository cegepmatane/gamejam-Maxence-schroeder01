using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Mommie : MonoBehaviour
{
    [SerializeField] Transform player;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        anim.SetBool("move", true);
        anim.SetFloat("velx", (player.position.x - transform.position.x));
        anim.SetFloat("vely", (player.position.y - transform.position.y));
    }
}
