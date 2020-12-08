using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Credit Maxence Schroeder
//06/12/2020
//GameJam 2020

public class MinotaurAI : MonoBehaviour
{
    public Animator anim;
    AudioSource audiol;
    public AudioClip impact;
    void Start()
    {
        audiol = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (anim.GetBool("attack") == true)
        {
            audiol.PlayOneShot(impact);
        }
        if (anim.GetBool("attack") == false)
        {
            audiol.Stop();
        }
    }
}
