using UnityEngine;

namespace Tools.StateMachine
{
    public abstract class State : MonoBehaviour
    {
        public abstract void StateStart();
        public abstract void StateUpdate();
    }
}