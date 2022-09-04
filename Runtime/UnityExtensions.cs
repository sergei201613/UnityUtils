using UnityEngine;

namespace TeaGames.Unity.Utils.Runtime
{
    public static class UnityExtensions
    {
        public static T RequireComponent<T>(this GameObject gameObject)
        {
#if DEBUG
            if (gameObject.TryGetComponent<T>(out var component))
                return component;
            else
                throw new MissingComponentException($"Missing {typeof(T).FullName} component of {gameObject.gameObject.name} game object!");
#else
            return gameObject.GetComponent<T>();
#endif
        }

        public static T RequireComponentInChildren<T>(this GameObject gameObject)
        {
#if DEBUG
            var component = gameObject.GetComponentInChildren<T>();

            if (component != null)
                return component;
            else
                throw new MissingComponentException($"Missing {typeof(T).FullName} component of {gameObject.gameObject.name} game object or it child!");
#else
            return gameObject.GetComponentInChildren<T>();
#endif
        }

        public static T FindComponentInScene<T>(this GameObject gameObject) where T : Object
        {
#if DEBUG
            var component = Object.FindObjectOfType<T>();

            if (component != null)
                return component;
            else
                throw new MissingComponentException($"Can't find component of type {typeof(T).FullName} in the scene!");
#else
            return Object.FindObjectOfType<T>();
#endif
        }
    }
}
