using UnityEngine;

public class RevealCards : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    SpriteRenderer _sr;
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Reveal();
    }

    void Reveal()
    {
        // Left Click
        if (Input.GetMouseButtonDown(0))
        {
            _sr.color = Color.black ;
        }
    }
}
