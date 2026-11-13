
using UnityEngine;
using Movement;

public class Collectible : MonoBehaviour
{
    private CollectibleTracker tracker;

    private void Start()
    {
        tracker = FindAnyObjectByType<CollectibleTracker>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<MovementController>() == null)
            return;

        if (tracker == null)
        {
            Debug.LogError("CollectibleTracker nicht gefunden!");
            return;
        }

        tracker.AddCollectible();
        Destroy(gameObject);
    }
}
