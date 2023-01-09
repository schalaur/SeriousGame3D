using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class ownership : NetworkBehaviour
{
    public GameObject PanelInformation;
    public Text TextInformation;

    public Material MaterialHover;
    public Material MaterialP1;
    public Material MaterialP2;
    public Material MaterialP3;
    public Material MaterialP4;
    public Material MaterialNonPlayer;
    public Material MaterialNone;
    public Material MaterialImplementiert;

    string parent;
    string OwnerParcel;

    [SyncVar]
    string AktuelleAktion;
    [SyncVar]
    string ProjectOrAction;

    void Start()
    {
        if (isServer)
        {
            AktuelleAktion = PlayerPrefs.GetString("AktuelleAktion");
            ProjectOrAction = PlayerPrefs.GetString("ProjectOrAction");
        }
    }

    void OnMouseEnter()
    {
        if (!(ProjectOrAction == "Action" && AktuelleAktion == "BuyNonPlayerBuilding"))
        {
            if (!(ProjectOrAction == "Action" && AktuelleAktion == "NonPlayerGarden"))
            {
                if (PanelInformation.activeInHierarchy == true)
                {
                    string PlayerName = NetworkClient.localPlayer.gameObject.name.ToString();

                    parent = gameObject.transform.parent.name;

                    CmdOnEntry(parent, PlayerName);
                }
            }
        }
    }

    void OnMouseExit()
    {
        if (!(ProjectOrAction == "Action" && AktuelleAktion == "BuyNonPlayerBuilding"))
        {
            if (!(ProjectOrAction == "Action" && AktuelleAktion == "NonPlayerGarden"))
            {
                gameObject.transform.parent.GetComponent<MeshRenderer>().material = Einfaerben(OwnerParcel);
            }
        }
    }


    [Command(requiresAuthority = false)]
    void CmdOnEntry(string PlayerNameServer, string parentServer)
    {
        parent = parentServer;
        OwnerParcel = Owner(parent);
        int NumbAppart = Appartment(parent);
        int NumbParking = Parking(parent);
        int NumbShop = Shop(parent);

        RpcOnEntry(PlayerNameServer, parent, OwnerParcel, NumbAppart, NumbParking, NumbShop);

    }

    [ClientRpc]
    void RpcOnEntry(string PlayerNameServer, string parent, string OwnerParcel, int NumbAppart, int NumbParking, int NumbShop)
    {
        string PlayerName = NetworkClient.localPlayer.gameObject.name.ToString();
        if (PlayerName == PlayerNameServer)
        {
            if (OwnerParcel != "Implementiert")
            {
                TextInformation.text = "Diese Parzelle gehört: " + OwnerParcel
                                + System.Environment.NewLine + "Und enthält " + NumbAppart.ToString() + " Wohnungen;"
                                + System.Environment.NewLine + "Und enthält " + NumbParking.ToString() + " Parkplätze;"
                                + System.Environment.NewLine + "Und enthält " + NumbShop.ToString() + " Gewerbe;";
            }
            else if (OwnerParcel == "Implementiert")
            {
                TextInformation.text = "Diese Parzelle wurde bereits verbaut. " +
                    System.Environment.NewLine + "Hier entstand ein Projekt ihrer Wahl. " +
                    System.Environment.NewLine + "Gehen Sie zurück zur realen Ansicht, um das implementierte Projekt zu sehen. ";
            }

            gameObject.transform.parent.GetComponent<MeshRenderer>().material = MaterialHover;
        }

    }


    string Owner(string parent)
    {
        // Aparthotel
        if (parent == "ApartHotel")
        {
            return PlayerPrefs.GetString("OwnerAparthotel");
        }
        // BrauiTreppe
        else if (parent == "BrauiTreppe")
        {
            return PlayerPrefs.GetString("OwnerBrauiTreppe");
        }
        // BrauiTurm
        else if (parent == "BrauiTurm")
        {
            return PlayerPrefs.GetString("OwnerBrauiTurm");
        }
        // GarageBox
        else if (parent == "GarageBox")
        {
            return PlayerPrefs.GetString("OwnerGarageBox");
        }
        // Garage mit Garten
        else if (parent == "GarageMitGarten")
        {
            return PlayerPrefs.GetString("OwnerGarageGarten");
        }
        // Garage Orange
        else if (parent == "GarageOrange")
        {
            return PlayerPrefs.GetString("OwnerGarageOrange");
        }
        // Gruenflaeche
        else if (parent == "GrunFlache")
        {
            return PlayerPrefs.GetString("OwnerGruenflaeche");
        }
        // Haus Brauiplatz4
        else if (parent == "Haus_Brauiplatz4")
        {
            return PlayerPrefs.GetString("OwnerHausBrauiplatz4");
        }
        // Haus Kleinwangenstr. 1
        else if (parent == "Haus_Kleinwangenstr1")
        {
            return PlayerPrefs.GetString("OwnerHausKleinw1");
        }
        //  Haus Kleinwangenstr. 3
        else if (parent == "Haus_Kleinwangenstr3")
        {
            return PlayerPrefs.GetString("OwnerHausKleinw3");
        }
        //  Haus Kleinwangenstr. 5
        else if (parent == "Haus_Kleinwangenstr5")
        {
            return PlayerPrefs.GetString("OwnerHausKleinw5");
        }
        //  Haus Kleinwangenstr. 7
        else if (parent == "Haus_Kleinwangenstr7")
        {
            return PlayerPrefs.GetString("OwnerHausKleinw7");
        }
        // Haus Rosengasse 12
        else if (parent == "Haus_Rosengasse12")
        {
            return PlayerPrefs.GetString("OwnerHausRoseng12");
        }
        // Hinterhof Parkplatz 1
        else if (parent == "HinterHofParkplatz1")
        {
            return PlayerPrefs.GetString("OwnerHHPP1");
        }
        // Hinterhof Parkplatz 2
        else if (parent == "HinterHofParkplatz2")
        {
            return PlayerPrefs.GetString("OwnerHHPP2");
        }
        // Hinterhof Parkplatz 3
        else if (parent == "HinterHofParkplatz3")
        {
            return PlayerPrefs.GetString("OwnerHHPP3");
        }
        // Kantonalbank 
        else if (parent == "Kantonalbank")
        {
            return PlayerPrefs.GetString("OwnerKantonalbank");
        }
        // Kulturzentrum Braui
        else if (parent == "KulturzentrumBraui")
        {
            return PlayerPrefs.GetString("OwnerKulturzentrum");
        }
        // Braui Platz 1
        else if (parent == "BrauiPlatz1")
        {
            return PlayerPrefs.GetString("OwnerBrauiPlatz1");
        }
        // Braui Platz 2
        else if (parent == "BrauiPlatz2")
        {
            return PlayerPrefs.GetString("OwnerBrauiPlatz2");
        }
        // Braui Platz Restaurant 
        else if (parent == "BrauiPlatz_RestaurantTerasse")
        {
            return PlayerPrefs.GetString("OwnerBrauiPlatzRestaurant");
        }
        // Braui Platz Testzentrum 
        else if (parent == "BrauiPlatz_Testcenter")
        {
            return PlayerPrefs.GetString("OwnerBrauiPlatzTest");
        }
        // BrauiParkplatz1-4
        else if (parent == "BrauiParkplatz1-4")
        {
            return PlayerPrefs.GetString("OwnerPP1to4");
        }
        // BrauiParkplatz5-8
        else if (parent == "BrauiParkplatz5-8")
        {
            return PlayerPrefs.GetString("OwnerPP5to8");
        }
        // BrauiParkplatz9-11
        else if (parent == "BrauiParkplatz9-11")
        {
            return PlayerPrefs.GetString("OwnerPP9to11");
        }
        // Braui Parkplatz Seite 12
        else if (parent == "BrauiParkplatz_Seite12")
        {
            return PlayerPrefs.GetString("OwnerPP12");
        }
        // Braui Parkplatz Seite 13
        else if (parent == "BrauiParkplatz_Seite13")
        {
            return PlayerPrefs.GetString("OwnerPP13");
        }
        // Braui Parkplatz Seite 14
        else if (parent == "BrauiParkplatz_Seite14")
        {
            return PlayerPrefs.GetString("OwnerPP14");
        }
        // Braui Parkplatz Seite 15
        else if (parent == "BrauiParkplatz_Seite15")
        {
            return PlayerPrefs.GetString("OwnerPP15");
        }
        // Reihenhaus 1
        else if (parent == "Reihenhaus1")
        {
            return PlayerPrefs.GetString("OwnerReihenhaus1");
        }
        // Reihenhaus 2
        else if (parent == "Reihenhaus2")
        {
            return PlayerPrefs.GetString("OwnerReihenhaus2");
        }
        // Reihenhaus 3
        else if (parent == "Reihenhaus3")
        {
            return PlayerPrefs.GetString("OwnerReihenhaus3");
        }
        // Reihenhaus 4
        else if (parent == "Reihenhaus4")
        {
            return PlayerPrefs.GetString("OwnerReihenhaus4");
        }
        // Reihenhaus 5
        else if (parent == "Reihenhaus5")
        {
            return PlayerPrefs.GetString("OwnerReihenhaus5");
        }
        // Reihenhaus 6
        else if (parent == "Reihenhaus6")
        {
            return PlayerPrefs.GetString("OwnerReihenhaus6");
        }
        // Reihenhaus 7
        else if (parent == "Reihenhaus7")
        {
            return PlayerPrefs.GetString("OwnerReihenhaus7");
        }
        // Reihenhaus 8
        else if (parent == "Reihenhaus8")
        {
            return PlayerPrefs.GetString("OwnerReihenhaus8");
        }
        // Reihenhaus 9
        else if (parent == "Reihenhaus9")
        {
            return PlayerPrefs.GetString("OwnerReihenhaus9");
        }
        // Reihenhaus 10
        else if (parent == "Reihenhaus10")
        {
            return PlayerPrefs.GetString("OwnerReihenhaus10");
        }
        // Restaurant Braui
        else if (parent == "RestaurantBraui")
        {
            return PlayerPrefs.GetString("OwnerRestaurant");
        }
        else
        {
            return "NONE";
        }
    }

    int Appartment(string parent)
    {
        // Aparthotel
        if (parent == "ApartHotel")
        {
            return PlayerPrefs.GetInt("AppartmentAparthotel");
        }
        // Garage mit Garten
        else if (parent == "GarageMitGarten")
        {
            return PlayerPrefs.GetInt("AppartmentGarageGarten");
        }
        // Haus Brauiplatz4
        else if (parent == "Haus_Brauiplatz4")
        {
            return PlayerPrefs.GetInt("AppartmentHausBrauiplatz4");
        }
        // Haus Kleinwangenstr. 1
        else if (parent == "Haus_Kleinwangenstr1")
        {
            return PlayerPrefs.GetInt("AppartmentHausKleinw1");
        }
        //  Haus Kleinwangenstr. 3
        else if (parent == "Haus_Kleinwangenstr3")
        {
            return PlayerPrefs.GetInt("AppartmentHausKleinw3");
        }
        //  Haus Kleinwangenstr. 5
        else if (parent == "Haus_Kleinwangenstr5")
        {
            return PlayerPrefs.GetInt("AppartmentHausKleinw5");
        }
        //  Haus Kleinwangenstr. 7
        else if (parent == "Haus_Kleinwangenstr7")
        {
            return PlayerPrefs.GetInt("AppartmentHausKleinw7");
        }
        // Haus Rosengasse 12
        else if (parent == "Haus_Rosengasse12")
        {
            return PlayerPrefs.GetInt("AppartmentHausRoseng12");
        }
        // Kantonalbank 
        else if (parent == "Kantonalbank")
        {
            return PlayerPrefs.GetInt("AppartmentKantonalbank");
        }
        // Reihenhaus 1
        else if (parent == "Reihenhaus1")
        {
            return PlayerPrefs.GetInt("AppartmentReihenhaus1");
        }
        // Reihenhaus 2
        else if (parent == "Reihenhaus2")
        {
            return PlayerPrefs.GetInt("AppartmentReihenhaus2");
        }
        // Reihenhaus 3
        else if (parent == "Reihenhaus3")
        {
            return PlayerPrefs.GetInt("AppartmentReihenhaus3");
        }
        // Reihenhaus 4
        else if (parent == "Reihenhaus4")
        {
            return PlayerPrefs.GetInt("AppartmentReihenhaus4");
        }
        // Reihenhaus 5
        else if (parent == "Reihenhaus5")
        {
            return PlayerPrefs.GetInt("AppartmentReihenhaus5");
        }
        // Reihenhaus 6
        else if (parent == "Reihenhaus6")
        {
            return PlayerPrefs.GetInt("AppartmentReihenhaus6");
        }
        // Reihenhaus 7
        else if (parent == "Reihenhaus7")
        {
            return PlayerPrefs.GetInt("AppartmentReihenhaus7");
        }
        // Reihenhaus 8
        else if (parent == "Reihenhaus8")
        {
            return PlayerPrefs.GetInt("AppartmentReihenhaus8");
        }
        // Reihenhaus 9
        else if (parent == "Reihenhaus9")
        {
            return PlayerPrefs.GetInt("AppartmentReihenhaus9");
        }
        // Reihenhaus 10
        else if (parent == "Reihenhaus10")
        {
            return PlayerPrefs.GetInt("AppartmentReihenhaus10");
        }
        else
        {
            return 0;
        }
    }

    int Parking(string parent)
    {
        // GarageBox
        if (parent == "GarageBox")
        {
            return PlayerPrefs.GetInt("ParkingGarageBox");
        }
        // Garage Orange
        else if (parent == "GarageOrange")
        {
            return PlayerPrefs.GetInt("ParkingGarageOrange");
        }
        // Hinterhof Parkplatz 1
        else if (parent == "HinterHofParkplatz1")
        {
            return PlayerPrefs.GetInt("ParkingHHPP1");
        }
        // Hinterhof Parkplatz 2
        else if (parent == "HinterHofParkplatz2")
        {
            return PlayerPrefs.GetInt("ParkingHHPP2");
        }
        // Hinterhof Parkplatz 3
        else if (parent == "HinterHofParkplatz3")
        {
            return PlayerPrefs.GetInt("ParkingHHPP3");
        }
        // BrauiParkplatz1-4
        else if (parent == "BrauiParkplatz1-4")
        {
            return PlayerPrefs.GetInt("ParkingPP1to4");
        }
        // BrauiParkplatz5-8
        else if (parent == "BrauiParkplatz5-8")
        {
            return PlayerPrefs.GetInt("ParkingPP5to8");
        }
        // BrauiParkplatz9-11
        else if (parent == "BrauiParkplatz9-11")
        {
            return PlayerPrefs.GetInt("ParkingPP9to11");
        }
        // Braui Parkplatz Seite 12
        else if (parent == "BrauiParkplatz_Seite12")
        {
            return PlayerPrefs.GetInt("ParkingPP12");
        }
        // Braui Parkplatz Seite 13
        else if (parent == "BrauiParkplatz_Seite13")
        {
            return PlayerPrefs.GetInt("ParkingPP13");
        }
        // Braui Parkplatz Seite 14
        else if (parent == "BrauiParkplatz_Seite14")
        {
            return PlayerPrefs.GetInt("ParkingPP14");
        }
        // Braui Parkplatz Seite 15
        else if (parent == "BrauiParkplatz_Seite15")
        {
            return PlayerPrefs.GetInt("ParkingPP15");
        }
        else
        {
            return 0;
        }
    }

    int Shop(string parent)
    {
        // Kantonalbank 
        if (parent == "Kantonalbank")
        {
            return PlayerPrefs.GetInt("ShopKantonalbank");
        }
        // Kulturzentrum Braui
        else if (parent == "KulturzentrumBraui")
        {
            return PlayerPrefs.GetInt("ShopKulturzentrum");
        }
        // Reihenhaus 2
        else if (parent == "Reihenhaus2")
        {
            return PlayerPrefs.GetInt("ShopReihenhaus2");
        }
        // Reihenhaus 3
        else if (parent == "Reihenhaus3")
        {
            return PlayerPrefs.GetInt("ShopReihenhaus3");
        }
        // Restaurant Braui
        else if (parent == "RestaurantBraui")
        {
            return PlayerPrefs.GetInt("ShopRestaurant");
        }
        else
        {
            return 0;
        }
    }

    Material Einfaerben(string owner)
    {
        if (owner == "Gemeinde")
        {
            return MaterialP1;
        }
        else if (owner == "Landbesitzer")
        {
            return MaterialP2;
        }
        else if (owner == "Genossenschaft")
        {
            return MaterialP3;
        }
        else if (owner == "Kulturzentrum")
        {
            return MaterialP4;
        }
        else if (owner == "NonPlayer")
        {
            return MaterialNonPlayer;
        }
        else if (owner == "Implementiert")
        {
            return MaterialImplementiert;
        }
        else
        {
            return MaterialNone;
        }

    }
}
