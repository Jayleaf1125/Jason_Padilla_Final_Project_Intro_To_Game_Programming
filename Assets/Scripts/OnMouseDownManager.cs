using UnityEngine;

public class OnMouseDownManager : MonoBehaviour
{
    void OnMouseDown()
    {
       SpriteRenderer _sr = gameObject.GetComponent<SpriteRenderer>();
        _sr.color = Color.red;

    }
}
