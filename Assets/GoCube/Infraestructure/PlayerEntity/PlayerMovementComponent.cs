using GoCube.Domain.PlayerEntity;
using UnityEngine;

namespace GoCube.Infraestructure.PlayerEntity
{
    public class PlayerMovementComponent : MonoBehaviour, IMovement
    {
        public GameObject NextPositionMarker;
        private Vector3 _destination;
        private float _acumulatedTimed;
        private Rigidbody2D _rigidBody;

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
            _destination = _rigidBody.position;
        }

        public void Jump()
        {
            _destination = new Vector3(NextPositionMarker.transform.position.x,
                transform.position.y,
                transform.position.z);
            _acumulatedTimed = 0f;
        }

        private void Update()
        {
            if (_acumulatedTimed < 1f)
            {
                _rigidBody.MovePosition(Vector3.Lerp(_rigidBody.position, _destination,
                    _acumulatedTimed));
                _acumulatedTimed += Time.deltaTime;
            }
        }
    }
}