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
        public PatrollingState(EnemyAi enemyAi)
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
    }
}
