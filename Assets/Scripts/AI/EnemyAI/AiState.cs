using System.Runtime.CompilerServices;
using UnityEngine;

namespace Assets.Scripts.AI.EnemyAI
{
    public class AiState : MonoBehaviour
    {
        // Ai property
        protected EnemyAi EnemyAiBehaviour;

        private void Awake()
        {
            EnemyAiBehaviour = GetComponent<EnemyAi>();
        }

        protected virtual void InitializeState()
        {

        }

        public virtual void OnPlayerDetected(GameObject player)
        {
            Debug.LogError("Not implemented");
        }

        public virtual void OnPlayerLost(GameObject player)
        {
            Debug.LogError("Not implemented");
        }

        public virtual void OnStateEntered(EnemyState previousState)
        {
            Debug.LogError("Not implemented");
        }

        public virtual void OnStateExited(EnemyState nextState)
        {
            Debug.LogError("Not implemented");
        }
    }
}
