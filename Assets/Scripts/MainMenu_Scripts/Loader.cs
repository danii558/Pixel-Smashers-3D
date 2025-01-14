using UnityEngine;
using System;
using System.Collections;

public class Loader : MonoBehaviour
{
    public GameObject loadingImage;     // ������ ������������ ������ � ��������� ��������
    public GameObject menuImage;        // ������ �������� ����
    public GameObject spinner;          // ������ ��������, ������� ����� ���������

    public static event Action OnLoadingComplete; // ������� ���������� ��������

    private float loadingTime = 3f;   // ����� �������� �������� � �������� (3 ������)
    private float rotationSpeed = 200f; // �������� �������� ��������

    void Start()
    {
        // �������� ����������� �����, ��������� ������� ����
        loadingImage.SetActive(true);
        menuImage.SetActive(false);

        // ��������� �������� ��� ��������� ��������
        StartCoroutine(LoadGame());
    }

    void Update()
    {
        // ������� �������
        if (spinner != null)
        {
            spinner.transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }

    IEnumerator LoadGame()
    {
        // ���� ��������� �����
        yield return new WaitForSeconds(loadingTime);

        // ��������� ����������� �����, �������� ������� ���� � �������� ������� ���������� ��������
        loadingImage.SetActive(false);
        menuImage.SetActive(true);

        OnLoadingComplete?.Invoke();  // �������� ������� ���������� ��������
    }
}
