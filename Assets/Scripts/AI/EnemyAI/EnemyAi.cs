using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts.AI.EnemyAI
{
    public class EnemyAi : MonoBehaviour
    {
        public EnemyState StartingState = EnemyState.IDLE;

        private AiState CurrentState;

        private IdleState _idleState;
        private PatrollingState _patrollingState;
        private FightingState _fightingState;

        private Transform _detectionArea;

        private void Awake()
        {
            _idleState = GetComponent<IdleState>();
            _patrollingState = GetComponent<PatrollingState>();
            _fightingState = GetComponent<FightingState>();

            // Idle by default.
            DisableAllStates();
            SetState(StartingState);

            _detectionArea = transform.Find("DetectionArea");
        }

        private void DisableAllStates()
        {
            _idleState.enabled = false;
            _patrollingState.enabled = false;
            _fightingState.enabled = false;
        }

        public void SetState(EnemyState newState)
        {
            if (CurrentState != null)
            {
                CurrentState.OnStateExited(newState);
                CurrentState.enabled = false;
            }

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
            CurrentState.enabled = true;
        }

        public void OnTouchingPlayer(Collider2D collider)
        {
            CurrentState.OnPlayerDetected(collider.gameObject);
        }
    }
}
