using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    private void Start()
    {
        RenderSettings.ambientLight = new Color(0.0f, 0.0f, 0.0f, 1.0f);
    }
}
