using System;
using UnityEngine;
using UnityEngine.Events;

public class Store : MonoBehaviour
{
    public MoneyHolder moneyHolder;
    public UnityEvent<StoreItem> onBuy = new();
    public StoreItem[] items = new StoreItem[2];
    public StoreSlot[] slots;
    public GameObject placeCursorPrefab;

    private void Start()
    {
        slots = GetComponentsInChildren<StoreSlot>();
        foreach (var slot in slots) slot.bindStore(this);
        moneyHolder.onCoinsChange.AddListener(canBuyCheck);

        onBuy.AddListener((item) => moneyHolder.spend(item.cost));
        onBuy.AddListener(createPlaceCursor);
    }

    private void createPlaceCursor(StoreItem item)
    {
        var cursor = Instantiate(placeCursorPrefab);

        cursor.GetComponent<PlaceCursor>().setItem(item);
    }

    public void canBuyCheck(int coins)
    {
        foreach (var slot in slots) slot.canBuyCheck(coins);
    }
}