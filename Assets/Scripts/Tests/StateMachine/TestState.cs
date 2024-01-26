using Tools.StateMachine;
using UnityEngine;

namespace Tests.StateMachine
{
    public abstract class TestState : State
    {
        [SerializeField] protected SpriteRenderer spriteRenderer;
    }
}