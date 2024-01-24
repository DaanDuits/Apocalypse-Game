using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Tools.StateMachine
{
    public abstract class StateMachineManager<T> : MonoBehaviour where T : State
    {
        [SerializeField] protected T startingState;
        [SerializeField] protected List<T> states;
        public T currentState;

        [SerializeField] protected UnityEvent switchEvent;

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
                currentState.StateStart();
                switchEvent.Invoke();
            }
            catch
            {
                throw new NullReferenceException("Specified type not found in states list");
            }
        }
    }
}