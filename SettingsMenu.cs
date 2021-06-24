using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    private void Start()
    {
        SetVolume(PlayerPrefs.GetFloat("vol"));
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("masterVolume", volume);
        PlayerPrefs.SetFloat("vol", volume);
        PlayerPrefs.Save();
    }

    public void OnSettingsLoad()
    {
        GameObject.Find("VolumeSlider").GetComponent<Slider>().value = PlayerPrefs.GetFloat("vol");
    }
}
