using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyBar : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public MoneyHolder moneyHolder;

    private void Start()
    {
        moneyHolder.onCoinsChange.AddListener(changeCoins);
    }

    private void changeCoins(int coins)
    {
        moneyText.text = coins.ToString();
    }
}