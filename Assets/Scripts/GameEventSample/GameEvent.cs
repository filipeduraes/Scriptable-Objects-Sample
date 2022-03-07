using System;
using UnityEngine;

namespace GameEventSample {
    
    [CreateAssetMenu(menuName = "Scriptable Objects/Game Event")]
    public class GameEvent : ScriptableObject {

        private Action action = delegate { };

        public void Invoke() => action();

        public void Subscribe(Action method) => action += method;

        public void Unsubscribe(Action method) => action -= method;
    }
}