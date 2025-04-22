using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CardPlacementSystem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        for (int i = 0; i < rows; i++)
        {
            for(int j = 0; j < columns; j++)
            {
                Vector3 rightSpacing = Vector3.right * (i * spacing);
                Vector3 downSpacing = Vector3.down * (j * spacing);

                cards[i,j] = Instantiate(cardPrefab, transform.position + rightSpacing + downSpacing, Quaternion.identity);
            }
        }
    }





}
