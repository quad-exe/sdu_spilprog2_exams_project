using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoodWillBar : MonoBehaviour
{
    [SerializeField] private GameObject ImageFill;
    private string NPCName;
    Image imageComponent;
    GameManager gameManager;

    void OnEnable()
    {
        NPCName = gameObject.name; // Assuming the GameObject's name corresponds to the NPC's name
        gameManager = GameManager.Instance;
        Debug.Log($"GoodWillBar initialized for NPC: {NPCName}");
        imageComponent = ImageFill.GetComponent<Image>();
        ResetGoodWillBar();
        // AddGoodWillPointsToNPC();
        StartCoroutine(DelayedAddGoodWillPoints());
    }

    private IEnumerator DelayedAddGoodWillPoints()
    {
        yield return new WaitForSeconds(0.2f);
        AddGoodWillPointsToNPC();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        //AddGoodWillPointsToNPC();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateGoodWillBar(int points)
    {
        // Assuming points is between 0 and 100, we convert it to a value between 0 and 1 for the fill amount
        float fillAmount = Mathf.Clamp01(points / 100f);
        imageComponent.fillAmount = fillAmount;
    }

    public void AddGoodWillPointsToNPC()
    {
        switch (NPCName)
        {
            case "Janet":
                UpdateGoodWillBar(gameManager.JanetPoints);
                break;
            case "Mr. Fischer":
                UpdateGoodWillBar(gameManager.DanielPoints);
                break;
            case "Brandy-Lynn":
                UpdateGoodWillBar(gameManager.BrandyPoints);
                break;
            default:
                Debug.LogError($"Unknown NPC: {NPCName}");
                break;
        }
    }

    public void ResetGoodWillBar()
    {
        UpdateGoodWillBar(0);
    }
}