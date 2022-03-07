using System;
using UnityEngine;

namespace ValueReferenceSample {
    
    [CreateAssetMenu(fileName = "Float Variable", menuName = "Scriptable Objects/Variables/Float")]
    public class FloatVariable : ScriptableObject {

        public event Action<float> OnValueChanged = delegate { };

        public float Value {
            get => value;
            set => SetValue(value);
        }

        [SerializeField] private float value;

        private void SetValue(float number) {
            value = number;
            OnValueChanged(number);
        }
    }

}