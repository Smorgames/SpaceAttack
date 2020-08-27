using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyShip1, enemyShip2;
    public int waveSize, waveNumber;
    public float startTime, waitBetweenWaves, waitBetweenSpawn;

    public static int gameMode = 1;

    private float spawnRate = 0.2f;
    private float nextSpawn;

    public Text scoreText;
    public int score;

    public float time, timeInSeconds;
    public Text timeText;

    public GameObject gameOverTable;

    public static bool switchTimer;

    public GameObject highScore, bestTime;
    public Text highScoreText, bestTimeText;

    private void Start()
    {
        switchTimer = true;
        if(gameMode == 1)
        {
            waveSize = 10;
            waveNumber = 0;
            score = 0;
            UpdateScore();
            StartCoroutine(SpawnWaves());
        }
        if (gameMode == 2)
        {
            time = 0;
            timeInSeconds = 0;
        }
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    PlayerPrefs.SetInt("Highscore", 0);
        //    PlayerPrefs.SetFloat("BestTime", 0);
        //}
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0;
            switchTimer = false;
        }
        if (gameMode == 2)
        {
            GameObject playerVariable = GameObject.FindWithTag("Player");
            if (playerVariable != null && switchTimer == true)
            {
                time += 1;
                if(time == 60)
                {
                    timeInSeconds += 1;
                    timeText.text = timeInSeconds.ToString() + " seconds";
                    time = 0;
                }
            }
                if (Time.time > nextSpawn)
            {
                int typeOfEnemyShip = Random.Range(0, 3);
                if (typeOfEnemyShip == 0 || typeOfEnemyShip == 1)
                    Instantiate(enemyShip1, new Vector3(transform.position.x, Random.Range(-3, 3), transform.position.z), Quaternion.Euler(0, 0, -90));
                if (typeOfEnemyShip == 2)
                    Instantiate(enemyShip2, new Vector3(transform.position.x, Random.Range(-3, 3), transform.position.z), Quaternion.Euler(0, 0, -90));
                nextSpawn = Time.time + spawnRate;
            }
            if (playerVariable == null)
            {
                HighscoreUpdate();
                bestTime.SetActive(true);
                bestTimeText.text = timeInSeconds.ToString() + " seconds";
                highScore.SetActive(false);
                highScoreText.text = "";
            }
        }
        if (gameMode == 1)
        {
            GameObject playerVariable = GameObject.FindWithTag("Player");
            if (playerVariable == null)
            {
                HighscoreUpdate();
                highScore.SetActive(true);
                highScoreText.text = score.ToString() + " points";
                bestTime.SetActive(false);
                bestTimeText.text = "";
            }
        }
        GameObject playerDeath = GameObject.FindWithTag("Player");
        if (playerDeath == null)
        {
            StartCoroutine(GameOver());

        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startTime);
        while (true)
        {
            yield return new WaitForSeconds(waitBetweenWaves);
            waveNumber += 1;
            if (waveNumber < 10)
            {
                waveSize = 10;
                for (int i = 0; i < waveSize; i++)
                {
                    yield return new WaitForSeconds(waitBetweenSpawn);
                    int typeOfEnemyShip = Random.Range(0, 3);
                    if (typeOfEnemyShip == 0 || typeOfEnemyShip == 1)
                        Instantiate(enemyShip1, new Vector3(transform.position.x, Random.Range(-3, 3), transform.position.z), Quaternion.Euler(0, 0, -90));
                    if (typeOfEnemyShip == 2)
                        Instantiate(enemyShip2, new Vector3(transform.position.x, Random.Range(-3, 3), transform.position.z), Quaternion.Euler(0, 0, -90));
                }
            }
            if (waveNumber >= 10 && waveNumber < 20)
            {
                waveSize = 15;
                for (int i = 0; i < waveSize; i++)
                {
                    yield return new WaitForSeconds(waitBetweenSpawn);
                    int typeOfEnemyShip = Random.Range(0, 3);
                    if (typeOfEnemyShip == 0 || typeOfEnemyShip == 1)
                        Instantiate(enemyShip1, new Vector3(transform.position.x, Random.Range(-3, 3), transform.position.z), Quaternion.Euler(0, 0, -90));
                    if (typeOfEnemyShip == 2)
                        Instantiate(enemyShip2, new Vector3(transform.position.x, Random.Range(-3, 3), transform.position.z), Quaternion.Euler(0, 0, -90));
                }
            }
            if (waveNumber >= 20 && waveNumber < 30)
            {
                waveSize = 20;
                for (int i = 0; i < waveSize; i++)
                {
                    yield return new WaitForSeconds(waitBetweenSpawn);
                    int typeOfEnemyShip = Random.Range(0, 3);
                    if (typeOfEnemyShip == 0 || typeOfEnemyShip == 1)
                        Instantiate(enemyShip1, new Vector3(transform.position.x, Random.Range(-3, 3), transform.position.z), Quaternion.Euler(0, 0, -90));
                    if (typeOfEnemyShip == 2)
                        Instantiate(enemyShip2, new Vector3(transform.position.x, Random.Range(-3, 3), transform.position.z), Quaternion.Euler(0, 0, -90));
                }
            }
            if (waveNumber >= 30)
            {
                waveSize = 30;
                for (int i = 0; i < waveSize; i++)
                {
                    yield return new WaitForSeconds(waitBetweenSpawn);
                    int typeOfEnemyShip = Random.Range(0, 3);
                    if (typeOfEnemyShip == 0 || typeOfEnemyShip == 1)
                        Instantiate(enemyShip1, new Vector3(transform.position.x, Random.Range(-3, 3), transform.position.z), Quaternion.Euler(0, 0, -90));
                    if (typeOfEnemyShip == 2)
                        Instantiate(enemyShip2, new Vector3(transform.position.x, Random.Range(-3, 3), transform.position.z), Quaternion.Euler(0, 0, -90));
                }
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        if(gameMode == 1)
            scoreText.text = "Score: " + score.ToString();
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1.5f);
        gameOverTable.SetActive(true);
        Time.timeScale = 0;
    }

    public void SwitchTrue(bool value)
    {
        switchTimer = value;
    }

    private void HighscoreUpdate()
    {
        if(gameMode == 1)
        {
            if(score > PlayerPrefs.GetInt("Highscore", 0))
            {
                PlayerPrefs.SetInt("Highscore", score);
            }
        }
        if (gameMode == 2)
        {
            if (timeInSeconds > PlayerPrefs.GetFloat("BestTime", 0))
            {
                PlayerPrefs.SetFloat("BestTime", timeInSeconds);
            }
        }
    }
}
