using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBaBalle : MonoBehaviour {

    public GameObject Cible;
    private Rigidbody2D rb;

    void FixedUpdate()
    {
        StartCoroutine("Timer");
        rb = GetComponent<Rigidbody2D>();
        Cible = GameObject.Find("Aomi_CameraTest");

        Vector2 direction = (Vector2)Cible.transform.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * 150;

        rb.velocity = transform.up * 5;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") || collision.name == "floor")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

}
