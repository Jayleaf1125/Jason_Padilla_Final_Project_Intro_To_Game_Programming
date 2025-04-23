using UnityEngine;

public class CardStats : MonoBehaviour
{
    public string cardType;
    public bool isClicked = false;

    public void SetType(string type)
    {
        cardType = type;
    }

    public void SetIsClicked(bool value)
    {
        isClicked = value;
    }
}
