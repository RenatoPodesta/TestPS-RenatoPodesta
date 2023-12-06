using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [Header("Timer")]
    [SerializeField] TMP_Text timerText;
    [SerializeField] GameObject winner;
    public float remainingTime = 180;
    float gsTime;

    private void Start()
    {
        Time.timeScale = 1;
        winner.gameObject.SetActive(false);
        gsTime = PlayerPrefs.GetFloat("GameSessionTime");
        //getRTime = float.Parse(GetComponent<UIHandler>()._iFieldGST.text);
    }

    void Update()
    {
        if (gsTime == 0) 
        {
            gsTime = remainingTime;
        }
        else
        {
            gsTime -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(gsTime / 60);
            int seconds = Mathf.FloorToInt(gsTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            StopTimer();
        }
    }

    void StopTimer()
    {
        if (gsTime > 0)
        {
            gsTime -= Time.deltaTime;
        }
        else if (gsTime <= 0)
        {
            gsTime = 0;
            Time.timeScale = 0;
            Winner();
        }

    }

    void Winner()
    {
        Time.timeScale = 0;
        winner.gameObject.SetActive(true);  
    }
    
}
