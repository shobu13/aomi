using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Vie_Aomi : MonoBehaviour {

    public float Vie;
    public float Seuil;
    public float Mana;
    public Slider BarreDeVie;
    public Slider BarreDeMana;
    public bool FRAPPE;
    bool Trigger;

    Animator animator;
    bool Recharge;

    void Start () {

        Vie = 200;
        Mana = 100;
        Seuil = Vie;
        animator = gameObject.GetComponent<Animator>();
        Trigger = true;
	}
	
	void Update () {

        BarreDeVie.value = Vie;
        BarreDeMana.value = Mana;

        if (FRAPPE && Trigger)
        {
            animator.SetTrigger("FRAPPE");
            StartCoroutine("Invincibiliter");
            Vie -= 50;
            Trigger = false;
        }

        if (Mana < 100 && !Recharge)
        {
            Recharge = true;
            StartCoroutine("_Mana");
        }

        if(Vie <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

	}

    IEnumerator _Mana()
    {

        yield return new WaitForSeconds(2);
        Mana += 10;
        Recharge = false;

    }

    IEnumerator Invincibiliter()
    {
        yield return new WaitForSeconds(2);
        Trigger = true;
        FRAPPE = false;

        
    }

}
