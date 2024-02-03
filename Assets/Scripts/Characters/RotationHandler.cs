using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Characters
{
    public class RotationHandler : MonoBehaviour
    {
        private int _rotationIndex = 0;
        public List<RotatebleObject > CharacterRotatebles
        {
            get;
            set;
        }

        public CardinalDirections cardinalDirection;

        private void Start()
        {
            CharacterRotatebles = new List<RotatebleObject >();
            foreach (Transform child in transform)
            {
                RotatebleObject  s = child.GetComponent<RotatebleObject>();
                if (s != null)
                { 
                    CharacterRotatebles.Add(s);
                }
            }
            SetRotation(cardinalDirection);
        }

        public void UpdateRotation(int direction)
        {
            _rotationIndex += direction;
            _rotationIndex = _rotationIndex < 0 ? 3 : _rotationIndex;
            _rotationIndex = _rotationIndex > 3 ? 0 : _rotationIndex;
            foreach (RotatebleObject rotateble in CharacterRotatebles)
            {
                rotateble.SetRotation(_rotationIndex);
            }

            cardinalDirection = (CardinalDirections)_rotationIndex;
        }

        public void SetRotation(Vector3 direction)
        {
            SetRotation(Vector3ToCardinalDirection(direction));
        }
        public void SetRotation(CardinalDirections cardinalDirection)
        {
            foreach (RotatebleObject rotateble in CharacterRotatebles)
            {
                rotateble.SetRotation((int)cardinalDirection);
            }

            _rotationIndex = (int)cardinalDirection;
        }
        
        public Vector3 CardinalDirectionToVector3(CardinalDirections direction) => direction switch
        {
            CardinalDirections.North => Vector3.up,
            CardinalDirections.East => Vector3.right,
            CardinalDirections.South => Vector3.down,
            CardinalDirections.West => Vector3.left,
            _ => throw new ArgumentOutOfRangeException(nameof(direction), $"Not expected direction value: {direction}")
        };
        
        public CardinalDirections Vector3ToCardinalDirection(Vector3 direction) => direction switch
        {
            _ when CardinalDirectionToVector3(CardinalDirections.North).Equals(Vector3.up) => CardinalDirections.North,
            _ when CardinalDirectionToVector3(CardinalDirections.East).Equals(Vector3.right) => CardinalDirections.East,
            _ when CardinalDirectionToVector3(CardinalDirections.South).Equals(Vector3.down) => CardinalDirections.South,
            _ when CardinalDirectionToVector3(CardinalDirections.West).Equals(Vector3.left) => CardinalDirections.West,
            _ => throw new ArgumentOutOfRangeException(nameof(direction), $"Not expected direction value: {direction}")
        };
    }
}

