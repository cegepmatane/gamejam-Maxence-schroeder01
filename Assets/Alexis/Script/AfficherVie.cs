using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfficherVie : MonoBehaviour
{
    public Text Vie;

    public void SetVie(int vie)
    {
        Vie.text = "Vie : " + vie;
    }
}
