using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public class BonusMalus : MonoBehaviour
{
    public Player Player;
    private Light2D Light2D;
    public Animator AnimCoffre;
    public GameObject Minautaure;
    public GameObject TpMino;
    public int Vie = 3;

    private void Start()
    {
        Player.GetComponent<AfficherVie>().SetVie(Vie);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bonus"))
        {
            Light2D = Player.GetComponentInChildren<Light2D>();
            RandomBonusMalus();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Coffre"))
        {
            AnimCoffre.SetTrigger("IsTouched");
            Destroy(collision.gameObject);
            SceneManager.LoadScene("Victoire");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Mino"))
        {
            Vie--;
            Minautaure.transform.position = TpMino.GetComponent<CreateLab>().EndCase.transform.position;
            Player.GetComponent<AfficherVie>().SetVie(Vie);
            if (Vie < 0)
                SceneManager.LoadScene("GameOver");
        }
    }

    private void RandomBonusMalus()
    {
        int RandomNumber = Random.Range(0,3);

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
