using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OnMouseDownManager : MonoBehaviour
{
    void OnMouseDown()
    {
       GameObject selectedcard = gameObject;
       string selectedCardName = selectedcard.GetComponent<CardStats>().cardType;

       GameManager gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
       Dictionary<string, GameObject> selectedCardsList = gameManager.selectedCards;

        if(selectedCardsList.Count == 0)
        {
            selectedCardsList.Add(selectedCardName, selectedcard);
        } else
        {
            if(selectedCardsList.ContainsKey(selectedCardName))
            {
                Debug.Log("You win");
                Destroy(selectedCardsList[selectedCardName]);
                Destroy(selectedcard);
                selectedCardsList.Clear();
            } else
            {
                Debug.Log("You Lose");
                selectedCardsList.Clear();
            }

        }



        
        



    }
}
