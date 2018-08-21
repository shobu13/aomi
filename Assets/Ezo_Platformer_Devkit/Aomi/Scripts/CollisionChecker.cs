using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour {

    //bool _Special;

    private void Start()
    {
       // _Special = GameObject.Find("Aomi_CameraTest").GetComponent<Attack_Aomi>().Special;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemie") && GameObject.Find("Aomi_CameraTest").GetComponent<Attack_Aomi>().Special)
        {
            GameObject.Find("Aomi_CameraTest").GetComponent<Attack_Aomi>().Attack = false;
            collision.GetComponent<Vie_Enemie>().Vie -= 75;
            Destroy(GameObject.Find("Energie"));
            Destroy(GameObject.Find("Trainé"));
        }
        if (collision.CompareTag("Enemie") && !GameObject.Find("Aomi_CameraTest").GetComponent<Attack_Aomi>().Special)
        {
            GameObject.Find("Aomi_CameraTest").GetComponent<Attack_Aomi>().Attack = false;
            collision.GetComponent<Vie_Enemie>().Vie -= 50;
        }
    }
}
