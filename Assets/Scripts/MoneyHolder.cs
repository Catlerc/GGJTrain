using UnityEngine;
using UnityEngine.Events;

public class MoneyHolder : MonoBehaviour
{
    public int coins;
    public UnityEvent<int> onCoinsChange = new();


    public bool canSpend(int amount) => coins >= amount;

    public bool spend(int amount)
    {
        if (coins >= amount)
        {
            coins -= amount;
            onCoinsChange.Invoke(coins);
            return true;
        }
        else
            return false;
    }

    public void add(int amount)
    {
        coins += amount;
        onCoinsChange.Invoke(coins);
    }

    private void Update()
    {
        if (Input.GetKeyDown("q")) add(10); // TODO: нужно только для теста. удалить при рабочих противниках
    }
}