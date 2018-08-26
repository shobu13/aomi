using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTremblement : MonoBehaviour {

	public IEnumerator Tremblement(float durer, float intensite)
    {
        Vector3 PositionOriginal = transform.localPosition;

        float Timer = 0.0f;

        while(Timer < durer)
        {
            float x = Random.Range(-1f, 1f) * intensite;
            float y = Random.Range(-1f, 1f) * intensite;

            transform.localPosition = new Vector3(x, y, PositionOriginal.z);

            Timer += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = PositionOriginal;
    }
	
}
