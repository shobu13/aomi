using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scenario : MonoBehaviour
{
    public Text Text;
    public int CompteurText;

    private LanguageSerializer.StringStringDico _intro;

    void Start()
    {
        _intro = GameObject.Find("GameManager").GetComponent<Language>().GetLanguage().Intro;
        Text.text = _intro["intro1"];
    }

    public void Incrementation()
    {
        CompteurText += 1;
        if (CompteurText == 1)
        {
            Text.text = _intro["intro2"];
        }

        if (CompteurText == 2)
        {
            Text.text = _intro["intro3"];
        }

        if (CompteurText == 3)
        {
            Text.text = _intro["intro4"];
        }

        if (CompteurText == 4)
        {
            Text.text = _intro["intro5"];
        }

        if (CompteurText == 5)
        {
            Text.text = _intro["intro6"];
        }

        if (CompteurText >= 6)
        {
            SceneManager.LoadScene("ice1");
        }
    }
}