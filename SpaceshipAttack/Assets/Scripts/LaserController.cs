using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public float speed;
    public AudioClip playerDamage, enemyDamage;
    public GameObject bombExplosion, enemyShip;

    private void Start()
    {
        Destroy(gameObject, 1.7f);
    }
    private void Update()
    {
        LaserTranslate();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.tag == "EnemyLaser")
            {
                collision.gameObject.GetComponent<PlayerController>().RecountHP(1);
                collision.gameObject.GetComponent<PlayerController>().PlayerDamageSound(playerDamage);
                Destroy(gameObject);
            }
            if (gameObject.tag == "EnemyBomb")
            {
                collision.gameObject.GetComponent<PlayerController>().RecountHP(3);
                collision.gameObject.GetComponent<PlayerController>().PlayerDamageSound(playerDamage);
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "Enemy")
        {
            if (gameObject.tag == "Laser")
            {
                collision.gameObject.GetComponent<EnemyBehaviour>().RecountEnemyHP(1);
                Destroy(gameObject);
            }
            if (gameObject.tag == "Bomb")
            {
                collision.gameObject.GetComponent<EnemyBehaviour>().RecountEnemyHP(3);
                Instantiate(bombExplosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
    void LaserTranslate()
    {
        if(gameObject.tag == "Laser")
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (gameObject.tag == "Bomb")
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (gameObject.tag == "EnemyLaser")
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (gameObject.tag == "EnemyBomb")
            transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
