using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class S00Update : NetworkBehaviour
{
    // Actor 1 - Count
    int A1CountShop;
    int A1CountParkingLot;
    int A1CountTiefgarageParkingLot;
    int A1CountAppartment;
    int A1CountAppartmentParkingLot;
    int A1CountAppartmentGarden;

    // Actor 1 - Money 
    int A1MoneyShop;
    int A1MoneyParkingLot;
    int A1MoneyAppartment;
    int A1MoneyAppartmentParkingLot;
    int A1MoneyAppartmentGarden;

    // Actor 2 - Count
    int A2CountShop;
    int A2CountParkingLot;
    int A2CountTiefgarageParkingLot;
    int A2CountAppartment;
    int A2CountAppartmentParkingLot;
    int A2CountAppartmentGarden;

    // Actor 2 - Money 
    int A2MoneyShop;
    int A2MoneyParkingLot;
    int A2MoneyAppartment;
    int A2MoneyAppartmentParkingLot;
    int A2MoneyAppartmentGarden;

    // Actor 3 - Count
    int A3CountShop;
    int A3CountParkingLot;
    int A3CountTiefgarageParkingLot;
    int A3CountAppartment;
    int A3CountAppartmentParkingLot;
    int A3CountAppartmentGarden;

    // Actor 3 - Money 
    int A3MoneyShop;
    int A3MoneyParkingLot;
    int A3MoneyAppartment;
    int A3MoneyAppartmentParkingLot;
    int A3MoneyAppartmentGarden;

    // Actor 4 - Count
    int A4CountShop;
    int A4CountParkingLot;
    int A4CountTiefgarageParkingLot;
    int A4CountAppartment;
    int A4CountAppartmentParkingLot;
    int A4CountAppartmentGarden;

    // Actor 1 - Money 
    int A4MoneyShop;
    int A4MoneyParkingLot;
    int A4MoneyAppartment;
    int A4MoneyAppartmentParkingLot;
    int A4MoneyAppartmentGarden;

    // Total
    int A1Total;
    int A2Total;
    int A3Total;
    int A4Total;

    //int Shopincome
    int ShopIncome;

    //Projects 
    int Buvette;
    int CreatingShadow;
    int FacadePainting;
    int StreetFurniture;
    int UniformFloorCovering;
    int PublicPark;
    int Jugendtreff;
    int Tiefgarage;
    int Polizei;
    int Arealentwicklung;
    int Zentrum;
    int Pedestrian;
    int BrauiStairs;


    // Events 
    int Fassaden;
    int Tempo30;
    int Dorfzentrum;
    int GrauesQuartier;
    int UnterhaltPark;
    int Graffiti;
    int Nachbardorf;
    int BewertungBraui;
    int ParkplaetzeVeranstaltungen;
    int Nachruhestoerung;
    int Corona;
    int Hitzewelle;
    int Sitzgelegenheit;
    int Diskussion;
    int FamilienWohnraum;
    int Ueberalterung;
    int Jugendliche;
    int Fussgaengerzone;
    int AnpassungKlimawandel;
    int FoerderungWohnraum;



    void Start()
    {
        if (isServer)
        {


            // Delete old Player Prefs
            PlayerPrefs.DeleteAll();

            PlayerPrefs.SetInt("Appeal", 0);
            PlayerPrefs.SetInt("Approval", 0);

            //Shop income is variable 
            ShopIncome = 0;
            PlayerPrefs.SetInt("ShopIncome", ShopIncome);

            /*// Actor 1 - Start Values 
            A1CountShop = 0;
            PlayerPrefs.SetInt("A1CountShop", A1CountShop);

            A1CountParkingLot = 0;
            PlayerPrefs.SetInt("A1CountParkingLot", A1CountParkingLot);

            A1CountTiefgarageParkingLot = 0;
            PlayerPrefs.SetInt("A1CountTiefgarageParkingLot", A1CountTiefgarageParkingLot);

            A1CountAppartment = 0;
            PlayerPrefs.SetInt("A1CountAppartment", A1CountAppartment);

            A1CountAppartmentParkingLot = 0;
            PlayerPrefs.SetInt("A1CountAppartmentParkingLot", A1CountAppartmentParkingLot);

            A1CountAppartmentGarden = 0;
            PlayerPrefs.SetInt("A1CountAppartmentGarden", A1CountAppartmentGarden);

            A1MoneyShop = ShopIncome * A1CountShop;
            PlayerPrefs.SetInt("A1MoneyShop", A1MoneyShop);

            A1MoneyParkingLot = 1 * A1CountParkingLot + 1 * A1CountTiefgarageParkingLot;
            PlayerPrefs.SetInt("A1MoneyParkingLot", A1MoneyParkingLot);

            A1MoneyAppartment = 2 * A1CountAppartment;
            PlayerPrefs.SetInt("A1MoneyAppartment", A1MoneyAppartment);

            A1MoneyAppartmentParkingLot = 4 * A1CountAppartmentParkingLot;
            PlayerPrefs.SetInt("A1MoneyAppartmentParkingLot", A1MoneyAppartmentParkingLot);

            A1MoneyAppartmentGarden = 4 * A1CountAppartmentGarden;
            PlayerPrefs.SetInt("A1MoneyAppartmentGarden", A1MoneyAppartmentGarden);

            A1Total = A1MoneyShop + A1MoneyParkingLot + A1MoneyAppartment + A1MoneyAppartmentParkingLot + A1MoneyAppartmentGarden;
            PlayerPrefs.SetInt("A1Total", A1Total);

            // Actor 2 - Start Values
            A2CountShop = 0;
            PlayerPrefs.SetInt("A2CountShop", A2CountShop);

            A2CountParkingLot = 0;
            PlayerPrefs.SetInt("A2CountParkingLot", A2CountParkingLot);

            A2CountTiefgarageParkingLot = 0;
            PlayerPrefs.SetInt("A2CountTiefgarageParkingLot", A2CountTiefgarageParkingLot);

            A2CountAppartment = 0;
            PlayerPrefs.SetInt("A2CountAppartment", A2CountAppartment);

            A2CountAppartmentParkingLot = 0;
            PlayerPrefs.SetInt("A2CountAppartmentParkingLot", A2CountAppartmentParkingLot);

            A2CountAppartmentGarden = 0;
            PlayerPrefs.SetInt("A2CountAppartmentGarden", A2CountAppartmentGarden);

            A2MoneyShop = ShopIncome * A2CountShop;
            PlayerPrefs.SetInt("A2MoneyShop", A2MoneyShop);

            A2MoneyParkingLot = 1 * A2CountParkingLot + 1 * A2CountTiefgarageParkingLot;
            PlayerPrefs.SetInt("A2MoneyParkingLot", A2MoneyParkingLot);

            A2MoneyAppartment = 2 * A2CountAppartment;
            PlayerPrefs.SetInt("A2MoneyAppartment", A2MoneyAppartment);

            A2MoneyAppartmentParkingLot = 4 * A2CountAppartmentParkingLot;
            PlayerPrefs.SetInt("A2MoneyAppartmentParkingLot", A2MoneyAppartmentParkingLot);

            A2MoneyAppartmentGarden = 4 * A2CountAppartmentGarden;
            PlayerPrefs.SetInt("A2MoneyAppartmentGarden", A2MoneyAppartmentGarden);

            A2Total = A2MoneyShop + A2MoneyParkingLot + A2MoneyAppartment + A2MoneyAppartmentParkingLot + A2MoneyAppartmentGarden;
            PlayerPrefs.SetInt("A2Total", A2Total);

            // Actor 3 - Start Values
            A3CountShop = 0;
            PlayerPrefs.SetInt("A3CountShop", A3CountShop);

            A3CountParkingLot = 0;
            PlayerPrefs.SetInt("A3CountParkingLot", A3CountParkingLot);

            A3CountTiefgarageParkingLot = 0;
            PlayerPrefs.SetInt("A3CountTiefgarageParkingLot", A3CountTiefgarageParkingLot);

            A3CountAppartment = 0;
            PlayerPrefs.SetInt("A3CountAppartment", A3CountAppartment);

            A3CountAppartmentParkingLot = 0;
            PlayerPrefs.SetInt("A3CountAppartmentParkingLot", A3CountAppartmentParkingLot);

            A3CountAppartmentGarden = 0;
            PlayerPrefs.SetInt("A3CountAppartmentGarden", A3CountAppartmentGarden);

            A3MoneyShop = ShopIncome * A3CountShop;
            PlayerPrefs.SetInt("A3MoneyShop", A3MoneyShop);

            A3MoneyParkingLot = 1 * A3CountParkingLot + 1 * A3CountTiefgarageParkingLot;
            PlayerPrefs.SetInt("A3MoneyParkingLot", A3MoneyParkingLot);

            A3MoneyAppartment = 2 * A3CountAppartment;
            PlayerPrefs.SetInt("A3MoneyAppartment", A3MoneyAppartment);

            A3MoneyAppartmentParkingLot = 4 * A3CountAppartmentParkingLot;
            PlayerPrefs.SetInt("A3MoneyAppartmentParkingLot", A3MoneyAppartmentParkingLot);

            A3MoneyAppartmentGarden = 4 * A3CountAppartmentGarden;
            PlayerPrefs.SetInt("A3MoneyAppartmentGarden", A3MoneyAppartmentGarden);

            A3Total = A3MoneyShop + A3MoneyParkingLot + A3MoneyAppartment + A3MoneyAppartmentParkingLot + A3MoneyAppartmentGarden;
            PlayerPrefs.SetInt("A3Total", A3Total);

            // Actor 4 - Start Values
            A4CountShop = 0;
            PlayerPrefs.SetInt("A4CountShop", A4CountShop);

            A4CountParkingLot = 0;
            PlayerPrefs.SetInt("A4CountParkingLot", A4CountParkingLot);

            A4CountTiefgarageParkingLot = 0;
            PlayerPrefs.SetInt("A4CountTiefgarageParkingLot", A4CountTiefgarageParkingLot);

            A4CountAppartment = 0;
            PlayerPrefs.SetInt("A4CountAppartment", A4CountAppartment);

            A4CountAppartmentParkingLot = 0;
            PlayerPrefs.SetInt("A4CountAppartmentParkingLot", A4CountAppartmentParkingLot);

            A4CountAppartmentGarden = 0;
            PlayerPrefs.SetInt("A4CountAppartmentGarden", A4CountAppartmentGarden);

            A4MoneyShop = ShopIncome * A4CountShop;
            PlayerPrefs.SetInt("A4MoneyShop", A4MoneyShop);

            A4MoneyParkingLot = 1 * A4CountParkingLot + 1 * A4CountTiefgarageParkingLot;
            PlayerPrefs.SetInt("A4MoneyParkingLot", A4MoneyParkingLot);

            A4MoneyAppartment = 2 * A4CountAppartment;
            PlayerPrefs.SetInt("A4MoneyAppartment", A4MoneyAppartment);

            A4MoneyAppartmentParkingLot = 4 * A4CountAppartmentParkingLot;
            PlayerPrefs.SetInt("A4MoneyAppartmentParkingLot", A4MoneyAppartmentParkingLot);

            A4MoneyAppartmentGarden = 4 * A4CountAppartmentGarden;
            PlayerPrefs.SetInt("A4MoneyAppartmentGarden", A4MoneyAppartmentGarden);

            A4Total = A4MoneyShop + A4MoneyParkingLot + A4MoneyAppartment + A4MoneyAppartmentParkingLot + A4MoneyAppartmentGarden;
            PlayerPrefs.SetInt("A4Total", A4Total);
            */

            // Actor 1 - Start Values 
            A1CountShop = 1;
            PlayerPrefs.SetInt("A1CountShop", A1CountShop);

            A1CountParkingLot = 15;
            PlayerPrefs.SetInt("A1CountParkingLot", A1CountParkingLot);

            A1CountTiefgarageParkingLot = 0;
            PlayerPrefs.SetInt("A1CountTiefgarageParkingLot", A1CountTiefgarageParkingLot);

            A1CountAppartment = 0;
            PlayerPrefs.SetInt("A1CountAppartment", A1CountAppartment);

            A1CountAppartmentParkingLot = 0;
            PlayerPrefs.SetInt("A1CountAppartmentParkingLot", A1CountAppartmentParkingLot);

            A1CountAppartmentGarden = 0;
            PlayerPrefs.SetInt("A1CountAppartmentGarden", A1CountAppartmentGarden);

            A1MoneyShop = ShopIncome * A1CountShop;
            PlayerPrefs.SetInt("A1MoneyShop", A1MoneyShop);

            A1MoneyParkingLot = 1 * A1CountParkingLot + 1 * A1CountTiefgarageParkingLot;
            PlayerPrefs.SetInt("A1MoneyParkingLot", A1MoneyParkingLot);

            A1MoneyAppartment = 2 * A1CountAppartment;
            PlayerPrefs.SetInt("A1MoneyAppartment", A1MoneyAppartment);

            A1MoneyAppartmentParkingLot = 4 * A1CountAppartmentParkingLot;
            PlayerPrefs.SetInt("A1MoneyAppartmentParkingLot", A1MoneyAppartmentParkingLot);

            A1MoneyAppartmentGarden = 4 * A1CountAppartmentGarden;
            PlayerPrefs.SetInt("A1MoneyAppartmentGarden", A1MoneyAppartmentGarden);

            A1Total = A1MoneyShop + A1MoneyParkingLot + A1MoneyAppartment + A1MoneyAppartmentParkingLot + A1MoneyAppartmentGarden;
            PlayerPrefs.SetInt("A1Total", A1Total);

            // Actor 2 - Start Values
            A2CountShop = 2;
            PlayerPrefs.SetInt("A2CountShop", A2CountShop);

            A2CountParkingLot = 8;
            PlayerPrefs.SetInt("A2CountParkingLot", A2CountParkingLot);

            A2CountTiefgarageParkingLot = 0;
            PlayerPrefs.SetInt("A2CountTiefgarageParkingLot", A2CountTiefgarageParkingLot);

            A2CountAppartment = 0;
            PlayerPrefs.SetInt("A2CountAppartment", A2CountAppartment);

            A2CountAppartmentParkingLot = 8;
            PlayerPrefs.SetInt("A2CountAppartmentParkingLot", A2CountAppartmentParkingLot);

            A2CountAppartmentGarden = 0;
            PlayerPrefs.SetInt("A2CountAppartmentGarden", A2CountAppartmentGarden);

            A2MoneyShop = ShopIncome * A2CountShop;
            PlayerPrefs.SetInt("A2MoneyShop", A2MoneyShop);

            A2MoneyParkingLot = 1 * A2CountParkingLot + 1 * A2CountTiefgarageParkingLot;
            PlayerPrefs.SetInt("A2MoneyParkingLot", A2MoneyParkingLot);

            A2MoneyAppartment = 2 * A2CountAppartment;
            PlayerPrefs.SetInt("A2MoneyAppartment", A2MoneyAppartment);

            A2MoneyAppartmentParkingLot = 4 * A2CountAppartmentParkingLot;
            PlayerPrefs.SetInt("A2MoneyAppartmentParkingLot", A2MoneyAppartmentParkingLot);

            A2MoneyAppartmentGarden = 4 * A2CountAppartmentGarden;
            PlayerPrefs.SetInt("A2MoneyAppartmentGarden", A2MoneyAppartmentGarden);

            A2Total = A2MoneyShop + A2MoneyParkingLot + A2MoneyAppartment + A2MoneyAppartmentParkingLot + A2MoneyAppartmentGarden;
            PlayerPrefs.SetInt("A2Total", A2Total);

            // Actor 3 - Start Values
            A3CountShop = 0;
            PlayerPrefs.SetInt("A3CountShop", A3CountShop);

            A3CountParkingLot = 0;
            PlayerPrefs.SetInt("A3CountParkingLot", A3CountParkingLot);

            A3CountTiefgarageParkingLot = 0;
            PlayerPrefs.SetInt("A3CountTiefgarageParkingLot", A3CountTiefgarageParkingLot);

            A3CountAppartment = 9;
            PlayerPrefs.SetInt("A3CountAppartment", A3CountAppartment);

            A3CountAppartmentParkingLot = 0;
            PlayerPrefs.SetInt("A3CountAppartmentParkingLot", A3CountAppartmentParkingLot);

            A3CountAppartmentGarden = 3;
            PlayerPrefs.SetInt("A3CountAppartmentGarden", A3CountAppartmentGarden);

            A3MoneyShop = ShopIncome * A3CountShop;
            PlayerPrefs.SetInt("A3MoneyShop", A3MoneyShop);

            A3MoneyParkingLot = 1 * A3CountParkingLot + 1 * A3CountTiefgarageParkingLot;
            PlayerPrefs.SetInt("A3MoneyParkingLot", A3MoneyParkingLot);

            A3MoneyAppartment = 2 * A3CountAppartment;
            PlayerPrefs.SetInt("A3MoneyAppartment", A3MoneyAppartment);

            A3MoneyAppartmentParkingLot = 4 * A3CountAppartmentParkingLot;
            PlayerPrefs.SetInt("A3MoneyAppartmentParkingLot", A3MoneyAppartmentParkingLot);

            A3MoneyAppartmentGarden = 4 * A3CountAppartmentGarden;
            PlayerPrefs.SetInt("A3MoneyAppartmentGarden", A3MoneyAppartmentGarden);

            A3Total = A3MoneyShop + A3MoneyParkingLot + A3MoneyAppartment + A3MoneyAppartmentParkingLot + A3MoneyAppartmentGarden;
            PlayerPrefs.SetInt("A3Total", A3Total);

            // Actor 4 - Start Values
            A4CountShop = 1;
            PlayerPrefs.SetInt("A4CountShop", A4CountShop);

            A4CountParkingLot = 0;
            PlayerPrefs.SetInt("A4CountParkingLot", A4CountParkingLot);

            A4CountTiefgarageParkingLot = 0;
            PlayerPrefs.SetInt("A4CountTiefgarageParkingLot", A4CountTiefgarageParkingLot);

            A4CountAppartment = 0;
            PlayerPrefs.SetInt("A4CountAppartment", A4CountAppartment);

            A4CountAppartmentParkingLot = 0;
            PlayerPrefs.SetInt("A4CountAppartmentParkingLot", A4CountAppartmentParkingLot);

            A4CountAppartmentGarden = 0;
            PlayerPrefs.SetInt("A4CountAppartmentGarden", A4CountAppartmentGarden);

            A4MoneyShop = ShopIncome * A4CountShop;
            PlayerPrefs.SetInt("A4MoneyShop", A4MoneyShop);

            A4MoneyParkingLot = 1 * A4CountParkingLot + 1 * A4CountTiefgarageParkingLot;
            PlayerPrefs.SetInt("A4MoneyParkingLot", A4MoneyParkingLot);

            A4MoneyAppartment = 2 * A4CountAppartment;
            PlayerPrefs.SetInt("A4MoneyAppartment", A4MoneyAppartment);

            A4MoneyAppartmentParkingLot = 4 * A4CountAppartmentParkingLot;
            PlayerPrefs.SetInt("A4MoneyAppartmentParkingLot", A4MoneyAppartmentParkingLot);

            A4MoneyAppartmentGarden = 4 * A4CountAppartmentGarden;
            PlayerPrefs.SetInt("A4MoneyAppartmentGarden", A4MoneyAppartmentGarden);

            A4Total = A4MoneyShop + A4MoneyParkingLot + A4MoneyAppartment + A4MoneyAppartmentParkingLot + A4MoneyAppartmentGarden;
            PlayerPrefs.SetInt("A4Total", A4Total);


            // Projects (0 = not built; 1 = built) 
            Buvette = 0;
            CreatingShadow = 0;
            FacadePainting = 0;
            StreetFurniture = 0;
            UniformFloorCovering = 0;
            PublicPark = 0;
            Jugendtreff = 0;
            Tiefgarage = 0;
            Polizei = 0;
            Arealentwicklung = 0;
            Zentrum = 0;
            Pedestrian = 0;
            BrauiStairs = 0;


            PlayerPrefs.SetInt("Buvette", Buvette);
            PlayerPrefs.SetInt("CreatingShadow", CreatingShadow);
            PlayerPrefs.SetInt("FacadePainting", FacadePainting);
            PlayerPrefs.SetInt("StreetFurniture", StreetFurniture);
            PlayerPrefs.SetInt("UniformFloorCovering", UniformFloorCovering);
            PlayerPrefs.SetInt("PublicPark", PublicPark);
            PlayerPrefs.SetInt("Jugendtreff", Jugendtreff);
            PlayerPrefs.SetInt("Tiefgarage", Tiefgarage);
            PlayerPrefs.SetInt("Polizei", Polizei);
            PlayerPrefs.SetInt("Arealentwicklung", Arealentwicklung);
            PlayerPrefs.SetInt("Zentrum", Zentrum);
            PlayerPrefs.SetInt("Pedestrian", Pedestrian);
            PlayerPrefs.SetInt("BrauiStairs", BrauiStairs);

            PlayerPrefs.SetInt("AnzahlMoebel", 0);

            // Events (0 = not shown, 1 = shown) 
            Fassaden = 0;
            Tempo30 = 0;
            Dorfzentrum = 0;
            GrauesQuartier = 0;
            UnterhaltPark = 0;
            Graffiti = 0;
            Nachbardorf = 0;
            BewertungBraui = 0;
            ParkplaetzeVeranstaltungen = 0;
            Nachruhestoerung = 0;
            Corona = 0;
            Hitzewelle = 0;
            Sitzgelegenheit = 0;
            Diskussion = 0;
            FamilienWohnraum = 0;
            Ueberalterung = 0;
            Jugendliche = 0;
            Fussgaengerzone = 0;
            AnpassungKlimawandel = 0;
            FoerderungWohnraum = 0;

            PlayerPrefs.SetInt("Fassaden", Fassaden);
            PlayerPrefs.SetInt("Tempo30", Tempo30);
            PlayerPrefs.SetInt("Dorfzentrum", Dorfzentrum);
            PlayerPrefs.SetInt("GrauesQuartier", GrauesQuartier);
            PlayerPrefs.SetInt("UnterhaltPark", UnterhaltPark);
            PlayerPrefs.SetInt("Graffiti", Graffiti);
            PlayerPrefs.SetInt("Nachbardorf", Nachbardorf);
            PlayerPrefs.SetInt("BewertungBraui", BewertungBraui);
            PlayerPrefs.SetInt("ParkplaetzeVeranstaltungen", ParkplaetzeVeranstaltungen);
            PlayerPrefs.SetInt("Nachruhestoerung", Nachruhestoerung);
            PlayerPrefs.SetInt("Corona", Corona);
            PlayerPrefs.SetInt("Hitzewelle", Hitzewelle);
            PlayerPrefs.SetInt("Sitzgelegenheit", Sitzgelegenheit);
            PlayerPrefs.SetInt("Diskussion", Diskussion);
            PlayerPrefs.SetInt("FamilienWohnraum", FamilienWohnraum);
            PlayerPrefs.SetInt("Ueberalterung", Ueberalterung);
            PlayerPrefs.SetInt("Jugendliche", Jugendliche);
            PlayerPrefs.SetInt("Fussgaengerzone", Fussgaengerzone);
            PlayerPrefs.SetInt("AnpassungKlimawandel", AnpassungKlimawandel);
            PlayerPrefs.SetInt("FoerderungWohnraum", FoerderungWohnraum);


            //Timer
            PlayerPrefs.SetFloat("timeRemaining", 600f);

            //Punktwolke - erfolgreiche Projekte werden auf 1 gesetzt (weiter oben); hinzu sollen die Positionen abgespeichert werden. 
            PlayerPrefs.SetString("PositionBuvette", "Pos unbekannt");
            PlayerPrefs.SetString("PositionCreatingShadow", "Pos unbekannt");
            PlayerPrefs.SetString("PositionFacadePainting", "Pos unbekannt");
            PlayerPrefs.SetString("PositionStreetFurniture0", "Pos unbekannt");
            PlayerPrefs.SetString("PositionStreetFurniture1", "Pos unbekannt");
            PlayerPrefs.SetString("PositionStreetFurniture2", "Pos unbekannt");
            PlayerPrefs.SetString("PositionUniformFloorCovering", "Pos unbekannt");
            PlayerPrefs.SetString("PositionPublicPark", "Pos unbekannt");
            PlayerPrefs.SetString("PositionJugendtreff", "Pos unbekannt");
            PlayerPrefs.SetString("PositionTiefgarage", "Pos unbekannt");
            PlayerPrefs.SetString("PositionPolizei", "Pos unbekannt");
            PlayerPrefs.SetString("PositionArealentwicklung", "Pos unbekannt");
            PlayerPrefs.SetString("PositionZentrum", "Pos unbekannt");
            PlayerPrefs.SetString("PositionPedestrian", "Pos unbekannt");
            PlayerPrefs.SetString("PositionBrauiStairs", "Pos unbekannt");

            PlayerPrefs.SetInt("ProjektAnnehmen", 0);

            //X Koordinaten der Projekte
            PlayerPrefs.SetFloat("XBuvette", 0.0f);
            PlayerPrefs.SetFloat("XCreatingShadow", 0.0f);
            PlayerPrefs.SetFloat("XFacadePainting", 0.0f);
            PlayerPrefs.SetFloat("XStreetFurniture0", 0.0f);
            PlayerPrefs.SetFloat("XStreetFurniture1", 0.0f);
            PlayerPrefs.SetFloat("XStreetFurniture2", 0.0f);
            PlayerPrefs.SetFloat("XUniformFloorCovering", 0.0f);
            PlayerPrefs.SetFloat("XPublicPark", 0.0f);
            PlayerPrefs.SetFloat("XJugendtreff", 0.0f);
            PlayerPrefs.SetFloat("XTiefgarage", 0.0f);
            PlayerPrefs.SetFloat("XPolizei", 0.0f);
            PlayerPrefs.SetFloat("XArealentwicklung", 0.0f);
            PlayerPrefs.SetFloat("XZentrum", 0.0f);
            PlayerPrefs.SetFloat("XPedestrian", 0.0f);
            PlayerPrefs.SetFloat("XBrauiStairs", 0.0f);

            //Y Koordinaten der Projekte
            PlayerPrefs.SetFloat("YBuvette", 0.0f);
            PlayerPrefs.SetFloat("YCreatingShadow", 0.0f);
            PlayerPrefs.SetFloat("YFacadePainting", 0.0f);
            PlayerPrefs.SetFloat("YStreetFurniture0", 0.0f);
            PlayerPrefs.SetFloat("YStreetFurniture1", 0.0f);
            PlayerPrefs.SetFloat("YStreetFurniture2", 0.0f);
            PlayerPrefs.SetFloat("YUniformFloorCovering", 0.0f);
            PlayerPrefs.SetFloat("YPublicPark", 0.0f);
            PlayerPrefs.SetFloat("YJugendtreff", 0.0f);
            PlayerPrefs.SetFloat("YTiefgarage", 0.0f);
            PlayerPrefs.SetFloat("YPolizei", 0.0f);
            PlayerPrefs.SetFloat("YArealentwicklung", 0.0f);
            PlayerPrefs.SetFloat("YZentrum", 0.0f);
            PlayerPrefs.SetFloat("YPedestrian", 0.0f);
            PlayerPrefs.SetFloat("YBrauiStairs", 0.0f);

            //Z Koordinaten der Projekte
            PlayerPrefs.SetFloat("ZBuvette", 0.0f);
            PlayerPrefs.SetFloat("ZCreatingShadow", 0.0f);
            PlayerPrefs.SetFloat("ZFacadePainting", 0.0f);
            PlayerPrefs.SetFloat("ZStreetFurniture0", 0.0f);
            PlayerPrefs.SetFloat("ZStreetFurniture1", 0.0f);
            PlayerPrefs.SetFloat("ZStreetFurniture2", 0.0f);
            PlayerPrefs.SetFloat("ZUniformFloorCovering", 0.0f);
            PlayerPrefs.SetFloat("ZPublicPark", 0.0f);
            PlayerPrefs.SetFloat("ZJugendtreff", 0.0f);
            PlayerPrefs.SetFloat("ZTiefgarage", 0.0f);
            PlayerPrefs.SetFloat("ZPolizei", 0.0f);
            PlayerPrefs.SetFloat("ZArealentwicklung", 0.0f);
            PlayerPrefs.SetFloat("ZZentrum", 0.0f);
            PlayerPrefs.SetFloat("ZPedestrian", 0.0f);
            PlayerPrefs.SetFloat("ZBrauiStairs", 0.0f);

            //X Rotationen der Projekte
            PlayerPrefs.SetFloat("XBuvetteRotation", 0.0f);
            PlayerPrefs.SetFloat("XCreatingShadowRotation", 0.0f);
            PlayerPrefs.SetFloat("XFacadePaintingRotation", 0.0f);
            PlayerPrefs.SetFloat("XStreetFurniture0Rotation", 0.0f);
            PlayerPrefs.SetFloat("XStreetFurniture1Rotation", 0.0f);
            PlayerPrefs.SetFloat("XStreetFurniture2Rotation", 0.0f);
            PlayerPrefs.SetFloat("XUniformFloorCoveringRotation", 0.0f);
            PlayerPrefs.SetFloat("XPublicParkRotation", 0.0f);
            PlayerPrefs.SetFloat("XJugendtreffRotation", 0.0f);
            PlayerPrefs.SetFloat("XTiefgarageRotation", 0.0f);
            PlayerPrefs.SetFloat("XPolizeiRotation", 0.0f);
            PlayerPrefs.SetFloat("XArealentwicklungRotation", 0.0f);
            PlayerPrefs.SetFloat("XZentrumRotation", 0.0f);
            PlayerPrefs.SetFloat("XPedestrianRotation", 0.0f);
            PlayerPrefs.SetFloat("XBrauiStairsRotation", 0.0f);

            //Y Rotationen der Projekte
            PlayerPrefs.SetFloat("YBuvetteRotation", 0.0f);
            PlayerPrefs.SetFloat("YCreatingShadowRotation", 0.0f);
            PlayerPrefs.SetFloat("YFacadePaintingRotation", 0.0f);
            PlayerPrefs.SetFloat("YStreetFurniture0Rotation", 0.0f);
            PlayerPrefs.SetFloat("YStreetFurniture1Rotation", 0.0f);
            PlayerPrefs.SetFloat("YStreetFurniture2Rotation", 0.0f);
            PlayerPrefs.SetFloat("YUniformFloorCoveringRotation", 0.0f);
            PlayerPrefs.SetFloat("YPublicParkRotation", 0.0f);
            PlayerPrefs.SetFloat("YJugendtreffRotation", 0.0f);
            PlayerPrefs.SetFloat("YTiefgarageRotation", 0.0f);
            PlayerPrefs.SetFloat("YPolizeiRotation", 0.0f);
            PlayerPrefs.SetFloat("YArealentwicklungRotation", 0.0f);
            PlayerPrefs.SetFloat("YZentrumRotation", 0.0f);
            PlayerPrefs.SetFloat("YPedestrianRotation", 0.0f);
            PlayerPrefs.SetFloat("YBrauiStairsRotation", 0.0f);

            //Z Rotationen der Projekte
            PlayerPrefs.SetFloat("ZBuvetteRotation", 0.0f);
            PlayerPrefs.SetFloat("ZCreatingShadowRotation", 0.0f);
            PlayerPrefs.SetFloat("ZFacadePaintingRotation", 0.0f);
            PlayerPrefs.SetFloat("ZStreetFurniture0Rotation", 0.0f);
            PlayerPrefs.SetFloat("ZStreetFurniture1Rotation", 0.0f);
            PlayerPrefs.SetFloat("ZStreetFurniture2Rotation", 0.0f);
            PlayerPrefs.SetFloat("ZUniformFloorCoveringRotation", 0.0f);
            PlayerPrefs.SetFloat("ZPublicParkRotation", 0.0f);
            PlayerPrefs.SetFloat("ZJugendtreffRotation", 0.0f);
            PlayerPrefs.SetFloat("ZTiefgarageRotation", 0.0f);
            PlayerPrefs.SetFloat("ZPolizeiRotation", 0.0f);
            PlayerPrefs.SetFloat("ZArealentwicklungRotation", 0.0f);
            PlayerPrefs.SetFloat("ZZentrumRotation", 0.0f);
            PlayerPrefs.SetFloat("ZPedestrianRotation", 0.0f);
            PlayerPrefs.SetFloat("ZBrauiStairsRotation", 0.0f);

            //Slider-Werte für PayPlayer
            PlayerPrefs.SetInt("SliderP1", 0);
            PlayerPrefs.SetInt("SliderP2", 0);
            PlayerPrefs.SetInt("SliderP3", 0);
            PlayerPrefs.SetInt("SliderP4", 0);

            //Projekt setzen
            PlayerPrefs.SetInt("MunPressed", 0);
            PlayerPrefs.SetInt("LandPressed", 0);
            PlayerPrefs.SetInt("CoPressed", 0);
            PlayerPrefs.SetInt("CultPressed", 0);

            PlayerPrefs.SetString("ProjectOrAction", "none");

            PlayerPrefs.SetInt("ErsteActionMun", 0);
            PlayerPrefs.SetInt("ErsteActionLand", 0);
            PlayerPrefs.SetInt("ErsteActionCo", 0);
            PlayerPrefs.SetInt("ErsteActionCult", 0);


            PlayerPrefs.SetInt("RundeArealentwicklung", 0);
            PlayerPrefs.SetInt("ArealAnnualbezahlt", 0);
            PlayerPrefs.SetInt("Annualbezahlt", 0);

            //Ownership
            PlayerPrefs.SetString("OwnerKulturzentrum", "Gemeinde");
            PlayerPrefs.SetString("OwnerRestaurant", "Gemeinde");
            PlayerPrefs.SetString("OwnerBrauiPlatzRestaurant", "Gemeinde");
            PlayerPrefs.SetString("OwnerBrauiPlatz1", "Gemeinde");
            PlayerPrefs.SetString("OwnerBrauiPlatz2", "Gemeinde");
            PlayerPrefs.SetString("OwnerBrauiPlatzTest", "Gemeinde");
            PlayerPrefs.SetString("OwnerBrauiTurm", "Gemeinde");
            PlayerPrefs.SetString("OwnerBrauiTreppe", "Gemeinde");
            PlayerPrefs.SetString("OwnerPP1to4", "Gemeinde");
            PlayerPrefs.SetString("OwnerPP5to8", "Gemeinde");
            PlayerPrefs.SetString("OwnerPP9to11", "Gemeinde");
            PlayerPrefs.SetString("OwnerPP12", "Gemeinde");
            PlayerPrefs.SetString("OwnerPP13", "Gemeinde");
            PlayerPrefs.SetString("OwnerPP14", "Gemeinde");
            PlayerPrefs.SetString("OwnerPP15", "Gemeinde");
            PlayerPrefs.SetString("OwnerKantonalbank", "NonPlayer");
            PlayerPrefs.SetString("OwnerAparthotel", "NonPlayer");
            PlayerPrefs.SetString("OwnerGruenflaeche", "NonPlayer");
            PlayerPrefs.SetString("OwnerHausBrauiplatz4", "NonPlayer");
            PlayerPrefs.SetString("OwnerHausKleinw1", "Landbesitzer");
            PlayerPrefs.SetString("OwnerHausKleinw3", "NonPlayer");
            PlayerPrefs.SetString("OwnerHausKleinw5", "NonPlayer");
            PlayerPrefs.SetString("OwnerHausKleinw7", "NonPlayer");
            PlayerPrefs.SetString("OwnerHausRoseng12", "Genossenschaft");
            PlayerPrefs.SetString("OwnerGarageGarten", "Genossenschaft");
            PlayerPrefs.SetString("OwnerGarageBox", "Landbesitzer");
            PlayerPrefs.SetString("OwnerGarageOrange", "Landbesitzer");
            PlayerPrefs.SetString("OwnerHHPP1", "Landbesitzer");
            PlayerPrefs.SetString("OwnerHHPP2", "Landbesitzer");
            PlayerPrefs.SetString("OwnerHHPP3", "Landbesitzer");
            PlayerPrefs.SetString("OwnerReihenhaus1", "NonPlayer");
            PlayerPrefs.SetString("OwnerReihenhaus2", "Landbesitzer");
            PlayerPrefs.SetString("OwnerReihenhaus3", "Landbesitzer");
            PlayerPrefs.SetString("OwnerReihenhaus4", "NonPlayer");
            PlayerPrefs.SetString("OwnerReihenhaus5", "NonPlayer");
            PlayerPrefs.SetString("OwnerReihenhaus6", "Genossenschaft");
            PlayerPrefs.SetString("OwnerReihenhaus7", "Genossenschaft");
            PlayerPrefs.SetString("OwnerReihenhaus8", "Genossenschaft");
            PlayerPrefs.SetString("OwnerReihenhaus9", "NonPlayer");
            PlayerPrefs.SetString("OwnerReihenhaus10", "Genossenschaft");
            PlayerPrefs.SetString("OwnerStrasse", "None");
            PlayerPrefs.SetString("OwnerFassadePainting", "Gemeinde");
            PlayerPrefs.SetString("OwnerJugendtreff", "Gemeinde");
            PlayerPrefs.SetString("OwnerPolizei", "Gemeinde");
            PlayerPrefs.SetString("OwnerTiefgarage", "Gemeinde");
            PlayerPrefs.SetString("OwnerEinheitlicherBodenbelag", "Gemeinde");
            PlayerPrefs.SetString("OwnerPedestrian", "Gemeinde");

            //Appartment per Object 
            PlayerPrefs.SetInt("AppartmentKantonalbank", 2);
            PlayerPrefs.SetInt("AppartmentAparthotel", 4);
            PlayerPrefs.SetInt("AppartmentHausBrauiplatz4", 4);
            PlayerPrefs.SetInt("AppartmentHausKleinw1", 4);
            PlayerPrefs.SetInt("AppartmentHausKleinw3", 4);
            PlayerPrefs.SetInt("AppartmentHausKleinw5", 4);
            PlayerPrefs.SetInt("AppartmentHausKleinw7", 4);
            PlayerPrefs.SetInt("AppartmentHausRoseng12", 2);
            PlayerPrefs.SetInt("AppartmentGarageGarten", 2);
            PlayerPrefs.SetInt("AppartmentReihenhaus1", 4);
            PlayerPrefs.SetInt("AppartmentReihenhaus2", 2);
            PlayerPrefs.SetInt("AppartmentReihenhaus3", 2);
            PlayerPrefs.SetInt("AppartmentReihenhaus4", 4);
            PlayerPrefs.SetInt("AppartmentReihenhaus5", 4);
            PlayerPrefs.SetInt("AppartmentReihenhaus6", 2);
            PlayerPrefs.SetInt("AppartmentReihenhaus7", 2);
            PlayerPrefs.SetInt("AppartmentReihenhaus8", 2);
            PlayerPrefs.SetInt("AppartmentReihenhaus9", 4);
            PlayerPrefs.SetInt("AppartmentReihenhaus10", 2);

            //Parking per Object 
            PlayerPrefs.SetInt("ParkingPP1to4", 4);
            PlayerPrefs.SetInt("ParkingPP5to8", 4);
            PlayerPrefs.SetInt("ParkingPP9to11", 3);
            PlayerPrefs.SetInt("ParkingPP12", 1);
            PlayerPrefs.SetInt("ParkingPP13", 1);
            PlayerPrefs.SetInt("ParkingPP14", 1);
            PlayerPrefs.SetInt("ParkingPP15", 1);
            PlayerPrefs.SetInt("ParkingGarageBox", 4);
            PlayerPrefs.SetInt("ParkingGarageOrange", 2);
            PlayerPrefs.SetInt("ParkingHHPP1", 6);
            PlayerPrefs.SetInt("ParkingHHPP2", 4);
            PlayerPrefs.SetInt("ParkingHHPP3", 2);

            //Shop per Object 
            PlayerPrefs.SetInt("ShopKulturzentrum", 1);
            PlayerPrefs.SetInt("ShopRestaurant", 1);
            PlayerPrefs.SetInt("ShopKantonalbank", 2);
            PlayerPrefs.SetInt("ShopReihenhaus2", 1);
            PlayerPrefs.SetInt("ShopReihenhaus3", 1);

            //Spielrunden zählen
            PlayerPrefs.SetInt("GameRunde", 0);
            PlayerPrefs.SetInt("SpielEnde", 0);

            //Zentrum-Position: 
            PlayerPrefs.SetString("ActualPointCloudParentZentrum1", "NONE");
            PlayerPrefs.SetString("ActualPointCloudParentZentrum2", "NONE");
            PlayerPrefs.SetString("ActualPointCloudParentZentrum3", "NONE");
            PlayerPrefs.SetString("ActualPointCloudParentZentrum4", "NONE");

            PlayerPrefs.SetString("LastPointCloudParentZentrum1", "NONE");
            PlayerPrefs.SetString("LastPointCloudParentZentrum2", "NONE");
            PlayerPrefs.SetString("LastPointCloudParentZentrum3", "NONE");
            PlayerPrefs.SetString("LastPointCloudParentZentrum4", "NONE");


            //Additional of Storey pro Grunstück 
            PlayerPrefs.SetInt("AdditionalOfStorey_Aparthotel", 0);
            PlayerPrefs.SetInt("AdditionalOfStorey_Brauiturm", 0);
            PlayerPrefs.SetInt("AdditionalOfStorey_Haus_Brauiplatz4", 0);
            PlayerPrefs.SetInt("AdditionalOfStorey_Kantonalbank", 0);
            PlayerPrefs.SetInt("AdditionalOfStorey_KulturzentrumBraui", 0);
            PlayerPrefs.SetInt("AdditionalOfStorey_RestaurantBraui", 0);
            PlayerPrefs.SetInt("AdditionalOfStorey_Haus_Kleinwangenstr7", 0);
            PlayerPrefs.SetInt("AdditionalOfStorey_Haus_Kleinwangenstr1", 0);
            PlayerPrefs.SetInt("AdditionalOfStorey_Haus_Kleinwangenstr3", 0);
            PlayerPrefs.SetInt("AdditionalOfStorey_Haus_Kleinwangenstr5", 0);
            PlayerPrefs.SetInt("AdditionalOfStorey_Haus_Rosengasse12", 0);
            PlayerPrefs.SetInt("AdditionalOfStorey_Reihenhaus1", 0);
            PlayerPrefs.SetInt("AdditionalOfStorey_Reihenhaus2", 0);
            PlayerPrefs.SetInt("AdditionalOfStorey_Reihenhaus3", 0);
            PlayerPrefs.SetInt("AdditionalOfStorey_Reihenhaus4", 0);
            PlayerPrefs.SetInt("AdditionalOfStorey_Reihenhaus5", 0);
            PlayerPrefs.SetInt("AdditionalOfStorey_Reihenhaus6", 0);
            PlayerPrefs.SetInt("AdditionalOfStorey_Reihenhaus7", 0);
            PlayerPrefs.SetInt("AdditionalOfStorey_Reihenhaus8", 0);
            PlayerPrefs.SetInt("AdditionalOfStorey_Reihenhaus9", 0);
            PlayerPrefs.SetInt("AdditionalOfStorey_Reihenhaus10", 0);


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

            PlayerPrefs.SetInt("A1MomAsset", 200);
            PlayerPrefs.SetInt("A4MomAsset", 200);

            PlayerPrefs.Save();
        }
    }


}


