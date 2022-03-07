using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Player Settings", menuName = "Scriptable Objects/Player Settings", order = 0)]
    public class PlayerSettings : ScriptableObject
    {
        public float JumpHeight => jumpHeight;
        public float Strength => strength;
        public float Speed => speed;

        [SerializeField] private float jumpHeight;
        [SerializeField] private float strength;
        [SerializeField] private float speed;
    }
}
