using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform PlayerT;
    public int laz;
     void Start()
    {

    }
    private void Update()
    {
        transform.position = new Vector3(PlayerT.transform.position.x, PlayerT.transform.position.y, laz);
    }
}
