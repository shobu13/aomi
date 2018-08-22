using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour {


    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemie") && GameObject.Find("Aomi_CameraTest").GetComponent<Attack_Aomi>().Special)
        {
            GameObject.Find("Aomi_CameraTest").GetComponent<Attack_Aomi>().Attack = false;
            collision.GetComponent<Vie_Enemie>().Vie -= 75;
        }

        if (collision.CompareTag("Enemie") && !GameObject.Find("Aomi_CameraTest").GetComponent<Attack_Aomi>().Special)
        {
            GameObject.Find("Aomi_CameraTest").GetComponent<Attack_Aomi>().Attack = false;
            collision.GetComponent<Vie_Enemie>().Vie -= 50;
        }
    }
}
