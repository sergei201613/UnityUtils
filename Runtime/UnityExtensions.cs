using UnityEngine;

namespace TeaGames.Unity.Utils.Runtime
{
    public static class UnityExtensions
    {
        public static T RequireComponent<T>(this GameObject gameObject)
        {
            if (gameObject.TryGetComponent<T>(out var component))
                return component;
            else
                throw new MissingComponentException($"Missing {typeof(T).FullName} component of {gameObject.gameObject.name} game object!");
        }

        public static T RequireComponentInChildren<T>(this GameObject gameObject)
        {
            var component = gameObject.GetComponentInChildren<T>();

            if (component != null)
                return component;
            else
                throw new MissingComponentException($"Missing {typeof(T).FullName} component of {gameObject.gameObject.name} game object or it child!");
        }
    }
}
