using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsMenu : MonoBehaviour
{
    [Header("UI Elements")]
    public Slider musicSlider;
    public Slider sfxSlider;

    private void Start()
    {
        // ������������� ��������� ���������� �� 0 �� 100
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 100f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 100f);

        // ��������� ���������� ��� ���������� ��������� ��� ��������� ���������
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void SetMusicVolume(float volume)
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.SetMusicVolume(volume); // �������� �������� �� 0 �� 100
        }
    }

    public void SetSFXVolume(float volume)
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.SetSFXVolume(volume); // �������� �������� �� 0 �� 100
        }
    }
}
