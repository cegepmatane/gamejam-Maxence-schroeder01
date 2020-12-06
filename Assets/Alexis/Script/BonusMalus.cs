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

    private int NbPot = 0;
    private int Coffre = 0;

    private void Start()
    {
        Player.GetComponent<AfficherVie>().SetVie(Vie);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bonus"))
        {
            NbPot++;
            VerifVictoire();
            Light2D = Player.GetComponentInChildren<Light2D>();
            RandomBonusMalus();
            Destroy(collision.gameObject);
            
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Coffre"))
        {
            AnimCoffre.SetTrigger("IsTouched");
            Destroy(collision.gameObject);
            Coffre++;
            VerifVictoire();
            Player.GetComponent<Message>().SetMessage("Bravo vous avez trouvé le coffre ! Vous avez trouvé " + NbPot + " pot sur 4");
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

    private void VerifVictoire()
    {
        if (NbPot >= 4 && Coffre >= 1)
        {
            SceneManager.LoadScene("Victoire");
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
        Player.GetComponent<Message>().SetMessage("Bonus : Speed\nVous avez trouvez " + NbPot + " pot sur 4");
        yield return new WaitForSeconds(7);
        Player.speedmove = 3f;
    }

    private IEnumerator Flash()
    {
        Light2D.pointLightOuterRadius = 50;
        Debug.Log("Flash");
        Player.GetComponent<Message>().SetMessage("Bonus : Flash\nVous avez trouvez " + NbPot + " pot sur 4");
        yield return new WaitForSeconds(2.5f);
        Light2D.pointLightOuterRadius = 5.5f;
    }

    private IEnumerator UnFlash()
    {
        Light2D.pointLightInnerRadius = 0;
        Light2D.pointLightOuterRadius = 2;
        Debug.Log("Unflash");
        Player.GetComponent<Message>().SetMessage("Bonus : UnFlash\nVous avez trouvez " + NbPot + " pot sur 4");
        yield return new WaitForSeconds(10);
        Light2D.pointLightOuterRadius = 5.5f;
        Light2D.pointLightInnerRadius = 2.5f;
    }

    private IEnumerator UnSpeed()
    {
        Player.speedmove = 1;
        Debug.Log("UnSpeed");
        Player.GetComponent<Message>().SetMessage("Bonus : UnSpeed\nVous avez trouvez " + NbPot + " pot sur 4");
        yield return new WaitForSeconds(10);
        Player.speedmove = 3f;
    }


}
