using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public bool loaded = false;
	// Use this for initialization
	void Start () {
        if (loaded == false)
	    {
	        DontDestroyOnLoad(gameObject);
            SceneManager.LoadScene("Menu");
        }
	}
	
}
