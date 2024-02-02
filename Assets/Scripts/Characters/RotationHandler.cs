using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Characters
{
    public class RotationHandler : MonoBehaviour
    {
        private int rotationIndex = 0;
        public List<SpriteRenderer> CharacterRenderers
        {
            get;
            set;
        }

        private void Awake()
        {

            CharacterRenderers = new List<SpriteRenderer>();
            foreach (Transform child in transform)
            {
                SpriteRenderer s = child.GetComponent<SpriteRenderer>();
                if (s != null)
                { 
                    CharacterRenderers.Add(s);
                }
            }
        }

        public void UpdateRotation(int direction)
        {
            rotationIndex += direction;
            rotationIndex = rotationIndex < 0 ? 3 : rotationIndex;
            rotationIndex = rotationIndex > 3 ? 0 : rotationIndex;
            foreach (SpriteRenderer renderer in CharacterRenderers)
            {
                renderer.sprite = AssetDatabase.LoadAllAssetsAtPath("Assets/Textures/Characters/" + renderer.sprite.texture.name + ".png" )
                    .OfType<Sprite>().ToArray()[rotationIndex];
            }
        }
    

    }
}

