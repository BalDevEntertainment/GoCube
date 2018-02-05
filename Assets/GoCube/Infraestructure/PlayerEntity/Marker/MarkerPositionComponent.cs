using UnityEngine;

namespace GoCube.Infraestructure.PlayerEntity.Marker
{
	public class MarkerPositionComponent : MonoBehaviour
	{
		[SerializeField]
		private int _speed = 5;
		[SerializeField]
		private float _originDistance = 1;
		[SerializeField]
		private float _destinationDistance = 3;
		private MarkerDirection _direction = MarkerDirection.Right();

		private void Update()
		{
			transform.Translate(_direction * _speed * Time.deltaTime, 0, 0);
			_direction = CalculateMarkerDirection();
		}

		private MarkerDirection CalculateMarkerDirection()
		{
			if (transform.localPosition.x > _destinationDistance)
			{
				return MarkerDirection.Left();
			}
			if (transform.localPosition.x < _originDistance)
			{
				return MarkerDirection.Right();
			}
			return _direction;
		}

		public void Stop()
		{
			_direction = MarkerDirection.None();
		}

		public void Resume()
		{
			_direction = CalculateMarkerDirection();
		}
	}
}
