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

        public void StartDialogue(DialogueTree dialogueTree)
        {
            tree = dialogueTree;

            // Build lookup for fast access
            nodeLookup = new Dictionary<string, DialogueNode>();
            foreach (var node in tree.nodes)
            {
                nodeLookup[node.id] = node;
            }

            currentNode = nodeLookup[tree.startNodeId];
        }

        public DialogueNode GetCurrentNode()
        {
            return currentNode;
        }

        public void SelectChoice(string choiceId)
        {
            var choice = currentNode.dialogueChoices.Find(c => c.id == choiceId);
            

            if (choice == null)
            {
                Debug.LogError("Choice not found!");
                return;
            }
            
            currentNode = nodeLookup[choice.nextNodeId];
        }
    }
}

