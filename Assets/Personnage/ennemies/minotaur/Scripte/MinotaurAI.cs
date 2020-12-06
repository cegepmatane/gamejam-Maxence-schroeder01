using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurAI : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("attack") == true)
        {
            SoundManager.PlaySound("sonminautor");
        }
        if (anim.GetBool("attack") == false)
        {
            SoundManager.stopPlaysound();
        }
    }
}
