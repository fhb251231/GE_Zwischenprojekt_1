using UnityEngine;

namespace Gameplay
{
    public class Win_Condition : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
                gameManager.WinGame();
        }
    }
}
