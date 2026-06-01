using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuScreen;
    [SerializeField] private GameObject MenuSettingsScreen;
    [SerializeField] private GameObject MenuQuitScreen;
    [SerializeField] private VideoPlayer backgroundVideoPlayer;
    [SerializeField] private Canvas GameScreen;

    private bool isMenuActive = false;

    // private RawImage backgroundImage;

     private void Awake()
    {
        SetMenuActive();
    }

    private void OnEnable()
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        BackgroundImageIsEnabled();

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            OnPause();
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
        if(isMenuActive) backgroundVideoPlayer.enabled = true;
        else backgroundVideoPlayer.enabled = false;
    }

    public void OnPause()
    {
        Debug.Log("Pause Game");
        Time.timeScale = 0f;
        isMenuActive = true;
        GameScreen.enabled = false;
    }

    public void OnResume()
    {
        Debug.Log("Resume Game");
        Time.timeScale = 1f;
        isMenuActive = false;
        GameScreen.enabled = true;
    }

    public void SetMenuActive()
    {
        isMenuActive = true;
        mainMenuScreen.SetActive(true);
        MenuSettingsScreen.SetActive(false);
        MenuQuitScreen.SetActive(false);
    }
}
