using UnityEngine;

namespace GoCube.Infraestructure.PlayerEntity
{
	public class TargetPositionComponent : MonoBehaviour
	{
		[SerializeField]
		private int _speed = 5;
		[SerializeField]
		private float _distance = 3;
		private int _direction = 1;

		private void Update()
		{
			transform.Translate(_direction * _speed * Time.deltaTime, 0, 0);

			if (transform.localPosition.x > _distance)
			{
				_direction = -1;
			}
			else if (transform.localPosition.x < 1)
			{
				_direction = 1;
			}
		}
	}
}
