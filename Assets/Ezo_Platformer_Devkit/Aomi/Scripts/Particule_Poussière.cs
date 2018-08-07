using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particule_Poussière : MonoBehaviour {

    GameObject Cible;
    GameObject Particule;

    void Start()
    {
        Particule = GameObject.Find("Particule_Poussière");
        Cible = GameObject.Find("Aomi_CameraTest");
    }

    void Update () {

        Particule.transform.position = new Vector3(Cible.transform.position.x - 0.15f, Cible.transform.position.y - 1, Cible.transform.position.z);

	}
}
