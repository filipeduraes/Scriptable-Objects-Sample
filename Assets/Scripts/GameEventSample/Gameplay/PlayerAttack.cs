using System;
using GameEventSample.Gameplay;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    
    [SerializeField] private float attackRadius;
    [SerializeField] private float strength;
    [SerializeField] private LayerMask enemyLayer;
    
    private bool attackKeyDown;
    
    private void OnDrawGizmos() {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

    private void Update() {
        
        attackKeyDown = Input.GetKeyDown(KeyCode.K);
    }

    private void FixedUpdate() {
        if (attackKeyDown) {
            
            Collider[] results = new Collider[1];
            int size = Physics.OverlapSphereNonAlloc(transform.position, attackRadius, results, enemyLayer);

            if (size > 0) {

                IDamageable damageable = results[0].GetComponent<IDamageable>();
                damageable.TakeDamage(strength);
            }
        }
    }
}
