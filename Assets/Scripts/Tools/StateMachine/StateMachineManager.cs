using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tools.StateMachine
{
    public abstract class StateMachineManage<T> : MonoBehaviour where T : State
    {
        [SerializeField] protected T startingState;
        [SerializeField] protected List<T> states;
        public T currentState;

        private void Start()
        {
            currentState = startingState;
            startingState.StateStart();
        }

        private void Update()
        {
            currentState.StateUpdate();
        }

        public void SwitchState(Type stateType)
        {
            try
            {
                currentState = states.Where(s => s.GetType() == stateType).ToArray()[0];
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}