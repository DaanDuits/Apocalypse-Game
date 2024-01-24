using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Tests.ObjectPooling
{
    public class NoObjectPooling : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private int maxAmount = 50;
        private void Start()
        {
            for (int i = 0; i < maxAmount; i++)
            {
                Instantiate(prefab, this.transform).SetActive(false);
            }
        }
    }
}