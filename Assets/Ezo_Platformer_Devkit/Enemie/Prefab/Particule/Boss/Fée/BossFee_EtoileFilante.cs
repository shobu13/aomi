using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFee_EtoileFilante : MonoBehaviour {

    public GameObject Etoile;

    GameObject EtoileSpawne;
    float Timer;
    float compteur;

	void Start () {

        compteur = 0;

	}
	
	void Update () {
		
        if(Timer <= 0 && compteur < 3)
        {
            Timer = 1;
            EtoileSpawne = Instantiate(Etoile, gameObject.transform.position, gameObject.transform.rotation);
            EtoileSpawne.GetComponent<Rigidbody2D>().AddForce(new Vector2(-Random.Range(5, 10), Random.Range(5, 10)), ForceMode2D.Impulse);
        }

        if(compteur >= 3)
        {
            Destroy(gameObject);
        }

	}
}
