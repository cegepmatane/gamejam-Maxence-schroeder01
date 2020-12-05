using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
}
