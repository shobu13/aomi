using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossfee : MonoBehaviour
{

    public CameraTremblement cameraTremblement;
    public GameObject PluieDeCristal;
    public GameObject RayonMagique;

    Vector3 Position;
    GameObject Aomi;
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

        cameraTremblement = gameObject.GetComponent<CameraTremblement>();
        Aomi = GameObject.Find("Aomi_CameraTest");
        Vie = 1250;
        Attack2 = true;

    }

    void Update()
    {

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
                StartCoroutine(cameraTremblement.Tremblement(0.45f, 0.4f));                 //Phase 1
                StartCoroutine("_Attack1");

            }
            if (Attack2)
            {
                // Rayon magique
                rayonMagique = true;
                Attack2 = false;
                StartCoroutine("_Attack2");
            }
            if (Attack3)
            {
                // Charge
                Attack3 = false;
                charge = true;
                Position = Aomi.transform.position;
                StartCoroutine("_Attack3");

            }
        }
        //////////////////////////////////////////////////////////////

    }

    void _RayonMagique()
    {

        gameObject.transform.position = new Vector2(gameObject.transform.position.x, Vector2.MoveTowards(gameObject.transform.position, Aomi.transform.position, 0.05f).y);

    }
    void _Charge()
    {

        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, Position, 0.05f);

    }

    IEnumerator _Attack1()
    {
        yield return new WaitForSeconds(10);
        Attack1 = false;
    }
    IEnumerator _Attack2()
    {
        yield return new WaitForSeconds(5);
        Instantiate(RayonMagique, gameObject.transform.position, gameObject.transform.rotation);
        rayonMagique = false;
        Attack3 = true;
    }
    IEnumerator _Attack3()
    {
        yield return new WaitForSeconds(5);
        charge = false;
        Attack2 = true;
    }

}
