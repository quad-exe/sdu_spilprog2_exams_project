using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuScreen;
    [SerializeField] private GameObject MenuSettingsScreen;
    [SerializeField] private GameObject MenuQuitScreen;

    private bool isMenuActive = false;

    private RawImage backgroundImage;

     private void Awake()
    {
        backgroundImage = GetComponent<RawImage>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        isMenuActive = true;
        mainMenuScreen.SetActive(true);
        MenuSettingsScreen.SetActive(false);
        MenuQuitScreen.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        BackgroundImageIsEnabled();

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isMenuActive = true;
            MenuQuitScreen.SetActive(true);
        }
    }

    public void OnStartButtonClicked()
    {
        Debug.Log("Start Game");
        // Here you would typically load the next scene or start the game logic
        isMenuActive = false;
    }

    public void BackgroundImageIsEnabled()
    {
        if(isMenuActive) backgroundImage.enabled = true;
        else backgroundImage.enabled = false;
    }

    public void OnPause()
    {
        Debug.Log("Pause Game");
        Time.timeScale = 0f;
        isMenuActive = true;
    }

    public void OnResume()
    {
        Debug.Log("Resume Game");
        Time.timeScale = 1f;
        isMenuActive = false;
    }
}
