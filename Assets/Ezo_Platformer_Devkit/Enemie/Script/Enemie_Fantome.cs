using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemie_Fantome : MonoBehaviour {

    public float Distance;
    public GameObject Cible;
    public float Speed;

    bool Poursuite;
    float Hauteur;
    SpriteRenderer SpriteR;
    Rigidbody2D rb2d;
    RaycastHit2D[] hit;

    void Start()
    {

        Poursuite = false;
        SpriteR = gameObject.GetComponent<SpriteRenderer>();
        Cible = GameObject.Find("Aomi_CameraTest");
        rb2d = gameObject.GetComponent<Rigidbody2D>();

    }

    void Update()
    {

        hit = Physics2D.LinecastAll(gameObject.transform.position, Cible.transform.position);

        for (int i = 0; i < hit.Length; i++)
        {
            Debug.DrawLine(gameObject.transform.position, hit[i].point, Color.red, 2f);

            if (hit[i].collider)    //hit[i] est verifier afin de trouver le joueur
            {
                Debug.Log(hit[i].collider.name);
                if (hit[i].collider.CompareTag("Player") && (hit[i].distance < Distance || Poursuite))     //Le Fantome poursuit des que le joueur rentre a porte puis ne le lache plus
                {
                    Hauteur = Cible.transform.position.y - gameObject.transform.position.y; //Calcul de la hauteur
                    if (Mathf.Sign(Hauteur) == -1)
                    {
                        Hauteur = Hauteur / -Hauteur;
                    }
                    else
                    {
                        Hauteur = Hauteur / Hauteur;
                    }
                    Poursuite = true;
                    if (hit[i].transform.position.x > gameObject.transform.position.x)
                    {
                       
                        SpriteR.flipX = false;
                        rb2d.velocity = new Vector2(Speed,  Hauteur * Speed);
                    }
                    if (hit[i].transform.position.x < gameObject.transform.position.x)
                    {
                        SpriteR.flipX = true;
                        rb2d.velocity = new Vector2(-Speed, Hauteur * Speed);
                    }
                }
            }
        }
    }
}
