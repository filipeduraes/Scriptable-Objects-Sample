using UnityEngine;

namespace ValueReferenceSample.Gameplay {

    public class PlayerDamageableV2: MonoBehaviour {

        private const KeyCode DamageInput = KeyCode.F;
        [SerializeField] private FloatReference currentHealth;
        [SerializeField] private FloatReference maxHealth;
        private bool isDead;

        private void Awake() {
            currentHealth.Value = maxHealth.Value;
        }

        private void Update() {
            if (IsPressingDamageInput() && !isDead)
                TakeDamage();
        }

        private static bool IsPressingDamageInput() {
            return Input.GetKeyDown(DamageInput);
        }

        private void TakeDamage() {
            currentHealth.Value--;

            if (PlayerHasNoHealth())
                Die();
        }

        private bool PlayerHasNoHealth() {
            return currentHealth.Value <= 0f;
        }

        private void Die() {
            Destroy(gameObject);
            isDead = true;
        }
    }
}