
using UnityEngine;
using TMPro;

public class CollectibleTracker : MonoBehaviour
{
    [SerializeField] private TMP_Text counterText;

    private int collected = 0;
    private int total;

    private void Start()
    {
        total = FindObjectsByType<Collectible>().Length;
        UpdateText();
    }

    public void AddCollectible()
    {
        collected++;
        UpdateText();
    }

    private void UpdateText()
    {
        counterText.text = collected + " / " + total;
    }
}
