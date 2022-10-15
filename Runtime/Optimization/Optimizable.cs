using UnityEngine;

namespace Sgorey.Unity.Utils.Runtime
{
    public class Optimizable : MonoBehaviour
    {
        public virtual void SetOptimized(bool optimized)
        {
            gameObject.SetActive(!optimized);
        }
    }
}
