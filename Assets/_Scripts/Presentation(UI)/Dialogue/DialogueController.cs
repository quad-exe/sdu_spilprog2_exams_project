using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Application.Dialog;
using Infrastructure.Dialogue;
using System.Collections.Generic;
using Domain.Dialogue;

public class DialogueController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Text npcText;
    [SerializeField] private Transform choicesContainer;
    [SerializeField] private Button choiceButtonPrefab;
    [SerializeField] private TextAsset jsonDialogueFile;

    private DialogueService dialogueService;

    void Start()
    {
        dialogueService = new DialogueService();

        var tree = DialogueLoader.Load(jsonDialogueFile.name);
        if (tree == null)
        {
            Debug.LogError("Failed to load dialogue");
            return;
        }
        dialogueService.StartDialogue(tree);
        Render();
    }

    void Render()
    {
        var node = dialogueService.GetCurrentNode();
        if (node == null) return;

        // 1. Vis NPC tekst
        npcText.text = node.text;

        // 2. Ryd gamle knapper
        foreach (Transform child in choicesContainer)
        {
            Destroy(child.gameObject);
        }

        if (dialogueService.IsDialogueFinished())
        {
            // Handle finished dialogue logic
            GameManager.Instance.ChangeToNextScreen();
        }
  
        // 3. Lav nye knapper
        foreach (var choice in node.dialogueChoices)
        {
            var button = Instantiate(choiceButtonPrefab, choicesContainer);
            button.GetComponentInChildren<TMP_Text>().text = choice.text;

            Debug.Log($"Choice text: {choice.text}, moving to node: {choice.nextNodeId}, Points: {choice.point}");

            string choiceId = choice.id; // vigtig (closure fix)
            button.onClick.AddListener(() => OnChoiceSelected(choiceId, choice.point));
        }
    }

    void OnChoiceSelected(string choiceId, int points)
    {
        if (!dialogueService.TestForChoiceIdDublicates(choiceId))
        {
            GameManager.Instance.points += points;
        }
        dialogueService.SelectChoice(choiceId);
        Render();
    }
}