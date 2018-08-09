using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemie_Poursuite : MonoBehaviour {

    public float Distance;
    public GameObject Cible;
    public float Speed;

    SpriteRenderer SpriteR;
    bool ToucheMur;
    Rigidbody2D rb2d;
    RaycastHit2D[] hit;

    void Start()
    {

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

            if (hit[i].collider)
            {
                if (hit[i].collider.name == "floor")
                {
                    ToucheMur = true;
                    StartCoroutine("CheckMur");
                }

                Debug.Log(hit[i].collider.name);
                if (hit[i].collider.CompareTag("Player") && hit[i].distance < Distance && !ToucheMur)
                {
                    Debug.Log(ToucheMur);

                    if (hit[i].transform.position.x > gameObject.transform.position.x)
                    {
                        SpriteR.flipX = false;
                        rb2d.velocity = new Vector2(Speed, rb2d.velocity.y);
                    }
                    if (hit[i].transform.position.x < gameObject.transform.position.x)
                    {
                        SpriteR.flipX = true;
                        rb2d.velocity = new Vector2(-Speed, rb2d.velocity.y);
                    }
                }
            }
        }
    }

    IEnumerator CheckMur()
    {
        yield return new WaitForSeconds(1);
        ToucheMur = false;
    }
}
