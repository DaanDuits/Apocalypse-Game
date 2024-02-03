using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

namespace Tools.ObjectPooling
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject poolPrefab;
        [SerializeField] private int maxAmount = 50;
        [SerializeField] private bool allowOverflow = true;
        [SerializeField] private int amountPerFrame = 5;

        private void Start()
        {
            StartCoroutine(InstantiateNewPrefabs(maxAmount / amountPerFrame));
        }

        public void RequestObject() => RequestObject(transform.position, quaternion.identity);
        public void RequestObject(Vector3 position, Quaternion rotation)
        {
            foreach (Transform child in transform)
            {
                if (!child.gameObject.activeSelf)
                {
                    child.gameObject.SetActive(true);
                    child.position = position;
                    child.rotation = rotation;
                    return;
                }
            }

            if (allowOverflow)
            {
                StartCoroutine(InstantiateNewPrefabs());
                RequestObject(position, rotation);
                return;
            }

            throw new ArgumentOutOfRangeException("All prefabs are in use!");
        }

        public void DestroyObject(GameObject objectToDestroy)
        {
            objectToDestroy.SetActive(false);
        }

        private IEnumerator InstantiateNewPrefabs() => InstantiateNewPrefabs(1);
        private IEnumerator InstantiateNewPrefabs(int loopAmount)
        {
            for (int i = 0; i < loopAmount; i++)
            {
                int amount = 0;
                while (amount < amountPerFrame)
                {
                    Instantiate(poolPrefab, this.transform).SetActive(false);
                    amount++;
                }

                yield return new WaitForEndOfFrame();
            }
        }
    }
}