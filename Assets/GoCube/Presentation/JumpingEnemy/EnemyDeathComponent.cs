using UnityEngine;

namespace GoCube.Presentation.JumpingEnemy
{
    public class EnemyDeathComponent : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            GetComponentInChildren<BoxCollider2D>().enabled = false;
        }
    }
}