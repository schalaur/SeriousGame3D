using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class PayPlayer_Arealentwicklung : NetworkBehaviour
{

    private int MoneyPlayer1;
    public Text TextPayPlayer1;
    public Slider SliderCostsP1;

    private int MoneyPlayer2;
    public Text TextPayPlayer2;
    public Slider SliderCostsP2;

    private int MoneyPlayer3;
    public Text TextPayPlayer3;
    public Slider SliderCostsP3;

    private int MoneyPlayer4;
    public Text TextPayPlayer4;
    public Slider SliderCostsP4;

    private int MoneyTotalPayed;
    public Text TextMoneyTotalPayed;

    private int MoneyTotalToPay;
    public Text TextMoneyTotalToPay;

    private int MoneyDifference;
    public Text TextMoneyDifference;

    public int AssetPlayer1;
    public int AssetPlayer2;
    public int AssetPlayer3;
    public int AssetPlayer4;

    public Button Accept;

    int Costs = 400;

    int Appeal = 2;
    int Approval = 2;

    public GameObject PanelAufteilung;
    public GameObject NotEnoughMoney;
    public GameObject PanelOverview;
    public GameObject PanelPay400;
    public GameObject PanelPay300;

    int Diff1;
    int Diff2;
    int Diff3;
    int Diff4;

    public Button Project;

    public Text TextMoney;
    public Text TextConstraint;
    public Text TextApproval;
    public Text TextAppeal;

    int A1MomAsset;
    int A2MomAsset;
    int A3MomAsset;
    int A4MomAsset;

    bool accepted = false;
    bool notaccepted = false;

    bool Player1 = false;
    bool Player2 = false;
    bool Player3 = false;
    bool Player4 = false;

    [SyncVar]
    int RatenArealentwicklung;

    // Enters Start-Value for every text-field 
    void Start()
    {
        TextMoney.text = "400 CHF";
        TextConstraint.text = "Kann in Raten abbezahlt werden: 3 Runden x 100 CHF ";
        TextApproval.text = "+ 2";
        TextAppeal.text = "+ 2";

        if (!isServer)
        {
            string PlayerName = NetworkClient.localPlayer.gameObject.name.ToString();

            if (PlayerName == "Gemeinde")
            {
                SliderCostsP1.gameObject.SetActive(true);
                SliderCostsP2.gameObject.SetActive(false);
                SliderCostsP3.gameObject.SetActive(false);
                SliderCostsP4.gameObject.SetActive(false);
            }
            else if (PlayerName == "Landbesitzer")
            {
                SliderCostsP1.gameObject.SetActive(false);
                SliderCostsP2.gameObject.SetActive(true);
                SliderCostsP3.gameObject.SetActive(false);
                SliderCostsP4.gameObject.SetActive(false);
            }
            else if (PlayerName == "Genossenschaft")
            {
                SliderCostsP1.gameObject.SetActive(false);
                SliderCostsP2.gameObject.SetActive(false);
                SliderCostsP3.gameObject.SetActive(true);
                SliderCostsP4.gameObject.SetActive(false);
            }
            else if (PlayerName == "Kulturzentrum")
            {
                SliderCostsP1.gameObject.SetActive(false);
                SliderCostsP2.gameObject.SetActive(false);
                SliderCostsP3.gameObject.SetActive(false);
                SliderCostsP4.gameObject.SetActive(true);
            }
        }

        SliderCostsP1.maxValue = Costs;
        SliderCostsP2.maxValue = Costs;
        SliderCostsP3.maxValue = Costs;
        SliderCostsP4.maxValue = Costs;

        SliderCostsP1.value = 0;
        SliderCostsP2.value = 0;
        SliderCostsP3.value = 0;
        SliderCostsP4.value = 0;

        if (isServer)
        {
            PlayerPrefs.SetInt("SliderP1", 0);
            PlayerPrefs.SetInt("SliderP2", 0);
            PlayerPrefs.SetInt("SliderP3", 0);
            PlayerPrefs.SetInt("SliderP4", 0);

            A1MomAsset = PlayerPrefs.GetInt("A1MomAsset");
            A2MomAsset = PlayerPrefs.GetInt("A2MomAsset");
            A3MomAsset = PlayerPrefs.GetInt("A3MomAsset");
            A4MomAsset = PlayerPrefs.GetInt("A4MomAsset");

            RatenArealentwicklung = PlayerPrefs.GetInt("RatenArealentwicklung");
        }

        MoneyPlayer1 = (int)SliderCostsP1.value;
        MoneyPlayer2 = (int)SliderCostsP2.value;
        MoneyPlayer3 = (int)SliderCostsP3.value;
        MoneyPlayer4 = (int)SliderCostsP4.value;

        TextPayPlayer1.text = MoneyPlayer1.ToString();
        TextPayPlayer2.text = MoneyPlayer2.ToString();
        TextPayPlayer3.text = MoneyPlayer3.ToString();
        TextPayPlayer4.text = MoneyPlayer4.ToString();

        MoneyTotalPayed = MoneyPlayer1 + MoneyPlayer2 + MoneyPlayer3 + MoneyPlayer4;
        MoneyTotalToPay = Costs;
        MoneyDifference = MoneyTotalToPay - MoneyTotalPayed;

        TextMoneyTotalPayed.text = MoneyTotalPayed.ToString();
        TextMoneyTotalToPay.text = MoneyTotalToPay.ToString();
        TextMoneyDifference.text = MoneyDifference.ToString();

    }

    void Update()
    {
        if (MoneyDifference == 0)
        {
            Accept.gameObject.SetActive(true);
        }
        else
        {
            Accept.gameObject.SetActive(false);
        }

        TextPayPlayer1.text = MoneyPlayer1.ToString();
        TextPayPlayer2.text = MoneyPlayer2.ToString();
        TextPayPlayer3.text = MoneyPlayer3.ToString();
        TextPayPlayer4.text = MoneyPlayer4.ToString();

        TextMoneyTotalPayed.text = MoneyTotalPayed.ToString();
        TextMoneyDifference.text = MoneyDifference.ToString();

        if (accepted)
        {
            Project.gameObject.SetActive(false);
            PanelPay400.SetActive(false);
            NotEnoughMoney.SetActive(false);
            accepted = false;
        }
        if (notaccepted)
        {
            NotEnoughMoney.SetActive(true);
            PanelPay400.SetActive(false);
            notaccepted = false;
        }
    }

    // Updates by every click on the sliders; all slider values are calculated again incl. sum & dif 
    public void ArealentwicklungCostChange()
    {
        string PlayerName = NetworkClient.localPlayer.gameObject.name.ToString();

        if (PlayerName == "Gemeinde")
        {
            MoneyPlayer1 = (int)SliderCostsP1.value;
            CmdCallServer(MoneyPlayer1, "Gemeinde");
        }
        else if (PlayerName == "Landbesitzer")
        {
            MoneyPlayer2 = (int)SliderCostsP2.value;
            CmdCallServer(MoneyPlayer2, "Landbesitzer");
        }
        else if (PlayerName == "Genossenschaft")
        {
            MoneyPlayer3 = (int)SliderCostsP3.value;
            CmdCallServer(MoneyPlayer3, "Genossenschaft");
        }
        else if (PlayerName == "Kulturzentrum")
        {
            MoneyPlayer4 = (int)SliderCostsP4.value;
            CmdCallServer(MoneyPlayer4, "Kulturzentrum");
        }

    }
    [Command(requiresAuthority = false)]
    void CmdCallServer(int Money, string PlayerName)
    {
        if (PlayerName == "Gemeinde")
        {
            MoneyPlayer1 = Money;
            PlayerPrefs.SetInt("SliderP1", MoneyPlayer1);
        }
        else if (PlayerName == "Landbesitzer")
        {
            MoneyPlayer2 = Money;
            PlayerPrefs.SetInt("SliderP2", MoneyPlayer2);
        }
        else if (PlayerName == "Genossenschaft")
        {
            MoneyPlayer3 = Money;
            PlayerPrefs.SetInt("SliderP3", MoneyPlayer3);
        }
        else if (PlayerName == "Kulturzentrum")
        {
            MoneyPlayer4 = Money;
            PlayerPrefs.SetInt("SliderP4", MoneyPlayer4);
        }

        MoneyTotalPayed = MoneyPlayer1 + MoneyPlayer2 + MoneyPlayer3 + MoneyPlayer4;
        MoneyDifference = MoneyTotalToPay - MoneyTotalPayed;

        TextPayPlayer1.text = MoneyPlayer1.ToString();
        TextPayPlayer2.text = MoneyPlayer2.ToString();
        TextPayPlayer3.text = MoneyPlayer3.ToString();
        TextPayPlayer4.text = MoneyPlayer4.ToString();

        TextMoneyTotalPayed.text = MoneyTotalPayed.ToString();
        TextMoneyDifference.text = MoneyDifference.ToString();

        PlayerPrefs.SetInt("MunPressed", 0);
        PlayerPrefs.SetInt("LandPressed", 0);
        PlayerPrefs.SetInt("CoPressed", 0);
        PlayerPrefs.SetInt("CultPressed", 0);

        RpcCallClients(MoneyPlayer1, MoneyPlayer2, MoneyPlayer3, MoneyPlayer4, MoneyTotalPayed, MoneyDifference);
    }

    [ClientRpc]
    void RpcCallClients(int MoneyPlayer1Server, int MoneyPlayer2Server, int MoneyPlayer3Server, int MoneyPlayer4Server, int MoneyTotalPayedServer, int MoneyDifferenceServer)
    {
        MoneyPlayer1 = MoneyPlayer1Server;
        MoneyPlayer2 = MoneyPlayer2Server;
        MoneyPlayer3 = MoneyPlayer3Server;
        MoneyPlayer4 = MoneyPlayer4Server;
        MoneyTotalPayed = MoneyTotalPayedServer;
        MoneyDifference = MoneyDifferenceServer;

        TextPayPlayer1.text = MoneyPlayer1.ToString();
        TextPayPlayer2.text = MoneyPlayer2.ToString();
        TextPayPlayer3.text = MoneyPlayer3.ToString();
        TextPayPlayer4.text = MoneyPlayer4.ToString();

        TextMoneyTotalPayed.text = MoneyTotalPayed.ToString();
        TextMoneyDifference.text = MoneyDifference.ToString();
    }


    public void ArealentwicklungAccept()
    {
        if (!isServer)
        {
            string PlayerName = NetworkClient.localPlayer.gameObject.name.ToString();

            CmdCreatingShadowAccept(PlayerName);
            CmdAcceptedNow();
        }

        if (isServer)
        {
            Player1 = false;
            Player2 = false;
            Player3 = false;
            Player4 = false;

            int A1MomAsset = PlayerPrefs.GetInt("A1MomAsset");
            int A2MomAsset = PlayerPrefs.GetInt("A2MomAsset");
            int A3MomAsset = PlayerPrefs.GetInt("A3MomAsset");
            int A4MomAsset = PlayerPrefs.GetInt("A4MomAsset");


            if (A1MomAsset >= 0)
            {
                Diff1 = A1MomAsset - PlayerPrefs.GetInt("SliderP1");
            }
            else if (A1MomAsset < 0 && PlayerPrefs.GetInt("SliderP1") == 0)
            {
                Diff1 = 0;
            }
            else
            {
                Diff1 = A1MomAsset - PlayerPrefs.GetInt("SliderP1");
            }

            if (A2MomAsset >= 0)
            {
                Diff2 = A2MomAsset - PlayerPrefs.GetInt("SliderP2");
            }
            else if (A2MomAsset < 0 && PlayerPrefs.GetInt("SliderP2") == 0)
            {
                Diff2 = 0;
            }
            else
            {
                Diff2 = A2MomAsset - PlayerPrefs.GetInt("SliderP2");
            }

            if (A3MomAsset >= 0)
            {
                Diff3 = A3MomAsset - PlayerPrefs.GetInt("SliderP3");
            }
            else if (A3MomAsset < 0 && PlayerPrefs.GetInt("SliderP3") == 0)
            {
                Diff3 = 0;
            }
            else
            {
                Diff3 = A3MomAsset - PlayerPrefs.GetInt("SliderP3");
            }

            if (A4MomAsset >= 0)
            {
                Diff4 = A4MomAsset - PlayerPrefs.GetInt("SliderP4");
            }
            else if (A4MomAsset < 0 && PlayerPrefs.GetInt("SliderP4") == 0)
            {
                Diff4 = 0;
            }
            else
            {
                Diff4 = A4MomAsset - PlayerPrefs.GetInt("SliderP4");
            }

            if (Diff1 >= 0 && Diff2 >= 0 && Diff3 >= 0 && Diff4 >= 0)
            {
                Project.gameObject.SetActive(false);

                Implement();
                BackToOverview();
                RpcAccepted(true);
            }
            else
            {
                NotEnoughMoney.SetActive(true);
                PanelPay400.SetActive(false);
                RpcNotAccepted(true);

            }
        }

    }
    [Command(requiresAuthority = false)]
    void CmdCreatingShadowAccept(string PlayerName)
    {
        if (PlayerName == "Gemeinde")
        {
            Player1 = true;
        }
        else if (PlayerName == "Kulturzentrum")
        {
            Player2 = true;
        }
        else if (PlayerName == "Landbesitzer")
        {
            Player3 = true;
        }
        else if (PlayerName == "Genossenschaft")
        {
            Player4 = true;
        }
    }

    [Command(requiresAuthority = false)]
    void CmdAcceptedNow()
    {
        if (Player1 && Player2 && Player3 && Player4)
        // if (Player1 && Player2)
        {
            Player1 = false;
            Player2 = false;
            Player3 = false;
            Player4 = false;

            int A1MomAsset = PlayerPrefs.GetInt("A1MomAsset");
            int A2MomAsset = PlayerPrefs.GetInt("A2MomAsset");
            int A3MomAsset = PlayerPrefs.GetInt("A3MomAsset");
            int A4MomAsset = PlayerPrefs.GetInt("A4MomAsset");


            if (A1MomAsset >= 0)
            {
                Diff1 = A1MomAsset - PlayerPrefs.GetInt("SliderP1");
            }
            else if (A1MomAsset < 0 && PlayerPrefs.GetInt("SliderP1") == 0)
            {
                Diff1 = 0;
            }
            else
            {
                Diff1 = A1MomAsset - PlayerPrefs.GetInt("SliderP1");
            }

            if (A2MomAsset >= 0)
            {
                Diff2 = A2MomAsset - PlayerPrefs.GetInt("SliderP2");
            }
            else if (A2MomAsset < 0 && PlayerPrefs.GetInt("SliderP2") == 0)
            {
                Diff2 = 0;
            }
            else
            {
                Diff2 = A2MomAsset - PlayerPrefs.GetInt("SliderP2");
            }

            if (A3MomAsset >= 0)
            {
                Diff3 = A3MomAsset - PlayerPrefs.GetInt("SliderP3");
            }
            else if (A3MomAsset < 0 && PlayerPrefs.GetInt("SliderP3") == 0)
            {
                Diff3 = 0;
            }
            else
            {
                Diff3 = A3MomAsset - PlayerPrefs.GetInt("SliderP3");
            }

            if (A4MomAsset >= 0)
            {
                Diff4 = A4MomAsset - PlayerPrefs.GetInt("SliderP4");
            }
            else if (A4MomAsset < 0 && PlayerPrefs.GetInt("SliderP4") == 0)
            {
                Diff4 = 0;
            }
            else
            {
                Diff4 = A4MomAsset - PlayerPrefs.GetInt("SliderP4");
            }

            if (Diff1 >= 0 && Diff2 >= 0 && Diff3 >= 0 && Diff4 >= 0)
            {
                Project.gameObject.SetActive(false);

                Implement();
                BackToOverview();
                RpcAccepted(true);
            }
            else
            {
                NotEnoughMoney.SetActive(true);
                PanelPay400.SetActive(false);
                RpcNotAccepted(true);

            }
        }
    }

    [ClientRpc]
    void RpcAccepted(bool acceptedServer)
    {
        accepted = acceptedServer;
    }

    [ClientRpc]
    void RpcNotAccepted(bool notacceptedServer)
    {
        notaccepted = notacceptedServer;
    }

    public void BackToProject()
    {
        NotEnoughMoney.SetActive(false);

        if (RatenArealentwicklung == 400)
        {
            PanelPay400.SetActive(true);
        }

        if (RatenArealentwicklung == 300)
        {
            PanelPay300.SetActive(true);
        }


    }

    public void BackToOverview()
    {
        Back();

        if (isServer)
        {
            RpcBack();
        }
        else
        {
            CmdBack();
        }
    }

    void Back()
    {
        PanelAufteilung.SetActive(true);
        PanelPay400.SetActive(false);
        NotEnoughMoney.SetActive(false);
    }

    [Command(requiresAuthority = false)]
    void CmdBack()
    {
        Back();
        RpcBack();

    }

    [ClientRpc]
    void RpcBack()
    {
        if (isLocalPlayer)
            return;
        Back();
    }

    void Implement()
    {

        PlayerPrefs.SetInt("ArealentwicklungPriceP1", PlayerPrefs.GetInt("SliderP1"));
        PlayerPrefs.SetInt("ArealentwicklungPriceP2", PlayerPrefs.GetInt("SliderP2"));
        PlayerPrefs.SetInt("ArealentwicklungPriceP3", PlayerPrefs.GetInt("SliderP3"));
        PlayerPrefs.SetInt("ArealentwicklungPriceP4", PlayerPrefs.GetInt("SliderP4"));

        PlayerPrefs.SetInt("SliderP1", 0);
        PlayerPrefs.SetInt("SliderP2", 0);
        PlayerPrefs.SetInt("SliderP3", 0);
        PlayerPrefs.SetInt("SliderP4", 0);

        PlayerPrefs.Save();

    }

    public void BackToProjectsOverview()
    {
        BackProjectsOverview();

        if (isServer)
        {
            RpcBackProjectsOverview();
        }
        else
        {
            CmdBackProjectsOverview();
        }
    }

    void BackProjectsOverview()
    {
        PanelOverview.SetActive(true);
        PanelPay400.SetActive(false);
        PanelPay300.SetActive(false);
        NotEnoughMoney.SetActive(false);
    }

    [Command(requiresAuthority = false)]
    void CmdBackProjectsOverview()
    {
        BackProjectsOverview();
        RpcBackProjectsOverview();

    }

    [ClientRpc]
    void RpcBackProjectsOverview()
    {
        if (isLocalPlayer)
            return;
        BackProjectsOverview();
    }
}
