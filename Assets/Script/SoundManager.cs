using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerSound, betesound, ambiance;
    static AudioSource audioSRC;

    private void Start()
    {
        playerSound = Resources.Load<AudioClip>("bruitdepas");
        betesound = Resources.Load<AudioClip>("sonminautor");
        ambiance = Resources.Load<AudioClip>("sonsambiant");
        audioSRC = GetComponent<AudioSource>();
    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
        }
    }
}
