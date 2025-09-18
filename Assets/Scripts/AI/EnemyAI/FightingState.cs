using UnityEngine;

namespace Assets.Scripts.AI.EnemyAI
{
    public class FightingState : AiState
    {
        public float Speed = 60;

        public override void OnPlayerDetected(GameObject player)
        {
            Debug.LogError("Not implemented");
        }

        public override void OnPlayerLost(GameObject player)
        {
            EnemyAiBehaviour.SetState(EnemyState.IDLE);
        }

        public override void OnStateEntered(EnemyState previousState)
        {
            
        }

        public override void OnStateExited(EnemyState nextState)
        {
            Debug.LogError("Not implemented");
        }

        private void FixedUpdate()
        {
            var player = EnemyAiBehaviour.GetDetectedPlayer();
            if(player == null)
            {
                EnemyAiBehaviour.SetState(EnemyState.IDLE);
                return;
            }


            Vector3 direction = player.transform.position - transform.position;
            direction = direction.normalized;

            Vector3 move = direction * Speed * Time.fixedDeltaTime;

            var rigidBody = GetComponent<Rigidbody2D>();
            rigidBody.linearVelocityX = move.x;
        }

    }
}