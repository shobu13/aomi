using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemie_AutoShoot : MonoBehaviour {

    public GameObject Cible;
    public float Radius;
    public GameObject BouBoule;
    public GameObject LaBaBalle;

    bool Stop;
    Animator animator;
    Vector2 OffSet1;
    Vector2 OffSet2;
    bool CoolDown;
    RaycastHit2D[] hit;

	void Start () {

        animator = gameObject.GetComponent<Animator>();
        CoolDown = true;
        Cible = GameObject.Find("Aomi_CameraTest");

	}
	
	void Update () {
        Debug.Log("Position Tourelle =" + gameObject.transform.position);
        hit = Physics2D.CircleCastAll(gameObject.transform.position, Radius, Vector2.zero, 0);
        for(int i = 0; i < hit.Length; i++)
        {
            if (hit[i].collider.CompareTag("Player") && CoolDown && Cible.transform.position.x < gameObject.transform.position.x)
            {
                Stop = false;
                CoolDown = false;
                StartCoroutine("Timer4s");
                animator.SetTrigger("Shoot");
                OffSet1 = new Vector2(gameObject.transform.position.x + -1, gameObject.transform.position.y + 0.75f);
                StartCoroutine("Timer");
            }
            if(Cible.transform.position.x > gameObject.transform.position.x)
            {
                animator.SetTrigger("Stop");
                Stop = true;
            }
        }
	}

    IEnumerator Timer4s()
    {
        yield return new WaitForSeconds(4);
        CoolDown = true;
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        if (!Stop)
        {
            Instantiate(LaBaBalle, OffSet1, gameObject.transform.rotation);
            Instantiate(BouBoule, gameObject.transform.position, gameObject.transform.rotation);
        }
    }

}
