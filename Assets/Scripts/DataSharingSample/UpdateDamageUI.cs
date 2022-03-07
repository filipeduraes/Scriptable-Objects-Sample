using TMPro;
using UnityEngine;

namespace DataSharingSample {
    
    public class UpdateDamageUI : MonoBehaviour {

        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private TMP_Text damageText;

        private void OnEnable() {
            UpdateDamageText(playerStats.CurrentHealth);
            playerStats.OnCurrentHealthChanged += UpdateDamageText;
        }
        
        private void OnDisable() {
            playerStats.OnCurrentHealthChanged -= UpdateDamageText;
        }

        private void UpdateDamageText(float damageValue) {
            damageText.SetText($"{damageValue} HP");
        }
    }
}