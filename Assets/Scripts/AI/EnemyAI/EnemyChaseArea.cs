using Assets.Scripts.AI.EnemyAI;
using UnityEngine;

namespace Assets.Scripts.AI.EnemyAI
{
    public class EnemyChaseArea : MonoBehaviour
    {
        private EnemyAi _enemyAi;

        private void Awake()
        {
            _enemyAi = transform.parent.GetComponent<EnemyAi>();
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            if (collider.tag == "Player")
            {
                _enemyAi.OnPlayerOutOfView(collider);
            }
        }
    }
}
