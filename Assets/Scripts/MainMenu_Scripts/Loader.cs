using UnityEngine;
using System;
using System.Collections;

public class Loader : MonoBehaviour
{
    public GameObject loadingImage;     // Объект загрузочного экрана с анимацией спиннера
    public GameObject menuImage;        // Объект главного меню
    public GameObject spinner;          // Объект спиннера, который будет вращаться

    public static event Action OnLoadingComplete; // Событие завершения загрузки

    private float loadingTime = 3f;   // Время ожидания загрузки в секундах (3 минуты)
    private float rotationSpeed = 200f; // Скорость вращения спиннера

    void Start()
    {
        // Включаем загрузочный экран, выключаем главное меню
        loadingImage.SetActive(true);
        menuImage.SetActive(false);

        // Запускаем корутину для симуляции загрузки
        StartCoroutine(LoadGame());
    }

    void Update()
    {
        // Вращаем спиннер
        if (spinner != null)
        {
            spinner.transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }

    IEnumerator LoadGame()
    {
        // Ждем указанное время
        yield return new WaitForSeconds(loadingTime);

        // Отключаем загрузочный экран, включаем главное меню и вызываем событие завершения загрузки
        loadingImage.SetActive(false);
        menuImage.SetActive(true);

        OnLoadingComplete?.Invoke();  // Вызываем событие завершения загрузки
    }
}
