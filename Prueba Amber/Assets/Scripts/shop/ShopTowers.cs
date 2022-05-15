using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopTowers : MonoBehaviour
{
    public  int PlayerSunCoins;

    public TMP_Text CoinsUI;
    // Start is called before the first frame update

    private void Start()
    {
        UpdateSunConis();
    }
    public void Addsuncoins(int _suncoins)
    {
        PlayerSunCoins += _suncoins;
        UpdateSunConis();
    }
    public void BuyTower(int towercost)
    {
        PlayerSunCoins -= towercost;
        UpdateSunConis();
    }

    public bool CanBuyTower(int towercost)
    {
        if (PlayerSunCoins >= towercost)
            return true;

        return false;
    }
    public void UpdateSunConis()
    {
        CoinsUI.text = "$ "+PlayerSunCoins.ToString();
    }
}
