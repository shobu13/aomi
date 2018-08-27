using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionLimiter : MonoBehaviour {

    ParticleSystem ps;

	void Start () {

        ps = gameObject.GetComponent<ParticleSystem>();
        StartCoroutine("Wait5");

	}
	
    IEnumerator Wait5()
    {
        yield return new WaitForSeconds(5);
        var em = ps.emission;
        em.enabled = false;
    }

}
