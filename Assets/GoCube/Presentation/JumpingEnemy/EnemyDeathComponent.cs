using UnityEngine;

namespace GoCube.Presentation.JumpingEnemy
{
    public class EnemyDeathComponent : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}