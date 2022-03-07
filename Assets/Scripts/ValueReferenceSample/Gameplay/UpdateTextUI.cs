using TMPro;
using UnityEngine;

namespace ValueReferenceSample.Gameplay {
    
    public class UpdateTextUI : MonoBehaviour {

        [Header("Components")]
        [SerializeField] private TMP_Text text;
        
        [Header("Text")]
        [SerializeField] private FloatReference floatReference;
        [SerializeField] private string prefix;
        [SerializeField] private string suffix;

        private void OnEnable() {
            UpdateText(floatReference.Value);
            floatReference.variableValue.OnValueChanged += UpdateText;
        }

        private void OnDisable() {
            floatReference.variableValue.OnValueChanged -= UpdateText;
        }

        private void UpdateText(float number) {
            text.SetText($"{prefix}{number}{suffix}");
        }
    }
}