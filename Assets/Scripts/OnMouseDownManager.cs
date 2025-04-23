using UnityEngine;

public class OnMouseDownManager : MonoBehaviour
{
    void OnMouseDown()
    {
       string cardName = gameObject.GetComponent<CardStats>().cardType;

       GameManager gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        gameManager.selectedCards.Add(cardName, gameObject);
        print(cardName);

    

    }
}
