using Tools.StateMachine;
using UnityEngine;

namespace Tests.StateMachine
{
    public class InactiveState : TestState
    {
        public override void StateStart()
        {
            spriteRenderer.color = Color.red;
        }

        public override void StateUpdate()
        {
            
        }
    }
}