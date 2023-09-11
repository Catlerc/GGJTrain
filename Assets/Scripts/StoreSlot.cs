using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreSlot : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI text;
    public StoreItem item;
    public Store store;
    public bool canBuy = false;
    public AudioSource clickSound;


    private void Start()
    {
        clickSound = GetComponent<AudioSource>();
        text.text = item.cost.ToString();
        image.sprite = item.sprite;
    }

    public void bindStore(Store store)
    {
        this.store = store;
        canBuyCheck(0);
    }

    public void canBuyCheck(int coins)
    {
        canBuy = store.moneyHolder.canSpend(item.cost);
        if (canBuy)
            image.color = Color.white;
        else
            image.color = Color.gray;
    }

    public void buy()
    {
        if (canBuy)
        {
            store.onBuy.Invoke(item);
            clickSound.Play();
        }
    }
}