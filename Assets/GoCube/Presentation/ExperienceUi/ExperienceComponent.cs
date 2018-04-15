using GoCube.Domain.ExperienceEntity;
using GoCube.Domain.Provider;
using GoCube.Infraestructure.GameEntity;
using UnityEngine;
using UnityEngine.UI;

namespace GoCube.Presentation.ExperienceUi
{
	public class ExperienceComponent : MonoBehaviour, IExperienceUi
	{
		[SerializeField] private float _maxExp;
		private float _fillExperienceBarInSeconds;
		private Experience _experience;
		private bool _fillBar;
		private int _fillBarUntil;
		private Slider _experienceBar;
		private float _currentExperienceBarValue;
		private float _acumulatedTime;

		private void Awake()
		{
			_experience = new Experience(_maxExp, this, ServiceProvider.ProvideScore(),
				GameObject.FindWithTag("GameManager").GetComponent<GameManagerComponent>());
			_experienceBar = GetComponentInChildren<Slider>();
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

		private void RiseExperienceBarValue()
		{
			var experienceBarValue = Mathf.Lerp(0, _fillBarUntil, _acumulatedTime / _fillExperienceBarInSeconds);
			_experienceBar.value = experienceBarValue/ _maxExp ;
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
