using System;
using UnityEngine;

namespace Assets.Scripts.AI.EnemyAI
{
    public class IdleState : AiState
    {
        public Transform IdlePosition;

        public float WatchTime = 2;
        private float _startLookTime;

        public float SearchTime = 6;
        private float _startSearchTime;

        public override void OnPlayerDetected(GameObject player)
        {
            EnemyAiBehaviour.SetState(EnemyState.FIGHTING);
        }

        public override void OnStateEntered(EnemyState previousState)
        {
            _startLookTime = Time.time;
            _startSearchTime = Time.time;
        }

        public override void OnStateExited(EnemyState nextState)
        {
            Debug.LogError("Not implemented");
        }

        public void Update()
        {
            LookAround();

            PatrolWhenSearchTimeExpired();
        }

        private void LookAround()
        {
            float timeSinceStartLook = Time.time - _startLookTime;
            if (timeSinceStartLook >= WatchTime)
            {
                Vector3 scale = gameObject.transform.localScale;
                scale.x *= -1;
                gameObject.transform.localScale = scale;

                _startLookTime = Time.time;
            }
        }

        private void PatrolWhenSearchTimeExpired()
        {
            float timeSinceStartSearch = Time.time - _startSearchTime;
            if (timeSinceStartSearch >= SearchTime)
            {
                EnemyAiBehaviour.SetState(EnemyState.PATROLLING);
            }
        }
    }
}
