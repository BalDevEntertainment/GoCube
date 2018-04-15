using System;
using GoCube.Domain.ExperienceEntity;
using GoCube.Domain.Provider;
using GoCube.Infraestructure.GameEntity;
using UnityEngine;
using UnityEngine.UI;

namespace GoCube.Presentation.ExperienceUi
{
	public class ExperienceComponent : MonoBehaviour, IExperienceUi
	{
		[SerializeField] private LevelComponent _level;
		private const float Tolerance = 0.01f;
		private float _fillExperienceBarInSeconds;
		private Experience _experience;
		private bool _fillBar;
		private int _fillBarUntil;
		private Slider _experienceBar;
		private float _currentExperienceBarValue;
		private float _acumulatedTime;
		private int _experienceNeededForNextLevel;
		private float _previousValue;

		private void Awake()
		{
			_experience = new Experience(this, ServiceProvider.ProvideScore(),
				ServiceProvider.ProvideExperience(),
				GameObject.FindWithTag("GameManager").GetComponent<GameManagerComponent>());
			_experienceBar = GetComponentInChildren<Slider>();
			_experienceNeededForNextLevel = _experience.NextLevelRequirement();
		}

		private void Update()
		{
			if (!_fillBar) return;
			_acumulatedTime += Time.deltaTime;
			if (HasReachedFillTime())
			{
				ResetFilling();
			}
			else
			{
				RiseExperienceBarValue();
			}
		}

		public void FillExperienceBar(int amount, float inSeconds)
		{
			_fillBar = true;
			_fillBarUntil = amount;
			_fillExperienceBarInSeconds = inSeconds;
		}

		public void NextLevelReached()
		{
			Debug.Log("NextLevelReached!!!!");
		}

		public void SetExperienceBarValue(int value)
		{
			_experienceBar.value = (float) value / _experienceNeededForNextLevel;
			_previousValue = _experienceBar.value;
		}

		public void SetLevel(int currentLevel)
		{
			_level.Setlevel(currentLevel);
		}

		private void RiseExperienceBarValue()
		{
			_experienceBar.value = Mathf.Lerp(_previousValue, _previousValue + (float) _fillBarUntil / _experienceNeededForNextLevel, _acumulatedTime / _fillExperienceBarInSeconds);
			if (HasBarReachedMaxValue())
			{
				SetExperienceBarValue(0);
				_level.IncreaseLevel();
				_experienceNeededForNextLevel = _experience.NextLevelRequirement();
			}
		}

		private bool HasBarReachedMaxValue()
		{
			return Math.Abs(_experienceBar.value - 1) < Tolerance;
		}

		private void OnDestroy()
		{
			_experience.Destroy();
		}

		private bool HasReachedFillTime()
		{
			return _acumulatedTime > _fillExperienceBarInSeconds;
		}

		private void ResetFilling()
		{
			_fillBar = false;
			_acumulatedTime = 0;
		}
	}
}
