using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemie_Patrol : MonoBehaviour {

    public float OffSetX_A;
    public float OffSetX_B;
    public float Speed;

    private Vector3 PositionA;
    private Vector3 PositionB;

    void Start()
    {

        PositionA = new Vector3(OffSetX_A, 0, gameObject.transform.position.z);
        PositionB = new Vector3(OffSetX_B, 0, gameObject.transform.position.z);
        gameObject.transform.position = PositionA;

    }

    void Update () {
        
        gameObject.transform.position = Vector3.Lerp(PositionA, PositionB, Speed);

	}

}
