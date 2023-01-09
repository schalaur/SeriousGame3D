using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

using System.Linq;
using System.Text;
using System.IO;

public class S04Update : NetworkBehaviour
{
    // Scene  
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

    // Actors 
    public GameObject panelActor1;
    public GameObject panelActor2;
    public GameObject panelActor3;
    public GameObject panelActor4;
    public GameObject panelOverviewActors;

    // Actor 1 - Count
    public Text TextA1CountShop;
    public Text TextA1CountParkingLot;
    public Text TextA1CountAppartment;
    public Text TextA1CountAppartmentParkingLot;
    public Text TextA1CountAppartmentGarden;

    // Actor 1 - Money 
    public Text TextA1MoneyShop;
    public Text TextA1MoneyParkingLot;
    public Text TextA1MoneyAppartment;
    public Text TextA1MoneyAppartmentParkingLot;
    public Text TextA1MoneyAppartmentGarden;

    // Actor 1 - Total
    public Text TextA1Total;

    // Actor 2 - Count
    public Text TextA2CountShop;
    public Text TextA2CountParkingLot;
    public Text TextA2CountAppartment;
    public Text TextA2CountAppartmentParkingLot;
    public Text TextA2CountAppartmentGarden;

    // Actor 2 - Money 
    public Text TextA2MoneyShop;
    public Text TextA2MoneyParkingLot;
    public Text TextA2MoneyAppartment;
    public Text TextA2MoneyAppartmentParkingLot;
    public Text TextA2MoneyAppartmentGarden;

    // Actor 2 - Total
    public Text TextA2Total;

    // Actor 3 - Count
    public Text TextA3CountShop;
    public Text TextA3CountParkingLot;
    public Text TextA3CountAppartment;
    public Text TextA3CountAppartmentParkingLot;
    public Text TextA3CountAppartmentGarden;

    // Actor 3 - Money 
    public Text TextA3MoneyShop;
    public Text TextA3MoneyParkingLot;
    public Text TextA3MoneyAppartment;
    public Text TextA3MoneyAppartmentParkingLot;
    public Text TextA3MoneyAppartmentGarden;

    // Actor 3 - Total
    public Text TextA3Total;

    // Actor 4 - Count
    public Text TextA4CountShop;
    public Text TextA4CountParkingLot;
    public Text TextA4CountAppartment;
    public Text TextA4CountAppartmentParkingLot;
    public Text TextA4CountAppartmentGarden;

    // Actor 4 - Money 
    public Text TextA4MoneyShop;
    public Text TextA4MoneyParkingLot;
    public Text TextA4MoneyAppartment;
    public Text TextA4MoneyAppartmentParkingLot;
    public Text TextA4MoneyAppartmentGarden;

    // Actor 4 - Total
    public Text TextA4Total;

    //Buttons Projects
    public Button ButtonBuvette;
    public Button ButtonCreatingShadow;
    public Button ButtonFacadePainting;
    public Button ButtonStreetFurniture;
    public Button ButtonUniformFloorCovering;
    public Button ButtonPublicPark;
    public Button ButtonJugendtreff;
    public Button ButtonTiefgarage;
    public Button ButtonPolizei;
    public Button ButtonArealentwicklung;
    public Button ButtonZentrum;
    public Button ButtonPedestrian;
    public Button ButtonBrauiStairs;

    int Appeal;
    int AppealLevel;
    int Approval;
    int ApprovalLevel;

    [SyncVar]
    int Buvette;
    [SyncVar]
    int CreatingShadow;
    [SyncVar]
    int FacadePainting;
    [SyncVar]
    int StreetFurniture;
    [SyncVar]
    int UniformFloorCovering;
    [SyncVar]
    int PublicPark;
    [SyncVar]
    int Jugendtreff;
    [SyncVar]
    int Tiefgarage;
    [SyncVar]
    int Polizei;
    [SyncVar]
    int Schatten;
    [SyncVar]
    int Arealentwicklung;
    [SyncVar]
    int Zentrum;
    [SyncVar]
    int Pedestrian;
    [SyncVar]
    int BrauiStairs;
    [SyncVar]
    int AnzahlMoebel;

    // Start is called before the first frame update
    // defines all Start-Values saved in PlayerPrefs
    void Start()
    {
        // UpdateActor1();
        //UpdateActor2();
        //UpdateActor3();
        //UpdateActor4();
        PressedZero();
        UpdateButtons();

        if (isServer)
        {
            Buvette = PlayerPrefs.GetInt("Buvette");
            CreatingShadow = PlayerPrefs.GetInt("CreatingShadow");
            FacadePainting = PlayerPrefs.GetInt("FacadePainting");
            StreetFurniture = PlayerPrefs.GetInt("StreetFurniture");
            UniformFloorCovering = PlayerPrefs.GetInt("UniformFloorCovering");
            PublicPark = PlayerPrefs.GetInt("PublicPark");
            Jugendtreff = PlayerPrefs.GetInt("Jugendtreff");
            Tiefgarage = PlayerPrefs.GetInt("Tiefgarage");
            Polizei = PlayerPrefs.GetInt("Polizei");
            Schatten = PlayerPrefs.GetInt("Schatten");
            Arealentwicklung = PlayerPrefs.GetInt("Arealentwicklung");
            Zentrum = PlayerPrefs.GetInt("Zentrum");
            Pedestrian = PlayerPrefs.GetInt("Pedestrian");
            BrauiStairs = PlayerPrefs.GetInt("BrauiStairs");

            AnzahlMoebel = PlayerPrefs.GetInt("AnzahlMoebel");

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

        //UpdateActor1();
        //UpdateActor2();
        //UpdateActor3();
        //UpdateActor4();
    }

    void PressedZero()
    {
        PlayerPrefs.SetInt("MunPressed", 0);
        PlayerPrefs.SetInt("LandPressed", 0);
        PlayerPrefs.SetInt("CoPressed", 0);
        PlayerPrefs.SetInt("CultPressed", 0);
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

    public void UpdateActor()
    {
        string PlayerName = NetworkClient.localPlayer.gameObject.name.ToString();

        if (PlayerName == "Gemeinde")
        {
            CmdCallServerUpdateActors("Gemeinde");
        }
        else if (PlayerName == "Kulturzentrum")
        {
            CmdCallServerUpdateActors("Kulturzentrum");
        }
        else if (PlayerName == "Landbesitzer")
        {
            CmdCallServerUpdateActors("Landbesitzer");
        }
        else if (PlayerName == "Genossenschaft")
        {
            CmdCallServerUpdateActors("Genossenschaft");
        }
    }

    [Command(requiresAuthority = false)]
    void CmdCallServerUpdateActors(string PlayerName)
    {
        int SyncShopIncome = PlayerPrefs.GetInt("SyncShopIncome");

        if (PlayerName == "Gemeinde")
        {
            int tempA1CountShop = PlayerPrefs.GetInt("A1CountShop");
            int tempA1CountParkingLot = PlayerPrefs.GetInt("A1CountParkingLot");
            int tempA1CountTiefgarageParkingLot = PlayerPrefs.GetInt("A1CountTiefgarageParkingLot");
            int tempA1CountAppartment = PlayerPrefs.GetInt("A1CountAppartment");
            int tempA1CountAppartmentParkingLot = PlayerPrefs.GetInt("A1CountAppartmentParkingLot");
            int tempA1CountAppartmentGarden = PlayerPrefs.GetInt("A1CountAppartmentGarden");

            int tempA1MoneyShop = SyncShopIncome * tempA1CountShop;
            int tempA1MoneyParkingLot = 1 * tempA1CountParkingLot + 1 * tempA1CountTiefgarageParkingLot;
            int tempA1MoneyAppartment = 2 * tempA1CountAppartment;
            int tempA1MoneyAppartmentParkingLot = 4 * tempA1CountAppartment;
            int tempA1MoneyAppartmentGarden = 4 * tempA1CountAppartmentParkingLot;
            int tempA1Total = tempA1MoneyShop + tempA1MoneyParkingLot + tempA1MoneyAppartment + tempA1MoneyAppartmentParkingLot + tempA1MoneyAppartmentGarden;

            RpcCallClientsUpdateActors(PlayerName, tempA1CountShop, tempA1CountParkingLot, tempA1CountTiefgarageParkingLot, tempA1CountAppartment, tempA1CountAppartmentParkingLot, tempA1CountAppartmentGarden, tempA1MoneyShop, tempA1MoneyParkingLot, tempA1MoneyAppartment, tempA1MoneyAppartmentParkingLot, tempA1MoneyAppartmentGarden, tempA1Total);
        }

        if (PlayerName == "Landbesitzer")
        {
            int tempA2CountShop = PlayerPrefs.GetInt("A2CountShop");
            int tempA2CountParkingLot = PlayerPrefs.GetInt("A2CountParkingLot");
            int tempA2CountTiefgarageParkingLot = PlayerPrefs.GetInt("A2CountTiefgarageParkingLot");
            int tempA2CountAppartment = PlayerPrefs.GetInt("A2CountAppartment");
            int tempA2CountAppartmentParkingLot = PlayerPrefs.GetInt("A2CountAppartmentParkingLot");
            int tempA2CountAppartmentGarden = PlayerPrefs.GetInt("A2CountAppartmentGarden");

            int tempA2MoneyShop = SyncShopIncome * tempA2CountShop;
            int tempA2MoneyParkingLot = 1 * tempA2CountParkingLot + 1 * tempA2CountTiefgarageParkingLot;
            int tempA2MoneyAppartment = 2 * tempA2CountAppartment;
            int tempA2MoneyAppartmentParkingLot = 4 * tempA2CountAppartment;
            int tempA2MoneyAppartmentGarden = 4 * tempA2CountAppartmentParkingLot;
            int tempA2Total = tempA2MoneyShop + tempA2MoneyParkingLot + tempA2MoneyAppartment + tempA2MoneyAppartmentParkingLot + tempA2MoneyAppartmentGarden;

            RpcCallClientsUpdateActors(PlayerName, tempA2CountShop, tempA2CountParkingLot, tempA2CountTiefgarageParkingLot, tempA2CountAppartment, tempA2CountAppartmentParkingLot, tempA2CountAppartmentGarden, tempA2MoneyShop, tempA2MoneyParkingLot, tempA2MoneyAppartment, tempA2MoneyAppartmentParkingLot, tempA2MoneyAppartmentGarden, tempA2Total);
        }

        if (PlayerName == "Genossenschaft")
        {
            int tempA3CountShop = PlayerPrefs.GetInt("A3CountShop");
            int tempA3CountParkingLot = PlayerPrefs.GetInt("A3CountParkingLot");
            int tempA3CountTiefgarageParkingLot = PlayerPrefs.GetInt("A3CountTiefgarageParkingLot");
            int tempA3CountAppartment = PlayerPrefs.GetInt("A3CountAppartment");
            int tempA3CountAppartmentParkingLot = PlayerPrefs.GetInt("A3CountAppartmentParkingLot");
            int tempA3CountAppartmentGarden = PlayerPrefs.GetInt("A3CountAppartmentGarden");

            int tempA3MoneyShop = SyncShopIncome * tempA3CountShop;
            int tempA3MoneyParkingLot = 1 * tempA3CountParkingLot + 1 * tempA3CountTiefgarageParkingLot;
            int tempA3MoneyAppartment = 2 * tempA3CountAppartment;
            int tempA3MoneyAppartmentParkingLot = 4 * tempA3CountAppartment;
            int tempA3MoneyAppartmentGarden = 4 * tempA3CountAppartmentParkingLot;
            int tempA3Total = tempA3MoneyShop + tempA3MoneyParkingLot + tempA3MoneyAppartment + tempA3MoneyAppartmentParkingLot + tempA3MoneyAppartmentGarden;

            RpcCallClientsUpdateActors(PlayerName, tempA3CountShop, tempA3CountParkingLot, tempA3CountTiefgarageParkingLot, tempA3CountAppartment, tempA3CountAppartmentParkingLot, tempA3CountAppartmentGarden, tempA3MoneyShop, tempA3MoneyParkingLot, tempA3MoneyAppartment, tempA3MoneyAppartmentParkingLot, tempA3MoneyAppartmentGarden, tempA3Total);
        }

        if (PlayerName == "Kulturzentrum")
        {
            int tempA4CountShop = PlayerPrefs.GetInt("A4CountShop");
            int tempA4CountParkingLot = PlayerPrefs.GetInt("A4CountParkingLot");
            int tempA4CountTiefgarageParkingLot = PlayerPrefs.GetInt("A4CountTiefgarageParkingLot");
            int tempA4CountAppartment = PlayerPrefs.GetInt("A4CountAppartment");
            int tempA4CountAppartmentParkingLot = PlayerPrefs.GetInt("A4CountAppartmentParkingLot");
            int tempA4CountAppartmentGarden = PlayerPrefs.GetInt("A4CountAppartmentGarden");

            int tempA4MoneyShop = SyncShopIncome * tempA4CountShop;
            int tempA4MoneyParkingLot = 1 * tempA4CountParkingLot + 1 * tempA4CountTiefgarageParkingLot;
            int tempA4MoneyAppartment = 2 * tempA4CountAppartment;
            int tempA4MoneyAppartmentParkingLot = 4 * tempA4CountAppartment;
            int tempA4MoneyAppartmentGarden = 4 * tempA4CountAppartmentParkingLot;
            int tempA4Total = tempA4MoneyShop + tempA4MoneyParkingLot + tempA4MoneyAppartment + tempA4MoneyAppartmentParkingLot + tempA4MoneyAppartmentGarden;

            RpcCallClientsUpdateActors(PlayerName, tempA4CountShop, tempA4CountParkingLot, tempA4CountTiefgarageParkingLot, tempA4CountAppartment, tempA4CountAppartmentParkingLot, tempA4CountAppartmentGarden, tempA4MoneyShop, tempA4MoneyParkingLot, tempA4MoneyAppartment, tempA4MoneyAppartmentParkingLot, tempA4MoneyAppartmentGarden, tempA4Total);
        }
    }

    [ClientRpc]
    void RpcCallClientsUpdateActors(string PlayerName, int CountShop, int CountParkingLot, int CountTiefgarageParkingLot, int CountAppartment, int CountAppartmentParkingLot, int CountAppartmentGarden, int MoneyShop, int MoneyParkingLot, int MoneyAppartment, int MoneyAppartmentParkingLot, int MoneyAppartmentGarden, int Total)
    {

        if (PlayerName == "Gemeinde")
        {
            TextA1CountShop.text = CountShop.ToString();
            TextA1CountParkingLot.text = (CountParkingLot + CountTiefgarageParkingLot).ToString();
            TextA1CountAppartment.text = CountAppartment.ToString();
            TextA1CountAppartmentParkingLot.text = CountAppartmentParkingLot.ToString();
            TextA1CountAppartmentGarden.text = CountAppartmentGarden.ToString();

            TextA1MoneyShop.text = MoneyShop.ToString() + " CHF";
            TextA1MoneyParkingLot.text = MoneyParkingLot.ToString() + " CHF";
            TextA1MoneyAppartment.text = MoneyAppartment.ToString() + " CHF";
            TextA1MoneyAppartmentParkingLot.text = MoneyAppartmentParkingLot.ToString() + " CHF";
            TextA1MoneyAppartmentGarden.text = MoneyAppartmentGarden.ToString() + " CHF";

            TextA1Total.text = Total.ToString() + " CHF";
        }

        else if (PlayerName == "Landbesitzer")
        {
            TextA2CountShop.text = CountShop.ToString();
            TextA2CountParkingLot.text = (CountParkingLot + CountTiefgarageParkingLot).ToString();
            TextA2CountAppartment.text = CountAppartment.ToString();
            TextA2CountAppartmentParkingLot.text = CountAppartmentParkingLot.ToString();
            TextA2CountAppartmentGarden.text = CountAppartmentGarden.ToString();

            TextA2MoneyShop.text = MoneyShop.ToString() + " CHF";
            TextA2MoneyParkingLot.text = MoneyParkingLot.ToString() + " CHF";
            TextA2MoneyAppartment.text = MoneyAppartment.ToString() + " CHF";
            TextA2MoneyAppartmentParkingLot.text = MoneyAppartmentParkingLot.ToString() + " CHF";
            TextA2MoneyAppartmentGarden.text = MoneyAppartmentGarden.ToString() + " CHF";

            TextA2Total.text = Total.ToString() + " CHF";
        }

        else if (PlayerName == "Genossenschaft")
        {
            TextA3CountShop.text = CountShop.ToString();
            TextA3CountParkingLot.text = (CountParkingLot + CountTiefgarageParkingLot).ToString();
            TextA3CountAppartment.text = CountAppartment.ToString();
            TextA3CountAppartmentParkingLot.text = CountAppartmentParkingLot.ToString();
            TextA3CountAppartmentGarden.text = CountAppartmentGarden.ToString();

            TextA3MoneyShop.text = MoneyShop.ToString() + " CHF";
            TextA3MoneyParkingLot.text = MoneyParkingLot.ToString() + " CHF";
            TextA3MoneyAppartment.text = MoneyAppartment.ToString() + " CHF";
            TextA3MoneyAppartmentParkingLot.text = MoneyAppartmentParkingLot.ToString() + " CHF";
            TextA3MoneyAppartmentGarden.text = MoneyAppartmentGarden.ToString() + " CHF";

            TextA3Total.text = Total.ToString() + " CHF";

        }

        else if (PlayerName == "Kulturzentrum")
        {
            TextA4CountShop.text = CountShop.ToString();
            TextA4CountParkingLot.text = (CountParkingLot + CountTiefgarageParkingLot).ToString();
            TextA4CountAppartment.text = CountAppartment.ToString();
            TextA4CountAppartmentParkingLot.text = CountAppartmentParkingLot.ToString();
            TextA4CountAppartmentGarden.text = CountAppartmentGarden.ToString();

            TextA4MoneyShop.text = MoneyShop.ToString() + " CHF";
            TextA4MoneyParkingLot.text = MoneyParkingLot.ToString() + " CHF";
            TextA4MoneyAppartment.text = MoneyAppartment.ToString() + " CHF";
            TextA4MoneyAppartmentParkingLot.text = MoneyAppartmentParkingLot.ToString() + " CHF";
            TextA4MoneyAppartmentGarden.text = MoneyAppartmentGarden.ToString() + " CHF";

            TextA4Total.text = Total.ToString() + " CHF";
        }
    }



    void UpdateButtons()
    {
        if (Buvette == 1)
        {
            ButtonBuvette.gameObject.SetActive(false);
        }
        if (CreatingShadow == 1)
        {
            ButtonCreatingShadow.gameObject.SetActive(false);
        }
        if (FacadePainting == 1)
        {
            ButtonFacadePainting.gameObject.SetActive(false);
        }
        if (StreetFurniture == 1)
        {
            // dreimal platzieren lassen (0,1,2)
            if (AnzahlMoebel > 2)
            {
                ButtonStreetFurniture.gameObject.SetActive(false);
            }
        }
        if (UniformFloorCovering == 1)
        {
            ButtonUniformFloorCovering.gameObject.SetActive(false);
        }
        if (PublicPark == 1)
        {
            ButtonPublicPark.gameObject.SetActive(false);
        }
        if (Jugendtreff == 1)
        {
            ButtonJugendtreff.gameObject.SetActive(false);
        }
        if (Tiefgarage == 1)
        {
            ButtonTiefgarage.gameObject.SetActive(false);
        }
        if (Polizei == 1)
        {
            ButtonPolizei.gameObject.SetActive(false);
        }
        if (Arealentwicklung == 1)
        {
            ButtonArealentwicklung.gameObject.SetActive(false);
        }
        if (Zentrum == 1)
        {
            ButtonZentrum.gameObject.SetActive(false);
        }
        if (Pedestrian == 1)
        {
            ButtonPedestrian.gameObject.SetActive(false);
        }
        if (BrauiStairs == 1)
        {
            ButtonBrauiStairs.gameObject.SetActive(false);
        }

    }

}


