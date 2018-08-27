using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossfee : MonoBehaviour
{

    public CameraTremblement cameraTremblement;
    public GameObject PluieDeCristal;
    public GameObject RayonMagique;
    public bool retour;

    Vector3 OriginalPosition;
    Vector3 Position;
    GameObject Aomi;
    GameObject rayonSpawne;
    float Angle;
    float Vie;
    bool Phase2;
    bool PhaseFinal;
    bool trigger;
    bool Phase1;
    bool Attack1;
    bool Attack2;
    bool Attack3;
    bool rayonMagique;
    bool charge;

    void Start()
    {

        OriginalPosition = gameObject.transform.position;
        cameraTremblement = gameObject.GetComponent<CameraTremblement>();
        Aomi = GameObject.Find("Aomi_CameraTest");
        Attack2 = true;

    }

    void Update()
    {
        Vie = gameObject.GetComponent<Vie_Boss_Fee>().Vie;
        if (rayonMagique)
        {
            // Rayon magique
            _RayonMagique();
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

        if (Vie < 625 && Vie > 250)
        {
            Phase1 = false;
            Phase2 = true;
        }
        if(Vie >= 625)
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
                Attack1 = true;
                retour = false;
                Instantiate(PluieDeCristal);
               // StartCoroutine(cameraTremblement.Tremblement(2f, 0.4f));                 //Phase 1
                StartCoroutine("_Attack1");

            }
            if (Attack2)
            {
                // Rayon magique
                rayonMagique = true;
                Attack2 = false;
                Instantiate(RayonMagique, gameObject.transform);
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

    }
    void _Retour()
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, OriginalPosition, 0.075f);
    }

    IEnumerator _Attack1()
    {
        yield return new WaitForSeconds(11);
        Attack1 = false;
    }
    IEnumerator _Attack2()
    {
        yield return new WaitForSeconds(2);
        rayonMagique = false;
        yield return new WaitForSeconds(3);
        Attack3 = true;
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
