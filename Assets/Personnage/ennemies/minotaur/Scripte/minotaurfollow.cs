using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minotaurfollow : MonoBehaviour
{
    public float speed;
    public  Transform player;
    private float dist;
    public float howclose;


    void Start()
    {
        
    }

    void Update()
    {
        dist = Vector2.Distance(player.position, transform.position);
        if (dist <= howclose)
        {
            transform.LookAt(player);
            GetComponent<Rigidbody2D>().AddForce(transform.forward * speed);


        }
    }
}
