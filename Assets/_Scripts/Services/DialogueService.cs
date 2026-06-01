using System.Collections.Generic;
using Domain.Dialogue;
using UnityEngine;

namespace Application.Dialog
{
    public class DialogueService
    {
        private DialogueTree tree;
        private Dictionary<string, DialogueNode> nodeLookup;
        private DialogueNode currentNode;
        private List<string> choiceIds = new List<string>();
        
        public string CurrentNPC {get ; private set;}

        public void StartDialogue(DialogueTree dialogueTree)
        {
            ResetForNewScreen();

            tree = dialogueTree;

            // Build lookup for fast access
            nodeLookup = new Dictionary<string, DialogueNode>();
            foreach (var node in tree.nodes)
            {
                nodeLookup[node.id] = node;
            }

            currentNode = nodeLookup[tree.startNodeId];

            CurrentNPC = tree.npcName;
            Debug.Log($"Starting dialogue with NPC: {CurrentNPC}");
        }

        public DialogueNode GetCurrentNode()
        {
            IsDialogueFinished();
            return currentNode;
        }

        public void SelectChoice(string choiceId)
        {
            choiceIds.Add(choiceId);
            var choice = currentNode.dialogueChoices.Find(c => c.id == choiceId);
            
            if (choice == null)
            {
                Debug.LogError("Choice not found!");
                return;
            }
            
            currentNode = nodeLookup[choice.nextNodeId];
        }

        public bool TestForChoiceIdDublicates(string choiceId)
        {
            if (choiceIds.Contains(choiceId))
            {
                Debug.LogError("Duplicate choice ID found!");
                return true;
            }
            return false;
        }

        public void ResetForNewScreen()
        {
            choiceIds.Clear();
            GameManager.Instance.points = 0;
        }

        public bool IsDialogueFinished()
        {
            return currentNode.dialogueChoices.Count == 0;
        }

        public void AddGoodWillPointsToNPC()
        {
            switch (CurrentNPC)
            {
                case "Janet":
                    GameManager.Instance.JanetPoints += GameManager.Instance.points;
                    break;
                case "Mr. Fischer":
                    GameManager.Instance.DanielPoints += GameManager.Instance.points;
                    break;
                case "Brandy-Lynn":
                    GameManager.Instance.BrandyPoints += GameManager.Instance.points;
                    break;
            }
            Debug.Log($"Added {GameManager.Instance.points} points to {CurrentNPC}");
            Debug.Log($"Current points - Janet: {GameManager.Instance.JanetPoints}, Daniel: {GameManager.Instance.DanielPoints}, Brandy: {GameManager.Instance.BrandyPoints}");
        }
    }
}

