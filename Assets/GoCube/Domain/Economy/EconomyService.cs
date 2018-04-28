using System;

namespace GoCube.Domain.Economy {
    public class EconomyService {

        private readonly EconomyRepository _economyRepository;
        public event Action<int> CoinsChanged = delegate {  };

        public EconomyService(EconomyRepository economyRepository) {
            _economyRepository = economyRepository;
        }

        public void IncrementCoins(int quantiy) {
            var economy = _economyRepository.Find();
            economy.IncrementCoins(quantiy);
            _economyRepository.Save(economy);
            CoinsChanged(economy.Coins);
        }

        public int QuantityCoins() {
            return _economyRepository.Find().Coins;
        }
    }
}