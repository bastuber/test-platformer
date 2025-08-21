using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts.AI.EnemyAI
{
    public class EnemyAi : MonoBehaviour
    {
        public AiState CurrentState {  get; private set; }

        private IdleState _idleState;
        private PatrollingState _patrollingState;
        private FightingState _fightingState;

        private Transform _detectionArea;

        private void Awake()
        {
            _idleState = new(this);
            _patrollingState = new(this);
            _fightingState = new(this);

            // Idle by default.
            CurrentState = _idleState;

            _detectionArea = transform.Find("DetectionArea");
        }

        public void SetState(EnemyState newState)
        {
            CurrentState.OnStateExited(newState);

            Debug.Log($"Changing state of {transform.name} to {newState}.");

            switch (newState)
            {
                case EnemyState.IDLE:
                    CurrentState = _idleState;
                    break;
                case EnemyState.PATROLLING:
                    CurrentState = _patrollingState;
                    break;
                case EnemyState.FIGHTING:
                    CurrentState = _fightingState;
                    break;
                default:
                    Debug.LogError($"SetState for {newState} not implemented!");
                    break;
            }
        }
            public void OnTouchingPlayer(Collider2D collider)
        {
            CurrentState.OnPlayerDetected(collider.gameObject);
        }
    }
}
