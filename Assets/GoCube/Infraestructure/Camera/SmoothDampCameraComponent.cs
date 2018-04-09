using UnityEngine;

namespace GoCube.Infraestructure.Camera
{
    public class SmoothDampCameraComponent : MonoBehaviour
    {
        public Transform Target;
        public float SmoothTime = 0.3F;
        private Vector3 _velocity = Vector3.zero;
        [SerializeField]private int _offset;

        private void Start()
        {
            enabled = false;
        }

        void Update()
        {
            Vector3 targetPosition = Target.TransformPoint(new Vector3(_offset, -Target.position.y, transform.position.z));
            transform.position =
                Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, SmoothTime);
        }

        public void FollowPlayer()
        {
            enabled = true;
        }
    }
}