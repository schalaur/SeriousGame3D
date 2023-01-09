using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

using System.Linq;
using System.Text;
using System.IO;

public class AppealApproval : NetworkBehaviour
{

    public GameObject ApprovalLevelM6;
    public GameObject ApprovalLevelM5;
    public GameObject ApprovalLevelM4;
    public GameObject ApprovalLevelM3;
    public GameObject ApprovalLevelM2;
    public GameObject ApprovalLevelM1;
    public GameObject ApprovalLevel0;
    public GameObject ApprovalLevelP1;
    public GameObject ApprovalLevelP2;
    public GameObject ApprovalLevelP3;
    public GameObject ApprovalLevelP4;
    public GameObject ApprovalLevelP5;
    public GameObject ApprovalLevelP6;

    public GameObject AppealLevelM6;
    public GameObject AppealLevelM5;
    public GameObject AppealLevelM4;
    public GameObject AppealLevelM3;
    public GameObject AppealLevelM2;
    public GameObject AppealLevelM1;
    public GameObject AppealLevel0;
    public GameObject AppealLevelP1;
    public GameObject AppealLevelP2;
    public GameObject AppealLevelP3;
    public GameObject AppealLevelP4;
    public GameObject AppealLevelP5;
    public GameObject AppealLevelP6;

    int number1;
    int number2;
    [SyncVar]
    int numberend;

    [SyncVar]
    int SyncShopIncome;

    public Text TextShopIncome;
    int newShopIncome;

    public Button ClickHere;
    public Text TextClickHere;

    public Button Continue;

    [SyncVar]
    bool Calculated = false;

    bool WroteAlready = false;

    GameObject buttonserver;



    // Start is called before the first frame update
    void Start()
    {
        if (isServer)
        {
            using (StreamWriter sw = File.AppendText(@"Z:\people\schalaur\Globescape\13_RecordingGame\Log.txt"))
            {
                sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " " + "New Round: Appeal & Approval - Effect on Shop Income");
                sw.Close();
            }
            buttonserver.SetActive(true);
        }

        WroteAlready = false;


        if (!isServer)
        {
            string PlayerName = NetworkClient.localPlayer.gameObject.name.ToString();
            if (PlayerName == "Kulturzentrum")
            {
                TextShopIncome.text = "Nachdem Sie (Kulturzentrum) auf den Knopf gedrückt haben, wird das neue Einkommen pro Shop angezeigt.";
            }
        }

        Continue.gameObject.SetActive(false);

    }

    void Update()
    {
        if (isServer && !Calculated)
        {
            ClickHere.gameObject.SetActive(true);
        }

        Continue.gameObject.SetActive(false);
        if (!isServer)
        {
            string PlayerName = NetworkClient.localPlayer.gameObject.name.ToString();
            if (PlayerName != "Kulturzentrum")
            {
                ClickHere.gameObject.SetActive(false);
            }
            else if (PlayerName == "Kulturzentrum" && !Calculated)
            {
                ClickHere.gameObject.SetActive(true);
            }
            else if (PlayerName == "Kulturzentrum" && Calculated)
            {
                ClickHere.gameObject.SetActive(false);

            }

            if (Calculated)
            {
                Continue.gameObject.SetActive(true);

                //if (PlayerPrefs.GetInt("Numberend") < 0)
                if (numberend < 0)
                {
                    TextShopIncome.text = "Das Gewerbseinkommen wird um " + numberend.ToString() + " CHF reduziert. Es beträgt nun " + SyncShopIncome.ToString() + " CHF.";
                }

                //if (PlayerPrefs.GetInt("Numberend") > 0)
                if (numberend > 0)
                {
                    TextShopIncome.text = "Das Gewerbseinkommen wird um " + numberend.ToString() + " CHF erhöht. Es beträgt nun " + SyncShopIncome.ToString() + " CHF.";
                }

                //if (PlayerPrefs.GetInt("Numberend") == 0)
                if (numberend == 0)
                {
                    TextShopIncome.text = "Das Gebwerbseinkommen wird nicht verändert. Demzufolge beträgt es " + SyncShopIncome.ToString() + " CHF.";
                }


            }
        }
        if (isServer && Calculated)
        {
            if (!WroteAlready)
            {
                using (StreamWriter sw = File.AppendText(@"Z:\people\schalaur\Globescape\13_RecordingGame\Log.txt"))
                {
                    sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " " + "ShopIncome reduced / increased: " + numberend + " CHF.");
                    sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " " + "ShopIncome is now: " + SyncShopIncome + " CHF.");
                    sw.Close();
                }
                WroteAlready = true;
            }

            Continue.gameObject.SetActive(true);

            //if (PlayerPrefs.GetInt("Numberend") < 0)
            if (numberend < 0)
            {
                TextShopIncome.text = "Das Gewerbseinkommen wird um " + numberend.ToString() + " CHF reduziert. Es beträgt nun " + SyncShopIncome.ToString() + " CHF.";
            }

            //if (PlayerPrefs.GetInt("Numberend") > 0)
            if (numberend > 0)
            {
                TextShopIncome.text = "Das Gewerbseinkommen wird um " + numberend.ToString() + " CHF erhöht. Es beträgt nun " + SyncShopIncome.ToString() + " CHF.";
            }

            //if (PlayerPrefs.GetInt("Numberend") == 0)
            if (numberend == 0)
            {
                TextShopIncome.text = "Das Gebwerbsein  kommen wird nicht verändert. Demzufolge beträgt es den Normwert von " + SyncShopIncome.ToString() + " CHF.";
            }

        }

    }

    public void RandomNumber()
    {
        if (isServer)
        {
            if (AppealLevelM6.activeInHierarchy == true || AppealLevelM5.activeInHierarchy == true || AppealLevelM4.activeInHierarchy == true || AppealLevelM3.activeInHierarchy == true || AppealLevelM2.activeInHierarchy == true || AppealLevelM1.activeInHierarchy == true)
            {

                number1 = Random.Range(-3, 4);
                number2 = Random.Range(-3, 4);

                numberend = Mathf.Min(number1, number2);

            }

            else if (AppealLevelP6.activeInHierarchy == true || AppealLevelP5.activeInHierarchy == true || AppealLevelP4.activeInHierarchy == true || AppealLevelP3.activeInHierarchy == true || AppealLevelP2.activeInHierarchy == true || AppealLevelP1.activeInHierarchy == true)
            {

                number1 = Random.Range(-3, 4);
                number2 = Random.Range(-3, 4);

                numberend = Mathf.Max(number1, number2);

            }

            else
            {
                numberend = Random.Range(-3, 4);

            }

            Calculated = true;

            SyncShopIncome = 5 + numberend;

            if (isServer)
            {
                PlayerPrefs.SetInt("SyncNumberend", numberend);
                PlayerPrefs.SetInt("SyncShopIncome", SyncShopIncome);
            }
            RpcRandomNumer(numberend);
        }
        else if (!isServer)
        {
            CmdRandomNumber();
        }
    }

    [Command(requiresAuthority = false)]
    void CmdRandomNumber()
    {
        if (AppealLevelM6.activeInHierarchy == true || AppealLevelM5.activeInHierarchy == true || AppealLevelM4.activeInHierarchy == true || AppealLevelM3.activeInHierarchy == true || AppealLevelM2.activeInHierarchy == true || AppealLevelM1.activeInHierarchy == true)
        {

            number1 = Random.Range(-3, 4);
            number2 = Random.Range(-3, 4);

            numberend = Mathf.Min(number1, number2);

        }

        else if (AppealLevelP6.activeInHierarchy == true || AppealLevelP5.activeInHierarchy == true || AppealLevelP4.activeInHierarchy == true || AppealLevelP3.activeInHierarchy == true || AppealLevelP2.activeInHierarchy == true || AppealLevelP1.activeInHierarchy == true)
        {

            number1 = Random.Range(-3, 4);
            number2 = Random.Range(-3, 4);

            numberend = Mathf.Max(number1, number2);

        }

        else
        {
            numberend = Random.Range(-3, 4);

        }

        Calculated = true;

        SyncShopIncome = 5 + numberend;

        if (isServer)
        {
            PlayerPrefs.SetInt("SyncNumberend", numberend);
            PlayerPrefs.SetInt("SyncShopIncome", SyncShopIncome);
        }

        RpcRandomNumer(numberend);
    }

    [ClientRpc]
    void RpcRandomNumer(int numberendserver)
    {
        Calculated = true;

        SyncShopIncome = 5 + numberendserver;
    }
}
