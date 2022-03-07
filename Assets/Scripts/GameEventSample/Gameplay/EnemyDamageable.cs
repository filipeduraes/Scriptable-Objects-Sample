using System.Collections;
using UnityEngine;

namespace GameEventSample.Gameplay {
    
    public class EnemyDamageable : MonoBehaviour, IDamageable {

        [Header("Health")]
        [SerializeField] private float maxHealth;
        [SerializeField] private GameEvent onDeathEvent;
        
        [Header("Damage Effect")]
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private Color damageColor;
        [SerializeField] private float damageEffectTime;

        private Color defaultColor;
        private float currentHealth;

        private void Awake() {
            
            defaultColor = meshRenderer.material.color;
            currentHealth = maxHealth;
        }

        public void TakeDamage(float damage) {

            currentHealth -= damage;
            
            if (currentHealth <= 0f) {
                
                onDeathEvent.Invoke();
                Destroy(gameObject);
            }
            else {
                
                StartCoroutine(DoDamageEffect());
            }
        }

        private IEnumerator DoDamageEffect() {

            Material material = meshRenderer.material;
            
            material.color = damageColor;
            yield return new WaitForSeconds(damageEffectTime);
            material.color = defaultColor;
        }
    }
}