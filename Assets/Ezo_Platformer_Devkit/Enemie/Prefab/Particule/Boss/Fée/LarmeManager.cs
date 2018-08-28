using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LarmeManager : MonoBehaviour {

    public GameObject Stalagmite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Vie_Aomi>().Vie -= 25;
            Destroy(gameObject);
        }
        if (collision.name == "floor")
        {
            Instantiate(Stalagmite, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
            Destroy(gameObject);
        }
    }

}
