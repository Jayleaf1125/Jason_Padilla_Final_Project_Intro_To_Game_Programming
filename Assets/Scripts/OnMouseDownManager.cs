using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OnMouseDownManager : MonoBehaviour
{
    void OnMouseDown()
    {
       GameObject selectedcard = gameObject;
       CardStats selectedCardStats = selectedcard.GetComponent<CardStats>();
       string selectedCardName = selectedCardStats.cardType;

       GameManager gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
       Dictionary<string, GameObject> selectedCardsList = gameManager.selectedCards;

        if (selectedCardsList.Count == 0 && !selectedCardStats.isClicked)
        {
            selectedCardsList.Add(selectedCardName, selectedcard);
            selectedCardStats.isClicked = true;
        } else
        {
            if(!selectedCardStats.isClicked && selectedCardsList.ContainsKey(selectedCardName))
            {
                Destroy(selectedCardsList[selectedCardName]);
                Destroy(selectedcard);
                selectedCardsList.Clear();
            } else
            {
                selectedCardsList.ElementAt(0).Value.GetComponent<CardStats>().isClicked = false;   
                selectedCardStats.isClicked = false;

                selectedCardsList.Clear();

            }

        }



        
        



    }
}
