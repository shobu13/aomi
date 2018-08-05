using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class OptionManager : MonoBehaviour
{
    public GameObject LanguageText;
    public GameObject ReturnText;

    private Options _options;
    private Dropdown _dropdown;
    private Language _language;

    // Use this for initialization
    void Start()
    {
        _options = GameObject.Find("GameManager").GetComponent<Options>();
        _language = GameObject.Find("GameManager").GetComponent<Language>();
        DirectoryInfo languageDirectoryInfo = new DirectoryInfo(@"Assets/Language");
        FileInfo[] fichiers = languageDirectoryInfo.GetFiles();
        _dropdown = gameObject.GetComponent<Dropdown>();
        foreach (FileInfo fichier in fichiers)
        {
            if (fichier.Extension == ".json")
            {
                _dropdown.options.Add(new Dropdown.OptionData(text: fichier.Name.Substring(0, fichier.Name.IndexOf("."))));
            }
        }

        foreach (Dropdown.OptionData dropdownOption in _dropdown.options)
        {
            if (dropdownOption.text == _options.GetOptions().Language)
            {
                _dropdown.value = _dropdown.options.IndexOf(dropdownOption);
            }
        }
        _dropdown.captionText.text = _options.GetOptions().Language;
        _dropdown.onValueChanged.AddListener(delegate { OnChange(_dropdown); });

    }

    void OnChange(Dropdown dropdown)
    {
        Options.OptionsSerializer serializer = new Options.OptionsSerializer();
        serializer.Language = dropdown.options[dropdown.value].text;
        _options.UpdateFile(serializer);
        UpdateText();
    }

    void UpdateText()
    {
        LanguageSerializer.StringStringDico uiComponent = _language.GetLanguage().UI;
        LanguageText.GetComponent<TextMeshProUGUI>().text = uiComponent["LanguageText"];
        ReturnText.GetComponent<TextMeshProUGUI>().text = uiComponent["ReturnText"];
    }
}