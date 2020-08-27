using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject laserPrefab;
    public AudioClip laserShot, takeDamage;
    public int amountOfEnemyHP;
    private float speed = 5f;
    private float shootTimer;

    public int scoreValue;
    private EnemySpawner enemySpawner;

    public GameObject explosion;

    private void Start()
    {
        amountOfEnemyHP = 3;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
            enemySpawner = gameControllerObject.GetComponent<EnemySpawner>();
        if (gameControllerObject == null)
            Debug.Log("Can not find gameControllerObject");
    }
    void Update()
    {
        shootTimer += Time.deltaTime;
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (shootTimer > 1f)
        {
            Instantiate(laserPrefab, new Vector3(transform.position.x - 0.8f, transform.position.y, 1), Quaternion.Euler(0, 0, 90));
            gameObject.GetComponent<AudioSource>().PlayOneShot(laserShot);
            shootTimer = 0;
        }
        if (transform.position.x < -8)
        {
            Destroy(gameObject);
        }
        if (amountOfEnemyHP <= 0)
        {
            Destroy(gameObject);
            if(EnemySpawner.gameMode == 1)
                enemySpawner.AddScore(scoreValue);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
    }

    public void RecountEnemyHP(int damage)
    {
        amountOfEnemyHP -= damage;
    }

    public void EnemyDamageSound(AudioClip damage)
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(damage);
    }
}
