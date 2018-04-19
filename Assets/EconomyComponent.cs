using System.Collections;
using System.Collections.Generic;
using GoCube.Domain.Provider;
using UnityEngine;
using UnityEngine.UI;

public class EconomyComponent : MonoBehaviour {

    public Text Coins;

    private void Start() {
        var economyService = ServiceProvider.ProvideEconomy();
        Coins.text = economyService.QuantityCoins().ToString();
        economyService.CoinsChanged += OnCoinsChanged;
    }

    private void OnCoinsChanged(int quantity) {
        Coins.text = quantity.ToString();
    }
}
