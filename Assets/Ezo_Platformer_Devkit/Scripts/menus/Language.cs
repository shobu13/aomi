using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class LanguageSerializer
{
    [System.Serializable]
    public class StringStringDico : SerializableDictionary<string, string> {};
    public StringStringDico Intro = new StringStringDico();
    public StringStringDico UI = new StringStringDico();
    public string test = "true";
}

public class Language : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    GetLanguage();
	}

    public LanguageSerializer GetLanguage()
    {
        Options options = GetComponent<Options>();
        string language = options.GetOptions().Language;
        Debug.Log("language = " + language);

        TextReader reader;
        reader = new StreamReader("Assets/Language/" + language + ".json");
        string result = reader.ReadToEnd();
        reader.Close();

        return JsonUtility.FromJson<LanguageSerializer>(result);
    }

    /*void SetLanguage()
    {
        LanguageSerializer serializer = new LanguageSerializer();
        serializer.Intro.Add("intro1", "");
        serializer.Intro.Add("intro2", "");
        Debug.Log(JsonUtility.ToJson(serializer));

        TextWriter writer;
        writer = new StreamWriter("Assets/Language/base.json");
        writer.Write(JsonUtility.ToJson(serializer, true));
        writer.Close();

    }*/
}
