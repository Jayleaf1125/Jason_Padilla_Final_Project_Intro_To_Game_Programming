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
        selectedCardStats.SetColor(Color.white);

        GameManager gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
       CardPlacementSystem cps = GameObject.Find("Card Placement System").GetComponent<CardPlacementSystem>();

       Dictionary<string, GameObject> selectedCardsList = gameManager.selectedCards;

        if (selectedCardsList.Count == 0 && !selectedCardStats.isClicked)
        {
            selectedCardsList.Add(selectedCardName, selectedcard);
            selectedCardStats.isClicked = true;
        } else
        {
            if(!selectedCardStats.isClicked && selectedCardsList.ContainsKey(selectedCardName))
            {
                StartCoroutine(ResetSelectedCardsOffWin(selectedCardsList, selectedcard, selectedCardName, cps));
            } else
            {
                StartCoroutine(ResetSelectedCardsOffLost(selectedCardsList, selectedCardStats));
            }

        }
    }

    IEnumerator ResetSelectedCardsOffLost(Dictionary<string, GameObject> selectedCardsList, CardStats selectedCardStats)
    {
        Cursor.visible = false;

        yield return new WaitForSeconds(1.5f);

        selectedCardsList.ElementAt(0).Value.GetComponent<CardStats>().isClicked = false;
        selectedCardStats.isClicked = false;

        selectedCardsList.ElementAt(0).Value.GetComponent<CardStats>().SetColor(Color.black);
        selectedCardStats.SetColor(Color.black);

        selectedCardsList.Clear();

        Cursor.visible = true;
    }

    IEnumerator ResetSelectedCardsOffWin(Dictionary<string, GameObject> selectedCardsList, GameObject selectedcard, string selectedCardName, CardPlacementSystem cps)
    {
        yield return new WaitForSeconds(1.5f);

        Destroy(selectedCardsList[selectedCardName]);
        Destroy(selectedcard);
        cps.totalNumOfCards -= 2;
        selectedCardsList.Clear();
    }
}
