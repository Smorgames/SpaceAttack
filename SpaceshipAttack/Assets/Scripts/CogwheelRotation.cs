using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogwheelRotation : MonoBehaviour
{
    void Update()
    {
        if(gameObject.tag == "RightCogwheel")
            gameObject.transform.Rotate(0, 0, Time.deltaTime * 30);
        if (gameObject.tag == "LeftCogwheel")
            gameObject.transform.Rotate(0, 0, -Time.deltaTime * 30);
    }
}
