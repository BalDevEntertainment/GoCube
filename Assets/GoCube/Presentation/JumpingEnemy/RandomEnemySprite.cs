using GoCube.Domain.Provider;
using UnityEngine;

namespace GoCube.Presentation.JumpingEnemy
{
	public class RandomEnemySprite : MonoBehaviour {
		private const int BaseValue = 5;

		private void Start()
		{
			var currentLevel = ServiceProvider.ProvideExperience().GetCurrentExperienceViewModel().CurrentLevel;
			var range = Random.Range(1, BaseValue + currentLevel);
			GetComponent<Animator>().SetInteger("EnemyType", Mathf.Min(range, 6));
		}
	}
}
