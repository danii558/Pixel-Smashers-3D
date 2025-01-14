using System;
using UnityEngine;

public static class CoinManager
{
    private static int coins;

    // Событие для уведомления об изменении количества монет
    public static event Action<int> OnCoinsChanged;

    static CoinManager()
    {
        // Загрузка количества монет из PlayerPrefs
        coins = PlayerPrefs.GetInt("Coins", 500);  // начальное значение
    }

    public static int Coins
    {
        get => coins;
        private set
        {
            coins = value;
            PlayerPrefs.SetInt("Coins", coins); // Сохраняем новое значение
            PlayerPrefs.Save();
            OnCoinsChanged?.Invoke(coins); // Вызываем событие для обновления UI
        }
    }

    // Метод для добавления монет
    public static void AddCoins(int amount)
    {
        Coins += amount;
    }

    // Метод для списания монет
    public static bool SpendCoins(int amount)
    {
        if (coins >= amount)
        {
            Coins -= amount;
            return true;
        }
        else
        {
            Debug.Log("Недостаточно монет!");
            return false;
        }
    }
}
