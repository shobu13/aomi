using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemie_AutoShoot : MonoBehaviour {

    public GameObject Cible;
    public float Radius;
    public GameObject BouBoule;
    public GameObject LaBaBalle;
    public Vector2 OffSet;

    bool CoolDown;
    RaycastHit2D[] hit;

	void Start () {

        CoolDown = true;
        Cible = GameObject.Find("Aomi_CameraTest");

	}
	
	void Update () {

        hit = Physics2D.CircleCastAll(gameObject.transform.position, Radius, Vector2.zero, 0);
        for(int i = 0; i < hit.Length; i++)
        {
            if (hit[i].collider.CompareTag("Player") && CoolDown)
            {
                CoolDown = false;
                StartCoroutine("Timer");
                OffSet = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f);
                Instantiate(LaBaBalle, OffSet, gameObject.transform.rotation);
                Instantiate(BouBoule, gameObject.transform);
            }
        }
	}

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(4);
        CoolDown = true;
    }

}
