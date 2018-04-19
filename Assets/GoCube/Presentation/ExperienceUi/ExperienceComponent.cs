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
		private Experience _experience;
		private FillBarMethod _fillBarMethod = FillBarMethod.None;
		private Slider _experienceBar;
		private float _acumulatedTime;
		private ExperienceViewModel _currentExperienceViewModel;
		private ExperienceViewModel _newExperienceViewModel;

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

		public void UpdateExperienceBar(ExperienceViewModel experienceViewModel)
		{
			_level.Setlevel(experienceViewModel.CurrentLevel);
			_experienceBar.value = (float) experienceViewModel.CurrentExperience / experienceViewModel.NextLevelRequirement;
			_currentExperienceViewModel = experienceViewModel;
		}

		public void FillExperienceBar(ExperienceViewModel newExperienceViewModel)
		{
			_acumulatedTime = 0;
			_newExperienceViewModel = newExperienceViewModel;
			if (!HasGainedALevel(newExperienceViewModel))
			{
				_fillBarMethod = FillBarMethod.RiseCurrentLevel;
			}
			else
			{
				_fillBarMethod = FillBarMethod.CompleteCurrentLevel;
			}
		}

		private bool HasGainedALevel(ExperienceViewModel newExperienceViewModel)
		{
			return _currentExperienceViewModel.CurrentLevel < newExperienceViewModel.CurrentLevel;
		}

		private void Update()
		{
			if (_fillBarMethod == FillBarMethod.None) return;
			_acumulatedTime += Time.deltaTime;

			switch (_fillBarMethod)
			{
				case FillBarMethod.RiseCurrentLevel:
					RiseExperienceBarCurrentLevel();
					break;
				case FillBarMethod.CompleteCurrentLevel:
					RiseExperienceBarToCompleteCurrentLevel();
					break;
				case FillBarMethod.None:
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private void RiseExperienceBarCurrentLevel()
		{
			_experienceBar.value = Mathf.Lerp(
				(float) _currentExperienceViewModel.CurrentExperience / _currentExperienceViewModel.NextLevelRequirement,
				(float) _newExperienceViewModel.CurrentExperience / _newExperienceViewModel.NextLevelRequirement,
				_acumulatedTime);

			if (HasReachedDesiredValue())
			{
				_currentExperienceViewModel = _newExperienceViewModel;
				_fillBarMethod = FillBarMethod.None;
			}
		}

		private void RiseExperienceBarToCompleteCurrentLevel()
		{
			_experienceBar.value = Mathf.Lerp(
				(float) _currentExperienceViewModel.CurrentExperience / _currentExperienceViewModel.NextLevelRequirement,
				1,
				_acumulatedTime * 2);
			if (HasReachedMaxValue())
			{
				_level.IncreaseLevel();
				_acumulatedTime = 0;
				_currentExperienceViewModel = new ExperienceViewModel(0,
					_newExperienceViewModel.NextLevelRequirement, _newExperienceViewModel.CurrentLevel,
					_newExperienceViewModel.EnemiesUnlocked);
				_fillBarMethod = FillBarMethod.RiseCurrentLevel;
			}
		}

		private bool HasReachedDesiredValue()
		{
			return Math.Abs(_experienceBar.value - (float) _newExperienceViewModel.CurrentExperience /
			                _newExperienceViewModel.NextLevelRequirement) < Tolerance;
		}

		private bool HasReachedMaxValue()
		{
			return Math.Abs(_experienceBar.value - 1) < Tolerance;
		}

		private void OnDestroy()
		{
			_experience.Destroy();
		}
	}

	enum FillBarMethod
	{
		CompleteCurrentLevel, RiseCurrentLevel, None
	}
}

