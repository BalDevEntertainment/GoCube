using UnityEngine;

namespace GoCube.Presentation
{
	public class PlaySoundComponent : MonoBehaviour
	{
		private AudioSource _audioSource;

		private void Start()
		{
			_audioSource = GetComponent<AudioSource>();
		}

		public void PlaySound()
		{
			_audioSource.Play();
		}
	}
}
