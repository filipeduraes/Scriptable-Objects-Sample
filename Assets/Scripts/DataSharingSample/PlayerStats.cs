using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Player Stats")]
public class PlayerStats : ScriptableObject {

    public event Action<float> OnCurrentHealthChanged = delegate {  }; 
    
    public float CurrentHealth {
        get => currentHealth;
        set => SetCurrentHealth(value);
    }
    
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;

    public void MaximizeHealth() {
        CurrentHealth = maxHealth;
    }

    private void SetCurrentHealth(float value) {
        OnCurrentHealthChanged(value);
        currentHealth = value;
    }
}
