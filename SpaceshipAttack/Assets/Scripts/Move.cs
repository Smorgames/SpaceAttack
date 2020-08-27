using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private bool isUp;
    private float shootTimer;
    public GameObject laserPrefab;
    public AudioClip laserShot;
    private void Start()
    {
        isUp = true;
    }
    void Update()
    {
        if (gameObject.tag == "Player")
        {
            transform.Translate(Vector3.up * 6 * Time.deltaTime);
            if (isUp == true)
            {
                transform.Translate(Vector3.right * 5 * Time.deltaTime);
            }
            if (transform.position.y > 3.3f)
            {
                isUp = false;
            }
            if (transform.position.y < 0.0f)
            {
                isUp = true;
            }
            if (isUp == false)
            {
                transform.Translate(Vector3.left * 5 * Time.deltaTime);
            }
            if (transform.position.x <= -15)
                Destroy(gameObject);
        }
        if (gameObject.tag == "Enemy")
        {
            shootTimer += Time.deltaTime;
            transform.Translate(Vector3.down * 5 * Time.deltaTime);
            if (shootTimer > 1f)
            {
                Instantiate(laserPrefab, new Vector3(transform.position.x - 0.8f, transform.position.y, 1), Quaternion.Euler(0, 0, 90));
                gameObject.GetComponent<AudioSource>().PlayOneShot(laserShot);
                shootTimer = 0;
            }
            if (transform.position.x <= -16)
                Destroy(gameObject);
        }
        if (gameObject.tag == "RateOfFireBonus")
        {
            transform.Translate(Vector3.down * 1 * Time.deltaTime);
            if (transform.position.x <= -10)
                Destroy(gameObject);
        }
        if (gameObject.tag == "SpeedBonus")
        {
            transform.Translate(Vector3.down * 1 * Time.deltaTime);
            if (transform.position.x <= -10)
                Destroy(gameObject);
        }
    }
}
