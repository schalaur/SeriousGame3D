using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class PayPlayer_AdditionalOfStorey : NetworkBehaviour
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

    int Costs = 40;

    int Appeal = 2;
    int Approval = 0;

    public GameObject NotEnoughMoney;
    public GameObject PanelOverview;
    public GameObject PanelPay;

    int Diff1;
    int Diff2;
    int Diff3;
    int Diff4;

    int A1MomAsset;
    int A2MomAsset;
    int A3MomAsset;
    int A4MomAsset;

    public GameObject GameManagerActions;

    bool accepted = false;
    bool notaccepted = false;

    bool Player1 = false;
    bool Player2 = false;
    bool Player3 = false;
    bool Player4 = false;

    // Enters Start-Value for every text-field 
    void Start()
    {
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
            PanelPay.SetActive(false);
            NotEnoughMoney.SetActive(false);
            accepted = false;
        }
        if (notaccepted)
        {
            NotEnoughMoney.SetActive(true);
            PanelPay.SetActive(false);
            notaccepted = false;
        }
    }

    // Updates by every click on the sliders; all slider values are calculated again incl. sum & dif 
    public void AdditionalOfStoreyCostChange()
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



    public void AdditionalOfStoreyAccept()
    {
        if (!isServer)
        {
            string PlayerName = NetworkClient.localPlayer.gameObject.name.ToString();

            CmdAccept(PlayerName);
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
                Implement();
                BackToOverview();
                RpcAccepted(true);
            }
            else
            {
                NotEnoughMoney.SetActive(true);
                PanelPay.SetActive(false);
                RpcNotAccepted(true);
            }

        }
    }

    [Command(requiresAuthority = false)]
    void CmdAccept(string PlayerName)
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
        //  if (Player1 && Player2)
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
                Implement();
                BackToOverview();
                RpcAccepted(true);
            }
            else
            {
                NotEnoughMoney.SetActive(true);
                PanelPay.SetActive(false);
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

    public void BackToAction()
    {
        NotEnoughMoney.SetActive(false);
        PanelPay.SetActive(true);
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
        PanelOverview.SetActive(true);
        PanelPay.SetActive(false);
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
        int tempp1 = PlayerPrefs.GetInt("A1MomAsset");
        int tempp2 = PlayerPrefs.GetInt("A2MomAsset");
        int tempp3 = PlayerPrefs.GetInt("A3MomAsset");
        int tempp4 = PlayerPrefs.GetInt("A4MomAsset");

        AssetPlayer1 = tempp1 - PlayerPrefs.GetInt("SliderP1");
        AssetPlayer2 = tempp2 - PlayerPrefs.GetInt("SliderP2");
        AssetPlayer3 = tempp3 - PlayerPrefs.GetInt("SliderP3");
        AssetPlayer4 = tempp4 - PlayerPrefs.GetInt("SliderP4");

        PlayerPrefs.SetInt("A1MomAsset", AssetPlayer1);
        PlayerPrefs.SetInt("A2MomAsset", AssetPlayer2);
        PlayerPrefs.SetInt("A3MomAsset", AssetPlayer3);
        PlayerPrefs.SetInt("A4MomAsset", AssetPlayer4);

        int tempAppeal1 = PlayerPrefs.GetInt("Appeal");
        int tempApproval1 = PlayerPrefs.GetInt("Approval");

        tempAppeal1 = tempAppeal1 + Appeal;
        if (tempAppeal1 > 6)
        {
            tempAppeal1 = 6;
        }

        if (tempAppeal1 < -6)
        {
            tempAppeal1 = -6;
        }
        tempApproval1 = tempApproval1 + Approval;

        PlayerPrefs.SetInt("Appeal", tempAppeal1);
        PlayerPrefs.SetInt("Approval", tempApproval1);

        PlayerPrefs.SetInt("AdditionalOfStorey", 1);

        //PlayerPrefs.SetString("AdditionalOfStorey", PlayerPrefs.GetString("ActualPointCloudParent"));

        //Abspeichern, welche Aufstockung erfolgt ist 
        // Aparthotel
        if (PlayerPrefs.GetString("PositionAdditionalOfStorey") == "ApartHotel")
        {
            PlayerPrefs.SetInt("AdditionalOfStorey_Aparthotel", 1);
        }
        // BrauiTurm
        else if (PlayerPrefs.GetString("PositionAdditionalOfStorey") == "BrauiTurm")
        {
            PlayerPrefs.SetInt("AdditionalOfStorey_Brauiturm", 1);
        }
        // Haus Brauiplatz4
        else if (PlayerPrefs.GetString("PositionAdditionalOfStorey") == "Haus_Brauiplatz4")
        {
            PlayerPrefs.SetInt("AdditionalOfStorey_Haus_Brauiplatz4", 1);
        }
        // Kantonalbank 
        else if (PlayerPrefs.GetString("PositionAdditionalOfStorey") == "Kantonalbank")
        {
            PlayerPrefs.SetInt("AdditionalOfStorey_Kantonalbank", 1);
        }
        // Kulturzentrum Braui
        else if (PlayerPrefs.GetString("PositionAdditionalOfStorey") == "KulturzentrumBraui")
        {
            PlayerPrefs.SetInt("AdditionalOfStorey_KulturzentrumBraui", 1);
        }
        // Restaurant Braui
        else if (PlayerPrefs.GetString("PositionAdditionalOfStorey") == "RestaurantBraui")
        {
            PlayerPrefs.SetInt("AdditionalOfStorey_RestaurantBraui", 1);
        }
        //  Haus Kleinwangenstr. 7
        else if (PlayerPrefs.GetString("PositionAdditionalOfStorey") == "Haus_Kleinwangenstr7")
        {
            PlayerPrefs.SetInt("AdditionalOfStorey_Haus_Kleinwangenstr7", 1);
        }
        // Haus Kleinwangenstr. 1
        else if (PlayerPrefs.GetString("PositionAdditionalOfStorey") == "Haus_Kleinwangenstr1")
        {
            PlayerPrefs.SetInt("AdditionalOfStorey_Haus_Kleinwangenstr1", 1);
        }
        //  Haus Kleinwangenstr. 3
        else if (PlayerPrefs.GetString("PositionAdditionalOfStorey") == "Haus_Kleinwangenstr3")
        {
            PlayerPrefs.SetInt("AdditionalOfStorey_Haus_Kleinwangenstr3", 1);
        }
        //  Haus Kleinwangenstr. 5
        else if (PlayerPrefs.GetString("PositionAdditionalOfStorey") == "Haus_Kleinwangenstr5")
        {
            PlayerPrefs.SetInt("AdditionalOfStorey_Haus_Kleinwangenstr5", 1);
        }
        // Haus Rosengasse 12
        else if (PlayerPrefs.GetString("PositionAdditionalOfStorey") == "Haus_Rosengasse12")
        {
            PlayerPrefs.SetInt("AdditionalOfStorey_Haus_Rosengasse12", 1);
        }
        // Reihenhaus 1
        else if (PlayerPrefs.GetString("PositionAdditionalOfStorey") == "Reihenhaus1")
        {
            PlayerPrefs.SetInt("AdditionalOfStorey_Reihenhaus1", 1);
        }
        // Reihenhaus 2
        else if (PlayerPrefs.GetString("PositionAdditionalOfStorey") == "Reihenhaus2")
        {
            PlayerPrefs.SetInt("AdditionalOfStorey_Reihenhaus2", 1);
        }
        // Reihenhaus 3
        else if (PlayerPrefs.GetString("PositionAdditionalOfStorey") == "Reihenhaus3")
        {
            PlayerPrefs.SetInt("AdditionalOfStorey_Reihenhaus3", 1);
        }
        // Reihenhaus 4
        else if (PlayerPrefs.GetString("PositionAdditionalOfStorey") == "Reihenhaus4")
        {
            PlayerPrefs.SetInt("AdditionalOfStorey_Reihenhaus4", 1);
        }
        // Reihenhaus 5
        else if (PlayerPrefs.GetString("PositionAdditionalOfStorey") == "Reihenhaus5")
        {
            PlayerPrefs.SetInt("AdditionalOfStorey_Reihenhaus5", 1);
        }
        // Reihenhaus 6
        else if (PlayerPrefs.GetString("PositionAdditionalOfStorey") == "Reihenhaus6")
        {
            PlayerPrefs.SetInt("AdditionalOfStorey_Reihenhaus6", 1);
        }
        // Reihenhaus 7
        else if (PlayerPrefs.GetString("PositionAdditionalOfStorey") == "Reihenhaus7")
        {
            PlayerPrefs.SetInt("AdditionalOfStorey_Reihenhaus7", 1);
        }
        // Reihenhaus 8
        else if (PlayerPrefs.GetString("PositionAdditionalOfStorey") == "Reihenhaus8")
        {
            PlayerPrefs.SetInt("AdditionalOfStorey_Reihenhaus8", 1);
        }
        // Reihenhaus 9
        else if (PlayerPrefs.GetString("PositionAdditionalOfStorey") == "Reihenhaus9")
        {
            PlayerPrefs.SetInt("AdditionalOfStorey_Reihenhaus9", 1);
        }
        // Reihenhaus 10
        else if (PlayerPrefs.GetString("PositionAdditionalOfStorey") == "Reihenhaus10")
        {
            PlayerPrefs.SetInt("AdditionalOfStorey_Reihenhaus10", 1);
        }

        PlayerPrefs.Save();

        Owner();

    }
    void Owner()
    {
        string grundstueck = PlayerPrefs.GetString("ActualPointCloudPosition");
        string ownerperson = Ownership(grundstueck);

        if (ownerperson == "Gemeinde")
        {
            int MomAppart = PlayerPrefs.GetInt("A1CountAppartment") + 2;
            PlayerPrefs.SetInt("A1CountAppartment", MomAppart);

            int A1MoneyAppartment = 2 * PlayerPrefs.GetInt("A1CountAppartment");
            PlayerPrefs.SetInt("A1MoneyAppartment", A1MoneyAppartment);

            int A1MoneyParkingLot = 1 * PlayerPrefs.GetInt("A1CountParkingLot") + 1 * PlayerPrefs.GetInt("A1CountTiefgarageParkingLot");
            int A1MoneyAppartmentParkingLot = 4 * PlayerPrefs.GetInt("A1CountAppartmentParkingLot");
            int A1MoneyAppartmentGarden = 4 * PlayerPrefs.GetInt("A1CountAppartmentGarden");

            int A1Total = PlayerPrefs.GetInt("A1MoneyShop") + A1MoneyParkingLot + A1MoneyAppartment + A1MoneyAppartmentParkingLot + A1MoneyAppartmentGarden;
            PlayerPrefs.SetInt("A1Total", A1Total);
        }
        else if (ownerperson == "Landbesitzer")
        {
            int MomAppart = PlayerPrefs.GetInt("A2CountAppartment") + 2;
            PlayerPrefs.SetInt("A2CountAppartment", MomAppart);

            int A2MoneyAppartment = 2 * PlayerPrefs.GetInt("A2CountAppartment");
            PlayerPrefs.SetInt("A2MoneyAppartment", A2MoneyAppartment);

            int A2MoneyParkingLot = 1 * PlayerPrefs.GetInt("A2CountParkingLot") + 1 * PlayerPrefs.GetInt("A2CountTiefgarageParkingLot");
            int A2MoneyAppartmentParkingLot = 4 * PlayerPrefs.GetInt("A2CountAppartmentParkingLot");
            int A2MoneyAppartmentGarden = 4 * PlayerPrefs.GetInt("A2CountAppartmentGarden");

            int A2Total = PlayerPrefs.GetInt("A2MoneyShop") + A2MoneyParkingLot + A2MoneyAppartment + A2MoneyAppartmentParkingLot + A2MoneyAppartmentGarden;
            PlayerPrefs.SetInt("A2Total", A2Total);
        }
        else if (ownerperson == "Genossenschaft")
        {
            int MomAppart = PlayerPrefs.GetInt("A3CountAppartment") + 2;
            PlayerPrefs.SetInt("A3CountAppartment", MomAppart);

            int A3MoneyAppartment = 2 * PlayerPrefs.GetInt("A3CountAppartment");
            PlayerPrefs.SetInt("A3MoneyAppartment", A3MoneyAppartment);

            int A3MoneyParkingLot = 1 * PlayerPrefs.GetInt("A3CountParkingLot") + 1 * PlayerPrefs.GetInt("A3CountTiefgarageParkingLot");
            int A3MoneyAppartmentParkingLot = 4 * PlayerPrefs.GetInt("A3CountAppartmentParkingLot");
            int A3MoneyAppartmentGarden = 4 * PlayerPrefs.GetInt("A3CountAppartmentGarden");

            int A3Total = PlayerPrefs.GetInt("A3MoneyShop") + A3MoneyParkingLot + A3MoneyAppartment + A3MoneyAppartmentParkingLot + A3MoneyAppartmentGarden;
            PlayerPrefs.SetInt("A3Total", A3Total);
        }
        else if (ownerperson == "Kulturzentrum")
        {
            int MomAppart = PlayerPrefs.GetInt("A4CountAppartment") + 2;
            PlayerPrefs.SetInt("A4CountAppartment", MomAppart);

            int A4MoneyAppartment = 2 * PlayerPrefs.GetInt("A4CountAppartment");
            PlayerPrefs.SetInt("A4MoneyAppartment", A4MoneyAppartment);

            int A4MoneyParkingLot = 1 * PlayerPrefs.GetInt("A4CountParkingLot") + 1 * PlayerPrefs.GetInt("A4CountTiefgarageParkingLot");
            int A4MoneyAppartmentParkingLot = 4 * PlayerPrefs.GetInt("A4CountAppartmentParkingLot");
            int A4MoneyAppartmentGarden = 4 * PlayerPrefs.GetInt("A4CountAppartmentGarden");

            int A4Total = PlayerPrefs.GetInt("A4MoneyShop") + A4MoneyParkingLot + A4MoneyAppartment + A4MoneyAppartmentParkingLot + A4MoneyAppartmentGarden;
            PlayerPrefs.SetInt("A4Total", A4Total);
        }

    }
    string Ownership(string grundstueck)
    {
        // Aparthotel
        if (grundstueck == "ApartHotel")
        {
            return PlayerPrefs.GetString("OwnerAparthotel");
        }
        // BrauiTreppe
        else if (grundstueck == "BrauiTreppe")
        {
            return PlayerPrefs.GetString("OwnerBrauiTreppe");
        }
        // BrauiTurm
        else if (grundstueck == "BrauiTurm")
        {
            return PlayerPrefs.GetString("OwnerBrauiTurm");
        }
        // GarageBox
        else if (grundstueck == "GarageBox")
        {
            return PlayerPrefs.GetString("OwnerGarageBox");
        }
        // Garage mit Garten
        else if (grundstueck == "GarageMitGarten")
        {
            return PlayerPrefs.GetString("OwnerGarageGarten");
        }
        // Garage Orange
        else if (grundstueck == "GarageOrange")
        {
            return PlayerPrefs.GetString("OwnerGarageOrange");
        }
        // Gruenflaeche
        else if (grundstueck == "GrunFlache")
        {
            return PlayerPrefs.GetString("OwnerGruenflaeche");
        }
        // Haus Brauiplatz4
        else if (grundstueck == "Haus_Brauiplatz4")
        {
            return PlayerPrefs.GetString("OwnerHausBrauiplatz4");
        }
        // Haus Kleinwangenstr. 1
        else if (grundstueck == "Haus_Kleinwangenstr1")
        {
            return PlayerPrefs.GetString("OwnerHausKleinw1");
        }
        //  Haus Kleinwangenstr. 3
        else if (grundstueck == "Haus_Kleinwangenstr3")
        {
            return PlayerPrefs.GetString("OwnerHausKleinw3");
        }
        //  Haus Kleinwangenstr. 5
        else if (grundstueck == "Haus_Kleinwangenstr5")
        {
            return PlayerPrefs.GetString("OwnerHausKleinw5");
        }
        //  Haus Kleinwangenstr. 7
        else if (grundstueck == "Haus_Kleinwangenstr7")
        {
            return PlayerPrefs.GetString("OwnerHausKleinw7");
        }
        // Haus Rosengasse 12
        else if (grundstueck == "Haus_Rosengasse12")
        {
            return PlayerPrefs.GetString("OwnerHausRoseng12");
        }
        // Hinterhof Parkplatz 1
        else if (grundstueck == "HinterHofParkplatz1")
        {
            return PlayerPrefs.GetString("OwnerHHPP1");
        }
        // Hinterhof Parkplatz 2
        else if (grundstueck == "HinterHofParkplatz2")
        {
            return PlayerPrefs.GetString("OwnerHHPP2");
        }
        // Hinterhof Parkplatz 3
        else if (grundstueck == "HinterHofParkplatz3")
        {
            return PlayerPrefs.GetString("OwnerHHPP3");
        }
        // Kantonalbank 
        else if (grundstueck == "Kantonalbank")
        {
            return PlayerPrefs.GetString("OwnerKantonalbank");
        }
        // Kulturzentrum Braui
        else if (grundstueck == "KulturzentrumBraui")
        {
            return PlayerPrefs.GetString("OwnerKulturzentrum");
        }
        // Braui Platz 1
        else if (grundstueck == "BrauiPlatz1")
        {
            return PlayerPrefs.GetString("OwnerBrauiPlatz1");
        }
        // Braui Platz 2
        else if (grundstueck == "BrauiPlatz2")
        {
            return PlayerPrefs.GetString("OwnerBrauiPlatz2");
        }
        // Braui Platz Restaurant 
        else if (grundstueck == "BrauiPlatz_RestaurantTerasse")
        {
            return PlayerPrefs.GetString("OwnerBrauiPlatzRestaurant");
        }
        // Braui Platz Testzentrum 
        else if (grundstueck == "BrauiPlatz_Testcenter")
        {
            return PlayerPrefs.GetString("OwnerBrauiPlatzTest");
        }
        // BrauiParkplatz1-4
        else if (grundstueck == "BrauiParkplatz1-4")
        {
            return PlayerPrefs.GetString("OwnerPP1to4");
        }
        // BrauiParkplatz5-8
        else if (grundstueck == "BrauiParkplatz5-8")
        {
            return PlayerPrefs.GetString("OwnerPP5to8");
        }
        // BrauiParkplatz9-11
        else if (grundstueck == "BrauiParkplatz9-11")
        {
            return PlayerPrefs.GetString("OwnerPP9to11");
        }
        // Braui Parkplatz Seite 12
        else if (grundstueck == "BrauiParkplatz_Seite12")
        {
            return PlayerPrefs.GetString("OwnerPP12");
        }
        // Braui Parkplatz Seite 13
        else if (grundstueck == "BrauiParkplatz_Seite13")
        {
            return PlayerPrefs.GetString("OwnerPP13");
        }
        // Braui Parkplatz Seite 14
        else if (grundstueck == "BrauiParkplatz_Seite14")
        {
            return PlayerPrefs.GetString("OwnerPP14");
        }
        // Braui Parkplatz Seite 15
        else if (grundstueck == "BrauiParkplatz_Seite15")
        {
            return PlayerPrefs.GetString("OwnerPP15");
        }
        // Reihenhaus 1
        else if (grundstueck == "Reihenhaus1")
        {
            return PlayerPrefs.GetString("OwnerReihenhaus1");
        }
        // Reihenhaus 2
        else if (grundstueck == "Reihenhaus2")
        {
            return PlayerPrefs.GetString("OwnerReihenhaus2");
        }
        // Reihenhaus 3
        else if (grundstueck == "Reihenhaus3")
        {
            return PlayerPrefs.GetString("OwnerReihenhaus3");
        }
        // Reihenhaus 4
        else if (grundstueck == "Reihenhaus4")
        {
            return PlayerPrefs.GetString("OwnerReihenhaus4");
        }
        // Reihenhaus 5
        else if (grundstueck == "Reihenhaus5")
        {
            return PlayerPrefs.GetString("OwnerReihenhaus5");
        }
        // Reihenhaus 6
        else if (grundstueck == "Reihenhaus6")
        {
            return PlayerPrefs.GetString("OwnerReihenhaus6");
        }
        // Reihenhaus 7
        else if (grundstueck == "Reihenhaus7")
        {
            return PlayerPrefs.GetString("OwnerReihenhaus7");
        }
        // Reihenhaus 8
        else if (grundstueck == "Reihenhaus8")
        {
            return PlayerPrefs.GetString("OwnerReihenhaus8");
        }
        // Reihenhaus 9
        else if (grundstueck == "Reihenhaus9")
        {
            return PlayerPrefs.GetString("OwnerReihenhaus9");
        }
        // Reihenhaus 10
        else if (grundstueck == "Reihenhaus10")
        {
            return PlayerPrefs.GetString("OwnerReihenhaus10");
        }
        // Restaurant Braui
        else if (grundstueck == "RestaurantBraui")
        {
            return PlayerPrefs.GetString("OwnerRestaurant");
        }
        // Restaurant Braui
        else
        if (grundstueck == "Jugendtreff")
        {
            return PlayerPrefs.GetString("OwnerJugendtreff");
        }
        else
        {
            return "NONE";
        }
    }

}
