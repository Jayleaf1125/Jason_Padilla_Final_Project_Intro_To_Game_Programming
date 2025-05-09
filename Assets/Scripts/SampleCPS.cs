using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SampleCPS : MonoBehaviour
{
    // Card Spawner
    public GameObject cardPrefab;
    public int rows = 10;
    public int columns = 10;
    public float spacing = 1.5f;
    public float totalSpawnTime = 5f;
    int totalCards;
    //
    public string[] cardTypes = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
    public Sprite[] spriteTypes;
    public Dictionary<string, Sprite> cardDict = new Dictionary<string, Sprite>();

    List<string> chosenCardTypes = new List<string>();
    List<Sprite> chosenSpriteTypes = new List<Sprite>();
    //
    //List<GameObject> spawnedCards = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SettingUpCardDict();
        StartCoroutine(SpawnCards());
        totalCards = rows * columns;
    }

    // Update is called once per frame
    void Update()
    {
        if (totalCards == 0) SceneManager.LoadSceneAsync(2);
    }

    void SettingUpCardDict()
    {
        for (int i = 0; i < cardTypes.Length; i++)
        {
            string cardName = cardTypes[i];
            Sprite cardSprite = spriteTypes[i];

            cardDict[cardName] = cardSprite;
        }
    }

    IEnumerator SpawnCards()
    {
        int totalCards = rows * columns;
        float delay = totalSpawnTime / totalCards;
        float unquieNumOfCards = totalCards / 2;
        int selectedUnquieCards = 0;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Vector3 position = new Vector3(col * spacing, row * -spacing, 0); // -spacing so it stacks downward
                GameObject card = Instantiate(cardPrefab, position, Quaternion.identity, transform);

                if (selectedUnquieCards != unquieNumOfCards)
                {
                    RandomSelectedUnquieCardType(card);
                    selectedUnquieCards++;
                }
                else
                {
                    RandomSelectedDuplicateCardType(card);
                }

                yield return new WaitForSeconds(delay);
            }
        }
    }

    void RandomSelectedUnquieCardType(GameObject card)
    {
        bool isPicking = true;
        CardStats selectedCardStats = card.GetComponent<CardStats>();

        while (isPicking)
        {
            string choosenType = cardTypes[Random.Range(0, cardTypes.Length)];
            if (chosenCardTypes.Contains(choosenType)) continue;

            chosenCardTypes.Add(choosenType);
            chosenSpriteTypes.Add(cardDict[choosenType]);

            isPicking = false;
            selectedCardStats.SetType(choosenType);
            selectedCardStats.SetSprite(cardDict[choosenType]);

            // Debug Statement
            card.name = choosenType;
        }
    }

    void RandomSelectedDuplicateCardType(GameObject card)
    {
        string choosenType = chosenCardTypes.ElementAt(Random.Range(0, chosenCardTypes.Count));
        CardStats selectedCardStats = card.GetComponent<CardStats>();

        chosenCardTypes.Remove(choosenType);
        chosenSpriteTypes.Remove(cardDict[choosenType]);

        selectedCardStats.SetType(choosenType);
        selectedCardStats.SetSprite(cardDict[choosenType]);

        // Debug Statement
        card.name = choosenType;
    }
}
