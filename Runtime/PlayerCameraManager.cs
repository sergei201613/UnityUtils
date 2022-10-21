using System.Collections.Generic;
using UnityEngine;

namespace Sgorey.Unity.Utils.Runtime
{
    public class PlayerCameraManager : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private float _fovSpeed = 5f;

        public float FovBase => _fovBase;

        public float FovMlt
        {
            get
            {
                float fovMlt = 1;

                foreach (Float mlt in _fovMlts)
                    fovMlt *= mlt.Value;

                return fovMlt;
            }
        }

        private float _fovBase;
        private readonly List<Float> _fovMlts = new();

        private void Awake()
        {
            _camera = _camera != null ? _camera : Camera.main;
            _fovBase = _camera.fieldOfView;
        }

        private void Update()
        {
            float targetFov = _fovBase * FovMlt;

            _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, targetFov, 
                _fovSpeed * Time.deltaTime);
        }

        public Float AddFovMultiplier()
        {
            Float mlt = new(1);
            _fovMlts.Add(mlt);
            return mlt;
        }

        public void RemoveFovMultiplier(Float value)
        {
            _fovMlts.Remove(value);
        }
    }
}
