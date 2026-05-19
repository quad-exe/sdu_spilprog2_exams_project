// using Domain.Dialogue;
// using Infrastructure.Dialogue;
// using UnityEditor.Rendering;
// using UnityEngine;


// public class TestJson : MonoBehaviour
// {
//     private string jsonFileName = "DialogTest";
//     DialogueLoader dialogue;
//     DialogueTree dialogueTree;

//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
//         dialogue = new DialogueLoader();
//         dialogueTree = new DialogueTree();

//         dialogueTree = dialogue.Load(jsonFileName);
//         Debug.Log("Dialoger id: " + dialogueTree.id);
//         Debug.Log("Dialoge Start Node: " + dialogueTree.startNodeId);
//         foreach(var dialogeNode in dialogueTree.nodes)
//         {
//             Debug.Log(dialogeNode.id);
//             Debug.Log(dialogeNode.text);
//         }
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }
