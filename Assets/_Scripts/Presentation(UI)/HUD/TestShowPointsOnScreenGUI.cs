using UnityEngine;
using TMPro;

public class TestShowPointsOnScreenGUI : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] private TMP_Text pointsText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = $"Points: {gameManager.points}";
    }
}
