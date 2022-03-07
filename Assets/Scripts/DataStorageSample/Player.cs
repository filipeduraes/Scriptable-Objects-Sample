using System;
using ScriptableObjects;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerSettings settings;

        private void Awake()
        {
            Debug.Log($"Jump Height: {settings.JumpHeight}");
            Debug.Log($"Strength: {settings.Strength}");
            Debug.Log($"Speed: {settings.Speed}");
        }
    }
}
