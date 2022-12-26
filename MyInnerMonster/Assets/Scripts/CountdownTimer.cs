using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private Image timerPic;
    [SerializeField] private Image backgroundPic;
    [SerializeField] private TMPro.TextMeshProUGUI timerText;
    public bool isFinished;



    [SerializeField] private LevelManager levelManager;

    [SerializeField] private ControllBlack _controllBlack;
    [SerializeField] private BlackMovement _blackMovement;

    private float currentTime; // текущее время
    private float startingTime = 20f; // Время на blackEnable

    private bool IsTimerSoundPlaying = false;

    void Awake()
    {
        isFinished = false;
        currentTime = startingTime;
    }



    void FixedUpdate()
    {
        if (_controllBlack.isBlackEnable)
        {
            if (currentTime > -0.0001f)
            {
                isFinished = false;
                timerPic.gameObject.SetActive(true);
                backgroundPic.gameObject.SetActive(true);
                timerText.gameObject.SetActive(true);

                if (!IsTimerSoundPlaying)
                {
                    FindObjectOfType<AudioManager>().Play("timer");
                    IsTimerSoundPlaying = true;
                }
                CountDown();
            }
            else
            {
                levelManager.FadeToLevel();
                levelManager.isPlayerDead = true;
                _controllBlack.canUseBlack = false;

                _blackMovement.enabled = false;
                timerPic.gameObject.SetActive(false);
                backgroundPic.gameObject.SetActive(false);
                timerText.gameObject.SetActive(false);
                FindObjectOfType<AudioManager>().Pause("timer");
                IsTimerSoundPlaying = false;
            }
        }
        else
        {
            currentTime = startingTime;
            isFinished = true;
            timerPic.gameObject.SetActive(false);
            backgroundPic.gameObject.SetActive(false);
            timerText.gameObject.SetActive(false);
            FindObjectOfType<AudioManager>().Pause("timer");
            IsTimerSoundPlaying = false;
        }
    }


    void CountDown()
    {
        currentTime -= Time.deltaTime;
        timerText.text = currentTime.ToString("0");
        timerPic.fillAmount = Mathf.InverseLerp(0, startingTime, currentTime);

    }
}
