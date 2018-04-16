using UnityEngine;
using UnityEngine.UI;

namespace GoCube.Presentation.ExperienceUi
{
	public class LevelComponent : MonoBehaviour {
		private int _level;
		private Text _text;

		private void Awake()
		{
			_text = GetComponent<Text>();
		}

		public void Setlevel(int level)
		{
			_level = level;
			_text.text = _level.ToString();
		}

		public void IncreaseLevel()
		{
			Setlevel(_level + 1);
		}
	}
}
