using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuiviSouris : MonoBehaviour {

    private Vector3 Calcul;
    
	
	void Update () {

        Calcul = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(Calcul.x, Calcul.y, gameObject.transform.position.z), 0.125f);
	}
}
