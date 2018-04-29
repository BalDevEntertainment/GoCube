using GoCube.Domain.Provider;
using UnityEngine;

namespace GoCube.Presentation.JumpingEnemy
{
	public class RandomEnemySprite : MonoBehaviour {
		private const int BaseValue = 5;

		private void Start()
		{
			var currentLevel = ServiceProvider.ProvideExperience().GetCurrentExperienceViewModel().CurrentLevel;
			var range = Random.Range(1, Mathf.Min(BaseValue + currentLevel, 7));
			GetComponent<Animator>().SetInteger("EnemyType", range);
		}
	}
}
