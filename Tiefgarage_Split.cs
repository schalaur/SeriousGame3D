using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class Tiefgarage_Split : NetworkBehaviour
{
    private int ParkingLotsPlayer1;
    public Text TextParkingLotsPlayer1;
    public Slider SliderParkingLotsP1;

    private int ParkingLotsPlayer2;
    public Text TextParkingLotsPlayer2;
    public Slider SliderParkingLotsP2;

    private int ParkingLotsPlayer3;
    public Text TextParkingLotsPlayer3;
    public Slider SliderParkingLotsP3;

    private int ParkingLotsPlayer4;
    public Text TextParkingLotsPlayer4;
    public Slider SliderParkingLotsP4;

    private int ParkingLotsTotalDistributed;
    public Text TextParkingLotsTotalDistributed;

    private int ParkingLotsTotalMax;
    public Text TextParkingLotsTotalMax;

    private int ParkingLotsDifference;
    public Text TextParkingLotsDifference;

    public Button Accept;

    int MaxParkingLots = 50;

    public GameObject PanelOverview;
    public GameObject PanelPay;
    public GameObject PanelAufteilen;

    public Button Project;

    int AssetPlayer1;
    int AssetPlayer2;
    int AssetPlayer3;
    int AssetPlayer4;

    int Appealpos = 2;
    int Appealneg = -1;
    int Approval = 1;


    bool accepted = false;
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
                SliderParkingLotsP1.gameObject.SetActive(true);
                SliderParkingLotsP2.gameObject.SetActive(false);
                SliderParkingLotsP3.gameObject.SetActive(false);
                SliderParkingLotsP4.gameObject.SetActive(false);
            }
            else if (PlayerName == "Landbesitzer")
            {
                SliderParkingLotsP1.gameObject.SetActive(false);
                SliderParkingLotsP2.gameObject.SetActive(true);
                SliderParkingLotsP3.gameObject.SetActive(false);
                SliderParkingLotsP4.gameObject.SetActive(false);
            }
            else if (PlayerName == "Genossenschaft")
            {
                SliderParkingLotsP1.gameObject.SetActive(false);
                SliderParkingLotsP2.gameObject.SetActive(false);
                SliderParkingLotsP3.gameObject.SetActive(true);
                SliderParkingLotsP4.gameObject.SetActive(false);
            }
            else if (PlayerName == "Kulturzentrum")
            {
                SliderParkingLotsP1.gameObject.SetActive(false);
                SliderParkingLotsP2.gameObject.SetActive(false);
                SliderParkingLotsP3.gameObject.SetActive(false);
                SliderParkingLotsP4.gameObject.SetActive(true);
            }
        }

        SliderParkingLotsP1.maxValue = MaxParkingLots;
        SliderParkingLotsP2.maxValue = MaxParkingLots;
        SliderParkingLotsP3.maxValue = MaxParkingLots;
        SliderParkingLotsP4.maxValue = MaxParkingLots;

        SliderParkingLotsP1.value = 0;
        SliderParkingLotsP2.value = 0;
        SliderParkingLotsP3.value = 0;
        SliderParkingLotsP4.value = 0;

        ParkingLotsPlayer1 = (int)SliderParkingLotsP1.value;
        ParkingLotsPlayer2 = (int)SliderParkingLotsP2.value;
        ParkingLotsPlayer3 = (int)SliderParkingLotsP3.value;
        ParkingLotsPlayer4 = (int)SliderParkingLotsP4.value;

        TextParkingLotsPlayer1.text = ParkingLotsPlayer1.ToString();
        TextParkingLotsPlayer2.text = ParkingLotsPlayer2.ToString();
        TextParkingLotsPlayer3.text = ParkingLotsPlayer3.ToString();
        TextParkingLotsPlayer4.text = ParkingLotsPlayer4.ToString();

        ParkingLotsTotalDistributed = ParkingLotsPlayer1 + ParkingLotsPlayer2 + ParkingLotsPlayer3 + ParkingLotsPlayer4;
        ParkingLotsTotalMax = MaxParkingLots;
        ParkingLotsDifference = ParkingLotsTotalMax - ParkingLotsTotalDistributed;

        TextParkingLotsTotalDistributed.text = ParkingLotsTotalDistributed.ToString();
        TextParkingLotsTotalMax.text = ParkingLotsTotalMax.ToString();
        TextParkingLotsDifference.text = ParkingLotsDifference.ToString();

    }

    void Update()
    {
        if (ParkingLotsDifference == 0)
        {
            Accept.gameObject.SetActive(true);
        }
        else
        {
            Accept.gameObject.SetActive(false);
        }

        TextParkingLotsPlayer1.text = ParkingLotsPlayer1.ToString();
        TextParkingLotsPlayer2.text = ParkingLotsPlayer2.ToString();
        TextParkingLotsPlayer3.text = ParkingLotsPlayer3.ToString();
        TextParkingLotsPlayer4.text = ParkingLotsPlayer4.ToString();

        TextParkingLotsTotalDistributed.text = ParkingLotsTotalDistributed.ToString();
        TextParkingLotsDifference.text = ParkingLotsDifference.ToString();

        if (accepted)
        {
            Project.GetComponent<Button>().interactable = false;
            Project.gameObject.SetActive(false);
            BackToOverview();
            accepted = false;
        }

    }

    // Updates by every click on the sliders; all slider values are calculated again incl. sum & dif 
    public void TiefgarageParkingLotsDristributionChange()
    {
        string PlayerName = NetworkClient.localPlayer.gameObject.name.ToString();

        if (PlayerName == "Gemeinde")
        {
            ParkingLotsPlayer1 = (int)SliderParkingLotsP1.value;
            CmdCallServer(ParkingLotsPlayer1, "Gemeinde");
        }
        else if (PlayerName == "Landbesitzer")
        {
            ParkingLotsPlayer2 = (int)SliderParkingLotsP2.value;
            CmdCallServer(ParkingLotsPlayer2, "Landbesitzer");
        }
        else if (PlayerName == "Genossenschaft")
        {
            ParkingLotsPlayer3 = (int)SliderParkingLotsP3.value;
            CmdCallServer(ParkingLotsPlayer3, "Genossenschaft");
        }
        else if (PlayerName == "Kulturzentrum")
        {
            ParkingLotsPlayer4 = (int)SliderParkingLotsP4.value;
            CmdCallServer(ParkingLotsPlayer4, "Kulturzentrum");
        }

    }

    [Command(requiresAuthority = false)]
    void CmdCallServer(int ParkingLots, string PlayerName)
    {
        if (PlayerName == "Gemeinde")
        {
            ParkingLotsPlayer1 = ParkingLots;
            PlayerPrefs.SetInt("SliderP1", ParkingLotsPlayer1);
        }
        else if (PlayerName == "Landbesitzer")
        {
            ParkingLotsPlayer2 = ParkingLots;
            PlayerPrefs.SetInt("SliderP2", ParkingLotsPlayer2);
        }
        else if (PlayerName == "Genossenschaft")
        {
            ParkingLotsPlayer3 = ParkingLots;
            PlayerPrefs.SetInt("SliderP3", ParkingLotsPlayer3);
        }
        else if (PlayerName == "Kulturzentrum")
        {
            ParkingLotsPlayer4 = ParkingLots;
            PlayerPrefs.SetInt("SliderP4", ParkingLotsPlayer4);
        }

        ParkingLotsTotalDistributed = ParkingLotsPlayer1 + ParkingLotsPlayer2 + ParkingLotsPlayer3 + ParkingLotsPlayer4;
        ParkingLotsDifference = ParkingLotsTotalMax - ParkingLotsTotalDistributed;

        TextParkingLotsPlayer1.text = ParkingLotsPlayer1.ToString();
        TextParkingLotsPlayer2.text = ParkingLotsPlayer2.ToString();
        TextParkingLotsPlayer3.text = ParkingLotsPlayer3.ToString();
        TextParkingLotsPlayer4.text = ParkingLotsPlayer4.ToString();

        TextParkingLotsTotalDistributed.text = ParkingLotsTotalDistributed.ToString();
        TextParkingLotsDifference.text = ParkingLotsDifference.ToString();

        PlayerPrefs.SetInt("MunPressed", 0);
        PlayerPrefs.SetInt("LandPressed", 0);
        PlayerPrefs.SetInt("CoPressed", 0);
        PlayerPrefs.SetInt("CultPressed", 0);

        RpcCallClients(ParkingLotsPlayer1, ParkingLotsPlayer2, ParkingLotsPlayer3, ParkingLotsPlayer4, ParkingLotsTotalDistributed, ParkingLotsDifference);
    }

    [ClientRpc]
    void RpcCallClients(int ParkingLotsPlayer1Server, int ParkingLotsPlayer2Server, int ParkingLotsPlayer3Server, int ParkingLotsPlayer4Server, int ParkingLotsTotalDistributedServer, int ParkingLotsDifferenceServer)
    {
        ParkingLotsPlayer1 = ParkingLotsPlayer1Server;
        ParkingLotsPlayer2 = ParkingLotsPlayer2Server;
        ParkingLotsPlayer3 = ParkingLotsPlayer3Server;
        ParkingLotsPlayer4 = ParkingLotsPlayer4Server;
        ParkingLotsTotalDistributed = ParkingLotsTotalDistributedServer;
        ParkingLotsDifference = ParkingLotsDifferenceServer;

        TextParkingLotsPlayer1.text = ParkingLotsPlayer1.ToString();
        TextParkingLotsPlayer2.text = ParkingLotsPlayer2.ToString();
        TextParkingLotsPlayer3.text = ParkingLotsPlayer3.ToString();
        TextParkingLotsPlayer4.text = ParkingLotsPlayer4.ToString();

        TextParkingLotsTotalDistributed.text = ParkingLotsTotalDistributed.ToString();
        TextParkingLotsDifference.text = ParkingLotsDifference.ToString();
    }

    public void TiefgarageAccept()
    {
        if (!isServer)
        {
            string PlayerName = NetworkClient.localPlayer.gameObject.name.ToString();

            CmdTiefgarageAccept(PlayerName);
            CmdAcceptedNow();
        }

        if (isServer)
        {
            Player1 = false;
            Player2 = false;
            Player3 = false;
            Player4 = false;

            Implement();
            Project.GetComponent<Button>().interactable = false;
            Project.gameObject.SetActive(false);
            BackToOverview();

            RpcAccepted(true);
        }

    }

    [Command(requiresAuthority = false)]
    void CmdTiefgarageAccept(string PlayerName)
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
        if (Player1 && Player2 && Player2 && Player4)
        //if (Player1 && Player2)
        {
            Player1 = false;
            Player2 = false;
            Player3 = false;
            Player4 = false;

            Implement();
            Project.GetComponent<Button>().interactable = false;
            Project.gameObject.SetActive(false); 
            BackToOverview();

            RpcAccepted(true);
        }
    }

    [ClientRpc]
    void RpcAccepted(bool acceptedServer)
    {
        accepted = acceptedServer;
    }

    public void BackToPayment()
    {
        PanelAufteilen.SetActive(false);
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
        PanelAufteilen.SetActive(false);
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
        // Implement from Costs (PayPlayer) adaptiert: 
        int tempp1 = PlayerPrefs.GetInt("A1MomAsset");
        int tempp2 = PlayerPrefs.GetInt("A2MomAsset");
        int tempp3 = PlayerPrefs.GetInt("A3MomAsset");
        int tempp4 = PlayerPrefs.GetInt("A4MomAsset");

        AssetPlayer1 = tempp1 - PlayerPrefs.GetInt("TiefgaragePriceP1");
        AssetPlayer2 = tempp2 - PlayerPrefs.GetInt("TiefgaragePriceP2");
        AssetPlayer3 = tempp3 - PlayerPrefs.GetInt("TiefgaragePriceP3");
        AssetPlayer4 = tempp4 - PlayerPrefs.GetInt("TiefgaragePriceP4");

        PlayerPrefs.SetInt("A1MomAsset", AssetPlayer1);
        PlayerPrefs.SetInt("A2MomAsset", AssetPlayer2);
        PlayerPrefs.SetInt("A3MomAsset", AssetPlayer3);
        PlayerPrefs.SetInt("A4MomAsset", AssetPlayer4);

        int tempAppeal1 = PlayerPrefs.GetInt("Appeal");
        int tempApproval1 = PlayerPrefs.GetInt("Approval");

        int ParkplatzA1 = PlayerPrefs.GetInt("A1CountParkingLot");
        int ParkplatzWohnungA1 = PlayerPrefs.GetInt("A1CountAppartmentParkingLot");
        int ParkplatzA2 = PlayerPrefs.GetInt("A2CountParkingLot");
        int ParkplatzWohnungA2 = PlayerPrefs.GetInt("A2CountAppartmentParkingLot");
        int ParkplatzA3 = PlayerPrefs.GetInt("A3CountParkingLot");
        int ParkplatzWohnungA3 = PlayerPrefs.GetInt("A3CountAppartmentParkingLot");
        int ParkplatzA4 = PlayerPrefs.GetInt("A4CountParkingLot");
        int ParkplatzWohnungA4 = PlayerPrefs.GetInt("A4CountAppartmentParkingLot");

        int TotalParkplatz = ParkplatzA1 + ParkplatzA2 + ParkplatzA3 + ParkplatzA4 + ParkplatzWohnungA1 + ParkplatzWohnungA2 + ParkplatzWohnungA3 + ParkplatzWohnungA4;

        tempApproval1 = tempApproval1 + Approval;

        if (TotalParkplatz < 0)
        {
            tempAppeal1 = tempAppeal1 + Appealpos;
        }
        else if (TotalParkplatz > 0)
        {
            tempAppeal1 = tempAppeal1 + Appealneg;
        }

        if (tempAppeal1 > 6)
        {
            tempAppeal1 = 6;
        }

        if (tempAppeal1 < -6)
        {
            tempAppeal1 = -6;
        }

        PlayerPrefs.SetInt("Appeal", tempAppeal1);
        PlayerPrefs.SetInt("Approval", tempApproval1);

        PlayerPrefs.SetInt("Tiefgarage", 1);

        PlayerPrefs.SetString("PositionTiefgarage", PlayerPrefs.GetString("ActualPointCloudParent"));

        //Nach Aufteilung der Parkplätze: 
        int A1Parkhaus = PlayerPrefs.GetInt("SliderP1");
        int A2Parkhaus = PlayerPrefs.GetInt("SliderP2");
        int A3Parkhaus = PlayerPrefs.GetInt("SliderP3");
        int A4Parkhaus = PlayerPrefs.GetInt("SliderP4");

        PlayerPrefs.SetInt("A1CountTiefgarageParkingLot", A1Parkhaus);
        PlayerPrefs.SetInt("A2CountTiefgarageParkingLot", A2Parkhaus);
        PlayerPrefs.SetInt("A3CountTiefgarageParkingLot", A3Parkhaus);
        PlayerPrefs.SetInt("A4CountTiefgarageParkingLot", A4Parkhaus);

        // Anpassen Values Actor 1
        int A1CountParkingLot = PlayerPrefs.GetInt("A1CountParkingLot");
        int A1CountTiefgarageParkingLot = PlayerPrefs.GetInt("A1CountTiefgarageParkingLot");
        int A1ParkingTotal = A1CountParkingLot + A1CountTiefgarageParkingLot;
        PlayerPrefs.SetInt("A1CountParkingTotal", A1ParkingTotal);

        int A1MoneyParkingLot = 1 * PlayerPrefs.GetInt("A1CountParkingLot") + 1 * PlayerPrefs.GetInt("A1CountTiefgarageParkingLot");
        PlayerPrefs.SetInt("A1MoneyParkingLot", A1MoneyParkingLot);

        // Anpassen Values Actor 2
        int A2CountParkingLot = PlayerPrefs.GetInt("A2CountParkingLot");
        int A2CountTiefgarageParkingLot = PlayerPrefs.GetInt("A2CountTiefgarageParkingLot");
        int A2ParkingTotal = A2CountParkingLot + A2CountTiefgarageParkingLot;
        PlayerPrefs.SetInt("A2CountParkingTotal", A2ParkingTotal);

        int A2MoneyParkingLot = 1 * PlayerPrefs.GetInt("A2CountParkingLot") + 1 * PlayerPrefs.GetInt("A2CountTiefgarageParkingLot");
        PlayerPrefs.SetInt("A2MoneyParkingLot", A2MoneyParkingLot);

        // Anpassen Values Actor 3
        int A3CountParkingLot = PlayerPrefs.GetInt("A3CountParkingLot");
        int A3CountTiefgarageParkingLot = PlayerPrefs.GetInt("A3CountTiefgarageParkingLot");
        int A3ParkingTotal = A3CountParkingLot + A3CountTiefgarageParkingLot;
        PlayerPrefs.SetInt("A3CountParkingTotal", A3ParkingTotal);

        int A3MoneyParkingLot = 1 * PlayerPrefs.GetInt("A3CountParkingLot") + 1 * PlayerPrefs.GetInt("A3CountTiefgarageParkingLot");
        PlayerPrefs.SetInt("A3MoneyParkingLot", A3MoneyParkingLot);

        // Anpassen Values Actor 4
        int A4CountParkingLot = PlayerPrefs.GetInt("A4CountParkingLot");
        int A4CountTiefgarageParkingLot = PlayerPrefs.GetInt("A4CountTiefgarageParkingLot");
        int A4ParkingTotal = A4CountParkingLot + A4CountTiefgarageParkingLot;
        PlayerPrefs.SetInt("A4CountParkingTotal", A4ParkingTotal);

        int A4MoneyParkingLot = 1 * PlayerPrefs.GetInt("A4CountParkingLot") + 1 * PlayerPrefs.GetInt("A4CountTiefgarageParkingLot");
        PlayerPrefs.SetInt("A4MoneyParkingLot", A4MoneyParkingLot);

        //Owner();

        PlayerPrefs.Save();
    }

    void Owner()
    {
        string grundstueck = PlayerPrefs.GetString("ActualPointCloudPosition");
        string ownerperson = Ownership(grundstueck);

        if (ownerperson == "Gemeinde")
        {
            int MomAppart = PlayerPrefs.GetInt("A1CountAppartment") - Appartment(grundstueck);
            int MomParking = PlayerPrefs.GetInt("A1CountParkingLot") - Parking(grundstueck);

            PlayerPrefs.SetInt("A1CountAppartment", MomAppart);
            PlayerPrefs.SetInt("A1CountParkingLot", MomParking);

            int A1CountParkingLot = PlayerPrefs.GetInt("A1CountParkingLot");
            int A1CountTiefgarageParkingLot = PlayerPrefs.GetInt("A1CountTiefgarageParkingLot");
            int A1ParkingTotal = A1CountParkingLot + A1CountTiefgarageParkingLot;
            PlayerPrefs.SetInt("A1CountParkingTotal", A1ParkingTotal);

            int A1MoneyParkingLot = 1 * PlayerPrefs.GetInt("A1CountParkingLot") + 1 * PlayerPrefs.GetInt("A1CountTiefgarageParkingLot");
            PlayerPrefs.SetInt("A1MoneyParkingLot", A1MoneyParkingLot);

            int A1MoneyAppartment = 2 * PlayerPrefs.GetInt("A1CountAppartment");
            PlayerPrefs.SetInt("A1MoneyAppartment", A1MoneyAppartment);

            int A1MoneyAppartmentParkingLot = 4 * PlayerPrefs.GetInt("A1CountAppartmentParkingLot");
            PlayerPrefs.SetInt("A1MoneyAppartmentParkingLot", A1MoneyAppartmentParkingLot);

            int A1MoneyAppartmentGarden = 4 * PlayerPrefs.GetInt("A1CountAppartmentGarden");
            PlayerPrefs.SetInt("A1MoneyAppartmentGarden", A1MoneyAppartmentGarden);

            int ShopIncome = PlayerPrefs.GetInt("ShopIncome");
            // Weil Kulturzentrum Braui der Gemeinde gehört, aber das Kulturzentrum seinen Shop drin hat
            if (grundstueck != "KulturzentrumBraui")
            {
                int MomShop = PlayerPrefs.GetInt("A1CountShop") - Shop(grundstueck);
                PlayerPrefs.SetInt("A1CountShop", MomShop);

                int A1MoneyShop = ShopIncome * PlayerPrefs.GetInt("A1CountShop");
                PlayerPrefs.SetInt("A1MoneyShop", A1MoneyShop);
            }
            if (grundstueck == "KulturzentrumBraui")
            {
                int MomShop = PlayerPrefs.GetInt("A4CountShop") - Shop(grundstueck);
                PlayerPrefs.SetInt("A4CountShop", MomShop);

                int A4MoneyShop = ShopIncome * PlayerPrefs.GetInt("A4CountShop");
                PlayerPrefs.SetInt("A4MoneyShop", A4MoneyShop);

                int A4Total = PlayerPrefs.GetInt("A4MoneyShop") + PlayerPrefs.GetInt("A4MoneyParkingLot") + PlayerPrefs.GetInt("A4MoneyAppartment") + PlayerPrefs.GetInt("A4MoneyAppartmentParkingLot") + PlayerPrefs.GetInt("A4MoneyAppartmentGarden");
                PlayerPrefs.SetInt("A4Total", A4Total);
            }

            int A1Total = PlayerPrefs.GetInt("A1MoneyShop") + A1MoneyParkingLot + A1MoneyAppartment + A1MoneyAppartmentParkingLot + A1MoneyAppartmentGarden;
            PlayerPrefs.SetInt("A1Total", A1Total);
        }
        else if (ownerperson == "Landbesitzer")
        {
            int MomAppart = PlayerPrefs.GetInt("A2CountAppartment") - Appartment(grundstueck);
            int MomParking = PlayerPrefs.GetInt("A2CountParkingLot") - Parking(grundstueck);
            int MomShop = PlayerPrefs.GetInt("A2CountShop") - Shop(grundstueck);

            PlayerPrefs.SetInt("A2CountAppartment", MomAppart);
            PlayerPrefs.SetInt("A2CountParkingLot", MomParking);
            PlayerPrefs.SetInt("A2CountShop", MomShop);

            int A2CountParkingLot = PlayerPrefs.GetInt("A2CountParkingLot");
            int A2CountTiefgarageParkingLot = PlayerPrefs.GetInt("A2CountTiefgarageParkingLot");
            int A2ParkingTotal = A2CountParkingLot + A2CountTiefgarageParkingLot;
            PlayerPrefs.SetInt("A2CountParkingTotal", A2ParkingTotal);

            int ShopIncome = PlayerPrefs.GetInt("ShopIncome");

            int A2MoneyShop = ShopIncome * PlayerPrefs.GetInt("A2CountShop");
            PlayerPrefs.SetInt("A2MoneyShop", A2MoneyShop);

            int A2MoneyParkingLot = 1 * PlayerPrefs.GetInt("A2CountParkingLot") + 1 * PlayerPrefs.GetInt("A2CountTiefgarageParkingLot");
            PlayerPrefs.SetInt("A2MoneyParkingLot", A2MoneyParkingLot);

            int A2MoneyAppartment = 2 * PlayerPrefs.GetInt("A2CountAppartment");
            PlayerPrefs.SetInt("A2MoneyAppartment", A2MoneyAppartment);

            int A2MoneyAppartmentParkingLot = 4 * PlayerPrefs.GetInt("A2CountAppartmentParkingLot");
            PlayerPrefs.SetInt("A2MoneyAppartmentParkingLot", A2MoneyAppartmentParkingLot);

            int A2MoneyAppartmentGarden = 4 * PlayerPrefs.GetInt("A2CountAppartmentGarden");
            PlayerPrefs.SetInt("A2MoneyAppartmentGarden", A2MoneyAppartmentGarden);

            int A2Total = A2MoneyShop + A2MoneyParkingLot + A2MoneyAppartment + A2MoneyAppartmentParkingLot + A2MoneyAppartmentGarden;
            PlayerPrefs.SetInt("A2Total", A2Total);
        }
        else if (ownerperson == "Genossenschaft")
        {
            int MomAppart = PlayerPrefs.GetInt("A3CountAppartment") - Appartment(grundstueck);
            int MomParking = PlayerPrefs.GetInt("A3CountParkingLot") - Parking(grundstueck);
            int MomShop = PlayerPrefs.GetInt("A3CountShop") - Shop(grundstueck);

            PlayerPrefs.SetInt("A3CountAppartment", MomAppart);
            PlayerPrefs.SetInt("A3CountParkingLot", MomParking);
            PlayerPrefs.SetInt("A3CountShop", MomShop);

            int A3CountParkingLot = PlayerPrefs.GetInt("A3CountParkingLot");
            int A3CountTiefgarageParkingLot = PlayerPrefs.GetInt("A3CountTiefgarageParkingLot");
            int A3ParkingTotal = A3CountParkingLot + A3CountTiefgarageParkingLot;
            PlayerPrefs.SetInt("A3CountParkingTotal", A3ParkingTotal);

            int ShopIncome = PlayerPrefs.GetInt("ShopIncome");

            int A3MoneyShop = ShopIncome * PlayerPrefs.GetInt("A3CountShop");
            PlayerPrefs.SetInt("A3MoneyShop", A3MoneyShop);

            int A3MoneyParkingLot = 1 * PlayerPrefs.GetInt("A3CountParkingLot") + 1 * PlayerPrefs.GetInt("A3CountTiefgarageParkingLot");
            PlayerPrefs.SetInt("A3MoneyParkingLot", A3MoneyParkingLot);

            int A3MoneyAppartment = 2 * PlayerPrefs.GetInt("A3CountAppartment");
            PlayerPrefs.SetInt("A3MoneyAppartment", A3MoneyAppartment);

            int A3MoneyAppartmentParkingLot = 4 * PlayerPrefs.GetInt("A3CountAppartmentParkingLot");
            PlayerPrefs.SetInt("A3MoneyAppartmentParkingLot", A3MoneyAppartmentParkingLot);

            int A3MoneyAppartmentGarden = 4 * PlayerPrefs.GetInt("A3CountAppartmentGarden");
            PlayerPrefs.SetInt("A3MoneyAppartmentGarden", A3MoneyAppartmentGarden);

            int A3Total = A3MoneyShop + A3MoneyParkingLot + A3MoneyAppartment + A3MoneyAppartmentParkingLot + A3MoneyAppartmentGarden;
            PlayerPrefs.SetInt("A3Total", A3Total);
        }
        else if (ownerperson == "Kulturzentrum")
        {
            int MomAppart = PlayerPrefs.GetInt("A4CountAppartment") - Appartment(grundstueck);
            int MomParking = PlayerPrefs.GetInt("A4CountParkingLot") - Parking(grundstueck);
            int MomShop = PlayerPrefs.GetInt("A4CountShop") - Shop(grundstueck);

            PlayerPrefs.SetInt("A4CountAppartment", MomAppart);
            PlayerPrefs.SetInt("A4CountParkingLot", MomParking);
            PlayerPrefs.SetInt("A4CountShop", MomShop);

            int A4CountParkingLot = PlayerPrefs.GetInt("A4CountParkingLot");
            int A4CountTiefgarageParkingLot = PlayerPrefs.GetInt("A4CountTiefgarageParkingLot");
            int A4ParkingTotal = A4CountParkingLot + A4CountTiefgarageParkingLot;
            PlayerPrefs.SetInt("A4CountParkingTotal", A4ParkingTotal);

            int ShopIncome = PlayerPrefs.GetInt("ShopIncome");

            int A4MoneyShop = ShopIncome * PlayerPrefs.GetInt("A4CountShop");
            PlayerPrefs.SetInt("A4MoneyShop", A4MoneyShop);

            int A4MoneyParkingLot = 1 * PlayerPrefs.GetInt("A4CountParkingLot") + 1 * PlayerPrefs.GetInt("A4CountTiefgarageParkingLot");
            PlayerPrefs.SetInt("A4MoneyParkingLot", A4MoneyParkingLot);

            int A4MoneyAppartment = 2 * PlayerPrefs.GetInt("A4CountAppartment");
            PlayerPrefs.SetInt("A4MoneyAppartment", A4MoneyAppartment);

            int A4MoneyAppartmentParkingLot = 4 * PlayerPrefs.GetInt("A4CountAppartmentParkingLot");
            PlayerPrefs.SetInt("A4MoneyAppartmentParkingLot", A4MoneyAppartmentParkingLot);

            int A4MoneyAppartmentGarden = 4 * PlayerPrefs.GetInt("A4CountAppartmentGarden");
            PlayerPrefs.SetInt("A4MoneyAppartmentGarden", A4MoneyAppartmentGarden);

            int A4Total = A4MoneyShop + A4MoneyParkingLot + A4MoneyAppartment + A4MoneyAppartmentParkingLot + A4MoneyAppartmentGarden;
            PlayerPrefs.SetInt("A4Total", A4Total);
        }

        ChangeOwnerToImplementiert(grundstueck);

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
        else
        {
            return "NONE";
        }
    }
    int Appartment(string grundstueck)
    {
        // Aparthotel
        if (grundstueck == "ApartHotel")
        {
            return PlayerPrefs.GetInt("AppartmentAparthotel");
        }
        // Garage mit Garten
        else if (grundstueck == "GarageMitGarten")
        {
            return PlayerPrefs.GetInt("AppartmentGarageGarten");
        }
        // Haus Brauiplatz4
        else if (grundstueck == "Haus_Brauiplatz4")
        {
            return PlayerPrefs.GetInt("AppartmentHausBrauiplatz4");
        }
        // Haus Kleinwangenstr. 1
        else if (grundstueck == "Haus_Kleinwangenstr1")
        {
            return PlayerPrefs.GetInt("AppartmentHausKleinw1");
        }
        //  Haus Kleinwangenstr. 3
        else if (grundstueck == "Haus_Kleinwangenstr3")
        {
            return PlayerPrefs.GetInt("AppartmentHausKleinw3");
        }
        //  Haus Kleinwangenstr. 5
        else if (grundstueck == "Haus_Kleinwangenstr5")
        {
            return PlayerPrefs.GetInt("AppartmentHausKleinw5");
        }
        //  Haus Kleinwangenstr. 7
        else if (grundstueck == "Haus_Kleinwangenstr7")
        {
            return PlayerPrefs.GetInt("AppartmentHausKleinw7");
        }
        // Haus Rosengasse 12
        else if (grundstueck == "Haus_Rosengasse12")
        {
            return PlayerPrefs.GetInt("AppartmentHausRoseng12");
        }
        // Kantonalbank 
        else if (grundstueck == "Kantonalbank")
        {
            return PlayerPrefs.GetInt("AppartmentKantonalbank");
        }
        // Reihenhaus 1
        else if (grundstueck == "Reihenhaus1")
        {
            return PlayerPrefs.GetInt("AppartmentReihenhaus1");
        }
        // Reihenhaus 2
        else if (grundstueck == "Reihenhaus2")
        {
            return PlayerPrefs.GetInt("AppartmentReihenhaus2");
        }
        // Reihenhaus 3
        else if (grundstueck == "Reihenhaus3")
        {
            return PlayerPrefs.GetInt("AppartmentReihenhaus3");
        }
        // Reihenhaus 4
        else if (grundstueck == "Reihenhaus4")
        {
            return PlayerPrefs.GetInt("AppartmentReihenhaus4");
        }
        // Reihenhaus 5
        else if (grundstueck == "Reihenhaus5")
        {
            return PlayerPrefs.GetInt("AppartmentReihenhaus5");
        }
        // Reihenhaus 6
        else if (grundstueck == "Reihenhaus6")
        {
            return PlayerPrefs.GetInt("AppartmentReihenhaus6");
        }
        // Reihenhaus 7
        else if (grundstueck == "Reihenhaus7")
        {
            return PlayerPrefs.GetInt("AppartmentReihenhaus7");
        }
        // Reihenhaus 8
        else if (grundstueck == "Reihenhaus8")
        {
            return PlayerPrefs.GetInt("AppartmentReihenhaus8");
        }
        // Reihenhaus 9
        else if (grundstueck == "Reihenhaus9")
        {
            return PlayerPrefs.GetInt("AppartmentReihenhaus9");
        }
        // Reihenhaus 10
        else if (grundstueck == "Reihenhaus10")
        {
            return PlayerPrefs.GetInt("AppartmentReihenhaus10");
        }
        else
        {
            return 0;
        }
    }

    int Parking(string grundstueck)
    {
        // GarageBox
        if (grundstueck == "GarageBox")
        {
            return PlayerPrefs.GetInt("ParkingGarageBox");
        }
        // Garage Orange
        else if (grundstueck == "GarageOrange")
        {
            return PlayerPrefs.GetInt("ParkingGarageOrange");
        }
        // Hinterhof Parkplatz 1
        else if (grundstueck == "HinterHofParkplatz1")
        {
            return PlayerPrefs.GetInt("ParkingHHPP1");
        }
        // Hinterhof Parkplatz 2
        else if (grundstueck == "HinterHofParkplatz2")
        {
            return PlayerPrefs.GetInt("ParkingHHPP2");
        }
        // Hinterhof Parkplatz 3
        else if (grundstueck == "HinterHofParkplatz3")
        {
            return PlayerPrefs.GetInt("ParkingHHPP3");
        }
        // BrauiParkplatz1-4
        else if (grundstueck == "BrauiParkplatz1-4")
        {
            return PlayerPrefs.GetInt("ParkingPP1to4");
        }
        // BrauiParkplatz5-8
        else if (grundstueck == "BrauiParkplatz5-8")
        {
            return PlayerPrefs.GetInt("ParkingPP5to8");
        }
        // BrauiParkplatz9-11
        else if (grundstueck == "BrauiParkplatz9-11")
        {
            return PlayerPrefs.GetInt("ParkingPP9to11");
        }
        // Braui Parkplatz Seite 12
        else if (grundstueck == "BrauiParkplatz_Seite12")
        {
            return PlayerPrefs.GetInt("ParkingPP12");
        }
        // Braui Parkplatz Seite 13
        else if (grundstueck == "BrauiParkplatz_Seite13")
        {
            return PlayerPrefs.GetInt("ParkingPP13");
        }
        // Braui Parkplatz Seite 14
        else if (grundstueck == "BrauiParkplatz_Seite14")
        {
            return PlayerPrefs.GetInt("ParkingPP14");
        }
        // Braui Parkplatz Seite 15
        else if (grundstueck == "BrauiParkplatz_Seite15")
        {
            return PlayerPrefs.GetInt("ParkingPP15");
        }
        else
        {
            return 0;
        }
    }

    int Shop(string grundstueck)
    {
        // Kantonalbank 
        if (grundstueck == "Kantonalbank")
        {
            return PlayerPrefs.GetInt("ShopKantonalbank");
        }
        // Kulturzentrum Braui
        else if (grundstueck == "KulturzentrumBraui")
        {
            return PlayerPrefs.GetInt("ShopKulturzentrum");
        }
        // Reihenhaus 2
        else if (grundstueck == "Reihenhaus2")
        {
            return PlayerPrefs.GetInt("ShopReihenhaus2");
        }
        // Reihenhaus 3
        else if (grundstueck == "Reihenhaus3")
        {
            return PlayerPrefs.GetInt("ShopReihenhaus3");
        }
        // Restaurant Braui
        else if (grundstueck == "RestaurantBraui")
        {
            return PlayerPrefs.GetInt("ShopRestaurant");
        }
        else
        {
            return 0;
        }
    }

    void ChangeOwnerToImplementiert(string grundstueck)
    {
        // Aparthotel
        if (grundstueck == "ApartHotel")
        {
            PlayerPrefs.SetString("OwnerAparthotel", "Implementiert");
        }
        // BrauiTreppe
        else if (grundstueck == "BrauiTreppe")
        {
            PlayerPrefs.SetString("OwnerBrauiTreppe", "Implementiert");
        }
        // BrauiTurm
        else if (grundstueck == "BrauiTurm")
        {
            PlayerPrefs.SetString("OwnerBrauiTurm", "Implementiert");
        }
        // GarageBox
        else if (grundstueck == "GarageBox")
        {
            PlayerPrefs.SetString("OwnerGarageBox", "Implementiert");
        }
        // Garage mit Garten
        else if (grundstueck == "GarageMitGarten")
        {
            PlayerPrefs.SetString("OwnerGarageGarten", "Implementiert");
        }
        // Garage Orange
        else if (grundstueck == "GarageOrange")
        {
            PlayerPrefs.SetString("OwnerGarageOrange", "Implementiert");
        }
        // Gruenflaeche
        else if (grundstueck == "GrunFlache")
        {
            PlayerPrefs.SetString("OwnerGruenflaeche", "Implementiert");
        }
        // Haus Brauiplatz4
        else if (grundstueck == "Haus_Brauiplatz4")
        {
            PlayerPrefs.SetString("OwnerHausBrauiplatz4", "Implementiert");
        }
        // Haus Kleinwangenstr. 1
        else if (grundstueck == "Haus_Kleinwangenstr1")
        {
            PlayerPrefs.SetString("OwnerHausKleinw1", "Implementiert");
        }
        //  Haus Kleinwangenstr. 3
        else if (grundstueck == "Haus_Kleinwangenstr3")
        {
            PlayerPrefs.SetString("OwnerHausKleinw3", "Implementiert");
        }
        //  Haus Kleinwangenstr. 5
        else if (grundstueck == "Haus_Kleinwangenstr5")
        {
            PlayerPrefs.SetString("OwnerHausKleinw5", "Implementiert");
        }
        //  Haus Kleinwangenstr. 7
        else if (grundstueck == "Haus_Kleinwangenstr7")
        {
            PlayerPrefs.SetString("OwnerHausKleinw7", "Implementiert");
        }
        // Haus Rosengasse 12
        else if (grundstueck == "Haus_Rosengasse12")
        {
            PlayerPrefs.SetString("OwnerHausRoseng12", "Implementiert");
        }
        // Hinterhof Parkplatz 1
        else if (grundstueck == "HinterHofParkplatz1")
        {
            PlayerPrefs.SetString("OwnerHHPP1", "Implementiert");
        }
        // Hinterhof Parkplatz 2
        else if (grundstueck == "HinterHofParkplatz2")
        {
            PlayerPrefs.SetString("OwnerHHPP2", "Implementiert");
        }
        // Hinterhof Parkplatz 3
        else if (grundstueck == "HinterHofParkplatz3")
        {
            PlayerPrefs.SetString("OwnerHHPP3", "Implementiert");
        }
        // Kantonalbank 
        else if (grundstueck == "Kantonalbank")
        {
            PlayerPrefs.SetString("OwnerKantonalbank", "Implementiert");
        }
        // Kulturzentrum Braui
        else if (grundstueck == "KulturzentrumBraui")
        {
            PlayerPrefs.SetString("OwnerKulturzentrum", "Implementiert");
        }
        // Braui Platz 1
        else if (grundstueck == "BrauiPlatz1")
        {
            PlayerPrefs.SetString("OwnerBrauiPlatz1", "Implementiert");
        }
        // Braui Platz 2
        else if (grundstueck == "BrauiPlatz2")
        {
            PlayerPrefs.SetString("OwnerBrauiPlatz2", "Implementiert");
        }
        // Braui Platz Restaurant 
        else if (grundstueck == "BrauiPlatz_RestaurantTerasse")
        {
            PlayerPrefs.SetString("OwnerBrauiPlatzRestaurant", "Implementiert");
        }
        // Braui Platz Testzentrum 
        else if (grundstueck == "BrauiPlatz_Testcenter")
        {
            PlayerPrefs.SetString("OwnerBrauiPlatzTest", "Implementiert");
        }
        // BrauiParkplatz1-4
        else if (grundstueck == "BrauiParkplatz1-4")
        {
            PlayerPrefs.SetString("OwnerPP1to4", "Implementiert");
        }
        // BrauiParkplatz5-8
        else if (grundstueck == "BrauiParkplatz5-8")
        {
            PlayerPrefs.SetString("OwnerPP5to8", "Implementiert");
        }
        // BrauiParkplatz9-11
        else if (grundstueck == "BrauiParkplatz9-11")
        {
            PlayerPrefs.SetString("OwnerPP9to11", "Implementiert");
        }
        // Braui Parkplatz Seite 12
        else if (grundstueck == "BrauiParkplatz_Seite12")
        {
            PlayerPrefs.SetString("OwnerPP12", "Implementiert");
        }
        // Braui Parkplatz Seite 13
        else if (grundstueck == "BrauiParkplatz_Seite13")
        {
            PlayerPrefs.SetString("OwnerPP13", "Implementiert");
        }
        // Braui Parkplatz Seite 14
        else if (grundstueck == "BrauiParkplatz_Seite14")
        {
            PlayerPrefs.SetString("OwnerPP14", "Implementiert");
        }
        // Braui Parkplatz Seite 15
        else if (grundstueck == "BrauiParkplatz_Seite15")
        {
            PlayerPrefs.SetString("OwnerPP15", "Implementiert");
        }
        // Reihenhaus 1
        else if (grundstueck == "Reihenhaus1")
        {
            PlayerPrefs.SetString("OwnerReihenhaus1", "Implementiert");
        }
        // Reihenhaus 2
        else if (grundstueck == "Reihenhaus2")
        {
            PlayerPrefs.SetString("OwnerReihenhaus2", "Implementiert");
        }
        // Reihenhaus 3
        else if (grundstueck == "Reihenhaus3")
        {
            PlayerPrefs.SetString("OwnerReihenhaus3", "Implementiert");
        }
        // Reihenhaus 4
        else if (grundstueck == "Reihenhaus4")
        {
            PlayerPrefs.SetString("OwnerReihenhaus4", "Implementiert");
        }
        // Reihenhaus 5
        else if (grundstueck == "Reihenhaus5")
        {
            PlayerPrefs.SetString("OwnerReihenhaus5", "Implementiert");
        }
        // Reihenhaus 6
        else if (grundstueck == "Reihenhaus6")
        {
            PlayerPrefs.SetString("OwnerReihenhaus6", "Implementiert");
        }
        // Reihenhaus 7
        else if (grundstueck == "Reihenhaus7")
        {
            PlayerPrefs.SetString("OwnerReihenhaus7", "Implementiert");
        }
        // Reihenhaus 8
        else if (grundstueck == "Reihenhaus8")
        {
            PlayerPrefs.SetString("OwnerReihenhaus8", "Implementiert");
        }
        // Reihenhaus 9
        else if (grundstueck == "Reihenhaus9")
        {
            PlayerPrefs.SetString("OwnerReihenhaus9", "Implementiert");
        }
        // Reihenhaus 10
        else if (grundstueck == "Reihenhaus10")
        {
            PlayerPrefs.SetString("OwnerReihenhaus10", "Implementiert");
        }
        // Restaurant Braui
        else if (grundstueck == "RestaurantBraui")
        {
            PlayerPrefs.SetString("OwnerRestaurant", "Implementiert");
        }

    }
}
