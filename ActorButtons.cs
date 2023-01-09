using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActorButtons : MonoBehaviour
{
    public GameObject panelOverviewActors;
    public GameObject panelActor1;
    public GameObject panelActor2;
    public GameObject panelActor3;
    public GameObject panelActor4;

    // Actor 1 - Count
    int A1CountShop;
    public Text TextA1CountShop;
    int A1CountParkingLot;
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

    // Actor 3 - Count
    int A3CountShop;
    public Text TextA3CountShop;
    int A3CountParkingLot;
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
    public Text TextA4CountParkingLot;
    int A4CountAppartment;
    public Text TextA4CountAppartment;
    int A4CountAppartmentParkingLot;
    public Text TextA4CountAppartmentParkingLot;
    int A4CountAppartmentGarden;
    public Text TextA4CountAppartmentGarden;

    // Actor 1 - Money 
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

    // Additional of Storey
    public Text A1AdditionalofStorey;
    public Text A2AdditionalofStorey;
    public Text A3AdditionalofStorey;
    public Text A4AdditionalofStorey;

    // Create New Parking Lot
    public Text A1CreateNewParkingLot;
    public Text A2CreateNewParkingLot;
    public Text A3CreateNewParkingLot;
    public Text A4CreateNewParkingLot;

    // RemoveParkingLot
    public Text A1RemoveParkingLot;
    public Text A2RemoveParkingLot;
    public Text A3RemoveParkingLot;
    public Text A4RemoveParkingLot;

    // Create New Parking Lot
    public Text A1BuyNonPlayerBuilding;
    public Text A2BuyNonPlayerBuilding;
    public Text A3BuyNonPlayerBuilding;
    public Text A4BuyNonPlayerBuilding;

    // Create New Parking Lot
    public Text A1BuyNonPlayerGarden;
    public Text A2BuyNonPlayerGarden;
    public Text A3BuyNonPlayerGarden;
    public Text A4BuyNonPlayerGarden;

    // ShopIncome
    int ShopIncome;


    public void ButtonActor1()
    {
        panelActor1.SetActive(true);
        panelOverviewActors.SetActive(false);
        UpdateShopIncome();
    }

    public void ButtonActor2()
    {
        panelActor2.SetActive(true);
        panelOverviewActors.SetActive(false);
        UpdateShopIncome();
    }

    public void ButtonActor3()
    {
        panelActor3.SetActive(true);
        panelOverviewActors.SetActive(false);
        UpdateShopIncome();
    }

    public void ButtonActor4()
    {
        panelActor4.SetActive(true);
        panelOverviewActors.SetActive(false);
        UpdateShopIncome();
    }

    public void ActionAdditionalOfStorey()
    {
        int tempA1AdditionalofStorey = int.Parse(A1AdditionalofStorey.text);
        int tempA2AdditionalofStorey = int.Parse(A2AdditionalofStorey.text);
        int tempA3AdditionalofStorey = int.Parse(A3AdditionalofStorey.text);
        int tempA4AdditionalofStorey = int.Parse(A4AdditionalofStorey.text);

        if (tempA1AdditionalofStorey > tempA2AdditionalofStorey & tempA1AdditionalofStorey > tempA3AdditionalofStorey & tempA1AdditionalofStorey > tempA4AdditionalofStorey)
        {
            A1CountAppartment = PlayerPrefs.GetInt("A1CountAppartment") + 2;
            PlayerPrefs.SetInt("A1CountAppartment", A1CountAppartment);
            A1MoneyAppartment = 2 * A1CountAppartment;
            PlayerPrefs.SetInt("A1MoneyAppartment", A1MoneyAppartment);
            TextA1MoneyAppartment.text = A1MoneyAppartment.ToString();
            TextA1CountAppartment.text = A1CountAppartment.ToString();
        }

        else if (tempA2AdditionalofStorey > tempA1AdditionalofStorey & tempA2AdditionalofStorey > tempA3AdditionalofStorey & tempA2AdditionalofStorey > tempA4AdditionalofStorey)
        {
            A2CountAppartment = PlayerPrefs.GetInt("A2CountAppartment") + 2;
            PlayerPrefs.SetInt("A2CountAppartment", A2CountAppartment);
            A2MoneyAppartment = 2 * A2CountAppartment;
            PlayerPrefs.SetInt("A2MoneyAppartment", A2MoneyAppartment);
            TextA2MoneyAppartment.text = A2MoneyAppartment.ToString();
            TextA2CountAppartment.text = A2CountAppartment.ToString();
        }

        else if (tempA3AdditionalofStorey > tempA1AdditionalofStorey & tempA3AdditionalofStorey > tempA2AdditionalofStorey & tempA3AdditionalofStorey > tempA4AdditionalofStorey)
        {
            A3CountAppartment = PlayerPrefs.GetInt("A3CountAppartment") + 2;
            PlayerPrefs.SetInt("A3CountAppartment", A3CountAppartment);
            A3MoneyAppartment = 2 * A3CountAppartment;
            PlayerPrefs.SetInt("A3MoneyAppartment", A3MoneyAppartment);
            TextA3MoneyAppartment.text = A3MoneyAppartment.ToString();
            TextA3CountAppartment.text = A3CountAppartment.ToString();
        }

        else if (tempA4AdditionalofStorey > tempA1AdditionalofStorey & tempA4AdditionalofStorey > tempA2AdditionalofStorey & tempA4AdditionalofStorey > tempA3AdditionalofStorey)
        {
            A4CountAppartment = PlayerPrefs.GetInt("A4CountAppartment") + 2;
            PlayerPrefs.SetInt("A4CountAppartment", A4CountAppartment);
            A4MoneyAppartment = 2 * A4CountAppartment;
            PlayerPrefs.SetInt("A4MoneyAppartment", A4MoneyAppartment);
            TextA4MoneyAppartment.text = A4MoneyAppartment.ToString();
            TextA4CountAppartment.text = A4CountAppartment.ToString();
        }

        PlayerPrefs.Save();

    }

    public void ActionCreateNewParkingLot()
    {
        int tempA1CreateNewParkingLot = int.Parse(A1CreateNewParkingLot.text);
        int tempA2CreateNewParkingLot = int.Parse(A2CreateNewParkingLot.text);
        int tempA3CreateNewParkingLot = int.Parse(A3CreateNewParkingLot.text);
        int tempA4CreateNewParkingLot = int.Parse(A4CreateNewParkingLot.text);

        if (tempA1CreateNewParkingLot > tempA2CreateNewParkingLot & tempA1CreateNewParkingLot > tempA3CreateNewParkingLot & tempA1CreateNewParkingLot > tempA4CreateNewParkingLot)
        {
            A1CountParkingLot = PlayerPrefs.GetInt("A1CountParkingLot") + 1;
            PlayerPrefs.SetInt("A1CountParkingLot", A1CountParkingLot);
            A1MoneyParkingLot = 2 * A1CountParkingLot;
            PlayerPrefs.SetInt("A1MoneyParkingLot", A1MoneyParkingLot);
            TextA1MoneyParkingLot.text = A1MoneyParkingLot.ToString();
            TextA1CountParkingLot.text = A1CountParkingLot.ToString();
        }

        else if (tempA2CreateNewParkingLot > tempA1CreateNewParkingLot & tempA2CreateNewParkingLot > tempA3CreateNewParkingLot & tempA2CreateNewParkingLot > tempA4CreateNewParkingLot)
        {
            A2CountParkingLot = PlayerPrefs.GetInt("A2CountParkingLot") + 1;
            PlayerPrefs.SetInt("A2CountParkingLot", A2CountParkingLot);
            A2MoneyParkingLot = 2 * A2CountParkingLot;
            PlayerPrefs.SetInt("A2MoneyParkingLot", A2MoneyParkingLot);
            TextA2MoneyParkingLot.text = A2MoneyParkingLot.ToString();
            TextA2CountParkingLot.text = A2CountParkingLot.ToString();
        }

        else if (tempA3CreateNewParkingLot > tempA1CreateNewParkingLot & tempA3CreateNewParkingLot > tempA2CreateNewParkingLot & tempA3CreateNewParkingLot > tempA4CreateNewParkingLot)
        {
            A3CountParkingLot = PlayerPrefs.GetInt("A3CountParkingLot") + 1;
            PlayerPrefs.SetInt("A3CountParkingLot", A3CountParkingLot);
            A3MoneyParkingLot = 2 * A3CountParkingLot;
            PlayerPrefs.SetInt("A3MoneyParkingLot", A3MoneyParkingLot);
            TextA3MoneyParkingLot.text = A3MoneyParkingLot.ToString();
            TextA3CountParkingLot.text = A3CountParkingLot.ToString();
        }

        else if (tempA4CreateNewParkingLot > tempA1CreateNewParkingLot & tempA4CreateNewParkingLot > tempA2CreateNewParkingLot & tempA4CreateNewParkingLot > tempA3CreateNewParkingLot)
        {
            A4CountParkingLot = PlayerPrefs.GetInt("A4CountParkingLot") + 1;
            PlayerPrefs.SetInt("A4CountParkingLot", A4CountParkingLot);
            A4MoneyParkingLot = 2 * A4CountParkingLot;
            PlayerPrefs.SetInt("A4MoneyParkingLot", A4MoneyParkingLot);
            TextA4MoneyParkingLot.text = A4MoneyParkingLot.ToString();
            TextA4CountParkingLot.text = A4CountParkingLot.ToString();
        }

        PlayerPrefs.Save();
    }

    public void ActionRemoveParkingLot()
    {
        int tempA1RemoveParkingLot = int.Parse(A1RemoveParkingLot.text);
        int tempA2RemoveParkingLot = int.Parse(A2RemoveParkingLot.text);
        int tempA3RemoveParkingLot = int.Parse(A3RemoveParkingLot.text);
        int tempA4RemoveParkingLot = int.Parse(A4RemoveParkingLot.text);

        if (tempA1RemoveParkingLot > tempA2RemoveParkingLot & tempA1RemoveParkingLot > tempA3RemoveParkingLot & tempA1RemoveParkingLot > tempA4RemoveParkingLot)
        {
            A1CountParkingLot = PlayerPrefs.GetInt("A1CountParkingLot") - 1;
            PlayerPrefs.SetInt("A1CountParkingLot", A1CountParkingLot);
            A1MoneyParkingLot = 2 * A1CountParkingLot;
            PlayerPrefs.SetInt("A1MoneyParkingLot", A1MoneyParkingLot);
            TextA1MoneyParkingLot.text = A1MoneyParkingLot.ToString();
            TextA1CountParkingLot.text = A1CountParkingLot.ToString();
        }

        else if (tempA2RemoveParkingLot > tempA1RemoveParkingLot & tempA2RemoveParkingLot > tempA3RemoveParkingLot & tempA2RemoveParkingLot > tempA4RemoveParkingLot)
        {
            A2CountParkingLot = PlayerPrefs.GetInt("A2CountParkingLot") - 1;
            PlayerPrefs.SetInt("A2CountParkingLot", A2CountParkingLot);
            A2MoneyParkingLot = 2 * A2CountParkingLot;
            PlayerPrefs.SetInt("A2MoneyParkingLot", A2MoneyParkingLot);
            TextA2MoneyParkingLot.text = A2MoneyParkingLot.ToString();
            TextA2CountParkingLot.text = A2CountParkingLot.ToString();
        }

        else if (tempA3RemoveParkingLot > tempA1RemoveParkingLot & tempA3RemoveParkingLot > tempA2RemoveParkingLot & tempA3RemoveParkingLot > tempA4RemoveParkingLot)
        {
            A3CountParkingLot = PlayerPrefs.GetInt("A3CountParkingLot") - 1;
            PlayerPrefs.SetInt("A3CountParkingLot", A3CountParkingLot);
            A3MoneyParkingLot = 2 * A3CountParkingLot;
            PlayerPrefs.SetInt("A3MoneyParkingLot", A3MoneyParkingLot);
            TextA3MoneyParkingLot.text = A3MoneyParkingLot.ToString();
            TextA3CountParkingLot.text = A3CountParkingLot.ToString();
        }

        else if (tempA4RemoveParkingLot > tempA1RemoveParkingLot & tempA4RemoveParkingLot > tempA2RemoveParkingLot & tempA4RemoveParkingLot > tempA3RemoveParkingLot)
        {
            A4CountParkingLot = PlayerPrefs.GetInt("A4CountParkingLot") - 1;
            PlayerPrefs.SetInt("A4CountParkingLot", A4CountParkingLot);
            A4MoneyParkingLot = 2 * A4CountParkingLot;
            PlayerPrefs.SetInt("A4MoneyParkingLot", A4MoneyParkingLot);
            TextA4MoneyParkingLot.text = A4MoneyParkingLot.ToString();
            TextA4CountParkingLot.text = A4CountParkingLot.ToString();
        }
        PlayerPrefs.Save();
    }

    public void ActionBuyNonPlayerBuilding()
    {
        int tempA1BuyNonPlayerBuilding = int.Parse(A1BuyNonPlayerBuilding.text);
        int tempA2BuyNonPlayerBuilding = int.Parse(A2BuyNonPlayerBuilding.text);
        int tempA3BuyNonPlayerBuilding = int.Parse(A3BuyNonPlayerBuilding.text);
        int tempA4BuyNonPlayerBuilding = int.Parse(A4BuyNonPlayerBuilding.text);

        if (tempA1BuyNonPlayerBuilding > tempA2BuyNonPlayerBuilding & tempA1BuyNonPlayerBuilding > tempA3BuyNonPlayerBuilding & tempA1BuyNonPlayerBuilding > tempA4BuyNonPlayerBuilding)
        {
            A1CountAppartment = PlayerPrefs.GetInt("A1CountAppartment") + 4;
            PlayerPrefs.SetInt("A1CountAppartment", A1CountAppartment);
            A1MoneyAppartment = 2 * A1CountAppartment;
            PlayerPrefs.SetInt("A1MoneyAppartment", A1MoneyAppartment);
            TextA1MoneyAppartment.text = A1MoneyAppartment.ToString();
            TextA1CountAppartment.text = A1CountAppartment.ToString();
        }

        else if (tempA2BuyNonPlayerBuilding > tempA1BuyNonPlayerBuilding & tempA2BuyNonPlayerBuilding > tempA3BuyNonPlayerBuilding & tempA2BuyNonPlayerBuilding > tempA4BuyNonPlayerBuilding)
        {
            A2CountAppartment = PlayerPrefs.GetInt("A2CountAppartment") + 4;
            PlayerPrefs.SetInt("A2CountAppartment", A2CountAppartment);
            A2MoneyAppartment = 2 * A2CountAppartment;
            PlayerPrefs.SetInt("A2MoneyAppartment", A2MoneyAppartment);
            TextA2MoneyAppartment.text = A2MoneyAppartment.ToString();
            TextA2CountAppartment.text = A2CountAppartment.ToString();
        }

        else if (tempA3BuyNonPlayerBuilding > tempA1BuyNonPlayerBuilding & tempA3BuyNonPlayerBuilding > tempA2BuyNonPlayerBuilding & tempA3BuyNonPlayerBuilding > tempA4BuyNonPlayerBuilding)
        {
            A3CountAppartment = PlayerPrefs.GetInt("A3CountAppartment") + 4;
            PlayerPrefs.SetInt("A3CountAppartment", A3CountAppartment);
            A3MoneyAppartment = 2 * A3CountAppartment;
            PlayerPrefs.SetInt("A3MoneyAppartment", A3MoneyAppartment);
            TextA3MoneyAppartment.text = A3MoneyAppartment.ToString();
            TextA3CountAppartment.text = A3CountAppartment.ToString();
        }

        else if (tempA4BuyNonPlayerBuilding > tempA1BuyNonPlayerBuilding & tempA4BuyNonPlayerBuilding > tempA2BuyNonPlayerBuilding & tempA4BuyNonPlayerBuilding > tempA3BuyNonPlayerBuilding)
        {
            A4CountAppartment = PlayerPrefs.GetInt("A4CountAppartment") + 4;
            PlayerPrefs.SetInt("A4CountAppartment", A4CountAppartment);
            A4MoneyAppartment = 2 * A4CountAppartment;
            PlayerPrefs.SetInt("A4MoneyAppartment", A4MoneyAppartment);
            TextA4MoneyAppartment.text = A4MoneyAppartment.ToString();
            TextA4CountAppartment.text = A4CountAppartment.ToString();
        }
        PlayerPrefs.Save();
    }

    // Automatically reduce one appartment and add a appartment with garden
    public void ActionBuyNonPlayerGarden()
    {
        int tempA1BuyNonPlayerGarden = int.Parse(A1BuyNonPlayerGarden.text);
        int tempA2BuyNonPlayerGarden = int.Parse(A2BuyNonPlayerGarden.text);
        int tempA3BuyNonPlayerGarden = int.Parse(A3BuyNonPlayerGarden.text);
        int tempA4BuyNonPlayerGarden = int.Parse(A4BuyNonPlayerGarden.text);

        if (tempA1BuyNonPlayerGarden > tempA2BuyNonPlayerGarden & tempA1BuyNonPlayerGarden > tempA3BuyNonPlayerGarden & tempA1BuyNonPlayerGarden > tempA4BuyNonPlayerGarden)
        {
            A1CountAppartmentGarden = PlayerPrefs.GetInt("A1CountAppartmentGarden") + 1;
            PlayerPrefs.SetInt("A1CountAppartmentGarden", A1CountAppartmentGarden);
            A1MoneyAppartmentGarden = 2 * A1CountAppartmentGarden;
            PlayerPrefs.SetInt("A1MoneyAppartmentGarden", A1MoneyAppartmentGarden);
            TextA1MoneyAppartmentGarden.text = A1MoneyAppartmentGarden.ToString();
            TextA1CountAppartmentGarden.text = A1CountAppartmentGarden.ToString();

            A1CountAppartment = PlayerPrefs.GetInt("A1CountAppartment") - 1;
            PlayerPrefs.SetInt("A1CountAppartment", A1CountAppartment);
            A1MoneyAppartment = 2 * A1CountAppartment;
            PlayerPrefs.SetInt("A1MoneyAppartment", A1MoneyAppartment);
            TextA1MoneyAppartment.text = A1MoneyAppartment.ToString();
            TextA1CountAppartment.text = A1CountAppartment.ToString();
        }

        else if (tempA2BuyNonPlayerGarden > tempA1BuyNonPlayerGarden & tempA2BuyNonPlayerGarden > tempA3BuyNonPlayerGarden & tempA2BuyNonPlayerGarden > tempA4BuyNonPlayerGarden)
        {
            A2CountAppartmentGarden = PlayerPrefs.GetInt("A2CountAppartmentGarden") + 1;
            PlayerPrefs.SetInt("A2CountAppartmentGarden", A2CountAppartmentGarden);
            A2MoneyAppartmentGarden = 2 * A2CountAppartmentGarden;
            PlayerPrefs.SetInt("A2MoneyAppartmentGarden", A2MoneyAppartmentGarden);
            TextA2MoneyAppartmentGarden.text = A2MoneyAppartmentGarden.ToString();
            TextA2CountAppartmentGarden.text = A2CountAppartmentGarden.ToString();

            A2CountAppartment = PlayerPrefs.GetInt("A2CountAppartment") - 1;
            PlayerPrefs.SetInt("A2CountAppartment", A2CountAppartment);
            A2MoneyAppartment = 2 * A2CountAppartment;
            PlayerPrefs.SetInt("A2MoneyAppartment", A2MoneyAppartment);
            TextA2MoneyAppartment.text = A2MoneyAppartment.ToString();
            TextA2CountAppartment.text = A2CountAppartment.ToString();
        }

        else if (tempA3BuyNonPlayerGarden > tempA1BuyNonPlayerGarden & tempA3BuyNonPlayerGarden > tempA2BuyNonPlayerGarden & tempA3BuyNonPlayerGarden > tempA4BuyNonPlayerGarden)
        {
            A3CountAppartmentGarden = PlayerPrefs.GetInt("A3CountAppartmentGarden") + 1;
            PlayerPrefs.SetInt("A3CountAppartmentGarden", A3CountAppartmentGarden);
            A3MoneyAppartmentGarden = 2 * A3CountAppartmentGarden;
            PlayerPrefs.SetInt("A3MoneyAppartmentGarden", A3MoneyAppartmentGarden);
            TextA3MoneyAppartmentGarden.text = A3MoneyAppartmentGarden.ToString();
            TextA3CountAppartmentGarden.text = A3CountAppartmentGarden.ToString();

            A3CountAppartment = PlayerPrefs.GetInt("A3CountAppartment") - 1;
            PlayerPrefs.SetInt("A3CountAppartment", A3CountAppartment);
            A3MoneyAppartment = 2 * A3CountAppartment;
            PlayerPrefs.SetInt("A3MoneyAppartment", A3MoneyAppartment);
            TextA3MoneyAppartment.text = A3MoneyAppartment.ToString();
            TextA3CountAppartment.text = A3CountAppartment.ToString();
        }

        else if (tempA4BuyNonPlayerGarden > tempA1BuyNonPlayerGarden & tempA4BuyNonPlayerGarden > tempA2BuyNonPlayerGarden & tempA4BuyNonPlayerGarden > tempA3BuyNonPlayerGarden)
        {
            A4CountAppartmentGarden = PlayerPrefs.GetInt("A4CountAppartmentGarden") + 1;
            PlayerPrefs.SetInt("A4CountAppartmentGarden", A4CountAppartmentGarden);
            A4MoneyAppartmentGarden = 2 * A4CountAppartmentGarden;
            PlayerPrefs.SetInt("A4MoneyAppartmentGarden", A4MoneyAppartmentGarden);
            TextA4MoneyAppartmentGarden.text = A4MoneyAppartmentGarden.ToString();
            TextA4CountAppartmentGarden.text = A4CountAppartmentGarden.ToString();

            A4CountAppartment = PlayerPrefs.GetInt("A4CountAppartment") - 1;
            PlayerPrefs.SetInt("A4CountAppartment", A4CountAppartment);
            A4MoneyAppartment = 2 * A4CountAppartment;
            PlayerPrefs.SetInt("A4MoneyAppartment", A4MoneyAppartment);
            TextA4MoneyAppartment.text = A4MoneyAppartment.ToString();
            TextA4CountAppartment.text = A4CountAppartment.ToString();
        }
        PlayerPrefs.Save();

    }

    void UpdateShopIncome()
    {
        ShopIncome = PlayerPrefs.GetInt("ShopIncome");
        A1CountShop = PlayerPrefs.GetInt("A1CountShop");
        A2CountShop = PlayerPrefs.GetInt("A2CountShop");
        A3CountShop = PlayerPrefs.GetInt("A3CountShop");
        A4CountShop = PlayerPrefs.GetInt("A4CountShop");

        A1MoneyShop = ShopIncome * A1CountShop;
        PlayerPrefs.SetInt("A1MoneyShop", A1MoneyShop);
        TextA1MoneyShop.text = A1MoneyShop.ToString();

        A2MoneyShop = ShopIncome * A2CountShop;
        PlayerPrefs.SetInt("A2MoneyShop", A2MoneyShop);
        TextA2MoneyShop.text = A2MoneyShop.ToString();

        A3MoneyShop = ShopIncome * A3CountShop;
        PlayerPrefs.SetInt("A3MoneyShop", A3MoneyShop);
        TextA3MoneyShop.text = A3MoneyShop.ToString();

        A4MoneyShop = ShopIncome * A4CountShop;
        PlayerPrefs.SetInt("A4MoneyShop", A4MoneyShop);
        TextA4MoneyShop.text = A4MoneyShop.ToString();
    }


}
