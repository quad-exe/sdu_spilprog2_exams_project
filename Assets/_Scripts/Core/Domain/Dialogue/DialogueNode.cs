using System.Collections.Generic;
using UnityEngine;

namespace Domain.Dialogue
{
    [System.Serializable]
    public class DialogueNode
    {
        // these 3 is set to public for testing purposes should be set to private later
        public string id;
        public string text;
        public List<DialogueChoice> dialogueChoices;
    }
}
