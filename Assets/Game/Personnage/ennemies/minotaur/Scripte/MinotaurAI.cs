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

    private float TimeCri = 10f, LastTimeCri;
    void Start()
    {
        audiol = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (anim.GetBool("attack") == true && TimeCri + LastTimeCri < Time.time)
        {
            audiol.PlayOneShot(impact);
            LastTimeCri = Time.time;
        }
        if (anim.GetBool("attack") == false)
        {
            audiol.Stop();
        }
    }
}
