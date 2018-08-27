using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BouttonManager : MonoBehaviour
{
    [System.Serializable]
    public struct ButtonsClass
    {
        public string tag;
        public GameObject button;
    }

    public ButtonsClass[] ButtonsArray;

    private Language _language;

    void Start()
    {
        _language = GameObject.Find("GameManager").GetComponent<Language>();
        LanguageSerializer.StringStringDico uiComponent = _language.GetLanguage().UI;
        foreach (ButtonsClass buttonsClass in ButtonsArray)
        {
            buttonsClass.button.GetComponent<TextMeshProUGUI>().text = uiComponent[buttonsClass.tag];
        }
//        PlayText.GetComponent<TextMeshProUGUI>().text = uiComponent["PlayText"];
    }

    public void Recommencer()
    {
        SceneManager.LoadScene("ice" + GameObject.Find("Manager").GetComponent<Manager>().Level);
    }

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
