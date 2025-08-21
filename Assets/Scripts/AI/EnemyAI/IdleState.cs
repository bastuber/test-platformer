using UnityEngine;

namespace Assets.Scripts.AI.EnemyAI
{
    public class IdleState : AiState
    {
        public Transform IdlePosition { get; set; }

        public IdleState(EnemyAi enemyAi)
            : base(enemyAi)
        {

        }

        public override void OnPlayerDetected(GameObject player)
        {
            EnemyAi.SetState(EnemyState.FIGHTING);
        }

        public override void OnStateEntered(EnemyState previousState)
        {
            Debug.LogError("Not implemented");
        }

        public override void OnStateExited(EnemyState nextState)
        {
            Debug.LogError("Not implemented");
        }

        public override void Update(GameObject gameObject, float deltaTime)
        {
            Debug.LogError("Not implemented");
        }
    }
}
