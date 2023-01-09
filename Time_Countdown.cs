using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mirror;

using System;

public class Time_Countdown : NetworkBehaviour
{

    //float timeRemaining;
    public bool timerIsRunning = false;
    float minutes;
    float seconds;

    System.DateTime currentDate;
    System.DateTime oldDate;
    long timeRemaining;

    public Text timeText;
    public GameObject PanelTime;

    [SyncVar]
    int SpielEnde;

    private void Start()
    {
        if (isServer)
        {
            SpielEnde = PlayerPrefs.GetInt("SpielEnde");
        }
        minutes = 10;
        seconds = 1;

        timeRemaining = -8585536522940901234;


        if (SpielEnde == 1)
        {
            timerIsRunning = false;
            PanelTime.SetActive(false);
        }
        else
        {
            timeRemaining = Convert.ToInt64(PlayerPrefs.GetString("timeRemaining"));

            timerIsRunning = true;
            minutes = 10;
            seconds = 10;
        }
    }

    [Command(requiresAuthority = false)]
    void CmdCallServerTime()
    {
        timeRemaining = Convert.ToInt64(PlayerPrefs.GetString("timeRemaining"));

        RpcCallClientsTime(timeRemaining);
    }

    [ClientRpc]
    void RpcCallClientsTime(long TimeServer)
    {
        timeRemaining = TimeServer;
    }


    void Update()
    {
        currentDate = System.DateTime.Now;
        long temp = Convert.ToInt64(timeRemaining);
        System.DateTime oldDate = DateTime.FromBinary(temp);
        System.TimeSpan difference = oldDate.Subtract(currentDate);
        minutes = difference.Minutes;
        seconds = difference.Seconds;

        if (timerIsRunning)
        {
            if (minutes > 1)
            {
                DisplayTime(minutes, seconds);
            }

            else if (seconds >= 0)
            {
                DisplayTime(minutes, seconds);
                PanelTime.GetComponent<Image>().color = new Color32(255, 0, 0, 70);
                if (seconds == 0)
                {
                    timeRemaining = 0;
                    timerIsRunning = false;
                    Scene05();
                }
            }
        }
    }

    void DisplayTime(float minutes, float seconds)
    {
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void Scene05()
    {
        NetworkServer.SetAllClientsNotReady();
        NetworkManager.singleton.ServerChangeScene("05_Events");
    }
}
