using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PluieDeCristal : MonoBehaviour {

    public GameObject Glace;

    Vector2 RandomPosition;
    float Timer;
    bool Pluie;

    void Start()
    {
        StartCoroutine("TimerDECE");
    }

    void Update ()
    {

        if(Timer <= 0)
        {
            Timer = Random.Range(2, 3);
            RandomPosition = new Vector2(Random.Range(-17, -1), 2);
            Instantiate(Glace, RandomPosition, gameObject.transform.rotation);
            RandomPosition = new Vector2(Random.Range(-17, -1), 2);
            Instantiate(Glace, RandomPosition, gameObject.transform.rotation);
            RandomPosition = new Vector2(Random.Range(-17, -1), 2);
            Instantiate(Glace, RandomPosition, gameObject.transform.rotation);
            RandomPosition = new Vector2(Random.Range(-17, -1), 2);
            Instantiate(Glace, RandomPosition, gameObject.transform.rotation);

        }
        else
        {
            Timer -= Time.deltaTime;
        }

	}

    IEnumerator TimerDECE()
    {
        yield return new WaitForSeconds(8f);
        Destroy(gameObject);
    }

}
