using System.Collections.Generic;
// using Unity.GraphToolkit.Editor;
using UnityEngine;

namespace Domain.Dialogue
{
    [System.Serializable]
    public class DialogueTree
    {
        // here the id is set to public for testing purposes. Should be set back to private
        public string id;
        public string startNodeId;
        public List<DialogueNode> nodes;
    }
}

