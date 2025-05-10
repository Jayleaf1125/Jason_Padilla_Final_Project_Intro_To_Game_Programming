using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardPlacementSystem : MonoBehaviour
{
    public string[] cardTypes = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
    public Sprite[] spriteTypes;

    public Dictionary<string, Sprite> cardDict = new Dictionary<string, Sprite>();

    List<string> chosenCardTypes = new List<string>();
    List<Sprite> chosenSpriteTypes = new List<Sprite>();

    public int rows;
    public int columns;
    public int totalNumOfCards;

    public GameObject cardPrefab;

    public float spacing;

    

    void SettingUpCardDict()
    {
        for (int i = 0; i < cardTypes.Length; i++)
        {
            string cardName = cardTypes[i];
            Sprite cardSprite = spriteTypes[i];

            cardDict[cardName] = cardSprite;
        }
    }

    void Start()
    {
        SettingUpCardDict();
        // cardsInPlay = new GameObject[rows, columns];
        totalNumOfCards = rows * columns;
        CardPlacementSetUp();
    }

    void CardPlacementSetUp()
    {
        int unquieNumOfCards = totalNumOfCards / 2;
        int selectedUnquieCards = 0;
        float idCounts = 0;

        for (int i = 0; i < rows; i++)
        {
            for(int j = 0; j < columns; j++)
            {
                Vector3 rightSpacing = Vector3.right * (i * spacing);
                Vector3 downSpacing = Vector3.down * (j * spacing);

                GameObject card = Instantiate(cardPrefab, transform.position + rightSpacing + downSpacing, Quaternion.identity);
                CardStats selectedCardStats = card.GetComponent<CardStats>();

                selectedCardStats.id =  ++idCounts;

                if (selectedUnquieCards != unquieNumOfCards)
                {
                    RandomSelectedUnquieCardType(selectedCardStats);
                    selectedUnquieCards++;
                } else
                {
                    RandomSelectedDuplicateCardType(selectedCardStats);
                }

            }
        }
    }

    void RandomSelectedUnquieCardType(CardStats cardStats)
    {
        bool isPicking = true;

        while (isPicking)
        {
            string choosenType = cardTypes[Random.Range(0, cardTypes.Length)];
            if (chosenCardTypes.Contains(choosenType)) continue;

            chosenCardTypes.Add(choosenType);
            chosenSpriteTypes.Add(cardDict[choosenType]);

            isPicking = false;
            cardStats.SetType(choosenType);
            cardStats.SetSprite(cardDict[choosenType]);
            cardStats.SetColor(Color.black);
        }
    }

    void RandomSelectedDuplicateCardType(CardStats cardStats)
    {
       string choosenType = chosenCardTypes.ElementAt(Random.Range(0, chosenCardTypes.Count));

       chosenCardTypes.Remove(choosenType);
       chosenSpriteTypes.Remove(cardDict[choosenType]);

       cardStats.SetType(choosenType);
       cardStats.SetSprite(cardDict[choosenType]);
       cardStats.SetColor(Color.black);
    }

    private void Update()
    {
        if (totalNumOfCards == 0) SceneManager.LoadSceneAsync(2);
    }

}
