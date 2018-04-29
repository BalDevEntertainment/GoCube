using GoCube.Domain.ExperienceEntity;
using GoCube.Domain.Provider;
using UnityEngine;

namespace GoCube.Presentation.ComingNextUi
{
	public class ComingNextComponent : MonoBehaviour {
		[SerializeField] private float _timeToShow;
		private ExperienceService _experienceService;
		private bool _showBoogerBat;
		private CanvasGroup _alpha;
		private float _acumulatedTime;

		private void Awake()
		{
			_experienceService = ServiceProvider.ProvideExperience();
			_experienceService.OnNextLevelReached += NextLevelReached;
			_alpha = GetComponent<CanvasGroup>();
			_alpha.alpha = 0;
		}

		private void Update()
		{
			if (!_showBoogerBat) return;
			_acumulatedTime += Time.deltaTime;
			_alpha.alpha = Mathf.Lerp(0, 1, _acumulatedTime / _timeToShow);
		}

		private void NextLevelReached()
		{
			if (_experienceService.GetCurrentExperienceViewModel().EnemiesUnlocked >= 1)
			{
				ShowBoogerBat();
			}
			else
			{
				if(_alpha != null ) _alpha.alpha = 0;
			}
		}

		private void ShowBoogerBat()
		{
			_showBoogerBat = true;
		}
	}
}
