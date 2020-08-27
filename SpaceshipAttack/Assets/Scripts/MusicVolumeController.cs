using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeController : MonoBehaviour
{
    public Slider musicSlider;
    public AudioSource player, enemy1, mainTheme;
    void Start()
    {
        if (!PlayerPrefs.HasKey("MusicVolume"))
            PlayerPrefs.SetInt("MusicVolume", 6);
        musicSlider.value = PlayerPrefs.GetInt("MusicVolume");
        GameObject enemy = GameObject.FindWithTag("Enemy");
        enemy1 = enemy.GetComponent<AudioSource>();
    }
    void Update()
    {
        PlayerPrefs.SetInt("MusicVolume", (int) musicSlider.value);
        player.volume = (float) PlayerPrefs.GetInt("MusicVolume") / 9;
        enemy1.volume = (float)PlayerPrefs.GetInt("MusicVolume") / 9;
        mainTheme.volume = (float)PlayerPrefs.GetInt("MusicVolume") / 9;

    }
}
