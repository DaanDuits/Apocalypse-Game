using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Characters
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class RotatebleObject : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private Sprite[] _sprites;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _sprites = AssetDatabase.LoadAllAssetsAtPath("Assets/Textures/Characters/" + _spriteRenderer.sprite.texture.name + ".png" )
                .OfType<Sprite>().ToArray();
        }

        public void SetRotation(int rotationIndex)
        {
            _spriteRenderer.sprite = _sprites[rotationIndex];
        }
    }
}