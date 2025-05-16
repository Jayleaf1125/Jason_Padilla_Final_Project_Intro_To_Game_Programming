using UnityEngine;

public class CardStats : MonoBehaviour
{
    public float id;
    public string cardType;
    public bool isClicked = false;
    public SpriteRenderer sr;
    public ParticleSystem starParticle;
    Transform starParticleSpawn;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        starParticleSpawn = GameObject.Find("Par_Spawner").transform;
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

    public void PlayParticle()
    {
        Instantiate(starParticle, starParticleSpawn);
        //starParticle.Play();
    }
}
