using Assets.Scripts.AI.EnemyAI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.AI.EnemyAI
{
    public class PatrollingState : AiState
    {
        public List<Transform> WayPoints;

        public float Speed;

        private float t = 0;
        private int wayPointIndex = 0;
        private bool goForward = true;

        protected override void InitializeState()
        {
            goForward = true;
        }

        public override void OnPlayerDetected(GameObject player)
        {
            EnemyAiBehaviour.SetState(EnemyState.FIGHTING);
        }

        public override void OnStateEntered(EnemyState previousState)
        {
            Debug.LogError("Not implemented");
        }

        public override void OnStateExited(EnemyState nextState)
        {
            Debug.LogError("Not implemented");
        }
        private void FixedUpdate()
        {
            if (WayPoints == null || WayPoints.Count < 2)
            {
                Console.WriteLine("Error: Not enough waypoints defined");
                return;
            }

            Vector3 startPos = WayPoints[wayPointIndex].position;
            Vector3 endPos;
            if (goForward)
            {
                endPos = WayPoints[wayPointIndex + 1].position;
            }
            else
            {
                endPos = WayPoints[wayPointIndex - 1].position;
            }

            Vector3 direction = (endPos - transform.position).normalized;
            Vector3 move = direction * Speed * Time.fixedDeltaTime;

            var rigidBody = GetComponent<Rigidbody2D>();
            rigidBody.linearVelocityX = move.x;

            float distanceToEndPos = (endPos - transform.position).magnitude;
            if (distanceToEndPos <= 0.5)
            {
                if (goForward)
                {
                    wayPointIndex++;
                    if (wayPointIndex == WayPoints.Count - 1)
                    {
                        goForward = false;
                    }
                }
                else
                {
                    wayPointIndex--;
                    if (wayPointIndex == 0)
                    {
                        goForward = true;
                    }
                }
            }

            EnemyAiBehaviour.LookAt(endPos);
        }
    }
}
