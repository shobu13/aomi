using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class OptionManager : MonoBehaviour
{
    private GameObject _gameManager;
    private Dropdown _dropdown;

    // Use this for initialization
    void Start ()
	{
        _gameManager = GameObject.Find("GameManager");
	    Options options = _gameManager.GetComponent<Options>();
        Debug.Log(options.Language);
        DirectoryInfo languageDirectoryInfo = new DirectoryInfo(@"Assets/Language");
	    FileInfo[] fichiers = languageDirectoryInfo.GetFiles();
	    _dropdown = gameObject.GetComponent<Dropdown>();
        foreach (FileInfo fichier in fichiers)
	    {
	        if (fichier.Extension == ".txt")
	        {
	            _dropdown.options.Add(new Dropdown.OptionData(text:fichier.Name));
	        }
	    }
        _dropdown.onValueChanged.AddListener(delegate
        {
            OnChange(_dropdown);
        });
	}

    void OnChange(Dropdown dropdown)
    {
        Debug.Log(dropdown.options[_dropdown.value].text);
    }
}
