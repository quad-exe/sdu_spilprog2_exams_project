using System.Collections.Generic;
using UnityEngine;
using Application.Dialog;
using System.Collections;


public class GameManager : MonoBehaviour
{
    [SerializeField] private DialogueService dialogueService;
    [SerializeField] private List<GameObject> screens;
    public int points;

    // Singleton pattern implementation
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                SetupInstance();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        // Ensure that only one instance of GameManager exists
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
            Debug.Log("Singleton instance created");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // This method is used to set up the singleton instance if it doesn't already exist
    private static void SetupInstance()
    {
        _instance = FindFirstObjectByType<GameManager>();

        if (_instance == null)
        {
            GameObject gameObj = new GameObject();
            gameObj.name = "GameManager";
            _instance = gameObj.AddComponent<GameManager>();
            DontDestroyOnLoad(gameObj);
        }
    }

    public void ChangeToNextScreen()
    {
        StartCoroutine(ChangeToNextScreenCoroutine());
    }

    public IEnumerator ChangeToNextScreenCoroutine()
    {
        for (int i = 0; i < screens.Count; i++)
        {
            if (screens[i].activeSelf)
            {
                yield return new WaitForSeconds(3.0f);
                screens[i].SetActive(false);
                screens[(i + 1) % screens.Count].SetActive(true);
                break;
            }
        }
    }
}