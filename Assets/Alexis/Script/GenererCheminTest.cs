using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;

[CustomEditor(typeof(Grid))]
[CanEditMultipleObjects]
public class GenererCheminTest : MonoBehaviour
{
    private void OnSceneGUI()
    {
        if(Event.current.type == EventType.MouseDown && Event.current.control)
        {

           
        }


    }
}
