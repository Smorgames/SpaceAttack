using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject[] healthPoints;
    public GameObject laserPrefab, bombPrefab;
    public AudioClip laserShot, bombShot;
    public int amountOfHP;
    public int score;
    public static int weaponChoice = 1;
    public float speed;
    private float fireRate1 = 0.25f, fireRate2 = 0.8f;
    private float nextFire;
    private bool isSpeedBonus = false, isSpeedRateOfShot = false;

    public GameObject explosion;
    public AudioClip explosionAudio;
    void Start()
    {
        amountOfHP = 6;
        score = 0;
        gameObject.transform.position = new Vector3(-5.41f, 0, 0);
        if (EnemySpawner.gameMode == 2)
        {
            fireRate1 = 0.2f;
            fireRate2 = 0.65f;
        }

        if (EnemySpawner.gameMode == 1)
        {
            fireRate1 = 0.25f;
            fireRate2 = 0.8f;
        }
    }

    void Update()
    {
        Move();
        if (weaponChoice == 1)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (Time.time > nextFire)
                {
                    Instantiate(laserPrefab, new Vector3(transform.position.x + 0.6f, transform.position.y + 0.31f, 1), Quaternion.Euler(0, 0, -90));
                    Instantiate(laserPrefab, new Vector3(transform.position.x + 0.6f, transform.position.y - 0.31f, 1), Quaternion.Euler(0, 0, -90));
                    nextFire = Time.time + fireRate1;
                    gameObject.GetComponent<AudioSource>().PlayOneShot(laserShot);
                }
            }
        }
        if (weaponChoice == 2)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (Time.time > nextFire)
                {
                    Instantiate(bombPrefab, new Vector3(transform.position.x + 0.7f, transform.position.y, 1), Quaternion.identity);
                    nextFire = Time.time + fireRate2;
                    gameObject.GetComponent<AudioSource>().PlayOneShot(bombShot);
                }
            }
        }
        if (isSpeedBonus == true)
        {
            StartCoroutine(SpeedBonusCourutine());
        }
        if (isSpeedRateOfShot == true)
        {
            StartCoroutine(SpeedRateOfShotCourutine());
        }
        HPAnimation();
        if(amountOfHP <= 0 && amountOfHP > -4)
        {
            amountOfHP = -8;
            enabled = false;
            Instantiate(explosion, transform.position, Quaternion.identity);
            gameObject.GetComponent<AudioSource>().PlayOneShot(explosionAudio);
            Destroy(gameObject, 1f);
        }
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * speed * Time.deltaTime * horizontalInput);
        transform.Translate(Vector3.left * speed * Time.deltaTime * verticalInput);
        if (transform.position.y > 3.3f)
        {
            transform.position = new Vector3(transform.position.x, -3.3f, 0);
        }
        if (transform.position.y < -3.3f)
        {
            transform.position = new Vector3(transform.position.x, 3.3f, 0);
        }
        if (transform.position.x > 5f)
        {
            transform.position = new Vector3(5f, transform.position.y, 0);
        }
        if (transform.position.x < -5.45f)
        {
            transform.position = new Vector3(-5.45f, transform.position.y, 0);
        }
    }

    public void RecountHP(int damage)
    {
        amountOfHP -= damage;
    }

    public void PlayerDamageSound(AudioClip damage)
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SpeedBonus")
        {
            isSpeedBonus = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "RateOfFireBonus")
        {
            isSpeedRateOfShot = true;
            Destroy(collision.gameObject);
        }
    }

    IEnumerator SpeedBonusCourutine()
    {
        isSpeedBonus = false;
        speed = speed + 3f;
        yield return new WaitForSeconds(5f);
        speed = speed - 3f;
    }
    IEnumerator SpeedRateOfShotCourutine()
    {
        isSpeedRateOfShot = false;
        fireRate1 = fireRate1 / 2;
        fireRate2 = fireRate2 / 2;
        yield return new WaitForSeconds(5f);
        fireRate1 = fireRate1 * 2;
        fireRate2 = fireRate2 * 2;
    }

    public void ScoreIncrease(int point)
    {
        score += point;
    }

    void HPAnimation()
    {
        if (amountOfHP >= 6)
            healthPoints[5].SetActive(true);
        else
            healthPoints[5].SetActive(false);
        if (amountOfHP >= 5)
            healthPoints[4].SetActive(true);
        else
            healthPoints[4].SetActive(false);
        if (amountOfHP >= 4)
            healthPoints[3].SetActive(true);
        else
            healthPoints[3].SetActive(false);
        if (amountOfHP >= 3)
            healthPoints[2].SetActive(true);
        else
            healthPoints[2].SetActive(false);
        if (amountOfHP >= 2)
            healthPoints[1].SetActive(true);
        else
            healthPoints[1].SetActive(false);
        if (amountOfHP >= 1)
            healthPoints[0].SetActive(true);
        else
            healthPoints[0].SetActive(false);
    }

    public void HPEqualNull()
    {
        for (int i = 0; i < 6; i++)
        {
            healthPoints[i].SetActive(false);
        }
    }

    public bool HPDetector()
    {
        if (amountOfHP <= 0)
            return true;
        else
            return false;
    }

}
