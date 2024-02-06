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
        [SerializeField]private Sprite[] _sprites;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _sprites = AssetDatabase.LoadAllAssetsAtPath("Assets/Textures/Characters/" + _spriteRenderer.sprite.texture.name + ".png" )
                .OfType<Sprite>().ToArray();
            ReorderSprites();
        }

        private void ReorderSprites()
        {
            List<Sprite> sprites = new List<Sprite>(_sprites.Length);
            for (int i = 0; i < _sprites.Length; i++)
            {
                sprites.Insert(i, _sprites.Where(s => s.name.Contains(i.ToString())).ToArray()[0]);
            }

            _sprites = sprites.ToArray();
        }

        public void SetRotation(int rotationIndex)
        {
            _spriteRenderer.sprite = _sprites[rotationIndex];
        }
    }
}