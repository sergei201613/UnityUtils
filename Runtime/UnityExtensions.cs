using UnityEngine;
using UnityEngine.Assertions;

namespace Sgorey.Unity.Utils.Runtime
{
    public static class UnityExtensions
    {
        public static T GetComp<T>(this GameObject gameObject) where T : Component
        {
            T comp = gameObject.GetComponent<T>();
            Assert.IsNotNull(comp, $"Missing {typeof(T).FullName} component of {gameObject.name} game object or it child!");
            return comp;
        }

        public static T GetCompInChildren<T>(this GameObject gameObject) where T : Component
        {
            T comp = gameObject.GetComponentInChildren<T>();
            Assert.IsNotNull(comp, $"Missing {typeof(T).FullName} component of {gameObject.name} game object or it child!");
            return comp;
        }

        public static T FindComp<T>(this MonoBehaviour _) where T : Component
        {
            T comp = Object.FindObjectOfType<T>();
            Assert.IsNotNull(comp, $"Can't find component of type {typeof(T).FullName} in the scene!");
            return comp;
        }
    }
}
