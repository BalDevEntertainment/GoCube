using UnityEngine;

namespace GoCube.Infraestructure.Background
{
	public class BackgroundComponent : MonoBehaviour
	{

		[SerializeField] private UnityEngine.Camera _camera;
		[SerializeField] private float _speed = 1f;
		private Renderer _rendererComponent;

		private void Start()
		{
			_rendererComponent = GetComponent<Renderer>();
		}

		void Update ()
		{
			var xOffset = _camera.transform.position.x;
			var offset = new Vector2(xOffset * _speed , 0);
			_rendererComponent.sharedMaterial.SetTextureOffset("_MainTex", offset);
		}
	}
}
