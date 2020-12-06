using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class BonusMalus : MonoBehaviour
{
    public Player Player;
    private Light2D Light2D;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bonus"))
        {
            Light2D = Player.GetComponentInChildren<Light2D>();
            RandomBonusMalus();
            Destroy(collision.gameObject);
        }
    }

    private void RandomBonusMalus()
    {
        int RandomNumber = Random.Range(0,4);

        switch (RandomNumber)
        {
            case 0:
                StartCoroutine(Speed());
                break;

            case 1:
                StartCoroutine(Flash());
                break;
            case 2 :
                StartCoroutine(UnFlash());
                break;
            case 3:
                StartCoroutine(UnSpeed());
                break;
        }
    }

    private IEnumerator Speed()
    {
        Player.speedmove = 4.5f;
        Debug.Log("Speed");
        yield return new WaitForSeconds(7);
        Player.speedmove = 3f;
        
    }

    private IEnumerator Flash()
    {
        Light2D.pointLightOuterRadius = 50;
        Debug.Log("Flash");
        yield return new WaitForSeconds(2.5f);
        Light2D.pointLightOuterRadius = 5.5f;
        
    }

    private IEnumerator UnFlash()
    {
        Light2D.pointLightInnerRadius = 0;
        Light2D.pointLightOuterRadius = 2;
        Debug.Log("Unflash");
        yield return new WaitForSeconds(10);
        Light2D.pointLightOuterRadius = 5.5f;
        Light2D.pointLightInnerRadius = 2.5f;
    }

    private IEnumerator UnSpeed()
    {
        Player.speedmove = 1;
        Debug.Log("UnSpeed");
        yield return new WaitForSeconds(10);
        Player.speedmove = 3f;
    }


}
