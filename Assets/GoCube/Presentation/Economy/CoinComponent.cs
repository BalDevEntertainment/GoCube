using GoCube.Domain.Economy;
using GoCube.Domain.Provider;
using UnityEngine;

namespace GoCube.Presentation.Economy
{
    public class CoinComponent : MonoBehaviour
    {
        private EconomyService _economyService;
        private AudioSource _audioSource;

        public void OnCollectedAnimationFinished()
        {
            Destroy(gameObject);
        }

        private void Start()
        {
            _economyService = ServiceProvider.ProvideEconomy();
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _economyService.IncrementCoins(1);
            if (other.transform.parent.CompareTag("Player"))
            {
                _audioSource.Play();
                GetComponent<Animator>().SetTrigger("Collected");
            }
        }
    }
}