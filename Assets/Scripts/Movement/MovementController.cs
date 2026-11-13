using UnityEngine;
using UnityEngine.InputSystem;

namespace Movement
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private InputActionReference move;
        [SerializeField] private InputActionReference jump;

        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpForce;

        [SerializeField] private Transform groundCheck;
        [SerializeField] private float groundCheckRadius = 0.2f;
        [SerializeField] private LayerMask groundLayer;

        public Rigidbody rb;

        private void OnEnable()
        {
            move.action.Enable();
            jump.action.Enable();

            jump.action.performed += OnJump;
        }

        private void OnDisable()
        {
            jump.action.performed -= OnJump;

            move.action.Disable();
            jump.action.Disable();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            var input = move.action.ReadValue<Vector2>().normalized;

            rb.linearVelocity = new Vector3(
                input.x * moveSpeed,
                rb.linearVelocity.y,
                input.y * moveSpeed
            );
        }

        /*
        private void Jump()
        {
            bool isGrounded = Physics.CheckSphere(
                groundCheck.position,
                groundCheckRadius,
                groundLayer,
                QueryTriggerInteraction.Ignore
            );

            if (!isGrounded)
                return;

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        */


        private void Jump()
        {
            if (Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer))
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

         private void OnJump(InputAction.CallbackContext context)
        {
            Jump();
        }
    }
}


