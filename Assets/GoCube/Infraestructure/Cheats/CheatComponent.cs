using GoCube.Domain.Provider;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GoCube.Infraestructure.Cheats
{
	public class CheatComponent : MonoBehaviour {

		void Update () {
			if (Input.GetKeyDown(KeyCode.Q))
			{
				ServiceProvider.ProvideScore().IncrementScore(10);
			}

			if (Input.GetKeyDown(KeyCode.P))
			{
				PlayerPrefs.DeleteAll();
				SceneManager.LoadScene("MainScene");
			}
		}
	}
}
