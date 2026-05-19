using Domain.Dialogue;
using UnityEngine;

namespace Infrastructure.Dialogue
{
    public static class DialogueLoader
    {
        public static DialogueTree Load(string fileName)
        {
            TextAsset jsonFile = Resources.Load<TextAsset>(fileName);

            if (jsonFile == null)
            {
                Debug.LogError($"Could not find JSON file: {fileName}");
                return null;
            }

            return JsonUtility.FromJson<DialogueTree>(jsonFile.text);
        }
    }
}
