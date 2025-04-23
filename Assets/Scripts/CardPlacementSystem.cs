using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardPlacementSystem : MonoBehaviour
{
    string[] cardTypes = { "Apple", "Orange", "Grape", "Watermelon", "Coconut" };
    List<string> chosenCardTypes = new List<string>();

    public int rows;
    public int columns;
    public GameObject cardPrefab;

    public GameObject[,] cardsInPlay;
    public float spacing;



    void Start()
    {
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
            isPicking = false;
            card.GetComponent<CardStats>().SetType(choosenType);

            // Debug Statement
            card.name = choosenType;
        }
    }

    void RandomSelectedDuplicateCardType(GameObject card)
    {
       string choosenType = chosenCardTypes.ElementAt(Random.Range(0, chosenCardTypes.Count));

       chosenCardTypes.Remove(choosenType);
       card.GetComponent<CardStats>().SetType(choosenType);

        // Debug Statement
        card.name = choosenType;
    }




}
