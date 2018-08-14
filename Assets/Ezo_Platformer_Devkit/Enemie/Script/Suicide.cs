using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suicide : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine("DECE");
	}

    IEnumerator DECE()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
        
    }

}
