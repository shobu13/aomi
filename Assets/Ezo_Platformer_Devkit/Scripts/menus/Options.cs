using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Options : MonoBehaviour
{
    public string Langage;

    [System.Serializable]
    class OptionsManager
    {
        public string Langage;
    }

    // Use this for initialization
    void Start()
    {
        this.Langage = "french";
        try
        {
            TextReader reader;
            reader = new StreamReader("Assets/option.json");
            string result = reader.ReadToEnd();
            reader.Close();

            OptionsManager optionResult = JsonUtility.FromJson<OptionsManager>(result);
            this.Langage = optionResult.Langage;
            Debug.Log(this.Langage);
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
}