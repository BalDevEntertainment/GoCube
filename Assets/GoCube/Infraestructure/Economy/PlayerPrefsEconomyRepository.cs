using GoCube.Domain.Economy;
using UnityEngine;

namespace GoCube.Infraestructure.Economy {

    public class PlayerPrefsEconomyRepository : EconomyRepository{
        public PlayerEconomy Find() {
            var coins = PlayerPrefs.GetInt("coins");
            return new PlayerEconomy(coins);
        }

        public void Save(PlayerEconomy economy) {
            PlayerPrefs.SetInt("coins", economy.Coins);
        }
    }
}