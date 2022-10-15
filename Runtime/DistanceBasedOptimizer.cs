using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Sgorey.Unity.Utils.Runtime
{
    public class DistanceBasedOptimizer : MonoBehaviour
    {
        [SerializeField]
        private float _distance = 10f;

        [SerializeField]
        private int _chunkSize = 64;

        private GameObject _player;
        private readonly List<GameObject> _objects = new();

        public void Init(GameObject playerObject)
        {
            _player = playerObject;
            StartCoroutine(UpdateCoroutine());
        }

        private IEnumerator UpdateCoroutine()
        {
            while (true)
            {
                int i = 0;
                while (i < _objects.Count)
                {
                    GameObject obj = _objects[i];

                    if (obj == null)
                    {
                        _objects.RemoveAt(i);
                        continue;
                    }

                    Vector3 playerPos = _player.transform.position;
                    Vector3 objPos = obj.transform.position;

                    float dist = Vector3.Distance(playerPos, objPos);

                    SetOptimized(obj, dist > _distance);

                    if (i % _chunkSize == 0)
                        yield return new WaitForEndOfFrame();

                    i++;
                }
            }
        }

        public void AddObject(GameObject obj)
        {
            Assert.IsNotNull(obj);
            _objects.Add(obj);
        }

        public void RemoveObject(GameObject obj)
        {
            Assert.IsNotNull(obj);
            _objects.Remove(obj);
        }

        protected virtual void SetOptimized(GameObject obj, bool optimized)
        {
            obj.SetActive(!optimized);
        }
    }
}
