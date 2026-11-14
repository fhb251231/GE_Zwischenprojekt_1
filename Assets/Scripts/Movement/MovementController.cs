using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using TMPro;

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

        [SerializeField] private Transform playerCamera;

        [SerializeField] private TMP_Text boostTimerText;

        public Rigidbody rb;

        private void Start()
        {
            if (boostTimerText != null)
                boostTimerText.gameObject.SetActive(false);
        }

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

        /*
        private void Move()
        {
            var input = move.action.ReadValue<Vector2>().normalized;

            Vector3 direction = transform.TransformDirection(
                new Vector3(input.x, 0, input.y)
            );

            rb.linearVelocity = new Vector3(
                direction.x * moveSpeed,
                rb.linearVelocity.y,
                direction.z * moveSpeed
            );
        }
        */


        private void Move()
        {
            var input = move.action.ReadValue<Vector2>().normalized;

            // Blickrichtung der Kamera ermitteln
            Vector3 forward = playerCamera.forward;
            Vector3 right = playerCamera.right;

            // Vertikale Bewegung verhindern
            forward.y = 0;
            right.y = 0;

            forward.Normalize();
            right.Normalize();

            // Bewegungsrichtung relativ zur Kamera berechnen
            Vector3 direction = forward * input.y + right * input.x;

            rb.linearVelocity = new Vector3(
                direction.x * moveSpeed * speedMultiplier,
                rb.linearVelocity.y,
                direction.z * moveSpeed * speedMultiplier
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

        private float speedMultiplier = 1f;
        private Coroutine speedBoostRoutine;


        public void ActivateSpeedBoost(float multiplier, float duration)
        {
            if (speedBoostRoutine != null)
                StopCoroutine(speedBoostRoutine);

            speedBoostRoutine = StartCoroutine(
                SpeedBoostRoutine(multiplier, duration)
            );
        }

        
        private IEnumerator SpeedBoostRoutine(float multiplier, float duration)
        {
            speedMultiplier = multiplier;

            float remainingTime = duration;

            // Timer anzeigen
            if (boostTimerText != null)
                boostTimerText.gameObject.SetActive(true);

            while (remainingTime > 0)
            {
                // Verbleibende Zeit anzeigen
                if (boostTimerText != null)
                    boostTimerText.text = "Speed Boost: " +
                        remainingTime.ToString("F1") + "s";

                remainingTime -= Time.deltaTime;

                yield return null;
            }

            // Boost beenden
            speedMultiplier = 1f;

            if (boostTimerText != null)
                boostTimerText.gameObject.SetActive(false);

            speedBoostRoutine = null;
        }
    }
}


