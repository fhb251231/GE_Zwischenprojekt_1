using UnityEngine;
using UnityEngine.UI;

public class Game_Over_Scripts : MonoBehaviour
{
        [SerializeField] private GameManager gameManager;
        [SerializeField] private Transform target;
        [SerializeField] private float detectionRange = 1.5f;

        private void Update()
        {
                IsTargetInRange();
        }

        private void IsTargetInRange()
        {
         if (target == null)
                return;

                if (Vector3.Distance(transform.position, target.position) <= detectionRange)
                {
                         gameManager.LoseGame();
                }
        }
}