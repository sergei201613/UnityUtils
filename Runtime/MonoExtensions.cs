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

        public static T RequireComponent<T>(this MonoBehaviour mono) where T : Component
        {
            if (mono.TryGetComponent<T>(out var component))
                return component;
            else
                throw new MissingComponentException($"Missing {typeof(T).FullName} component of {mono.gameObject.name} game object!");
        }
    }
}
