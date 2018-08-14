using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Aomi : MonoBehaviour {

    public Animator animator;

    bool Attack;

	void Start () {

        Attack = false;
        animator = gameObject.GetComponent<Animator>();

	}
	
	void Update () {


        if (Input.GetKeyDown("x") && !Attack)
        {

            Attack = true;
            animator.SetBool("Attack1", true);
            StartCoroutine("Wait");

        }

	}

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        Attack = false;
        animator.SetBool("Attack1", false);
    }

}
