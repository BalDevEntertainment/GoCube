using GoCube.Domain.Provider;
using UnityEngine;

namespace GoCube.Presentation.JumpingEnemy
{
	public class RandomEnemySprite : MonoBehaviour {
		private const int BaseValue = 6;

		private void Start()
		{
			var unlockedEnemies = ServiceProvider.ProvideExperience().GetCurrentExperienceViewModel().EnemiesUnlocked;
			var range = Random.Range(1, Mathf.Min(BaseValue + unlockedEnemies, 7));
			GetComponent<Animator>().SetInteger("EnemyType", range);
		}
	}
}
