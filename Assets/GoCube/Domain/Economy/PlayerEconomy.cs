namespace GoCube.Domain.Economy {

    public class PlayerEconomy {

        public int Coins { get; private set; }

        public PlayerEconomy(int coins) {
            this.Coins = coins;
        }

        public void IncrementCoins(int quantiy) {
            Coins += quantiy;
        }
    }
}