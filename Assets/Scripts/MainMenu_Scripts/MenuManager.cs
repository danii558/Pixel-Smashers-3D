using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour
{
    [Header("Images")]

    public GameObject MenuBG_Image;
    public GameObject Store_Image;
    public GameObject Settings_Image;
    public GameObject LeaderBoard_Image;
    public GameObject Developers_Image;

    [Header("Buttons")]

    public Button Play_Button;

    public Button Store_Button;
    public Button StoreBack_Button;

    public Button Settings_Button;
    public Button SettingsBack_Button;

    public Button LeaderBoard_Button;
    public Button LeaderBoardBack_Button;

    public Button Developers_Button;
    public Button DevelopersBack_Button;
    


    void OnEnable()
    {
        // Подписка на событие завершения загрузки
        Loader.OnLoadingComplete += ShowMainMenu;
    }

    void OnDisable()
    {
        // Отписка от события
        Loader.OnLoadingComplete -= ShowMainMenu;
    }

    void Start()
    {
        Play_Button.onClick.AddListener(() =>
        {
            AudioManager.instance.PlaySFX("tap");
            StartGame();
        });


        Store_Button.onClick.AddListener(() =>
        {
            AudioManager.instance.PlaySFX("tap");
            ShowMenu(Store_Image);
        });

        StoreBack_Button.onClick.AddListener(() =>
        {
            AudioManager.instance.PlaySFX("tap");
            ShowMenu(MenuBG_Image);
        });


        Settings_Button.onClick.AddListener(() =>
        {
            AudioManager.instance.PlaySFX("tap");
            ShowMenu(Settings_Image);
        });

        SettingsBack_Button.onClick.AddListener(() =>
        {
            AudioManager.instance.PlaySFX("tap");
            ShowMenu(MenuBG_Image);
        });


        LeaderBoard_Button.onClick.AddListener(() =>
        {
            AudioManager.instance.PlaySFX("tap");
            ShowMenu(LeaderBoard_Image);
        });

        LeaderBoardBack_Button.onClick.AddListener(() =>
        {
            AudioManager.instance.PlaySFX("tap");
            ShowMenu(MenuBG_Image);
        });


        Developers_Button.onClick.AddListener(() =>
        {
            AudioManager.instance.PlaySFX("tap");
            ShowMenu(Developers_Image);
        });

        DevelopersBack_Button.onClick.AddListener(() =>
        {
            AudioManager.instance.PlaySFX("tap");
            ShowMenu(MenuBG_Image);
        });
    }

    private void StartGame()
    {
        SceneManager.LoadScene("Game_Scene");
    }

    void ShowMainMenu()
    {
        // Показываем главное меню после загрузки
        ShowMenu(MenuBG_Image);
    }

    void ShowMenu(GameObject menu)
    {
        // Отключаем все меню
        MenuBG_Image.SetActive(false);
        Store_Image.SetActive(false);
        Settings_Image.SetActive(false);
        LeaderBoard_Image.SetActive(false);
        Developers_Image.SetActive(false);

        // Включаем выбранное меню
        menu.SetActive(true);
    }

    //void ResetProgress()
    //{
    //    PlayerPrefs.DeleteAll();
    //}

}
