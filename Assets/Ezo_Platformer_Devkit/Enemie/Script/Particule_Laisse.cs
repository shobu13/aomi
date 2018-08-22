using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particule_Laisse : MonoBehaviour {

    ParticleSystem Pr;

	void Start () {

        Pr = gameObject.GetComponent<ParticleSystem>();
        StartCoroutine("Timer");

	}

    IEnumerator Timer()
    {

        yield return new WaitForSeconds(1);
        var em = Pr.emission;
        em.enabled = false;
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

}
