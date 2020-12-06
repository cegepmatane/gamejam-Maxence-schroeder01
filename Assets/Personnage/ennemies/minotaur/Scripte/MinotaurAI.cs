using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurAI : MonoBehaviour
{
    public Animator anim;
    AudioSource audiol;
    public AudioClip impact;
    private float compt = 0;
    void Start()
    {
        audiol = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("attack") == true)
        {
            if (audiol.isPlaying == false)
            {
                if (compt == 0)
                {
                    audiol.PlayOneShot(impact);
                    compt = 1;
                }
            }
        }
        if (anim.GetBool("attack") == false)
        {
            audiol.Stop();
        }
    }
}
