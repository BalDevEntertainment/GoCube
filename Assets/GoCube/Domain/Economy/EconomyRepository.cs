namespace GoCube.Domain.Economy {
    public interface EconomyRepository {
        PlayerEconomy Find();
        void Save(PlayerEconomy economy);
    }
}