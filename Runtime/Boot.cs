using UnityEngine;

namespace Sgorey.Unity.Utils.Runtime
{
    public class Boot : MonoBehaviour
    {
        public event System.Action SceneLoaded;

        [SerializeField] private string _startScene;

        private void Awake()
        {
            SceneHelper.AddSceneAsync(_startScene, () =>
            {
                SceneLoaded?.Invoke();
                Destroy(gameObject);
            });
        }
    }
}
