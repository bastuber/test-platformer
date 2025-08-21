using System.Runtime.CompilerServices;
using UnityEngine;

namespace Assets.Scripts.AI.EnemyAI
{
    public class AiState
    {
        // Ai property
        protected EnemyAi EnemyAi;
        
        //Constructor
        public AiState(EnemyAi enemyAi)
        {
            EnemyAi = enemyAi;
        }

        public virtual void OnPlayerDetected(GameObject player)
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

        public virtual void Update(GameObject gameObject, float deltaTime)
        {
            Debug.LogError("Not implemented");
        }
    }
}
