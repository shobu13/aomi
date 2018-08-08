using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemie_Patrol : MonoBehaviour {


    public float Distance;
    private RaycastHit2D hit;

    void Update () {

        hit = Physics2D.Raycast(gameObject.transform.position, gameObject.transform.right);
        Debug.DrawRay(gameObject.transform.position, hit.point, Color.red, 3f);

	}

}
