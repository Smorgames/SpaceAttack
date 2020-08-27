using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public AudioClip explosion;
    void Start()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(explosion);
        Destroy(gameObject, 2f);
    }
}
