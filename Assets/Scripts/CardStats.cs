using UnityEngine;

public class CardStats : MonoBehaviour
{
    public string cardType;
    public bool isClicked = false;
    public SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void SetType(string type)
    {
        cardType = type;
    }

    public void SetIsClicked(bool value)
    {
        isClicked = value;
    }

    public void SetSprite(Sprite sprite)
    {
        sr.sprite = sprite;
    }

    public void SetColor(Color color)
    {
        sr.color = color;
    }
}
