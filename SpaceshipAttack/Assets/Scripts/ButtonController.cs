using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject pausePanel, modeRedactor, scoreTab;
    public AudioClip weaponChoseLaserGun, sound;
    public Text _text, _time;

    private int score;
    private float time;

    public GameObject enemySpawner;

    private void Start()
    {
        enemySpawner = GameObject.FindWithTag("GameController");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Play()
    {
        SceneManager.LoadScene("SpaceAttack");
    }
    public void PauseOff()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        enemySpawner.GetComponent<EnemySpawner>().SwitchTrue(true);
    }
    public void ToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    public void LaserGunChose()
    {
        PlayerController.weaponChoice = 1;
        gameObject.GetComponent<AudioSource>().PlayOneShot(weaponChoseLaserGun);
    }
    public void BlasterChose()
    {
        PlayerController.weaponChoice = 2;
        gameObject.GetComponent<AudioSource>().PlayOneShot(weaponChoseLaserGun);
    }
    public void HighscoreModeChose()
    {
        EnemySpawner.gameMode = 1;
        gameObject.GetComponent<AudioSource>().PlayOneShot(sound);
    }
    public void TimeModeChose()
    {
        EnemySpawner.gameMode = 2;
        gameObject.GetComponent<AudioSource>().PlayOneShot(sound);
    }
    public void CloseModeRedactor()
    {
        modeRedactor.SetActive(false);
    }
    public void OpenModeRedactor()
    {
        modeRedactor.SetActive(true);
    }
    public void SaveCheck()
    {
        _text.text = PlayerPrefs.GetInt("Highscore").ToString() + " points";
        _time.text = PlayerPrefs.GetFloat("BestTime").ToString() + " seconds";
    }
    public void OpenScoreTab()
    {
        scoreTab.SetActive(true);
    }
    public void CloseScoreTab()
    {
        scoreTab.SetActive(false);
    }

    public void StartTimeScale()
    {
        Time.timeScale = 1;
    }
}
