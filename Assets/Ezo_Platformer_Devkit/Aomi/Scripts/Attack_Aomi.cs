using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Aomi : MonoBehaviour {

    public Animator animator;
    public float ForceChiro;
    public float Distance;
    public float OffSet;
    public bool Attack;
    public float JumpForce;
    public GameObject LASER;
    public bool Special;

    private GameObject Chiro;
    private PlayerPlatformerController Link;

    bool trigger;
    RaycastHit2D[] hit;
    Vector2 Stockage;
    Rigidbody2D rb2d;


    void Start () {

        rb2d = gameObject.GetComponent<Rigidbody2D>();
        Attack = false;
        animator = gameObject.GetComponent<Animator>();
        Chiro = GameObject.Find("Chiro");
        Link = gameObject.GetComponent<PlayerPlatformerController>();

    }

    void Update () {

   
        
        if (!Attack && Link.Flip)
        {

            Destroy(GameObject.Find("Energie"));
            Destroy(GameObject.Find("Trainé"));
            StartCoroutine("ParticuleLaisse");
            Chiro.GetComponent<SpriteRenderer>().flipX = true;
            Chiro.transform.position = Vector3.MoveTowards(Chiro.transform.position, new Vector3(gameObject.transform.position.x + 1, gameObject.transform.position.y + 1, 0), 0.3f);
        }

        if (!Attack && !Link.Flip)
        {

            Destroy(GameObject.Find("Energie"));
            Destroy(GameObject.Find("Trainé"));
            StartCoroutine("ParticuleLaisse");
            Chiro.GetComponent<SpriteRenderer>().flipX = false;
            Chiro.transform.position = Vector3.MoveTowards(Chiro.transform.position, new Vector3(gameObject.transform.position.x - 1, gameObject.transform.position.y + 1, 0), 0.3f);
        }
        

        if (Input.GetKeyDown("x") && !Attack)       //Attack de base
        {
            Special = false;
            trigger = true;
            Attack = true;
            animator.SetTrigger("Attack");
            StartCoroutine("Wait");

        }
        if (Input.GetKeyDown("c") && !Attack && gameObject.GetComponent<Vie_Aomi>().Mana >= 30)       //Attack Special(pareil mais special)
        {
            gameObject.GetComponent<Vie_Aomi>().Mana -= 30;
            Special = true;
            Instantiate(LASER, Chiro.transform);
            trigger = true;
            Attack = true;
            animator.SetTrigger("Attack");
            StartCoroutine("Wait");

        }


        if (trigger && !Link.Flip)
        {

            trigger = false;
            Stockage = new Vector2(gameObject.transform.position.x + Distance, gameObject.transform.position.y);
            hit = Physics2D.RaycastAll(gameObject.transform.position - new Vector3(0, OffSet, 0), Vector2.right, Distance);


            foreach (RaycastHit2D _hit in hit)
            {
                if (_hit.collider.name == "floor")
                {
                    if (_hit.collider.transform.position.x < Stockage.x)
                    {
                        Stockage = _hit.point;
                    }
                }
                if (_hit.collider.CompareTag("Enemie"))
                {
                    if (_hit.collider.transform.position.x < Stockage.x)
                    {
                        Stockage = _hit.point;
                    }
                }
            }
            
        }

        if (trigger && Link.Flip)
        {

            trigger = false;
            hit = Physics2D.RaycastAll(gameObject.transform.position - new Vector3(0, OffSet, 0), Vector2.left, Distance);
            Stockage = new Vector2(gameObject.transform.position.x - Distance, gameObject.transform.position.y);

            foreach (RaycastHit2D _hit in hit)
            {
                if (_hit.collider.name == "floor")
                {
                    if (_hit.collider.transform.position.x > Stockage.x)
                    {
                        Stockage = _hit.point;
                    }
                }
                if (_hit.collider.CompareTag("Enemie"))
                {
                    if (_hit.collider.transform.position.x > Stockage.x)
                    {
                        Stockage = _hit.point - new Vector2(1, 0);
                    }
                }
            }
        }
        if (Attack == true && Special)
        {
            Chiro.transform.position = Vector3.MoveTowards(Chiro.transform.position, Stockage, 0.4f);
        }


        if (Attack == true && !Special)
        {
            Chiro.transform.position = Vector3.MoveTowards(Chiro.transform.position, Stockage, 0.2f);
        }


    }

    IEnumerator ParticuleLaisse()
    {
        yield return new WaitForSeconds(10);
        Destroy(GameObject.Find("Laser(Clone)"));
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.3f);
        if (Attack)
        {
            Attack = false;
        }
        if (Special)
        {
            Special = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemie"))
        {
            collision.GetComponent<Vie_Enemie>().Vie -= 75;
            rb2d.velocity = Vector2.up * JumpForce;
        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }

    }

}
