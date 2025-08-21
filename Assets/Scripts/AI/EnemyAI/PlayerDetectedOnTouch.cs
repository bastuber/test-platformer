
using UnityEngine;

namespace Assets.Scripts.AI.EnemyAI
{
    public class PlayerDetectedOnTouch : MonoBehaviour
    {
        private EnemyAi _enemyAi;

        private void Awake()
        {
            _enemyAi = transform.parent.GetComponent<EnemyAi>();
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if(collider.tag == "Player")
            {
                _enemyAi.OnTouchingPlayer(collider);
            }
        }
    }
}
