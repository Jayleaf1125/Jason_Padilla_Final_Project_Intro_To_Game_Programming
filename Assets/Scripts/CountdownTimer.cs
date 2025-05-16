using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI countdownTimer;
    public float intialTime = 0f;
    public float remainingTime;
    public int loseLevel;

    public bool instantLose = false;

    private void Awake()
    {
        remainingTime = intialTime;
    }

    private void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
            countdownTimer.color = Color.red;
            SceneManager.LoadSceneAsync(loseLevel);
        }

        if (instantLose && Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadSceneAsync(loseLevel);
        }


        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        countdownTimer.text = string.Format("{0:00}: {1:00}", minutes, seconds);
    }
}
