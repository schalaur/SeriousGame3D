using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

using System.Linq;
using System.Text;
using System.IO;


public class IncomeCalculator : NetworkBehaviour
{

    // Actor 1 - Count

    int A1CountShop;
    public Text TextA1CountShop;
    int A1CountParkingLot;
    int A1CountTiefgarageParkingLot;
    int A1ParkingTotal;
    public Text TextA1CountParkingLot;
    int A1CountAppartment;
    public Text TextA1CountAppartment;
    int A1CountAppartmentParkingLot;
    public Text TextA1CountAppartmentParkingLot;
    int A1CountAppartmentGarden;
    public Text TextA1CountAppartmentGarden;

    // Actor 1 - Money 

    int A1MoneyShop;
    public Text TextA1MoneyShop;
    int A1MoneyParkingLot;
    public Text TextA1MoneyParkingLot;
    int A1MoneyAppartment;
    public Text TextA1MoneyAppartment;
    int A1MoneyAppartmentParkingLot;
    public Text TextA1MoneyAppartmentParkingLot;
    int A1MoneyAppartmentGarden;
    public Text TextA1MoneyAppartmentGarden;

    // Actor 2 - Count

    int A2CountShop;
    public Text TextA2CountShop;
    int A2CountParkingLot;
    int A2CountTiefgarageParkingLot;
    int A2ParkingTotal;
    public Text TextA2CountParkingLot;
    int A2CountAppartment;
    public Text TextA2CountAppartment;
    int A2CountAppartmentParkingLot;
    public Text TextA2CountAppartmentParkingLot;
    int A2CountAppartmentGarden;
    public Text TextA2CountAppartmentGarden;

    // Actor 2 - Money 

    int A2MoneyShop;
    public Text TextA2MoneyShop;
    int A2MoneyParkingLot;
    public Text TextA2MoneyParkingLot;
    int A2MoneyAppartment;
    public Text TextA2MoneyAppartment;
    int A2MoneyAppartmentParkingLot;
    public Text TextA2MoneyAppartmentParkingLot;
    int A2MoneyAppartmentGarden;
    public Text TextA2MoneyAppartmentGarden;


    // Actor3 - Count
    int A3CountShop;
    public Text TextA3CountShop;
    int A3CountParkingLot;
    int A3CountTiefgarageParkingLot;
    int A3ParkingTotal;
    public Text TextA3CountParkingLot;
    int A3CountAppartment;
    public Text TextA3CountAppartment;
    int A3CountAppartmentParkingLot;
    public Text TextA3CountAppartmentParkingLot;
    int A3CountAppartmentGarden;
    public Text TextA3CountAppartmentGarden;

    // Actor 3 - Money 

    int A3MoneyShop;
    public Text TextA3MoneyShop;
    int A3MoneyParkingLot;
    public Text TextA3MoneyParkingLot;
    int A3MoneyAppartment;
    public Text TextA3MoneyAppartment;
    int A3MoneyAppartmentParkingLot;
    public Text TextA3MoneyAppartmentParkingLot;
    int A3MoneyAppartmentGarden;
    public Text TextA3MoneyAppartmentGarden;

    // Actor 4 - Count

    int A4CountShop;
    public Text TextA4CountShop;
    int A4CountParkingLot;
    int A4CountTiefgarageParkingLot;
    int A4ParkingTotal;
    public Text TextA4CountParkingLot;
    int A4CountAppartment;
    public Text TextA4CountAppartment;
    int A4CountAppartmentParkingLot;
    public Text TextA4CountAppartmentParkingLot;
    int A4CountAppartmentGarden;
    public Text TextA4CountAppartmentGarden;

    // Actor 4 - Money 

    int A4MoneyShop;
    public Text TextA4MoneyShop;
    int A4MoneyParkingLot;
    public Text TextA4MoneyParkingLot;
    int A4MoneyAppartment;
    public Text TextA4MoneyAppartment;
    int A4MoneyAppartmentParkingLot;
    public Text TextA4MoneyAppartmentParkingLot;
    int A4MoneyAppartmentGarden;
    public Text TextA4MoneyAppartmentGarden;

    // Total

    int A1Total;
    public Text TextA1Total;
    int A2Total;
    public Text TextA2Total;
    int A3Total;
    public Text TextA3Total;
    int A4Total;
    public Text TextA4Total;

    // Assets

    int AssetP1;
    int AssetP2;
    int AssetP3;
    int AssetP4;

    //Button
    public Button ButtonStartP1;
    public Button ButtonStartP2;
    public Button ButtonStartP3;
    public Button ButtonStartP4;


    int A1MomAsset;
    int A2MomAsset;
    int A3MomAsset;
    int A4MomAsset;

    int SyncShopIncome;
    int count;

    bool A1 = false;
    bool A2 = false;
    bool A3 = false;
    bool A4 = false;

    public GameObject buttonserver;

    public Text GemeindeVOR;
    public Text GemeindeLOHN;
    public Text GemeindeNACH;

    public Text LandbesitzerVOR;
    public Text LandbesitzerLOHN;
    public Text LandbesitzerNACH;

    public Text KulturzentrumVOR;
    public Text KulturzentrumLOHN;
    public Text KulturzentrumNACH;

    public Text GenossenschaftVOR;
    public Text GenossenschaftLOHN;
    public Text GenossenschaftNACH;


    void Start()
    {
        if (!isServer)
        {
            string PlayerName = NetworkClient.localPlayer.gameObject.name.ToString();
            CmdCallServer(PlayerName);
        }

        if (isServer)
        {
            buttonserver.SetActive(true);
        }
    }

    void Update()
    {

    }

    [Command(requiresAuthority = false)]
    void CmdCallServer(string PlayerName)
    {
        SyncShopIncome = PlayerPrefs.GetInt("SyncShopIncome");

        // Actor 1 
        A1MomAsset = PlayerPrefs.GetInt("A1MomAsset");

        A1CountShop = PlayerPrefs.GetInt("A1CountShop");
        A1CountParkingLot = PlayerPrefs.GetInt("A1CountParkingLot");
        A1CountTiefgarageParkingLot = PlayerPrefs.GetInt("A1CountTiefgarageParkingLot");
        A1CountAppartment = PlayerPrefs.GetInt("A1CountAppartment");
        A1CountAppartmentParkingLot = PlayerPrefs.GetInt("A1CountAppartmentParkingLot");
        A1CountAppartmentGarden = PlayerPrefs.GetInt("A1CountAppartmentGarden");

        A1MoneyShop = SyncShopIncome * A1CountShop;
        A1MoneyParkingLot = 1 * A1CountParkingLot + 1 * A1CountTiefgarageParkingLot;
        A1MoneyAppartment = 2 * A1CountAppartment;
        A1MoneyAppartmentParkingLot = 4 * A1CountAppartmentParkingLot;
        A1MoneyAppartmentGarden = 4 * A1CountAppartmentGarden;
        A1Total = A1MoneyShop + A1MoneyParkingLot + A1MoneyAppartment + A1MoneyAppartmentParkingLot + A1MoneyAppartmentGarden;

        GemeindeVOR.text = "VOR: " + A1MomAsset.ToString();
        GemeindeLOHN.text = "LOHN: " + A1Total.ToString();
        GemeindeNACH.text = "NACH: " + (A1MomAsset + A1Total).ToString();

        //Actor 2
        A2MomAsset = PlayerPrefs.GetInt("A2MomAsset");

        A2CountShop = PlayerPrefs.GetInt("A2CountShop");
        A2CountParkingLot = PlayerPrefs.GetInt("A2CountParkingLot");
        A2CountTiefgarageParkingLot = PlayerPrefs.GetInt("A2CountTiefgarageParkingLot");
        A2CountAppartment = PlayerPrefs.GetInt("A2CountAppartment");
        A2CountAppartmentParkingLot = PlayerPrefs.GetInt("A2CountAppartmentParkingLot");
        A2CountAppartmentGarden = PlayerPrefs.GetInt("A2CountAppartmentGarden");

        A2MoneyShop = SyncShopIncome * A2CountShop;
        A2MoneyParkingLot = 1 * A2CountParkingLot + 1 * A2CountTiefgarageParkingLot;
        A2MoneyAppartment = 2 * A2CountAppartment;
        A2MoneyAppartmentParkingLot = 4 * A2CountAppartmentParkingLot;
        A2MoneyAppartmentGarden = 4 * A2CountAppartmentGarden;
        A2Total = A2MoneyShop + A2MoneyParkingLot + A2MoneyAppartment + A2MoneyAppartmentParkingLot + A2MoneyAppartmentGarden;

        LandbesitzerVOR.text = "VOR: " + A2MomAsset.ToString();
        LandbesitzerLOHN.text = "LOHN: " + A2Total.ToString();
        LandbesitzerNACH.text = "NACH: " + (A2MomAsset + A2Total).ToString();

        // Actor 3 
        A3MomAsset = PlayerPrefs.GetInt("A3MomAsset");

        A3CountShop = PlayerPrefs.GetInt("A3CountShop");
        A3CountParkingLot = PlayerPrefs.GetInt("A3CountParkingLot");
        A3CountTiefgarageParkingLot = PlayerPrefs.GetInt("A3CountTiefgarageParkingLot");
        A3CountAppartment = PlayerPrefs.GetInt("A3CountAppartment");
        A3CountAppartmentParkingLot = PlayerPrefs.GetInt("A3CountAppartmentParkingLot");
        A3CountAppartmentGarden = PlayerPrefs.GetInt("A3CountAppartmentGarden");

        A3MoneyShop = SyncShopIncome * A3CountShop;
        A3MoneyParkingLot = 1 * A3CountParkingLot + 1 * A3CountTiefgarageParkingLot;
        A3MoneyAppartment = 2 * A3CountAppartment;
        A3MoneyAppartmentParkingLot = 4 * A3CountAppartmentParkingLot;
        A3MoneyAppartmentGarden = 4 * A3CountAppartmentGarden;
        A3Total = A3MoneyShop + A3MoneyParkingLot + A3MoneyAppartment + A3MoneyAppartmentParkingLot + A3MoneyAppartmentGarden;

        GenossenschaftVOR.text = "VOR: " + A3MomAsset.ToString();
        GenossenschaftLOHN.text = "LOHN: " + A3Total.ToString();
        GenossenschaftNACH.text = "NACH: " + (A3MomAsset + A3Total).ToString();

        //Actor 4
        A4MomAsset = PlayerPrefs.GetInt("A4MomAsset");

        A4CountShop = PlayerPrefs.GetInt("A4CountShop");
        A4CountParkingLot = PlayerPrefs.GetInt("A4CountParkingLot");
        A4CountTiefgarageParkingLot = PlayerPrefs.GetInt("A4CountTiefgarageParkingLot");
        A4CountAppartment = PlayerPrefs.GetInt("A4CountAppartment");
        A4CountAppartmentParkingLot = PlayerPrefs.GetInt("A4CountAppartmentParkingLot");
        A4CountAppartmentGarden = PlayerPrefs.GetInt("A4CountAppartmentGarden");

        A4MoneyShop = SyncShopIncome * A4CountShop;
        A4MoneyParkingLot = 1 * A4CountParkingLot + 1 * A4CountTiefgarageParkingLot;
        A4MoneyAppartment = 2 * A4CountAppartment;
        A4MoneyAppartmentParkingLot = 4 * A4CountAppartmentParkingLot;
        A4MoneyAppartmentGarden = 4 * A4CountAppartmentGarden;
        A4Total = A4MoneyShop + A4MoneyParkingLot + A4MoneyAppartment + A4MoneyAppartmentParkingLot + A4MoneyAppartmentGarden;

        KulturzentrumVOR.text = "VOR: " + A4MomAsset.ToString();
        KulturzentrumLOHN.text = "LOHN: " + A4Total.ToString();
        KulturzentrumNACH.text = "NACH: " + (A4MomAsset + A4Total).ToString();

        RpcCallClients(PlayerName, A1CountShop, A1CountParkingLot, A1CountTiefgarageParkingLot, A1CountAppartment, A1CountAppartmentParkingLot, A1CountAppartmentGarden, A1MoneyShop, A1MoneyParkingLot, A1MoneyAppartment, A1MoneyAppartmentParkingLot, A1MoneyAppartmentGarden, A1Total, A2CountShop, A2CountParkingLot, A2CountTiefgarageParkingLot, A2CountAppartment, A2CountAppartmentParkingLot, A2CountAppartmentGarden, A2MoneyShop, A2MoneyParkingLot, A2MoneyAppartment, A2MoneyAppartmentParkingLot, A2MoneyAppartmentGarden, A2Total, A3CountShop, A3CountParkingLot, A3CountTiefgarageParkingLot, A3CountAppartment, A3CountAppartmentParkingLot, A3CountAppartmentGarden, A3MoneyShop, A3MoneyParkingLot, A3MoneyAppartment, A3MoneyAppartmentParkingLot, A3MoneyAppartmentGarden, A3Total, A4CountShop, A4CountParkingLot, A4CountTiefgarageParkingLot, A4CountAppartment, A4CountAppartmentParkingLot, A4CountAppartmentGarden, A4MoneyShop, A4MoneyParkingLot, A4MoneyAppartment, A4MoneyAppartmentParkingLot, A4MoneyAppartmentGarden, A4Total);
    }

    [ClientRpc]
    void RpcCallClients(string PlayerName, int A1CountShop, int A1CountParkingLot, int A1CountTiefgarageParkingLot, int A1CountAppartment, int A1CountAppartmentParkingLot, int A1CountAppartmentGarden, int A1MoneyShop, int A1MoneyParkingLot, int A1MoneyAppartment, int A1MoneyAppartmentParkingLot, int A1MoneyAppartmentGarden, int A1Total, int A2CountShop, int A2CountParkingLot, int A2CountTiefgarageParkingLot, int A2CountAppartment, int A2CountAppartmentParkingLot, int A2CountAppartmentGarden, int A2MoneyShop, int A2MoneyParkingLot, int A2MoneyAppartment, int A2MoneyAppartmentParkingLot, int A2MoneyAppartmentGarden, int A2Total, int A3CountShop, int A3CountParkingLot, int A3CountTiefgarageParkingLot, int A3CountAppartment, int A3CountAppartmentParkingLot, int A3CountAppartmentGarden, int A3MoneyShop, int A3MoneyParkingLot, int A3MoneyAppartment, int A3MoneyAppartmentParkingLot, int A3MoneyAppartmentGarden, int A3Total, int A4CountShop, int A4CountParkingLot, int A4CountTiefgarageParkingLot, int A4CountAppartment, int A4CountAppartmentParkingLot, int A4CountAppartmentGarden, int A4MoneyShop, int A4MoneyParkingLot, int A4MoneyAppartment, int A4MoneyAppartmentParkingLot, int A4MoneyAppartmentGarden, int A4Total)
    {

        if (PlayerName == "Gemeinde")
        {
            TextA1CountShop.text = A1CountShop.ToString();
            A1ParkingTotal = A1CountParkingLot + A1CountTiefgarageParkingLot;
            TextA1CountParkingLot.text = A1ParkingTotal.ToString();
            TextA1CountAppartment.text = A1CountAppartment.ToString();
            TextA1CountAppartmentParkingLot.text = A1CountAppartmentParkingLot.ToString();
            TextA1CountAppartmentGarden.text = A1CountAppartmentGarden.ToString();
            TextA1MoneyShop.text = A1MoneyShop.ToString() + " CHF";

            A1MoneyParkingLot = 1 * A1CountParkingLot + 1 * A1CountTiefgarageParkingLot;
            TextA1MoneyParkingLot.text = A1MoneyParkingLot.ToString() + " CHF";
            TextA1MoneyAppartment.text = A1MoneyAppartment.ToString() + " CHF";
            TextA1MoneyAppartmentParkingLot.text = A1MoneyAppartmentParkingLot.ToString() + " CHF";
            TextA1MoneyAppartmentGarden.text = A1MoneyAppartmentGarden.ToString() + " CHF";

            A1Total = A1MoneyShop + A1MoneyParkingLot + A1MoneyAppartment + A1MoneyAppartmentParkingLot + A1MoneyAppartmentGarden;
            TextA1Total.text = A1Total.ToString() + " CHF";
        }

        else if (PlayerName == "Landbesitzer")
        {
            TextA2CountShop.text = A2CountShop.ToString();
            A2ParkingTotal = A2CountParkingLot + A2CountTiefgarageParkingLot;
            TextA2CountParkingLot.text = A2ParkingTotal.ToString();
            TextA2CountAppartment.text = A2CountAppartment.ToString();
            TextA2CountAppartmentParkingLot.text = A2CountAppartmentParkingLot.ToString();
            TextA2CountAppartmentGarden.text = A2CountAppartmentGarden.ToString();
            TextA2MoneyShop.text = A2MoneyShop.ToString() + " CHF";

            A2MoneyParkingLot = 1 * A2CountParkingLot + 1 * A2CountTiefgarageParkingLot;
            TextA2MoneyParkingLot.text = A2MoneyParkingLot.ToString() + " CHF";
            TextA2MoneyAppartment.text = A2MoneyAppartment.ToString() + " CHF";
            TextA2MoneyAppartmentParkingLot.text = A2MoneyAppartmentParkingLot.ToString() + " CHF";
            TextA2MoneyAppartmentGarden.text = A2MoneyAppartmentGarden.ToString() + " CHF";

            A2Total = A2MoneyShop + A2MoneyParkingLot + A2MoneyAppartment + A2MoneyAppartmentParkingLot + A2MoneyAppartmentGarden;
            TextA2Total.text = A2Total.ToString() + " CHF";
        }

        else if (PlayerName == "Genossenschaft")
        {
            TextA3CountShop.text = A3CountShop.ToString();
            A3ParkingTotal = A3CountParkingLot + A3CountTiefgarageParkingLot;
            TextA3CountParkingLot.text = A3ParkingTotal.ToString();
            TextA3CountAppartment.text = A3CountAppartment.ToString();
            TextA3CountAppartmentParkingLot.text = A3CountAppartmentParkingLot.ToString();
            TextA3CountAppartmentGarden.text = A3CountAppartmentGarden.ToString();
            TextA3MoneyShop.text = A3MoneyShop.ToString() + " CHF";

            A3MoneyParkingLot = 1 * A3CountParkingLot + 1 * A3CountTiefgarageParkingLot;
            TextA3MoneyParkingLot.text = A3MoneyParkingLot.ToString() + " CHF";
            TextA3MoneyAppartment.text = A3MoneyAppartment.ToString() + " CHF";
            TextA3MoneyAppartmentParkingLot.text = A3MoneyAppartmentParkingLot.ToString() + " CHF";
            TextA3MoneyAppartmentGarden.text = A3MoneyAppartmentGarden.ToString() + " CHF";

            A3Total = A3MoneyShop + A3MoneyParkingLot + A3MoneyAppartment + A3MoneyAppartmentParkingLot + A3MoneyAppartmentGarden;
            TextA3Total.text = A3Total.ToString() + " CHF";
        }

        else if (PlayerName == "Kulturzentrum")
        {
            TextA4CountShop.text = A4CountShop.ToString();
            A4ParkingTotal = A4CountParkingLot + A4CountTiefgarageParkingLot;
            TextA4CountParkingLot.text = A4ParkingTotal.ToString();
            TextA4CountAppartment.text = A4CountAppartment.ToString();
            TextA4CountAppartmentParkingLot.text = A4CountAppartmentParkingLot.ToString();
            TextA4CountAppartmentGarden.text = A4CountAppartmentGarden.ToString();
            TextA4MoneyShop.text = A4MoneyShop.ToString() + " CHF";

            A4MoneyParkingLot = 1 * A4CountParkingLot + 1 * A4CountTiefgarageParkingLot;
            TextA4MoneyParkingLot.text = A4MoneyParkingLot.ToString() + " CHF";
            TextA4MoneyAppartment.text = A4MoneyAppartment.ToString() + " CHF";
            TextA4MoneyAppartmentParkingLot.text = A4MoneyAppartmentParkingLot.ToString() + " CHF";
            TextA4MoneyAppartmentGarden.text = A4MoneyAppartmentGarden.ToString() + " CHF";

            A4Total = A4MoneyShop + A4MoneyParkingLot + A4MoneyAppartment + A4MoneyAppartmentParkingLot + A4MoneyAppartmentGarden;
            TextA4Total.text = A4Total.ToString() + " CHF";
        }
    }

    public void CalculateIncome()
    {
        if (!isServer)
        {
            string PlayerName = NetworkClient.localPlayer.gameObject.name.ToString();

            if (PlayerName == "Gemeinde")
            {
                CmdCalculateIncomeActor1();
                ButtonStartP1.gameObject.SetActive(false);
            }

            else if (PlayerName == "Landbesitzer")
            {
                CmdCalculateIncomeActor2();
                ButtonStartP2.gameObject.SetActive(false);
            }
            else if (PlayerName == "Genossenschaft")
            {
                CmdCalculateIncomeActor3();
                ButtonStartP3.gameObject.SetActive(false);
            }

            else if (PlayerName == "Kulturzentrum")
            {
                CmdCalculateIncomeActor4();
                ButtonStartP4.gameObject.SetActive(false);
            }
        }

        if (isServer)
        {
            if (!A1)
            {
                AssetP1 = A1MomAsset + A1Total;
                PlayerPrefs.SetInt("A1MomAsset", AssetP1);
            }
            if (!A2)
            {
                AssetP1 = A2MomAsset + A2Total;
                PlayerPrefs.SetInt("A2MomAsset", AssetP1);
            }
            if (!A3)
            {
                AssetP1 = A3MomAsset + A3Total;
                PlayerPrefs.SetInt("A3MomAsset", AssetP1);
            }
            if (!A4)
            {
                AssetP1 = A4MomAsset + A4Total;
                PlayerPrefs.SetInt("A4MomAsset", AssetP1);
            }
        }
    }

    [Command(requiresAuthority = false)]
    void CmdCalculateIncomeActor1()
    {
        A1 = true;
        AssetP1 = A1MomAsset + A1Total;
        PlayerPrefs.SetInt("A1MomAsset", AssetP1);
    }

    [Command(requiresAuthority = false)]
    void CmdCalculateIncomeActor2()
    {
        A2 = true;
        AssetP2 = A2MomAsset + A2Total;
        PlayerPrefs.SetInt("A2MomAsset", AssetP2);
    }

    [Command(requiresAuthority = false)]
    void CmdCalculateIncomeActor3()
    {
        A3 = true;
        AssetP3 = A3MomAsset + A3Total;
        PlayerPrefs.SetInt("A3MomAsset", AssetP3);
    }

    [Command(requiresAuthority = false)]
    void CmdCalculateIncomeActor4()
    {
        A4 = true;
        AssetP4 = A4MomAsset + A4Total;
        PlayerPrefs.SetInt("A4MomAsset", AssetP4);
    }
}


