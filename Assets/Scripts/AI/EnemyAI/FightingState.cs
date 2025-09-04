using UnityEngine;

namespace Assets.Scripts.AI.EnemyAI
{
    public class FightingState : AiState
    {
        public FightingState(EnemyAi enemyAi)
            : base(enemyAi)
        {

        }


        public override void OnPlayerDetected(GameObject player)
        {
            Debug.LogError("Not implemented");
        }

        public override void OnStateEntered(EnemyState previousState)
        {
            Debug.LogError("Not implemented");
        }

        public override void OnStateExited(EnemyState nextState)
        {
            Debug.LogError("Not implemented");
        }
    }
}