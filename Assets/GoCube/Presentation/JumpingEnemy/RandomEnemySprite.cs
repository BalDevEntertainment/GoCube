using UnityEngine;

namespace GoCube.Presentation.JumpingEnemy
{
	public class RandomEnemySprite : MonoBehaviour {
		private void Start()
		{
			GetComponent<Animator>().SetInteger("EnemyType", Random.Range(1,6));
		}
	}
}
