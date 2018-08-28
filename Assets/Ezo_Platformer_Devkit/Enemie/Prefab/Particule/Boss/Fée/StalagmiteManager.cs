using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalagmiteManager : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Vie_Aomi>().Vie -= 50;
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if(gameObject.transform.position.y != -8.2f)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, -8.2f);
        }
        StartCoroutine("Destroy");
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

}
