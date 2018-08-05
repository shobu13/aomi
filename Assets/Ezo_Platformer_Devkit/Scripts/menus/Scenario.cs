<<<<<<< HEAD:Assets/Ezo_Platformer_Devkit/Scripts/menus/Scenario.cs
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scenario : MonoBehaviour
{
    public Text Text;
    public float CompteurText;
    public float Langue;

    void Start()
    {
    }

    public void Incrementation()
    {
        CompteurText += 1;
        if (CompteurText == 1 && Langue == 0f)
        {
            Text.text = "Chaque soir, quand je m’endors, je rêve.";
        }

        if (CompteurText == 2 && Langue == 0f)
        {
            Text.text =
                "J’aime mes rêves. Ils sont faits de plaines froides et de châteaux lugubres. Toujours noirs et déprimants.";
        }

        if (CompteurText == 3 && Langue == 0f)
        {
            Text.text = "C’est dans mes rêves qu’il y a mon seul ami, Chiro.";
        }

        if (CompteurText == 3 && Langue == 0f)
        {
            Text.text = "J’aime parler à Chiro.";
        }

        if (CompteurText == 3 && Langue == 0f)
        {
            Text.text =
                "Mais je ne suis plus tranquille. Des hordes de petits animaux mignons et de petites fées brillantes veulent détruire mes belles ténèbres. Je ne le permettrai pas !";
        }

        if (CompteurText >= 4)
        {
            SceneManager.LoadScene("ProtoLevel1");
        }
    }
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scenario : MonoBehaviour {

    public Text text;
    public float CompteurText;
    public float Langue;

	void Start () {

	}
	
    public void Incrementation()
    {

        CompteurText += 1;
        if (CompteurText == 1 && Langue == 0f)
        {
            text.text = "Chaque soir, quand je m’endors, je rêve.";
        }
        if (CompteurText == 2 && Langue == 0f)
        {
            text.text = "J’aime mes rêves. Ils sont faits de plaines froides et de châteaux lugubres. Toujours noirs et déprimants.";
        }
        if (CompteurText == 3 && Langue == 0f)
        {
            text.text = "C’est dans mes rêves qu’il y a mon seul ami, Chiro.";
        }
        if (CompteurText == 3 && Langue == 0f)
        {
            text.text = "J’aime parler à Chiro.";
        }
        if (CompteurText == 3 && Langue == 0f)
        {
            text.text = "Mais je ne suis plus tranquille. Des hordes de petits animaux mignons et de petites fées brillantes veulent détruire mes belles ténèbres. Je ne le permettrai pas !";
        }
        if(CompteurText >= 4)
        {
            SceneManager.LoadScene("ProtoLevel1");
        }

    }

}
>>>>>>> Level:Assets/Ezo_Platformer_Devkit/Scripts/Scenario.cs