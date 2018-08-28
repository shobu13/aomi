using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalagtiteManager : MonoBehaviour {

    Vector2 Rotation;

	
	void Update () {

            //Tourne sur lui-même et tombe
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 1), 0.075f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    { 
        
        if(collision.name == "floor")
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("Player") && !GameObject.Find("Aomi_CameraTest").GetComponent<Vie_Aomi>().FRAPPE)
        {
            //collision.GetComponent<Vie_Aomi>().Vie -= 25;
            collision.GetComponent<Vie_Aomi>().FRAPPE = true;
            Destroy(gameObject);
        }

    }
}
