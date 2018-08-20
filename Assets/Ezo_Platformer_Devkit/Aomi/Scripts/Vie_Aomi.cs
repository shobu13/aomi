using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vie_Aomi : MonoBehaviour {

    float Vie;

	void Start () {

        Vie = 150;

	}
	
	// Update is called once per frame
	void Update () {
	
        if(Vie <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

	}
}
