using GoCube.Domain.Provider;
using UnityEngine;

namespace GoCube.Presentation.JumpingEnemy
{
	public class RandomEnemySprite : MonoBehaviour {
		private const int BaseValue = 5;

		private void Start()
		{
			var currentLevel = ServiceProvider.ProvideExperience().CurrentLevel();
			GetComponent<Animator>().SetInteger("EnemyType", Random.Range(1, BaseValue + currentLevel));
		}
	}
}
