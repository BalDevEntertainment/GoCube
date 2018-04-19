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
		public event Action OnUiLoaded = delegate {  };
		[SerializeField] private LevelComponent _level;
		private const float Tolerance = 0.01f;
		private float _fillExperienceBarInSeconds;
		private Experience _experience;
		private bool _fillBar;
		private int _fillBarUntil;
		private Slider _experienceBar;
		private float _currentExperienceBarValue;
		private float _acumulatedTime;
		private float _previousValue;
		private int _experienceRequiredForNextLevel;

		private void Awake()
		{
			_experienceBar = GetComponentInChildren<Slider>();
			_experience = new Experience(this, ServiceProvider.ProvideScore(),
				ServiceProvider.ProvideExperience(),
				GameObject.FindWithTag("GameManager").GetComponent<GameManagerComponent>());
		}

		private void Start()
		{
			OnUiLoaded.Invoke();
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

		public void FillExperienceBar(int amount, int experienceRequiredForNextLevel, float inSeconds)
		{
			_fillBar = true;
			_fillBarUntil = amount;
			_fillExperienceBarInSeconds = inSeconds;
			_experienceRequiredForNextLevel = experienceRequiredForNextLevel;
		}

		public void NextLevelReached()
		{
			Debug.Log("NextLevelReached!!!!");
		}

		public void SetExperienceBarValue(int currentExperience, int experienceRequirement)
		{
			_experienceBar.value = (float) currentExperience / experienceRequirement;
			_previousValue = _experienceBar.value;
		}

		public void SetLevel(int currentLevel)
		{
			_level.Setlevel(currentLevel);
		}

		private void RiseExperienceBarValue()
		{
			_experienceBar.value = Mathf.Lerp(_previousValue, _previousValue + (float) _fillBarUntil / _experienceRequiredForNextLevel, _acumulatedTime / _fillExperienceBarInSeconds);
			if (HasBarReachedMaxValue())
			{
				SetExperienceBarValue(0, _experienceRequiredForNextLevel);
				_level.IncreaseLevel();
				_experienceRequiredForNextLevel = _experience.NextLevelRequirement();
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
