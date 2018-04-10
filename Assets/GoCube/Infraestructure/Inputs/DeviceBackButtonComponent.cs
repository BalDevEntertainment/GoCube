
using UnityEngine;

namespace GoCube.Infraestructure.Inputs
{
	public class DeviceBackButtonComponent : MonoBehaviour {

		void Update () {
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				Application.Quit();
			}
		}
	}
}
