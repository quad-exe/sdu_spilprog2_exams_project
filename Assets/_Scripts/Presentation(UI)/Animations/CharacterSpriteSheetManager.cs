using UnityEngine;
using UnityEngine.UI;

public class CharacterSpriteSheetManager : MonoBehaviour
{
    [SerializeField] private Image characterImage;
    [SerializeField] private Sprite[] characterSprites;
    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {      
        gameManager = GameManager.Instance;
        characterImage.sprite = characterSprites[1];
    }

    // Update is called once per frame
    void Update()
    {
        SetCharacterSprite(gameManager.points);
    }

    public void SetCharacterSprite(int points)
    {
        if (points < 0)
        {
            characterImage.sprite = characterSprites[2];
        }
        else if (points >= 0 && points < 10)
        {
            characterImage.sprite = characterSprites[0];
        }
        else if (points > 10)
        {
            characterImage.sprite = characterSprites[1];
        }
        else
        {
            characterImage.sprite = characterSprites[1]; // or some default sprite
        }
    }
}
