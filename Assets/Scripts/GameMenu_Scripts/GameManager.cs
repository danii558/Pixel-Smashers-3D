using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button BackToMenu_Button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BackToMenu_Button.onClick.AddListener(() =>
        {
            //AudioManager.instance.PlaySFX("tap");
            BackToMenu();
        });
    }

    private void BackToMenu()
    {
        SceneManager.LoadScene("Menu_Scene");
    }
}
