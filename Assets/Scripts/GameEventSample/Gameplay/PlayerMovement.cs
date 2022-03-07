using UnityEngine;

namespace GameEventSample.Gameplay {
    
    public class PlayerMovement : MonoBehaviour {
        
        private Transform PlayerTransform => playerBody.transform;
        
        [SerializeField] private float speed;
        [SerializeField] private Rigidbody playerBody;
        
        private Vector3 directionInput;

        private void Update() {
            
            float horizontalAxis = Input.GetAxis("Horizontal");
            float verticalAxis = -Input.GetAxis("Vertical");
            directionInput = new Vector3(verticalAxis, 0f, horizontalAxis);
        }

        private void FixedUpdate() {

            MovePlayer();

            if (directionInput.sqrMagnitude > 0.01f)
                RotateTowardsDirection();
        }

        private void MovePlayer() {
            
            Vector3 velocity = directionInput.normalized * speed;
            velocity.y = playerBody.velocity.y;
            playerBody.velocity = velocity;
        }

        private void RotateTowardsDirection() {
            
            Quaternion addedRotation = Quaternion.LookRotation(directionInput);
            PlayerTransform.rotation = addedRotation;
        }
    }
}