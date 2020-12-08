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
            Destroy(collision.gameObject);
            NbPot++;
            Light2D = Player.GetComponentInChildren<Light2D>();
            RandomBonusMalus();
            VerifVictoire();
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Coffre"))
        {
            AnimCoffre.SetTrigger("IsTouched");
            Destroy(collision.gameObject);
            Coffre++;
            VerifVictoire();
            Player.GetComponent<Message>().SetMessage("Bravo vous avez trouvé le coffre !\nVous avez trouvé " + NbPot + " pot sur 4");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Mino"))
        {
            Vie--;
            Minautaure.transform.position = TpMino.GetComponent<CreateLab>().EndCase.transform.position;
            Player.GetComponent<AfficherVie>().SetVie(Vie);
            if (Vie <= 0)
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
        int RandomNumber = Random.Range(0,5);

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
            case 4:
                TpDebut();
                break;
        }
    }

    private void TpDebut()
    {
        Player.GetComponent<Message>().SetMessage("Malus : Retour a la case depart\nVous avez trouvez " + NbPot + " pot sur 4");
        Player.transform.position = TpMino.GetComponent<CreateLab>().StartCase.transform.position;
    }

    private IEnumerator Speed()
    {
        Player.speedmove = 4.5f;
        Player.GetComponent<Message>().SetMessage("Bonus : Vitesse augmenter\nVous avez trouvez " + NbPot + " pot sur 4");
        yield return new WaitForSeconds(7);
        Player.speedmove = 2f;
    }

    private IEnumerator Flash()
    {
        Light2D.pointLightOuterRadius = 50;
        Player.GetComponent<Message>().SetMessage("Bonus : Vision nocturne\nVous avez trouvez " + NbPot + " pot sur 4");
        yield return new WaitForSeconds(3f);
        Light2D.pointLightOuterRadius = 5.5f;
    }

    private IEnumerator UnFlash()
    {
        Light2D.pointLightInnerRadius = 0;
        Light2D.pointLightOuterRadius = 2;
        Player.GetComponent<Message>().SetMessage("Malus : Panne de torche\nVous avez trouvez " + NbPot + " pot sur 4");
        yield return new WaitForSeconds(10);
        Light2D.pointLightOuterRadius = 5.5f;
        Light2D.pointLightInnerRadius = 2.5f;
    }

    private IEnumerator UnSpeed()
    {
        Player.speedmove = 1;
        Player.GetComponent<Message>().SetMessage("Malus : Ralentissement\nVous avez trouvez " + NbPot + " pot sur 4");
        yield return new WaitForSeconds(10);
        Player.speedmove = 2f;
    }


}
