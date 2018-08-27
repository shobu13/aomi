using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vie_Enemie : MonoBehaviour {

    public float Vie;

	void Start () {
        
        Vie = 150;

	}
	
	// Update is called once per frame
	void Update () {
		
        if(Vie <= 0)
        {
            Destroy(gameObject);
        }

	}
}
