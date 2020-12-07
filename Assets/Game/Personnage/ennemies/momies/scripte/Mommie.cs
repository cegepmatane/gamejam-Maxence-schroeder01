using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

// Credit Maxence Schroeder
//06/12/2020
//GameJam 2020
//n'est pas uttiliser les sheets etait pas belle
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
