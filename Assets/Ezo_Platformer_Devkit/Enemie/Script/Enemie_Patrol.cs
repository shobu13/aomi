using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemie_Patrol : MonoBehaviour {

    public float Distance;
    RaycastHit2D[] hit;
    public GameObject Cible;

     void Start()
     {

        Cible = GameObject.Find("Aomi_CameraTest");

     }

    void Update() {

        hit = Physics2D.LinecastAll(gameObject.transform.position, Cible.transform.position);
        for (int i = 0; i < hit.Length; i++) {
            Debug.DrawLine(gameObject.transform.position, hit[i].point, Color.red, 2f);
            if (hit[i].collider)
            {

                Debug.Log(hit[i].collider.name);
                if (hit[i].collider.CompareTag("Player") && hit[i].distance < Distance)
                {

                    gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, hit[i].transform.position, 0.025f);
                }
            }
        }
    }
}
