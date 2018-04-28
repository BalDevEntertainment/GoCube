using GoCube.Domain.Economy;
using GoCube.Domain.Provider;
using UnityEngine;
using UnityEngine.UI;

namespace GoCube.Presentation.Economy {
    public class EconomyComponent : MonoBehaviour {

        [SerializeField]
        public Text Coins;

        private EconomyService economyService;

        private void Awake() {
            economyService = ServiceProvider.ProvideEconomy();
            Coins.text = economyService.QuantityCoins().ToString();
            economyService.CoinsChanged += OnCoinsChanged;
        }

        private void OnCoinsChanged(int quantity) {
            Coins.text = quantity.ToString();
        }

        private void OnDestroy() {
            economyService.CoinsChanged -= OnCoinsChanged;
        }
    }
}
