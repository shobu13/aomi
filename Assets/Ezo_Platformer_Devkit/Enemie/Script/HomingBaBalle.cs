using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBaBalle : MonoBehaviour {

    public float Force;
    public GameObject Explosion;

    Rigidbody2D rb2d;
    GameObject Cible;
    float CibleX;
    float CibleY;
    float BalleX;
    float BalleY;

    void Start()
    {
        Cible = GameObject.Find("Aomi_CameraTest");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        CibleX = Cible.transform.position.x;
        CibleY = Cible.transform.position.y;
        BalleX = gameObject.transform.position.x;
        BalleY = gameObject.transform.position.y;

        rb2d.AddForce(new Vector2(CibleX - BalleX, BalleY - CibleY) * Force, ForceMode2D.Impulse);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "floor")
        {
            Instantiate(Explosion, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
        if (collision.CompareTag("Player") && !GameObject.Find("Aomi_CameraTest").GetComponent<Vie_Aomi>().FRAPPE)
        {
            //collision.GetComponent<Vie_Aomi>().Vie -= 25;
            collision.GetComponent<Vie_Aomi>().FRAPPE = true;
            Instantiate(Explosion, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }

}
