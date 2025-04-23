using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Dictionary<string, GameObject> selectedCards = new Dictionary<string, GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (selectedCards.Count == 2)
        {
            if (selectedCards.ElementAt(0).Key == selectedCards.ElementAt(1).Key)
            {
                Debug.Log("Nice");
                Destroy(selectedCards.ElementAt(0).Value);
                Destroy(selectedCards.ElementAt(1).Value);

            } else
            {
                Debug.Log("Stupid");
                selectedCards.Clear();
            }
        }
        
    }
}
