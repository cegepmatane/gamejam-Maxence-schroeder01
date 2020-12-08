using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Credit Maxence Schroeder
//06/12/2020
//GameJam 2020

public class SoundEverywhere : MonoBehaviour{
    private void Start(){
    }
    private static SoundEverywhere instance = null;
    public static SoundEverywhere Instance{
        get { return instance; }
    }
    private void Awake(){
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }else{
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
