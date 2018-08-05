using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Options : MonoBehaviour
{
    public string Language;

    [System.Serializable]
    class OptionsSerializer
    {
        public string Language;
    }

    // Use this for initialization
    void Start()
    {
        this.Language = "french";
        try
        {
            TextReader reader;
            reader = new StreamReader("Assets/option.json");
            string result = reader.ReadToEnd();
            reader.Close();

            OptionsSerializer optionResult = JsonUtility.FromJson<OptionsSerializer>(result);
            this.Language = optionResult.Language;
            Debug.Log(this.Language);
        }
        catch (FileNotFoundException e)
        {
            TextWriter writer;
            writer = new StreamWriter("Assets/option.json");
            writer.Write(JsonUtility.ToJson(this));
            writer.Close();
            Debug.Log(e);
        }
    }

    string GetLanguage()
    {
        return Language;
    }
}