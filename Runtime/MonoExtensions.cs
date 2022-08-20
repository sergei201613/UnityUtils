using System.Collections;
using UnityEngine;
using System;

namespace TeaGames.Unity.Utils.Runtime
{
    public static class MonoExtensions
    {
        public static Action Delay(this MonoBehaviour mono, float delayInSeconds, Action action)
        {
            IEnumerator DelayCoroutine()
            {
                yield return new WaitForSeconds(delayInSeconds);
                action?.Invoke();
            }

            mono.StartCoroutine(DelayCoroutine());
            return action;
        }

        public static T RequireComponent<T>(this MonoBehaviour mono)
        {
            if (mono.TryGetComponent<T>(out var component))
                return component;
            else
                throw new MissingComponentException($"Missing {typeof(T).FullName} component of {mono.gameObject.name} game object!");
        }

        public static T RequireComponentInChildren<T>(this MonoBehaviour mono)
        {
            var component = mono.GetComponentInChildren<T>();

            if (component != null)
                return component;
            else
                throw new MissingComponentException($"Missing {typeof(T).FullName} component of {mono.gameObject.name} game object or it child!");
        }
    }
}
