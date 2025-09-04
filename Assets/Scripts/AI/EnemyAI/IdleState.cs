using System;
using UnityEngine;

namespace Assets.Scripts.AI.EnemyAI
{
    public class IdleState : AiState
    {
        public Transform IdlePosition;

        public float WatchTime = 2;
        private float _startLookTime;

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
            _startLookTime = Time.time;
        }

        public override void OnStateExited(EnemyState nextState)
        {
            Debug.LogError("Not implemented");
        }

        public void Update()
        {
            float timeSinceStartLook = Time.time - _startLookTime;
            if(timeSinceStartLook >= WatchTime)
            {
                Vector3 scale = gameObject.transform.localScale;
                scale.x *= -1;
                gameObject.transform.localScale = scale;

                _startLookTime = Time.time;
            }
        }
    }
}
