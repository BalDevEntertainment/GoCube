using GoCube.Domain.Provider;
using UnityEngine;

namespace GoCube.Infraestructure.Cheats
{
	public class CheatComponent : MonoBehaviour {

		void Update () {
			if (Input.GetKeyDown(KeyCode.Q))
			{
				ServiceProvider.ProvideScore().IncrementScore(1);
			}
		}
	}
}
