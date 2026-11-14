using UnityEngine;
using Movement;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] private float speedMultiplier = 1.5f;
    [SerializeField] private float duration = 5f;

    private void OnTriggerEnter(Collider other)
    {
        MovementController player =
            other.GetComponentInParent<MovementController>();

        if (player == null)
            return;

        player.ActivateSpeedBoost(speedMultiplier, duration);

        Destroy(gameObject);
    }
}
