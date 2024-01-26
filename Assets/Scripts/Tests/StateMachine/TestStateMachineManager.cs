using System;
using Tools.StateMachine;
using UnityEngine;

namespace Tests.StateMachine
{
    public class TestStateMachineManager : StateMachineManager<TestState>
    {
        private void OnMouseEnter()
        {
            SwitchState(typeof(MonoBehaviour));
        }

        private void OnMouseExit()
        {
            SwitchState(typeof(InactiveState));
        }

        public void Test()
        {
            Debug.Log("Invoked Event");
        }
    }
}