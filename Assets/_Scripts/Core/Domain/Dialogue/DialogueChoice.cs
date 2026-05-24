using UnityEngine;
namespace Domain.Dialogue
{
    [System.Serializable]
    public class DialogueChoice
    {
        // these 3 is set to public for testing purposes should be set to private later
        public string id;
        public string text;
        public int point;
        public string nextNodeId;
    }
}
