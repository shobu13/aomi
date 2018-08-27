using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Vie_Aomi : MonoBehaviour {

    public float Vie;
    public float Mana;
    public Slider BarreDeVie;
    public Slider BarreDeMana;

    bool Recharge;

    void Start () {

        Vie = 150;
        Mana = 100;

	}
	
	// Update is called once per frame
	void Update () {

        BarreDeVie.value = Vie;
        BarreDeMana.value = Mana;

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

}
