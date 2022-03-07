using UnityEngine;

namespace DataSharingSample {
    
    public class PlayerDamageable : MonoBehaviour {

        private const KeyCode DamageInput = KeyCode.F;
        [SerializeField] private PlayerStats playerStats;
        private bool isDead;

        private void Awake() {
            playerStats.MaximizeHealth();
        }

        private void Update() {
            if (IsPressingDamageInput() && !isDead)
                TakeDamage();
        }

        private static bool IsPressingDamageInput() {
            return Input.GetKeyDown(DamageInput);
        }

        private void TakeDamage() {
            playerStats.CurrentHealth--;
            
            if (PlayerHasNoHealth()) 
                Die();
        }

        private bool PlayerHasNoHealth() {
            return playerStats.CurrentHealth <= 0f;
        }

        private void Die() {
            Destroy(gameObject);
            isDead = true;
        }
    }
}