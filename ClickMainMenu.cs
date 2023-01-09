using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;


public class ClickMainMenu : NetworkBehaviour
{

    // Projects Menu
    public GameObject panelProjectsMenu;
    public GameObject panelNoOwner;

    // Street Furniture
    public GameObject panelProjectStreetFurniture;
    public GameObject panelPayStreetFurniture;

    // Public Park
    public GameObject panelProjectPublicPark;
    public GameObject panelPayPublicPark;

    // Facade Painting
    public GameObject panelProjectFacadePainting;
    public GameObject panelPayFacadePainting;

    // Uniform Floor Covering
    public GameObject panelProjectUniformFloorCovering;
    public GameObject panelPayUniformFloorCovering;

    // Creating Shadow
    public GameObject panelProjectCreatingShadow;
    public GameObject panelPayCreatingShadow;

    // Buvette
    public GameObject panelProjectBuvette;
    public GameObject panelPayBuvette;

    // Jugendtreff
    public GameObject panelProjectJugendtreff;
    public GameObject panelPayJugendtreff;

    //Tiefgarage
    public GameObject panelProjectTiefgarage;
    public GameObject panelPayTiefgarage;
    public GameObject panelAufteilenTiefgarage;

    // Polizei
    public GameObject panelProjectPolizei;
    public GameObject panelPayPolizei;

    // Arealentwicklung
    public GameObject panelProjectArealentwicklung;
    public GameObject panelPay400Arealentwicklung;
    public GameObject panelPay3x100Arealentwicklung;
    public GameObject panelRatenArealentwicklung;

    // Zentrum
    public GameObject panelProjectZentrum;
    public GameObject panelPayZentrum;

    // Pedestrian
    public GameObject panelProjectPedestrian;
    public GameObject panelPayPedestrian;

    // BrauiStairs
    public GameObject panelProjectBrauiStairs;
    public GameObject panelPayBrauiStairs;

    // Actions Menu
    public GameObject panelActionsMenu;

    // Additional of Storey
    public GameObject panelPayAdditionalOfStorey;

    // Create New Parking Lots 
    public GameObject panelPayCreateNewParkingLots;

    // Remove Parking Lots
    public GameObject panelPayRemoveParkingLots;

    // Buy a non-player building 
    public GameObject panelPayBuyNonPlayerBuilding;

    // Buy a non-player Garden
    public GameObject panelPayBuyNonPlayerGarden;

    // Actors Sheets
    public GameObject panelActor1;
    public GameObject panelActor2;
    public GameObject panelActor3;
    public GameObject panelActor4;

    public Button ActorsName;


    void Start()
    {
        if (!isServer)
        {
            string LocalPlayer = NetworkClient.localPlayer.gameObject.name.ToString();

            if (LocalPlayer == "Gemeinde")
            {
                ActorsName.GetComponentInChildren<Text>().text = "Gemeinde";
            }

            if (LocalPlayer == "Landbesitzer")
            {
                ActorsName.GetComponentInChildren<Text>().text = "Landbesitzer";
            }

            if (LocalPlayer == "Genossenschaft")
            {
                ActorsName.GetComponentInChildren<Text>().text = "Genossenschaft";
            }

            if (LocalPlayer == "Kulturzentrum")
            {
                ActorsName.GetComponentInChildren<Text>().text = "Kulturzentrum";
            }
        }
    }

    // Open Project Menu 
    public void OpenMainMenuProject()
    {
        if (panelProjectsMenu.activeInHierarchy == true)
        {
            panelProjectsMenu.SetActive(false);
        }

        else if (panelProjectsMenu.activeInHierarchy == false)
        {
            panelProjectsMenu.SetActive(true);
        }

        //hide Project Panel
        panelProjectStreetFurniture.SetActive(false);
        panelProjectPublicPark.SetActive(false);
        panelProjectFacadePainting.SetActive(false);
        panelProjectUniformFloorCovering.SetActive(false);
        panelProjectCreatingShadow.SetActive(false);
        panelProjectBuvette.SetActive(false);
        panelProjectJugendtreff.SetActive(false);
        panelProjectTiefgarage.SetActive(false);
        panelProjectPolizei.SetActive(false);
        panelProjectArealentwicklung.SetActive(false);
        panelProjectZentrum.SetActive(false);
        panelProjectJugendtreff.SetActive(false);
        panelProjectBrauiStairs.SetActive(false);

        //hide Project Pay Panel
        panelPayStreetFurniture.SetActive(false);
        panelPayPublicPark.SetActive(false);
        panelPayFacadePainting.SetActive(false);
        panelPayUniformFloorCovering.SetActive(false);
        panelPayCreatingShadow.SetActive(false);
        panelPayBuvette.SetActive(false);
        panelPayJugendtreff.SetActive(false);
        panelPayTiefgarage.SetActive(false);
        panelAufteilenTiefgarage.SetActive(false);
        panelPayPolizei.SetActive(false);
        panelPay400Arealentwicklung.SetActive(false);
        panelPay3x100Arealentwicklung.SetActive(false);
        panelRatenArealentwicklung.SetActive(false);
        panelPayZentrum.SetActive(false);
        panelPayJugendtreff.SetActive(false);
        panelPayBrauiStairs.SetActive(false);

        //hide Action Panel
        panelActionsMenu.SetActive(false);
        panelNoOwner.SetActive(false);

        //hide Action Pay Panel
        panelPayAdditionalOfStorey.SetActive(false);
        panelPayCreateNewParkingLots.SetActive(false);
        panelPayRemoveParkingLots.SetActive(false);
        panelPayBuyNonPlayerBuilding.SetActive(false);
        panelPayBuyNonPlayerGarden.SetActive(false);

        //hide Actor Panel 
        panelActor1.SetActive(false);
        panelActor2.SetActive(false);
        panelActor3.SetActive(false);
        panelActor4.SetActive(false);

    }

    // Open Project Menu 
    public void OpenMainMenuAction()
    {
        if (panelActionsMenu.activeInHierarchy == true)
        {
            panelActionsMenu.SetActive(false);
        }

        else if (panelActionsMenu.activeInHierarchy == false)
        {
            panelActionsMenu.SetActive(true);
        }

        //hide Project Panel
        panelProjectStreetFurniture.SetActive(false);
        panelProjectPublicPark.SetActive(false);
        panelProjectFacadePainting.SetActive(false);
        panelProjectUniformFloorCovering.SetActive(false);
        panelProjectCreatingShadow.SetActive(false);
        panelProjectBuvette.SetActive(false);
        panelProjectJugendtreff.SetActive(false);
        panelProjectTiefgarage.SetActive(false);
        panelProjectPolizei.SetActive(false);
        panelProjectArealentwicklung.SetActive(false);
        panelProjectZentrum.SetActive(false);
        panelProjectJugendtreff.SetActive(false);
        panelProjectBrauiStairs.SetActive(false);

        //hide Project Pay Panel
        panelPayStreetFurniture.SetActive(false);
        panelPayPublicPark.SetActive(false);
        panelPayFacadePainting.SetActive(false);
        panelPayUniformFloorCovering.SetActive(false);
        panelPayCreatingShadow.SetActive(false);
        panelPayBuvette.SetActive(false);
        panelPayJugendtreff.SetActive(false);
        panelPayTiefgarage.SetActive(false);
        panelAufteilenTiefgarage.SetActive(false);
        panelPayPolizei.SetActive(false);
        panelPay400Arealentwicklung.SetActive(false);
        panelPay3x100Arealentwicklung.SetActive(false);
        panelRatenArealentwicklung.SetActive(false);
        panelPayZentrum.SetActive(false);
        panelPayJugendtreff.SetActive(false);
        panelPayBrauiStairs.SetActive(false);

        //hide Project Panel
        panelProjectsMenu.SetActive(false);
        panelNoOwner.SetActive(false);

        //hide Action Pay Panel
        panelPayAdditionalOfStorey.SetActive(false);
        panelPayCreateNewParkingLots.SetActive(false);
        panelPayRemoveParkingLots.SetActive(false);
        panelPayBuyNonPlayerBuilding.SetActive(false);
        panelPayBuyNonPlayerGarden.SetActive(false);

        //hide Actor Panel 
        panelActor1.SetActive(false);
        panelActor2.SetActive(false);
        panelActor3.SetActive(false);
        panelActor4.SetActive(false);

    }

    // Open Actor  
    public void OpenMainMenuActors()
    {
        string LocalPlayer = NetworkClient.localPlayer.gameObject.name.ToString();

        if (LocalPlayer == "Gemeinde")
        {
            if (panelActor1.activeInHierarchy == true)
            {
                panelActor1.SetActive(false);
            }

            else if (panelActor1.activeInHierarchy == false)
            {
                panelActor1.SetActive(true);
            }

        }

        if (LocalPlayer == "Landbesitzer")
        {

            if (panelActor2.activeInHierarchy == true)
            {
                panelActor2.SetActive(false);
            }

            else if (panelActor2.activeInHierarchy == false)
            {
                panelActor2.SetActive(true);
            }
        }

        if (LocalPlayer == "Genossenschaft")
        {

            if (panelActor3.activeInHierarchy == true)
            {
                panelActor3.SetActive(false);
            }

            else if (panelActor3.activeInHierarchy == false)
            {
                panelActor3.SetActive(true);
            }
        }

        if (LocalPlayer == "Kulturzentrum")
        {

            if (panelActor4.activeInHierarchy == true)
            {
                panelActor4.SetActive(false);
            }

            else if (panelActor4.activeInHierarchy == false)
            {
                panelActor4.SetActive(true);
            }
        }

        //hide Project Main Panel
        panelProjectsMenu.SetActive(false);

        //hide Project Panel
        panelProjectStreetFurniture.SetActive(false);
        panelProjectPublicPark.SetActive(false);
        panelProjectFacadePainting.SetActive(false);
        panelProjectUniformFloorCovering.SetActive(false);
        panelProjectCreatingShadow.SetActive(false);
        panelProjectBuvette.SetActive(false);
        panelProjectJugendtreff.SetActive(false);
        panelProjectTiefgarage.SetActive(false);
        panelProjectPolizei.SetActive(false);
        panelProjectArealentwicklung.SetActive(false);
        panelProjectZentrum.SetActive(false);
        panelProjectJugendtreff.SetActive(false);
        panelProjectBrauiStairs.SetActive(false);

        //hide Project Pay Panel
        panelPayStreetFurniture.SetActive(false);
        panelPayPublicPark.SetActive(false);
        panelPayFacadePainting.SetActive(false);
        panelPayUniformFloorCovering.SetActive(false);
        panelPayCreatingShadow.SetActive(false);
        panelPayBuvette.SetActive(false);
        panelPayJugendtreff.SetActive(false);
        panelPayTiefgarage.SetActive(false);
        panelAufteilenTiefgarage.SetActive(false);
        panelPayPolizei.SetActive(false);
        panelPay400Arealentwicklung.SetActive(false);
        panelPay3x100Arealentwicklung.SetActive(false);
        panelRatenArealentwicklung.SetActive(false);
        panelPayZentrum.SetActive(false);
        panelPayJugendtreff.SetActive(false);
        panelPayBrauiStairs.SetActive(false);

        //hide Action Panel
        panelActionsMenu.SetActive(false);
        panelNoOwner.SetActive(false);

        //hide Action Pay Panel
        panelPayAdditionalOfStorey.SetActive(false);
        panelPayCreateNewParkingLots.SetActive(false);
        panelPayRemoveParkingLots.SetActive(false);
        panelPayBuyNonPlayerBuilding.SetActive(false);
        panelPayBuyNonPlayerGarden.SetActive(false);

    }
}
