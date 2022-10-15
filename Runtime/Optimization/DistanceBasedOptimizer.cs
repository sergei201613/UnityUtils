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

        private Transform _playerTransform;

        // TODO: List can contain duplicates!
        private readonly List<Optimizable> _optimizables = new();

        public void Init(Transform playerTransform)
        {
            _playerTransform = playerTransform;
            StartCoroutine(UpdateCoroutine());
        }

        private IEnumerator UpdateCoroutine()
        {
            while (true)
            {
                int i = 0;
                while (i < _optimizables.Count)
                {
                    Optimizable opt = _optimizables[i];

                    if (opt == null)
                    {
                        _optimizables.RemoveAt(i);
                        continue;
                    }

                    Vector3 playerPos = _playerTransform.position;
                    Vector3 optPos = opt.transform.position;

                    float dist = Vector3.Distance(playerPos, optPos);

                    opt.SetOptimized(dist > _distance);

                    if (i % _chunkSize == 0)
                        yield return new WaitForEndOfFrame();

                    i++;
                }
                yield return new WaitForEndOfFrame();
            }
        }

        public void Register(Optimizable opt)
        {
            Assert.IsNotNull(opt);
            _optimizables.Add(opt);
        }

        public void Unregister(Optimizable opt)
        {
            Assert.IsNotNull(opt);
            _optimizables.Remove(opt);
        }

        protected virtual void SetOptimized(GameObject obj, bool optimized)
        {
            obj.SetActive(!optimized);
        }
    }
}
