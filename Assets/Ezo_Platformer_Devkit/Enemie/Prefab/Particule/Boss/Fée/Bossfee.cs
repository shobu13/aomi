using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossfee : MonoBehaviour
{

    public GameObject PluieDeCristal;
    public GameObject RayonMagiqueLeft;
    public GameObject RayonMagiqueRight;
    public bool retour;

    RaycastHit2D[] hit;
    Animator CamAnimator;
    Vector3 OriginalPosition;
    Vector3 Position;
    GameObject Aomi;
    GameObject rayonSpawne;
    float Angle;
    float Vie;
    bool Gauche;
    bool Phase2;
    bool PhaseFinal;
    bool trigger;
    bool Phase1;
    bool Attack1;
    bool Attack2;
    bool Attack3;
    bool rayonMagique;
    bool charge;
    bool Touche;
    bool Contact;
    bool BAM;

    void Start()
    {

        OriginalPosition = gameObject.transform.position;
        CamAnimator = GameObject.Find("CM vcam1").GetComponent<Animator>();
        Aomi = GameObject.Find("Aomi_CameraTest");

    }

    void Update()
    {

        if (gameObject.transform.position.x > Aomi.transform.position.x)
        {
            Gauche = true;
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            Gauche = false;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        //////////////////////////////////////////////////////////////

        Vie = gameObject.GetComponent<Vie_Boss_Fee>().Vie;
        if (rayonMagique)
        {
            // Rayon magique
            _RayonMagique();
        }
        if (!rayonMagique && BAM)
        {
            if (Gauche)
            {
                hit = Physics2D.RaycastAll(gameObject.transform.position, Vector2.left, 100);
            }
            else
            {
                hit = Physics2D.RaycastAll(gameObject.transform.position, Vector2.right, 100);
            }

            foreach (RaycastHit2D _hit in hit)
            {
                if (_hit.collider.CompareTag("Player") && !GameObject.Find("Aomi_CameraTest").GetComponent<Vie_Aomi>().FRAPPE)
                {
                    //Aomi.GetComponent<Vie_Aomi>().Vie -= 50;
                    Aomi.GetComponent<Vie_Aomi>().FRAPPE = true;
                }
            }
        }

        if (charge)
        {
            // Rayon magique
            _Charge();
        }
        if (retour)
        {
            // Pause
            _Retour();
        }


        //////////////////////////////////////////////////////////////

        if (Vie > 625)
        {
            Phase1 = true;                                                               //Check de Phase
        }
        else
        {
            Phase1 = false;
        }

        //////////////////////////////////////////////////////////////

        if (!Phase2 && !PhaseFinal && Phase1)
        {
            if (!Attack1)
            {
                // Chute de cristal
                CamAnimator.SetTrigger("Shake");
                Attack1 = true;
                retour = false;
                //Phase 1
                StartCoroutine("_Attack1");

            }
            if (Attack2)
            {
                // Rayon magique

                rayonMagique = true;
                Attack2 = false;
                if (Gauche)
                {
                    Instantiate(RayonMagiqueLeft, gameObject.transform);
                }
                else
                {
                    Instantiate(RayonMagiqueRight, gameObject.transform);
                }
                StartCoroutine("_Attack2");
            }
            if (Attack3)
            {
                // Charge
                Attack3 = false;
                Position = Aomi.transform.position;
                StartCoroutine("_Attack3");

            }
        }
        //////////////////////////////////////////////////////////////


    }

    void _RayonMagique()
    {

        gameObject.transform.position = new Vector2(gameObject.transform.position.x, Vector2.MoveTowards(gameObject.transform.position, Aomi.transform.position, 0.075f).y);

    }
    void _Charge()
    {

        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, Position, 0.075f);
        if (Contact)
        {
            Contact = false;
            charge = false;
            Aomi.GetComponent<Vie_Aomi>().Vie -= 25;
        }
    }
    void _Retour()
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, OriginalPosition, 0.075f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Contact = true;
        }
        else
        {
            Contact = false;
        }
    }

    IEnumerator _Attack1()
    {
        yield return new WaitForSeconds(1);
        Instantiate(PluieDeCristal);
        yield return new WaitForSeconds(1);
        Attack2 = true;
        yield return new WaitForSeconds(9);
        Attack1 = false;
    }
    IEnumerator _Attack2()
    {
        yield return new WaitForSeconds(2);
        rayonMagique = false;
        BAM = true;
        yield return new WaitForSeconds(3);
        BAM = false;
        Attack3 = true;
        Touche = false;
    }
    IEnumerator _Attack3()
    {
        yield return new WaitForSeconds(1);
        charge = true;
        yield return new WaitForSeconds(2);
        charge = false;
        retour = true;
        yield return new WaitForSeconds(3);
        Attack2 = true;
    }

}
    

