using GoCube.Domain.Economy;
using GoCube.Domain.Provider;
using UnityEngine;

namespace GoCube.Presentation.Economy {
	public class CoinComponent : MonoBehaviour {

		private EconomyService economyService;

		private void Start()
		{
			economyService = ServiceProvider.ProvideEconomy();
		}

		private void OnTriggerEnter2D(Collider2D other) {
			economyService.IncrementCoins(1);
			Destroy(gameObject);
		}
	}
}
