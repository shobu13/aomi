using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DegatSlash : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !GameObject.Find("Aomi_CameraTest").GetComponent<Vie_Aomi>().FRAPPE)
        {
            //collision.GetComponent<Vie_Aomi>().Vie -= 75;
            collision.GetComponent<Vie_Aomi>().FRAPPE = true;
            Destroy(gameObject);
        }
        if (collision.name == "floor")
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        StartCoroutine("Suicide");
    }

    IEnumerator Suicide()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

}


