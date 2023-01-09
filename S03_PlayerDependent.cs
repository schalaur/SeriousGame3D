using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;


using System.Linq;
using System.Text;
using System.IO;

public class S03_PlayerDependent : NetworkBehaviour
{
    public Text PlayerName;
    public Text PlayerAsset;

    public Text Tax2;
    public Text Tax3;
    public Text Tax4;


    public GameObject PanelTaxes;
    public GameObject PanelWait;
    public Text WaitText;

    [SyncVar]
    int AssetPlayer1;
    [SyncVar]
    int AssetPlayer2;
    [SyncVar]
    int AssetPlayer3;
    [SyncVar]
    int AssetPlayer4;

    [SyncVar]
    int TaxesPlayer2;
    [SyncVar]
    int TaxesPlayer3;
    [SyncVar]
    int TaxesPlayer4;

    // Start is called before the first frame update
    void Start()
    {
        if (isServer)
        {
            using (StreamWriter sw = File.AppendText(@"Z:\people\schalaur\Globescape\13_RecordingGame\Log.txt"))
            {
                sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " Started Scene 03 - Taxes");
                sw.Close();
            }

            AssetPlayer1 = PlayerPrefs.GetInt("A1MomAsset");
            AssetPlayer2 = PlayerPrefs.GetInt("A2MomAsset");
            AssetPlayer3 = PlayerPrefs.GetInt("A3MomAsset");
            AssetPlayer4 = PlayerPrefs.GetInt("A4MomAsset");
        }
        Starting(AssetPlayer1, AssetPlayer2, AssetPlayer3, AssetPlayer4);
    }

    void Starting(int AssetPlayer1, int AssetPlayer2, int AssetPlayer3, int AssetPlayer4)
    {
        if (!isServer)
        {
            string LocalPlayer = NetworkClient.localPlayer.gameObject.name.ToString();

            if (LocalPlayer == "Gemeinde")
            {
                PlayerName.text = "Gemeinde";
                PlayerAsset.text = AssetPlayer1.ToString() + " CHF";
                PanelTaxes.SetActive(true);
                PanelWait.SetActive(false);
            }

            if (LocalPlayer == "Landbesitzer")
            {
                PlayerName.text = "Landbesitzer";
                PlayerAsset.text = AssetPlayer2.ToString() + " CHF";
                PanelWait.SetActive(true);
                PanelTaxes.SetActive(false);
            }

            if (LocalPlayer == "Genossenschaft")
            {
                PlayerName.text = "Genossenschaft";
                PlayerAsset.text = AssetPlayer3.ToString() + " CHF";
                PanelWait.SetActive(true);
                PanelTaxes.SetActive(false);
            }

            if (LocalPlayer == "Kulturzentrum")
            {
                PlayerName.text = "Kulturzentrum";
                PlayerAsset.text = AssetPlayer4.ToString() + " CHF";
                PanelWait.SetActive(true);
                PanelTaxes.SetActive(false);
            }
        }

        if (isServer)
        {
            PanelTaxes.SetActive(true);
            PanelWait.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isServer)
        {
            TaxesPlayer2 = PlayerPrefs.GetInt("P2Taxes");
            TaxesPlayer3 = PlayerPrefs.GetInt("P3Taxes");
            TaxesPlayer4 = PlayerPrefs.GetInt("P4Taxes");

            Tax2.text = TaxesPlayer2.ToString();
            Tax3.text = TaxesPlayer3.ToString();
            Tax4.text = TaxesPlayer4.ToString();
        }

        if (!isServer)
        {
            string LocalPlayer = NetworkClient.localPlayer.gameObject.name.ToString();

            if (LocalPlayer == "Landbesitzer")
            {
                WaitText.text = "Die Gemeinde kann nun Steuern erheben. Die Steuerhöhe kann bei allen Spielern variieren. " + System.Environment.NewLine + System.Environment.NewLine +
                    "Momentan werden Sie mit einem Betrag von " + TaxesPlayer2 + " CHF besteuert." + System.Environment.NewLine + System.Environment.NewLine +
                    "Falls die Gemeinde Steuern erheben wird, so wird die öffentliche Zustimmung um -2 gesenkt. ";
            }

            if (LocalPlayer == "Genossenschaft")
            {
                WaitText.text = "Die Gemeinde kann nun Steuern erheben. Die Steuerhöhe kann bei allen Spielern variieren. " + System.Environment.NewLine + System.Environment.NewLine +
                    "Momentan werden Sie mit einem Betrag von " + TaxesPlayer3 + " CHF besteuert." + System.Environment.NewLine + System.Environment.NewLine +
                    "Falls die Gemeinde Steuern erheben wird, so wird die öffentliche Zustimmung um -2 gesenkt. ";
            }

            if (LocalPlayer == "Kulturzentrum")
            {
                WaitText.text = "Die Gemeinde kann nun Steuern erheben. Die Steuerhöhe kann bei allen Spielern variieren. " + System.Environment.NewLine + System.Environment.NewLine +
                    "Momentan werden Sie mit einem Betrag von " + TaxesPlayer4 + " CHF besteuert." + System.Environment.NewLine + System.Environment.NewLine +
                    "Falls die Gemeinde Steuern erheben wird, so wird die öffentliche Zustimmung um -2 gesenkt. ";
            }
        }
    }
}
