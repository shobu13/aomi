using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Options : MonoBehaviour
{

    [System.Serializable]
    public class OptionsSerializer
    {
        public string Language;

        public OptionsSerializer()
        {
             Language = "Français";
        }
    }

    private OptionsSerializer options;

    // Use this for initialization
    void Start()
    {
        options = GetOptions();
    }

    public OptionsSerializer GetOptions()
    {
        OptionsSerializer optionResult = new OptionsSerializer();
        try
        {
            TextReader reader;
            reader = new StreamReader("Assets/option.json");
            string result = reader.ReadToEnd();
            reader.Close();

            optionResult = JsonUtility.FromJson<OptionsSerializer>(result);
        }
        catch (FileNotFoundException e)
        {
            TextWriter writer;
            writer = new StreamWriter("Assets/option.json");
            writer.Write(JsonUtility.ToJson(optionResult));
            writer.Close();
            Debug.Log(e);
        }
        return optionResult;
    }

    public void UpdateFile(OptionsSerializer serializer)
    {
        options = serializer;

        TextWriter writer = new StreamWriter("Assets/option.json");
        writer.Write(JsonUtility.ToJson(serializer));
        writer.Close();
    }
}