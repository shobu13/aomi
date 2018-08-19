using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Aomi : MonoBehaviour {

    public Animator animator;
    public float ForceChiro;
    public float Distance;
    public float OffSet;

    private GameObject Chiro;
    private PlayerPlatformerController Link;

    bool trigger;
    bool Attack;
    RaycastHit2D[] hit;
    Vector2 Stockage;

    void Start () {

        Attack = false;
        animator = gameObject.GetComponent<Animator>();
        Chiro = GameObject.Find("Chiro");
        Link = gameObject.GetComponent<PlayerPlatformerController>();

    }

    void Update () {

   
        
        if (!Attack && Link.Flip)
        {
            Chiro.GetComponent<SpriteRenderer>().flipX = true;
            Chiro.transform.position = Vector3.Lerp(Chiro.transform.position, new Vector3(gameObject.transform.position.x + 1, gameObject.transform.position.y + 1, 0), 0.045f);
        }

        if (!Attack && !Link.Flip)
        {
            Chiro.GetComponent<SpriteRenderer>().flipX = false;
            Chiro.transform.position = Vector3.Lerp(Chiro.transform.position, new Vector3(gameObject.transform.position.x - 1, gameObject.transform.position.y + 1, 0), 0.045f);
        }
        

        if (Input.GetKeyDown("x") && !Attack)
        {
            trigger = true;
            Attack = true;
            //animator.SetBool("Attack1", true);
            StartCoroutine("Wait");

        }

        
        if (trigger && !Link.Flip)
        {

            trigger = false;
            Stockage = new Vector2(gameObject.transform.position.x + Distance, gameObject.transform.position.y);
            hit = Physics2D.RaycastAll(gameObject.transform.position - new Vector3(0, OffSet, 0), Vector2.right, Distance);


            foreach (RaycastHit2D _hit in hit)
            {
                if (_hit.collider.name == "floor" || _hit.collider.CompareTag("Enemie"))
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
                if(_hit.collider.name == "floor" || _hit.collider.CompareTag("Enemie"))
                {
                    if (_hit.collider.transform.position.x > Stockage.x)
                    {
                        Stockage = _hit.point;
                    }
                }
            }
        }
        
        if(Attack == true)
        {
            Chiro.transform.position = Vector3.Lerp(Chiro.transform.position, Stockage, 0.025f);
        }


    }


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        Attack = false;
        animator.SetBool("Attack1", false);
    }

}
