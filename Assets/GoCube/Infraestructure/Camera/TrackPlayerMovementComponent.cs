using UnityEngine;

namespace GoCube.Infraestructure.Camera
{
	public class TrackPlayerMovementComponent : MonoBehaviour
	{
		[SerializeField] private SmoothDampCameraComponent _cameraComponent;

		private void OnTriggerEnter2D(Collider2D other)
		{
			_cameraComponent.FollowPlayer();
		}
	}
}
