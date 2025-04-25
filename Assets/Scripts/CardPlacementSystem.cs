using NUnit.Framework;
using NUnit.Framework.Constraints;
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
    public GameObject cardPrefab;

    public GameObject[,] cardsInPlay;
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
        cardsInPlay = new GameObject[rows, columns];
        CardPlacementSetUp(cardsInPlay);
    }

    void CardPlacementSetUp(GameObject[,] cards)
    {
        int unquieNumOfCards = cardsInPlay.Length / 2;
        int selectedUnquieCards = 0;

        for (int i = 0; i < rows; i++)
        {
            for(int j = 0; j < columns; j++)
            {
                Vector3 rightSpacing = Vector3.right * (i * spacing);
                Vector3 downSpacing = Vector3.down * (j * spacing);

                cards[i,j] = Instantiate(cardPrefab, transform.position + rightSpacing + downSpacing, Quaternion.identity);

                if (selectedUnquieCards != unquieNumOfCards)
                {
                    RandomSelectedUnquieCardType(cards[i, j]);
                    selectedUnquieCards++;
                } else
                {
                    RandomSelectedDuplicateCardType(cards[i, j]);
                }

            }
        }
    }

    void RandomSelectedUnquieCardType(GameObject card)
    {
        bool isPicking = true;

        while (isPicking)
        {
            string choosenType = cardTypes[Random.Range(0, cardTypes.Length)];
            if (chosenCardTypes.Contains(choosenType)) continue;

            chosenCardTypes.Add(choosenType);
            chosenSpriteTypes.Add(cardDict[choosenType]);

            isPicking = false;
            card.GetComponent<CardStats>().SetType(choosenType);
            card.GetComponent<CardStats>().SetSprite(cardDict[choosenType]);

            // Debug Statement
            card.name = choosenType;
        }
    }

    void RandomSelectedDuplicateCardType(GameObject card)
    {
       string choosenType = chosenCardTypes.ElementAt(Random.Range(0, chosenCardTypes.Count));

       chosenCardTypes.Remove(choosenType);
       chosenSpriteTypes.Remove(cardDict[choosenType]);

       card.GetComponent<CardStats>().SetType(choosenType);
       card.GetComponent<CardStats>().SetSprite(cardDict[choosenType]);

        // Debug Statement
        card.name = choosenType;
    }


    private void Update()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                GameObject card = cardsInPlay[i, j];
                if (card != null) return;
            }
        }

        SceneManager.LoadSceneAsync(2);
    }

}
