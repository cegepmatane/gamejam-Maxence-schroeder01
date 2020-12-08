using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Credit Maxence Schroeder
//06/12/2020
//GameJam 2020
public class munu : MonoBehaviour
{
    public void Recommencer_Click()
    {
        SceneManager.LoadScene("Game");
    }
    public void quit()
    {
        Application.Quit();
    }
    public void credit()
    {
        SceneManager.LoadScene("Credit");
    }
    public void retour()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
    public void regle()
    {
        SceneManager.LoadScene("Regle");
    }
}
