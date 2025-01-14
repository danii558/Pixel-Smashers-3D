using System;
using UnityEngine;

public static class CoinManager
{
    private static int coins;

    // ������� ��� ����������� �� ��������� ���������� �����
    public static event Action<int> OnCoinsChanged;

    static CoinManager()
    {
        // �������� ���������� ����� �� PlayerPrefs
        coins = PlayerPrefs.GetInt("Coins", 500);  // ��������� ��������
    }

    public static int Coins
    {
        get => coins;
        private set
        {
            coins = value;
            PlayerPrefs.SetInt("Coins", coins); // ��������� ����� ��������
            PlayerPrefs.Save();
            OnCoinsChanged?.Invoke(coins); // �������� ������� ��� ���������� UI
        }
    }

    // ����� ��� ���������� �����
    public static void AddCoins(int amount)
    {
        Coins += amount;
    }

    // ����� ��� �������� �����
    public static bool SpendCoins(int amount)
    {
        if (coins >= amount)
        {
            Coins -= amount;
            return true;
        }
        else
        {
            Debug.Log("������������ �����!");
            return false;
        }
    }
}
