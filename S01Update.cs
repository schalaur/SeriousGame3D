using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

using System.Linq;
using System.Text;
using System.IO;

public class S01Update : NetworkBehaviour
{

    // Scene S00 
    public GameObject LevelAppealM6;
    public GameObject LevelAppealM5;
    public GameObject LevelAppealM4;
    public GameObject LevelAppealM3;
    public GameObject LevelAppealM2;
    public GameObject LevelAppealM1;
    public GameObject LevelAppeal0;
    public GameObject LevelAppealP1;
    public GameObject LevelAppealP2;
    public GameObject LevelAppealP3;
    public GameObject LevelAppealP4;
    public GameObject LevelAppealP5;
    public GameObject LevelAppealP6;

    public GameObject LevelApprovalM6;
    public GameObject LevelApprovalM5;
    public GameObject LevelApprovalM4;
    public GameObject LevelApprovalM3;
    public GameObject LevelApprovalM2;
    public GameObject LevelApprovalM1;
    public GameObject LevelApproval0;
    public GameObject LevelApprovalP1;
    public GameObject LevelApprovalP2;
    public GameObject LevelApprovalP3;
    public GameObject LevelApprovalP4;
    public GameObject LevelApprovalP5;
    public GameObject LevelApprovalP6;

    int Appeal;
    int AppealLevel;
    int Approval;
    int ApprovalLevel;

    // Start is called before the first frame update
    // defines all Start-Values saved in PlayerPrefs
    void Start()
    {
        if (isServer)
        {
            SaveVotes();
            PlayerPrefs.SetInt("ArealAnnualbezahlt", 0);
            PlayerPrefs.SetInt("PolizeiAnnualbezahlt", 0);

        }
    }

    // Update is called once per frame
    // Update non-stop the assets and appeal/approval 
    void Update()
    {
        if (!isServer)
        {
            CmdCallServer();

        }
    }

    [Command(requiresAuthority = false)]
    void CmdCallServer()
    {
        Appeal = PlayerPrefs.GetInt("Appeal");
        Approval = PlayerPrefs.GetInt("Approval");

        UpdateAppeal(Appeal);
        UpdateApproval(Approval);

        RpcCallClients(AppealLevel, Appeal, ApprovalLevel, Approval);
    }

    [ClientRpc]
    void RpcCallClients(int AppealLevel, int AppealServer, int ApprovalLevel, int ApprovalServer)
    {
        AppealLevel = AppealServer;
        ApprovalLevel = ApprovalServer;
        UpdateAppeal(AppealLevel);
        UpdateApproval(ApprovalLevel);
    }

    void UpdateAppeal(int AppealLevelGiven)
    {
        if (AppealLevelGiven <= -6)
        {
            LevelAppealM6.SetActive(true);
            LevelAppealM5.SetActive(false);
            LevelAppealM4.SetActive(false);
            LevelAppealM3.SetActive(false);
            LevelAppealM2.SetActive(false);
            LevelAppealM1.SetActive(false);
            LevelAppeal0.SetActive(false);
            LevelAppealP1.SetActive(false);
            LevelAppealP2.SetActive(false);
            LevelAppealP3.SetActive(false);
            LevelAppealP4.SetActive(false);
            LevelAppealP5.SetActive(false);
            LevelAppealP6.SetActive(false);
        }
        else if (AppealLevelGiven == -5)
        {
            LevelAppealM6.SetActive(false);
            LevelAppealM5.SetActive(true);
            LevelAppealM4.SetActive(false);
            LevelAppealM3.SetActive(false);
            LevelAppealM2.SetActive(false);
            LevelAppealM1.SetActive(false);
            LevelAppeal0.SetActive(false);
            LevelAppealP1.SetActive(false);
            LevelAppealP2.SetActive(false);
            LevelAppealP3.SetActive(false);
            LevelAppealP4.SetActive(false);
            LevelAppealP5.SetActive(false);
            LevelAppealP6.SetActive(false);
        }
        else if (AppealLevelGiven == -4)
        {
            LevelAppealM6.SetActive(false);
            LevelAppealM5.SetActive(false);
            LevelAppealM4.SetActive(true);
            LevelAppealM3.SetActive(false);
            LevelAppealM2.SetActive(false);
            LevelAppealM1.SetActive(false);
            LevelAppeal0.SetActive(false);
            LevelAppealP1.SetActive(false);
            LevelAppealP2.SetActive(false);
            LevelAppealP3.SetActive(false);
            LevelAppealP4.SetActive(false);
            LevelAppealP5.SetActive(false);
            LevelAppealP6.SetActive(false);
        }
        else if (AppealLevelGiven == -3)
        {
            LevelAppealM6.SetActive(false);
            LevelAppealM5.SetActive(false);
            LevelAppealM4.SetActive(false);
            LevelAppealM3.SetActive(true);
            LevelAppealM2.SetActive(false);
            LevelAppealM1.SetActive(false);
            LevelAppeal0.SetActive(false);
            LevelAppealP1.SetActive(false);
            LevelAppealP2.SetActive(false);
            LevelAppealP3.SetActive(false);
            LevelAppealP4.SetActive(false);
            LevelAppealP5.SetActive(false);
            LevelAppealP6.SetActive(false);
        }
        else if (AppealLevelGiven == -2)
        {
            LevelAppealM6.SetActive(false);
            LevelAppealM5.SetActive(false);
            LevelAppealM4.SetActive(false);
            LevelAppealM3.SetActive(false);
            LevelAppealM2.SetActive(true);
            LevelAppealM1.SetActive(false);
            LevelAppeal0.SetActive(false);
            LevelAppealP1.SetActive(false);
            LevelAppealP2.SetActive(false);
            LevelAppealP3.SetActive(false);
            LevelAppealP4.SetActive(false);
            LevelAppealP5.SetActive(false);
            LevelAppealP6.SetActive(false);
        }
        else if (AppealLevelGiven == -1)
        {
            LevelAppealM6.SetActive(false);
            LevelAppealM5.SetActive(false);
            LevelAppealM4.SetActive(false);
            LevelAppealM3.SetActive(false);
            LevelAppealM2.SetActive(false);
            LevelAppealM1.SetActive(true);
            LevelAppeal0.SetActive(false);
            LevelAppealP1.SetActive(false);
            LevelAppealP2.SetActive(false);
            LevelAppealP3.SetActive(false);
            LevelAppealP4.SetActive(false);
            LevelAppealP5.SetActive(false);
            LevelAppealP6.SetActive(false);
        }
        else if (AppealLevelGiven == 0)
        {
            LevelAppealM6.SetActive(false);
            LevelAppealM5.SetActive(false);
            LevelAppealM4.SetActive(false);
            LevelAppealM3.SetActive(false);
            LevelAppealM2.SetActive(false);
            LevelAppealM1.SetActive(false);
            LevelAppeal0.SetActive(true);
            LevelAppealP1.SetActive(false);
            LevelAppealP2.SetActive(false);
            LevelAppealP3.SetActive(false);
            LevelAppealP4.SetActive(false);
            LevelAppealP5.SetActive(false);
            LevelAppealP6.SetActive(false);
        }
        else if (AppealLevelGiven == 1)
        {
            LevelAppealM6.SetActive(false);
            LevelAppealM5.SetActive(false);
            LevelAppealM4.SetActive(false);
            LevelAppealM3.SetActive(false);
            LevelAppealM2.SetActive(false);
            LevelAppealM1.SetActive(false);
            LevelAppeal0.SetActive(false);
            LevelAppealP1.SetActive(true);
            LevelAppealP2.SetActive(false);
            LevelAppealP3.SetActive(false);
            LevelAppealP4.SetActive(false);
            LevelAppealP5.SetActive(false);
            LevelAppealP6.SetActive(false);
        }
        else if (AppealLevelGiven == 2)
        {
            LevelAppealM6.SetActive(false);
            LevelAppealM5.SetActive(false);
            LevelAppealM4.SetActive(false);
            LevelAppealM3.SetActive(false);
            LevelAppealM2.SetActive(false);
            LevelAppealM1.SetActive(false);
            LevelAppeal0.SetActive(false);
            LevelAppealP1.SetActive(false);
            LevelAppealP2.SetActive(true);
            LevelAppealP3.SetActive(false);
            LevelAppealP4.SetActive(false);
            LevelAppealP5.SetActive(false);
            LevelAppealP6.SetActive(false);
        }
        else if (AppealLevelGiven == 3)
        {
            LevelAppealM6.SetActive(false);
            LevelAppealM5.SetActive(false);
            LevelAppealM4.SetActive(false);
            LevelAppealM3.SetActive(false);
            LevelAppealM2.SetActive(false);
            LevelAppealM1.SetActive(false);
            LevelAppeal0.SetActive(false);
            LevelAppealP1.SetActive(false);
            LevelAppealP2.SetActive(false);
            LevelAppealP3.SetActive(true);
            LevelAppealP4.SetActive(false);
            LevelAppealP5.SetActive(false);
            LevelAppealP6.SetActive(false);
        }
        else if (AppealLevelGiven == 4)
        {
            LevelAppealM6.SetActive(false);
            LevelAppealM5.SetActive(false);
            LevelAppealM4.SetActive(false);
            LevelAppealM3.SetActive(false);
            LevelAppealM2.SetActive(false);
            LevelAppealM1.SetActive(false);
            LevelAppeal0.SetActive(false);
            LevelAppealP1.SetActive(false);
            LevelAppealP2.SetActive(false);
            LevelAppealP3.SetActive(false);
            LevelAppealP4.SetActive(true);
            LevelAppealP5.SetActive(false);
            LevelAppealP6.SetActive(false);
        }
        else if (AppealLevelGiven == 5)
        {
            LevelAppealM6.SetActive(false);
            LevelAppealM5.SetActive(false);
            LevelAppealM4.SetActive(false);
            LevelAppealM3.SetActive(false);
            LevelAppealM2.SetActive(false);
            LevelAppealM1.SetActive(false);
            LevelAppeal0.SetActive(false);
            LevelAppealP1.SetActive(false);
            LevelAppealP2.SetActive(false);
            LevelAppealP3.SetActive(false);
            LevelAppealP4.SetActive(false);
            LevelAppealP5.SetActive(true);
            LevelAppealP6.SetActive(false);
        }
        else if (AppealLevelGiven >= 6)
        {
            LevelAppealM6.SetActive(false);
            LevelAppealM5.SetActive(false);
            LevelAppealM4.SetActive(false);
            LevelAppealM3.SetActive(false);
            LevelAppealM2.SetActive(false);
            LevelAppealM1.SetActive(false);
            LevelAppeal0.SetActive(false);
            LevelAppealP1.SetActive(false);
            LevelAppealP2.SetActive(false);
            LevelAppealP3.SetActive(false);
            LevelAppealP4.SetActive(false);
            LevelAppealP5.SetActive(false);
            LevelAppealP6.SetActive(true);
        }
    }

    void UpdateApproval(int ApprovalLevelGiven)
    {
        if (ApprovalLevelGiven <= -6)
        {
            LevelApprovalM6.SetActive(true);
            LevelApprovalM5.SetActive(false);
            LevelApprovalM4.SetActive(false);
            LevelApprovalM3.SetActive(false);
            LevelApprovalM2.SetActive(false);
            LevelApprovalM1.SetActive(false);
            LevelApproval0.SetActive(false);
            LevelApprovalP1.SetActive(false);
            LevelApprovalP2.SetActive(false);
            LevelApprovalP3.SetActive(false);
            LevelApprovalP4.SetActive(false);
            LevelApprovalP5.SetActive(false);
            LevelApprovalP6.SetActive(false);
        }
        else if (ApprovalLevelGiven == -5)
        {
            LevelApprovalM6.SetActive(false);
            LevelApprovalM5.SetActive(true);
            LevelApprovalM4.SetActive(false);
            LevelApprovalM3.SetActive(false);
            LevelApprovalM2.SetActive(false);
            LevelApprovalM1.SetActive(false);
            LevelApproval0.SetActive(false);
            LevelApprovalP1.SetActive(false);
            LevelApprovalP2.SetActive(false);
            LevelApprovalP3.SetActive(false);
            LevelApprovalP4.SetActive(false);
            LevelApprovalP5.SetActive(false);
            LevelApprovalP6.SetActive(false);
        }
        else if (ApprovalLevelGiven == -4)
        {
            LevelApprovalM6.SetActive(false);
            LevelApprovalM5.SetActive(false);
            LevelApprovalM4.SetActive(true);
            LevelApprovalM3.SetActive(false);
            LevelApprovalM2.SetActive(false);
            LevelApprovalM1.SetActive(false);
            LevelApproval0.SetActive(false);
            LevelApprovalP1.SetActive(false);
            LevelApprovalP2.SetActive(false);
            LevelApprovalP3.SetActive(false);
            LevelApprovalP4.SetActive(false);
            LevelApprovalP5.SetActive(false);
            LevelApprovalP6.SetActive(false);
        }
        else if (ApprovalLevelGiven == -3)
        {
            LevelApprovalM6.SetActive(false);
            LevelApprovalM5.SetActive(false);
            LevelApprovalM4.SetActive(false);
            LevelApprovalM3.SetActive(true);
            LevelApprovalM2.SetActive(false);
            LevelApprovalM1.SetActive(false);
            LevelApproval0.SetActive(false);
            LevelApprovalP1.SetActive(false);
            LevelApprovalP2.SetActive(false);
            LevelApprovalP3.SetActive(false);
            LevelApprovalP4.SetActive(false);
            LevelApprovalP5.SetActive(false);
            LevelApprovalP6.SetActive(false);
        }
        else if (ApprovalLevelGiven == -2)
        {
            LevelApprovalM6.SetActive(false);
            LevelApprovalM5.SetActive(false);
            LevelApprovalM4.SetActive(false);
            LevelApprovalM3.SetActive(false);
            LevelApprovalM2.SetActive(true);
            LevelApprovalM1.SetActive(false);
            LevelApproval0.SetActive(false);
            LevelApprovalP1.SetActive(false);
            LevelApprovalP2.SetActive(false);
            LevelApprovalP3.SetActive(false);
            LevelApprovalP4.SetActive(false);
            LevelApprovalP5.SetActive(false);
            LevelApprovalP6.SetActive(false);
        }
        else if (ApprovalLevelGiven == -1)
        {
            LevelApprovalM6.SetActive(false);
            LevelApprovalM5.SetActive(false);
            LevelApprovalM4.SetActive(false);
            LevelApprovalM3.SetActive(false);
            LevelApprovalM2.SetActive(false);
            LevelApprovalM1.SetActive(true);
            LevelApproval0.SetActive(false);
            LevelApprovalP1.SetActive(false);
            LevelApprovalP2.SetActive(false);
            LevelApprovalP3.SetActive(false);
            LevelApprovalP4.SetActive(false);
            LevelApprovalP5.SetActive(false);
            LevelApprovalP6.SetActive(false);
        }
        else if (ApprovalLevelGiven == 0)
        {
            LevelApprovalM6.SetActive(false);
            LevelApprovalM5.SetActive(false);
            LevelApprovalM4.SetActive(false);
            LevelApprovalM3.SetActive(false);
            LevelApprovalM2.SetActive(false);
            LevelApprovalM1.SetActive(false);
            LevelApproval0.SetActive(true);
            LevelApprovalP1.SetActive(false);
            LevelApprovalP2.SetActive(false);
            LevelApprovalP3.SetActive(false);
            LevelApprovalP4.SetActive(false);
            LevelApprovalP5.SetActive(false);
            LevelApprovalP6.SetActive(false);
        }
        else if (ApprovalLevelGiven == 1)
        {
            LevelApprovalM6.SetActive(false);
            LevelApprovalM5.SetActive(false);
            LevelApprovalM4.SetActive(false);
            LevelApprovalM3.SetActive(false);
            LevelApprovalM2.SetActive(false);
            LevelApprovalM1.SetActive(false);
            LevelApproval0.SetActive(false);
            LevelApprovalP1.SetActive(true);
            LevelApprovalP2.SetActive(false);
            LevelApprovalP3.SetActive(false);
            LevelApprovalP4.SetActive(false);
            LevelApprovalP5.SetActive(false);
            LevelApprovalP6.SetActive(false);
        }
        else if (ApprovalLevelGiven == 2)
        {
            LevelApprovalM6.SetActive(false);
            LevelApprovalM5.SetActive(false);
            LevelApprovalM4.SetActive(false);
            LevelApprovalM3.SetActive(false);
            LevelApprovalM2.SetActive(false);
            LevelApprovalM1.SetActive(false);
            LevelApproval0.SetActive(false);
            LevelApprovalP1.SetActive(false);
            LevelApprovalP2.SetActive(true);
            LevelApprovalP3.SetActive(false);
            LevelApprovalP4.SetActive(false);
            LevelApprovalP5.SetActive(false);
            LevelApprovalP6.SetActive(false);
        }
        else if (ApprovalLevelGiven == 3)
        {
            LevelApprovalM6.SetActive(false);
            LevelApprovalM5.SetActive(false);
            LevelApprovalM4.SetActive(false);
            LevelApprovalM3.SetActive(false);
            LevelApprovalM2.SetActive(false);
            LevelApprovalM1.SetActive(false);
            LevelApproval0.SetActive(false);
            LevelApprovalP1.SetActive(false);
            LevelApprovalP2.SetActive(false);
            LevelApprovalP3.SetActive(true);
            LevelApprovalP4.SetActive(false);
            LevelApprovalP5.SetActive(false);
            LevelApprovalP6.SetActive(false);
        }
        else if (ApprovalLevelGiven == 4)
        {
            LevelApprovalM6.SetActive(false);
            LevelApprovalM5.SetActive(false);
            LevelApprovalM4.SetActive(false);
            LevelApprovalM3.SetActive(false);
            LevelApprovalM2.SetActive(false);
            LevelApprovalM1.SetActive(false);
            LevelApproval0.SetActive(false);
            LevelApprovalP1.SetActive(false);
            LevelApprovalP2.SetActive(false);
            LevelApprovalP3.SetActive(false);
            LevelApprovalP4.SetActive(true);
            LevelApprovalP5.SetActive(false);
            LevelApprovalP6.SetActive(false);
        }
        else if (ApprovalLevelGiven == 5)
        {
            LevelApprovalM6.SetActive(false);
            LevelApprovalM5.SetActive(false);
            LevelApprovalM4.SetActive(false);
            LevelApprovalM3.SetActive(false);
            LevelApprovalM2.SetActive(false);
            LevelApprovalM1.SetActive(false);
            LevelApproval0.SetActive(false);
            LevelApprovalP1.SetActive(false);
            LevelApprovalP2.SetActive(false);
            LevelApprovalP3.SetActive(false);
            LevelApprovalP4.SetActive(false);
            LevelApprovalP5.SetActive(true);
            LevelApprovalP6.SetActive(false);
        }
        else if (ApprovalLevelGiven >= 6)
        {
            LevelApprovalM6.SetActive(false);
            LevelApprovalM5.SetActive(false);
            LevelApprovalM4.SetActive(false);
            LevelApprovalM3.SetActive(false);
            LevelApprovalM2.SetActive(false);
            LevelApprovalM1.SetActive(false);
            LevelApproval0.SetActive(false);
            LevelApprovalP1.SetActive(false);
            LevelApprovalP2.SetActive(false);
            LevelApprovalP3.SetActive(false);
            LevelApprovalP4.SetActive(false);
            LevelApprovalP5.SetActive(false);
            LevelApprovalP6.SetActive(true);
        }
    }

    void SaveVotes()
    {
        using (StreamWriter sw = File.AppendText(@"Z:\people\schalaur\Globescape\13_RecordingGame\Log.txt"))
        {
            sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " Vote - Gemeinde - Allgemein: " + PlayerPrefs.GetString("VoteAllgemeinP1"));
            sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " Vote - Gemeinde - Projekt: " + PlayerPrefs.GetString("VoteProjektP1"));
            sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " Vote - Gemeinde - Aktion: " + PlayerPrefs.GetString("VoteAktionP1"));
            sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " Vote - Gemeinde - Events: " + PlayerPrefs.GetString("VoteEreignisseP1"));

            sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " Vote - Landbesitzer - Allgemein: " + PlayerPrefs.GetString("VoteAllgemeinP2"));
            sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " Vote - Landbesitzer - Projekt: " + PlayerPrefs.GetString("VoteProjektP2"));
            sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " Vote - Landbesitzer - Aktion: " + PlayerPrefs.GetString("VoteAktionP2"));
            sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " Vote - Landbesitzer - Events: " + PlayerPrefs.GetString("VoteEreignisseP2"));

            sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " Vote - Genossenschaft - Allgemein: " + PlayerPrefs.GetString("VoteAllgemeinP3"));
            sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " Vote - Genossenschaft - Projekt: " + PlayerPrefs.GetString("VoteProjektP3"));
            sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " Vote - Genossenschaft - Aktion: " + PlayerPrefs.GetString("VoteAktionP3"));
            sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " Vote - Genossenschaft - Events: " + PlayerPrefs.GetString("VoteEreignisseP3"));

            sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " Vote - Kulturzentrum - Allgemein: " + PlayerPrefs.GetString("VoteAllgemeinP4"));
            sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " Vote - Kulturzentrum - Projekt: " + PlayerPrefs.GetString("VoteProjektP4"));
            sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " Vote - Kulturzentrum - Aktion: " + PlayerPrefs.GetString("VoteAktionP4"));
            sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " Vote - Kulturzentrum - Events: " + PlayerPrefs.GetString("VoteEreignisseP4"));

            sw.Close();
        }
        NeueVotes();
    }

    void NeueVotes()
    {
        PlayerPrefs.SetString("VoteAllgemeinP1", "Nicht angegeben");
        PlayerPrefs.SetString("VoteAllgemeinP2", "Nicht angegeben");
        PlayerPrefs.SetString("VoteAllgemeinP3", "Nicht angegeben");
        PlayerPrefs.SetString("VoteAllgemeinP4", "Nicht angegeben");

        PlayerPrefs.SetString("VoteAktionP1", "Nicht angegeben");
        PlayerPrefs.SetString("VoteAktionP2", "Nicht angegeben");
        PlayerPrefs.SetString("VoteAktionP3", "Nicht angegeben");
        PlayerPrefs.SetString("VoteAktionP4", "Nicht angegeben");

        PlayerPrefs.SetString("VoteProjektP1", "Nicht angegeben");
        PlayerPrefs.SetString("VoteProjektP2", "Nicht angegeben");
        PlayerPrefs.SetString("VoteProjektP3", "Nicht angegeben");
        PlayerPrefs.SetString("VoteProjektP4", "Nicht angegeben");

        PlayerPrefs.SetString("VoteEventsP1", "Nicht angegeben");
        PlayerPrefs.SetString("VoteEventsP2", "Nicht angegeben");
        PlayerPrefs.SetString("VoteEventsP3", "Nicht angegeben");
        PlayerPrefs.SetString("VoteEventsP4", "Nicht angegeben");
    }

}
