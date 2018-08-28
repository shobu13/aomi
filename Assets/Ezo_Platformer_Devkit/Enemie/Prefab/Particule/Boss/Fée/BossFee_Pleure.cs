using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFee_Pleure : MonoBehaviour {


    public GameObject Larme;

    GameObject LarmeSpawne;
    float Timer;


	void Start () {
        StartCoroutine("TimerSuicide");
	}
	
	void Update () {
		
        if(Timer <= 0)
        {
            Timer = 0.5f;
            LarmeSpawne = Instantiate(Larme, gameObject.transform.position, gameObject.transform.rotation);
            LarmeSpawne.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-10, 10), Random.Range(5, 10)), ForceMode2D.Impulse);
        }
        if (LarmeSpawne != null)
        {
        }


        Timer -= Time.deltaTime;
	}

    IEnumerator TimerSuicide()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

}
