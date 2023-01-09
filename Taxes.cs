using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

using System.Linq;
using System.Text;
using System.IO;

public class Taxes : NetworkBehaviour
{

    [SyncVar]
    private int TaxesPlayer2;
    [SyncVar]
    private float ProcentPlayer2;
    public Text TextPayPlayer2;
    public Slider SliderCostsP2;

    [SyncVar]
    private int TaxesPlayer3;
    [SyncVar]
    private float ProcentPlayer3;
    public Text TextPayPlayer3;
    public Slider SliderCostsP3;

    [SyncVar]
    private int TaxesPlayer4;
    [SyncVar]
    private float ProcentPlayer4;
    public Text TextPayPlayer4;
    public Slider SliderCostsP4;

    [SyncVar]
    private int TaxesPlayerTotal;
    public Text TextPayTotal;

    [SyncVar]
    int AssetPlayer1;

    [SyncVar]
    int AssetPlayer2;

    [SyncVar]
    int AssetPlayer3;

    [SyncVar]
    int AssetPlayer4;

    int ApprovalMinus = 2;

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

    public Button SetTaxes;

    public GameObject buttonserver;

    int Appeal;
    int AppealLevel;
    int Approval;
    int ApprovalLevel;


    void StartRaiseTaxes()
    {
        NormRaiseTaxes();

        if (isServer)
        {
            RpcRaiseTaxes();
        }
        else
        {
            CmdRaiseTaxes();
        }
    }

    void NormRaiseTaxes()
    {
        TaxesPlayer2 = (int)SliderCostsP2.value;
        TaxesPlayer3 = (int)SliderCostsP3.value;
        TaxesPlayer4 = (int)SliderCostsP4.value;
    }

    [Command(requiresAuthority = false)]
    void CmdRaiseTaxes()
    {
        NormRaiseTaxes();
        RpcRaiseTaxes();

    }

    [ClientRpc]
    void RpcRaiseTaxes()
    {
        if (isLocalPlayer)
            return;
        NormRaiseTaxes();
    }

    void Start()
    {
        if (isServer)
        {
            buttonserver.SetActive(true);

            AssetPlayer1 = PlayerPrefs.GetInt("A1MomAsset");
            AssetPlayer2 = PlayerPrefs.GetInt("A2MomAsset");
            AssetPlayer3 = PlayerPrefs.GetInt("A3MomAsset");
            AssetPlayer4 = PlayerPrefs.GetInt("A4MomAsset");

            PlayerPrefs.SetInt("P2Taxes", 0);
            PlayerPrefs.SetInt("P3Taxes", 0);
            PlayerPrefs.SetInt("P4Taxes", 0);
            PlayerPrefs.SetInt("TaxesPlayerTotal", 0);

        }

        Starting(AssetPlayer1, AssetPlayer2, AssetPlayer3, AssetPlayer4);

        SliderEnable();

        if (isServer)
        {
            using (StreamWriter sw = File.AppendText(@"Z:\people\schalaur\Globescape\13_RecordingGame\Log.txt"))
            {
                sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " Start Scene 03_Taxes! ");
                sw.Close();
            }
        }
    }

    void Starting(int AssetPlayer1, int AssetPlayer2, int AssetPlayer3, int AssetPlayer4)
    {
        if (!isServer)
        {
            string PlayerName = NetworkClient.localPlayer.gameObject.name.ToString();

            if (PlayerName == "Gemeinde")
            {
                SliderCostsP2.maxValue = AssetPlayer2;
                SliderCostsP3.maxValue = AssetPlayer3;
                SliderCostsP4.maxValue = AssetPlayer4;

                SliderCostsP2.value = 0;
                SliderCostsP3.value = 0;
                SliderCostsP4.value = 0;

                StartRaiseTaxes();

                if (AssetPlayer2 != 0)
                {
                    ProcentPlayer2 = (float)TaxesPlayer2 / (float)AssetPlayer2 * 100.0f;
                }
                else
                {
                    ProcentPlayer2 = 0;
                }

                if (AssetPlayer3 != 0)
                {
                    ProcentPlayer3 = (float)TaxesPlayer3 / (float)AssetPlayer3 * 100.0f;
                }
                else
                {
                    ProcentPlayer3 = 0;
                }

                if (AssetPlayer4 != 0)
                {
                    ProcentPlayer4 = (float)TaxesPlayer4 / (float)AssetPlayer4 * 100.0f;
                }
                else
                {
                    ProcentPlayer4 = 0;
                }

                TaxesPlayerTotal = TaxesPlayer2 + TaxesPlayer3 + TaxesPlayer4;

                TextPayPlayer2.text = ProcentPlayer2.ToString("0.00") + " %";
                TextPayPlayer3.text = ProcentPlayer3.ToString("0.00") + " %";
                TextPayPlayer4.text = ProcentPlayer4.ToString("0.00") + " %";
                TextPayTotal.text = TaxesPlayerTotal.ToString("0.00") + " CHF";
            }
        }
    }



    void Update()
    {
        if (!isServer)
        {
            string PlayerName = NetworkClient.localPlayer.gameObject.name.ToString();

            if (PlayerName == "Gemeinde")
            {
                TextPayPlayer2.text = ProcentPlayer2.ToString("0.00") + " %";
                TextPayPlayer3.text = ProcentPlayer3.ToString("0.00") + " %";
                TextPayPlayer4.text = ProcentPlayer4.ToString("0.00") + " %";
                TextPayTotal.text = TaxesPlayerTotal.ToString() + " CHF";

                if (TaxesPlayer2 + TaxesPlayer3 + TaxesPlayer4 > 0)
                {
                    SetTaxes.GetComponentInChildren<Text>().text = "Steuern setzen";
                }

                if (TaxesPlayer2 + TaxesPlayer3 + TaxesPlayer4 == 0)
                {
                    SetTaxes.GetComponentInChildren<Text>().text = "Keine Steuern erheben";
                }
            }
            CmdCallServer();
        }
    }


    public void SliderTaxesChange()
    {
        if (!isServer)
        {
            string PlayerName = NetworkClient.localPlayer.gameObject.name.ToString();
            if (PlayerName == "Gemeinde")
            {
                TaxesPlayer2 = (int)SliderCostsP2.value;
                TaxesPlayer3 = (int)SliderCostsP3.value;
                TaxesPlayer4 = (int)SliderCostsP4.value;

                if (AssetPlayer2 != 0)
                {
                    ProcentPlayer2 = (float)TaxesPlayer2 / (float)AssetPlayer2 * 100.0f;
                }
                else
                {
                    ProcentPlayer2 = 0;
                }

                if (AssetPlayer3 != 0)
                {
                    ProcentPlayer3 = (float)TaxesPlayer3 / (float)AssetPlayer3 * 100.0f;
                }
                else
                {
                    ProcentPlayer3 = 0;
                }

                if (AssetPlayer4 != 0)
                {
                    ProcentPlayer4 = (float)TaxesPlayer4 / (float)AssetPlayer4 * 100.0f;
                }
                else
                {
                    ProcentPlayer4 = 0;
                }

                TaxesPlayerTotal = TaxesPlayer2 + TaxesPlayer3 + TaxesPlayer4;

                CmdChangeTaxes(TaxesPlayer2, TaxesPlayer3, TaxesPlayer4, TaxesPlayerTotal);
            }
        }

        if (isServer)
        {
            TaxesPlayer2 = (int)SliderCostsP2.value;
            TaxesPlayer3 = (int)SliderCostsP3.value;
            TaxesPlayer4 = (int)SliderCostsP4.value;

            if (AssetPlayer2 != 0)
            {
                ProcentPlayer2 = (float)TaxesPlayer2 / (float)AssetPlayer2 * 100.0f;
            }
            else
            {
                ProcentPlayer2 = 0;
            }

            if (AssetPlayer3 != 0)
            {
                ProcentPlayer3 = (float)TaxesPlayer3 / (float)AssetPlayer3 * 100.0f;
            }
            else
            {
                ProcentPlayer3 = 0;
            }

            if (AssetPlayer4 != 0)
            {
                ProcentPlayer4 = (float)TaxesPlayer4 / (float)AssetPlayer4 * 100.0f;
            }
            else
            {
                ProcentPlayer4 = 0;
            }

            TaxesPlayerTotal = TaxesPlayer2 + TaxesPlayer3 + TaxesPlayer4;

            if (isServer)
            {
                using (StreamWriter sw = File.AppendText(@"Z:\people\schalaur\Globescape\13_RecordingGame\Log.txt"))
                {
                    sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " Taxes have been changed.");
                    sw.Close();
                }

                PlayerPrefs.SetInt("P2Taxes", TaxesPlayer2);
                PlayerPrefs.SetInt("P3Taxes", TaxesPlayer3);
                PlayerPrefs.SetInt("P4Taxes", TaxesPlayer4);
                PlayerPrefs.SetInt("TaxesPlayerTotal", TaxesPlayerTotal);

            }
        }
    }

    [Command(requiresAuthority = false)]
    void CmdChangeTaxes(int TaxesPlayer2, int TaxesPlayer3, int TaxesPlayer4, int TaxesPlayerTotal)
    {
        if (isServer)
        {
            using (StreamWriter sw = File.AppendText(@"Z:\people\schalaur\Globescape\13_RecordingGame\Log.txt"))
            {
                sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " Taxes have been changed.");
                sw.Close();
            }

            PlayerPrefs.SetInt("P2Taxes", TaxesPlayer2);
            PlayerPrefs.SetInt("P3Taxes", TaxesPlayer3);
            PlayerPrefs.SetInt("P4Taxes", TaxesPlayer4);
            PlayerPrefs.SetInt("TaxesPlayerTotal", TaxesPlayerTotal);

        }
    }


    public void SliderEnable()
    {
        if (!isServer)
        {
            string PlayerName = NetworkClient.localPlayer.gameObject.name.ToString();

            if (PlayerName == "Gemeinde")
            {
                SliderCostsP2.enabled = true;
                SliderCostsP3.enabled = true;
                SliderCostsP4.enabled = true;
            }
            if (PlayerName != "Gemeinde")
            {
                SliderCostsP2.enabled = false;
                SliderCostsP3.enabled = false;
                SliderCostsP4.enabled = false;
            }
        }
    }

    public void RaiseTaxes()
    {
        CmdMakeTaxes();
    }

    [Command(requiresAuthority = false)]
    void CmdMakeTaxes()
    {
        System.DateTime d1 = System.DateTime.Now;
        System.DateTime minutes10 = d1.AddMinutes(10);
        PlayerPrefs.SetString("timeRemaining", minutes10.ToBinary().ToString());

        RpcTime(minutes10.ToBinary().ToString());

        int P1Taxes = PlayerPrefs.GetInt("TaxesPlayerTotal");
        int P2Taxes = PlayerPrefs.GetInt("P2Taxes");
        int P3Taxes = PlayerPrefs.GetInt("P3Taxes");
        int P4Taxes = PlayerPrefs.GetInt("P4Taxes");

        AssetPlayer1 = PlayerPrefs.GetInt("A1MomAsset") + P1Taxes;
        AssetPlayer2 = PlayerPrefs.GetInt("A2MomAsset") - P2Taxes;
        AssetPlayer3 = PlayerPrefs.GetInt("A3MomAsset") - P3Taxes;
        AssetPlayer4 = PlayerPrefs.GetInt("A4MomAsset") - P4Taxes;

        PlayerPrefs.SetInt("A1MomAsset", AssetPlayer1);
        PlayerPrefs.SetInt("A2MomAsset", AssetPlayer2);
        PlayerPrefs.SetInt("A3MomAsset", AssetPlayer3);
        PlayerPrefs.SetInt("A4MomAsset", AssetPlayer4);

        int total = P2Taxes + P3Taxes + P4Taxes;

        if (total > 0)
        {
            int tempApproval = PlayerPrefs.GetInt("Approval") - ApprovalMinus;
            PlayerPrefs.SetInt("Approval", tempApproval);
        }

        NetworkServer.SetAllClientsNotReady();
        NetworkManager.singleton.ServerChangeScene("04_ProjectsActions");

    }

    public void Servernext()
    {
        System.DateTime d1 = System.DateTime.Now;
        System.DateTime minutes10 = d1.AddMinutes(10);
        PlayerPrefs.SetString("timeRemaining", minutes10.ToBinary().ToString());

        RpcTime(minutes10.ToBinary().ToString());

        int P1Taxes = PlayerPrefs.GetInt("TaxesPlayerTotal");
        int P2Taxes = PlayerPrefs.GetInt("P2Taxes");
        int P3Taxes = PlayerPrefs.GetInt("P3Taxes");
        int P4Taxes = PlayerPrefs.GetInt("P4Taxes");

        AssetPlayer1 = PlayerPrefs.GetInt("A1MomAsset") + P1Taxes;
        AssetPlayer2 = PlayerPrefs.GetInt("A2MomAsset") - P2Taxes;
        AssetPlayer3 = PlayerPrefs.GetInt("A3MomAsset") - P3Taxes;
        AssetPlayer4 = PlayerPrefs.GetInt("A4MomAsset") - P4Taxes;

        PlayerPrefs.SetInt("A1MomAsset", AssetPlayer1);
        PlayerPrefs.SetInt("A2MomAsset", AssetPlayer2);
        PlayerPrefs.SetInt("A3MomAsset", AssetPlayer3);
        PlayerPrefs.SetInt("A4MomAsset", AssetPlayer4);

        int total = P2Taxes + P3Taxes + P4Taxes;

        if (total > 0)
        {
            int tempApproval = PlayerPrefs.GetInt("Approval") - ApprovalMinus;
            PlayerPrefs.SetInt("Approval", tempApproval);
        }

        NetworkServer.SetAllClientsNotReady();
        NetworkManager.singleton.ServerChangeScene("04_ProjectsActions");
    }

    [ClientRpc]
    void RpcTime(string timestring)
    {
        PlayerPrefs.SetString("timeRemaining", timestring);
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

}

