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

    private DialogueService dialogueService;

    void Start()
    {
        dialogueService = new DialogueService();

        var tree = DialogueLoader.Load("DialogTest");
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
  
        // 3. Lav nye knapper
        foreach (var choice in node.dialogueChoices)
        {
            var button = Instantiate(choiceButtonPrefab, choicesContainer);
            button.GetComponentInChildren<TMP_Text>().text = choice.text;

            string choiceId = choice.id; // vigtig (closure fix)
            button.onClick.AddListener(() => OnChoiceSelected(choiceId));
        }
    }

    void OnChoiceSelected(string choiceId)
    {
        dialogueService.SelectChoice(choiceId);
        Render();
    }
}