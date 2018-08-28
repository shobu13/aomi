using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFee_Phase2 : MonoBehaviour {

    public GameObject PleureStalagmite;
    public GameObject SlashPaillette;
    public GameObject EtoileFilante;
    public float speed;
    public GameObject PatrolGauche;
    public GameObject PatrolDroite;

    GameObject Aomi;
    GameObject SlashSpawne;
    bool Phase2;
    bool PhaseFinal;
    bool Slash;
    bool attack1;
    bool attack2;
    bool LancementPleure;
    bool Gauche;

    void Start()
    {
        Aomi = GameObject.Find("Aomi_CameraTest");
    }

    void Update () {
		if(gameObject.GetComponent<Vie_Boss_Fee>().Vie <= 625 && gameObject.GetComponent<Vie_Boss_Fee>().Vie > 0)
        {
            Phase2 = true;
        }

        if(Phase2 == true)
        {

            Attack1();

        }
        if (PhaseFinal)
        {
            Pleure();
        }

        if(gameObject.GetComponent<Vie_Boss_Fee>().Vie <= 0)
        {
            Phase2 = false;
            PhaseFinal = true;
        }
	}

    void Attack1()
    {
        if (!Slash)
        {
            Slash = true;
            SlashSpawne = Instantiate(SlashPaillette, gameObject.transform.position, gameObject.transform.rotation);
            attack1 = true;
            StartCoroutine("_Attack1");
        }
        if (attack1 && SlashSpawne != null)
        {
            Vector3 difference = Aomi.transform.position - SlashSpawne.transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            SlashSpawne.transform.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);

        }
        if(Slash && !attack1 && SlashSpawne != null)
        {
            SlashSpawne.transform.Translate(SlashSpawne.transform.right * speed * Time.deltaTime);
        }

    }


    void Pleure()
    {
        
        if (!LancementPleure)
        {
            LancementPleure = true;
            Instantiate(PleureStalagmite, gameObject.transform);
            StartCoroutine("Finish");
        }
        if (Gauche)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, PatrolDroite.transform.position, 0.05f);
            if (gameObject.transform.position.x == PatrolDroite.transform.position.x)
            {
                Gauche = false;
            }
        }
        else
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, PatrolGauche.transform.position, 0.05f);
            if (gameObject.transform.position.x == PatrolGauche.transform.position.x)
            {
                Gauche = true;
            }
        }
    }

    IEnumerator Finish()
    {
        yield return new WaitForSeconds(8);
    }


    IEnumerator _Attack1()
    {
        yield return new WaitForSeconds(2);
        attack1 = false;
        Instantiate(EtoileFilante, gameObject.transform.position, gameObject.transform.rotation);
        yield return new WaitForSeconds(2);
        Slash = false;
    }

}
