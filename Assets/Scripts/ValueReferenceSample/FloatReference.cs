using System;

namespace ValueReferenceSample {
    
    [Serializable]
    public class FloatReference {

        public float Value {
            get => GetValue();
            set => SetValue(value);
        }

        public bool useConstant;
        public float constantValue;
        public FloatVariable variableValue;

        private float GetValue() {
            return useConstant ? constantValue : variableValue.Value;
        }

        private void SetValue(float value) {

            if (useConstant)
                constantValue = value;
            else
                variableValue.Value = value;
        }
    }

}