using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcumulationPaillette : MonoBehaviour {

    bool Delaie;
    ParticleSystem ps;

	void Start () {
        ps = gameObject.GetComponent<ParticleSystem>();
        StartCoroutine("Timer");
	}
	

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(2);
        var em = ps.emission;
        em.enabled = false;
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

}
