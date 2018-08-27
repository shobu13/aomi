using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalagtiteManager : MonoBehaviour {

    Vector2 Rotation;
    bool Tombe;

	void Start () {

        Tombe = true;

	}
	
	void Update () {

        if (Tombe)
        {
            //Tourne sur lui-même et tombe
            gameObject.transform.eulerAngles = Vector2.MoveTowards(gameObject.transform.eulerAngles, new Vector2(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y + 1), 0.075f);
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 1), 0.075f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    { 
        
        if(collision.name == "floor")
        {
            Debug.Log("Stop");
            Tombe = false;
            gameObject.GetComponent<SpriteRenderer>().flipY = false;
            StartCoroutine("TimerSuicide");
        }
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Vie_Aomi>().Vie -= 25;
        }

    }

    IEnumerator TimerSuicide()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }

}
