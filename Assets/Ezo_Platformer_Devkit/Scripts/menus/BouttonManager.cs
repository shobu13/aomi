using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BouttonManager : MonoBehaviour {

	public void Jouer()
    {
        SceneManager.LoadScene("Scenar");
    }

    public void Option()
    {
        SceneManager.LoadScene("Option");
    }

    public void Quitter()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

}
