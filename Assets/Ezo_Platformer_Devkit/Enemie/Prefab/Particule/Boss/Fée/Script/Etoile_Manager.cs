using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Etoile_Manager : MonoBehaviour {

	void Start () {
        StartCoroutine("TimerSuicide");
	}
	
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !GameObject.Find("Aomi_CameraTest").GetComponent<Vie_Aomi>().FRAPPE)
        {
            //collision.GetComponent<Vie_Aomi>().Vie -= 50;
            collision.GetComponent<Vie_Aomi>().FRAPPE = true;
            Destroy(gameObject);
        }
        if (collision.name == "Left")
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, gameObject.GetComponent<Rigidbody2D>().velocity.y);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(5, 10), 0), ForceMode2D.Impulse);
        }
        if (collision.name == "Right")
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, gameObject.GetComponent<Rigidbody2D>().velocity.y);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-Random.Range(5, 10), 0), ForceMode2D.Impulse);
        }
        if (collision.name == "Down")
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, 0);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Random.Range(10, 15)), ForceMode2D.Impulse);
        }
    }

    IEnumerator TimerSuicide()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

}
