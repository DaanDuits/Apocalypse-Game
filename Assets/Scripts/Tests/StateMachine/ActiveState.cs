using Tools.StateMachine;
using UnityEngine;

namespace Tests.StateMachine
{
    public class ActiveState : TestState
    {
        public override void StateStart()
        {
            spriteRenderer.color = Color.green;
        }

        public override void StateUpdate()
        {
            
        }
    }
}