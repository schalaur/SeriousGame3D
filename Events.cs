using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;


using System.Linq;
using System.Text;
using System.IO;


using UnityEngine.SceneManagement;

public class Events : NetworkBehaviour
{
    public GameObject[] EventArray;
    public Button ButtonNextEvent;
    string[] ArrayName;

    GameObject GameCurrentEvent;
    GameObject Canvas;
    GameObject Panel;

    [SyncVar]
    string currentEvent;
    [SyncVar]
    int IndexEvent;

    [SyncVar]
    int EventRunde;

    int round;
    List<string> ListName;

    void Start()
    {
        if (isServer)
        {
            using (StreamWriter sw = File.AppendText(@"Z:\people\schalaur\Globescape\13_RecordingGame\Log.txt"))
            {
                sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " " + "Starting the Events! ");
                sw.Close();
            }

            PlayerPrefs.SetInt("EventRunde", 0);

            ArrayName = new string[EventArray.Length];

            for (int i = 0; i < EventArray.Length; i++)
            {
                ArrayName[i] = EventArray[i].name;
            }
            ListName = ArrayName.ToList();
        }


        Canvas = GameObject.Find("Canvas_Events");
        Panel = Canvas.transform.Find("Panel_Events").gameObject;
        currentEvent = "Panel_HeruntergekommeneFassaden";

        ButtonNextEvent.GetComponentInChildren<Text>().text = "Für nächsten Event hier drücken";

    }


    [ClientRpc]
    void RpcTellAllClientsToUpdateHuds(int newint)
    {
        EventRunde = newint;
    }


    void Update()
    {
        if (isServer)
        {
            ButtonNextEvent.gameObject.SetActive(true);
        }

        if (!isServer)
        {
            if (EventRunde == 0)
            {
                string PlayerName = NetworkClient.localPlayer.gameObject.name.ToString();
                if (PlayerName == "Kulturzentrum") //TODO: Kulturzentrum
                {
                    ButtonNextEvent.gameObject.SetActive(true);
                }
                else
                {
                    ButtonNextEvent.gameObject.SetActive(false);
                }
            }

            if (EventRunde == 1)
            {
                string PlayerName = NetworkClient.localPlayer.gameObject.name.ToString();
                if (PlayerName == "Landbesitzer") //TODO: Landbesitzer
                {
                    ButtonNextEvent.gameObject.SetActive(true);
                }
                else
                {
                    ButtonNextEvent.gameObject.SetActive(false);
                }
            }

            if (EventRunde == 2)
            {
                string PlayerName = NetworkClient.localPlayer.gameObject.name.ToString();
                if (PlayerName == "Genossenschaft") //TODO: Genossenschaft
                {
                    ButtonNextEvent.gameObject.SetActive(true);
                }
                else
                {
                    ButtonNextEvent.gameObject.SetActive(false);
                }
            }

            if (EventRunde >= 3)
            {
                string PlayerName = NetworkClient.localPlayer.gameObject.name.ToString();
                if (PlayerName == "Gemeinde")
                {
                    ButtonNextEvent.GetComponentInChildren<Text>().text = "Weiter zum Voting";
                    ButtonNextEvent.gameObject.SetActive(true);
                }
                else
                {
                    ButtonNextEvent.gameObject.SetActive(false);
                }
            }

        }

    }

    public void EventMixer()
    {
        if (!isServer)
        {
            string PlayerName = NetworkClient.localPlayer.gameObject.name.ToString();

            if (PlayerName == "Kulturzentrum" && EventRunde == 0)
            {
                CmdCallServer();
            }
            else if (PlayerName == "Landbesitzer" && EventRunde == 1) //TODO: Landbesitzer
            {
                CmdCallServer();
            }
            else if (PlayerName == "Genossenschaft" && EventRunde == 2) //TODO: Genossenschaft
            {
                CmdCallServer();
            }
            else if (PlayerName == "Gemeinde" && EventRunde == 3)
            {
                CmdUpdateScene06();
            }

        }

        if (isServer)
        {
            if (PlayerPrefs.GetInt("EventRunde") <= 3)
            {
                string oldEvent = currentEvent;
                CloseEvent(oldEvent);

                IndexEvent = Random.Range(0, ListName.Count);
                currentEvent = ListName[IndexEvent];

                ListName.RemoveAt(IndexEvent);

                ReadEvent(currentEvent);
                RpcCallClients(oldEvent, currentEvent);

                round = PlayerPrefs.GetInt("EventRunde") + 1;
                PlayerPrefs.SetInt("EventRunde", round);

                RpcTellAllClientsToUpdateHuds(round);
            }
            if (PlayerPrefs.GetInt("EventRunde") > 3)
            {
                NetworkServer.SetAllClientsNotReady();
                NetworkManager.singleton.ServerChangeScene("06_Voting");
            }
        }

    }

    [Command(requiresAuthority = false)]
    void CmdCallServer()
    {
        string oldEvent = currentEvent;
        CloseEvent(oldEvent);

        IndexEvent = Random.Range(0, ListName.Count);
        currentEvent = ListName[IndexEvent];

        ListName.RemoveAt(IndexEvent);

        ReadEvent(currentEvent);
        RpcCallClients(oldEvent, currentEvent);

        round = PlayerPrefs.GetInt("EventRunde") + 1;
        PlayerPrefs.SetInt("EventRunde", round);

        RpcTellAllClientsToUpdateHuds(round);

    }

    [ClientRpc]
    void RpcCallClients(string oldEventServer, string currentEventServer)
    {
        CloseEvent(oldEventServer);

        ReadEventClient(currentEventServer);

    }



    void CloseEvent(string closeEventName)
    {
        GameCurrentEvent = Panel.transform.Find(closeEventName).gameObject;
        GameCurrentEvent.SetActive(false);

    }

    void ReadEvent(string currentEvent)
    {
        if (isServer)
        {
            
        }

        if (currentEvent == "Panel_HeruntergekommeneFassaden")
        {

            PlayerPrefs.SetInt("Fassaden", 1);
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);

            if (PlayerPrefs.GetInt("FacadePainting") == 0)
            {
                int tempAppeal = PlayerPrefs.GetInt("Appeal") - 1;

                PlayerPrefs.SetInt("Appeal", tempAppeal);
            }

            if (isServer)
            {
                using (StreamWriter sw = File.AppendText(@"Z:\people\schalaur\Globescape\13_RecordingGame\Log.txt"))
                {
                    sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " " + round + ". Event to show: " + currentEvent);
                    sw.Close();
                }

            }
        }

        else if (currentEvent == "Panel_Tempo30")
        {

            PlayerPrefs.SetInt("Tempo30", 1);
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);

            int tempAppeal = PlayerPrefs.GetInt("Appeal") + 1;
            int tempApproval = PlayerPrefs.GetInt("Approval") - 1;

            PlayerPrefs.SetInt("Appeal", tempAppeal);
            PlayerPrefs.SetInt("Approval", tempApproval);

            if (isServer)
            {
                using (StreamWriter sw = File.AppendText(@"Z:\people\schalaur\Globescape\13_RecordingGame\Log.txt"))
                {
                    sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " " + round + ". Event to show: " + currentEvent);
                    sw.Close();
                }

            }
        }

        else if (currentEvent == "Panel_Dorfzentrum")
        {

            PlayerPrefs.SetInt("Dorfzentrum", 1);
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);


            // Falls Fasaden gemalt
            if (PlayerPrefs.GetInt("FacadePainting") == 1)
            {
                int tempAppeal = PlayerPrefs.GetInt("Appeal") + 1;
                int tempApproval = PlayerPrefs.GetInt("Approval") + 1;
                int tempAssetA1 = PlayerPrefs.GetInt("A1MomAsset") + 20;

                PlayerPrefs.SetInt("Appeal", tempAppeal);
                PlayerPrefs.SetInt("Approval", tempApproval);
                PlayerPrefs.SetInt("A1MomAsset", tempAssetA1);
            }

            if (isServer)
            {
                using (StreamWriter sw = File.AppendText(@"Z:\people\schalaur\Globescape\13_RecordingGame\Log.txt"))
                {
                    sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " " + round + ". Event to show: " + currentEvent);
                    sw.Close();
                }
            }
        }

        else if (currentEvent == "Panel_GrauesQuartier")
        {
            PlayerPrefs.SetInt("GrauesQuartier", 1);
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);

            int Parkfelder = PlayerPrefs.GetInt("A1CountParkingLot") + PlayerPrefs.GetInt("A2CountParkingLot") + PlayerPrefs.GetInt("A3CountParkingLot") + PlayerPrefs.GetInt("A4CountParkingLot") + PlayerPrefs.GetInt("A1CountAppartmentParkingLot") + PlayerPrefs.GetInt("A2CountAppartmentParkingLot") + PlayerPrefs.GetInt("A3CountAppartmentParkingLot") + PlayerPrefs.GetInt("A4CountAppartmentParkingLot");
            if (Parkfelder > 4 && PlayerPrefs.GetInt("PublicPark") == 0)
            {
                int tempAppeal = PlayerPrefs.GetInt("Appeal");
                int tempApproval = PlayerPrefs.GetInt("Approval");

                PlayerPrefs.SetInt("Appeal", tempAppeal);
                PlayerPrefs.SetInt("Approval", tempApproval);
            }
            if (isServer)
            {
                using (StreamWriter sw = File.AppendText(@"Z:\people\schalaur\Globescape\13_RecordingGame\Log.txt"))
                {
                    sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " " + round + ". Event to show: " + currentEvent);
                    sw.Close();
                }

            }
        }

        else if (currentEvent == "Panel_UnterhaltPark")
        {
            PlayerPrefs.SetInt("UnterhaltPark", 1);
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);


            // Falls öffentlicher Park vorhanden

            if (PlayerPrefs.GetInt("PublicPark") == 1)
            {
                int TempMomAssetA1 = PlayerPrefs.GetInt("A1MomAsset") - 4;
                PlayerPrefs.SetInt("A1MomAsset", TempMomAssetA1);
            }

            if (isServer)
            {
                using (StreamWriter sw = File.AppendText(@"Z:\people\schalaur\Globescape\13_RecordingGame\Log.txt"))
                {
                    sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " " + round + ". Event to show: " + currentEvent);
                    sw.Close();
                }
            }

        }

        else if (currentEvent == "Panel_Graffiti")
        {
            PlayerPrefs.SetInt("UnterhaltPark", 1);
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);

            if (PlayerPrefs.GetInt("Appeal") <= 0 && PlayerPrefs.GetInt("Jugendtreff") == 0)
            {
                // -1 CHF pro 4 Appartements 
                int TempAppartmentsA1 = PlayerPrefs.GetInt("A1CountAppartment") + PlayerPrefs.GetInt("A1CountAppartmentParkingLot") + PlayerPrefs.GetInt("A1CountAppartmentGarden");
                int TempAppartmentsA2 = PlayerPrefs.GetInt("A2CountParkingLot") + PlayerPrefs.GetInt("A2CountAppartmentParkingLot") + PlayerPrefs.GetInt("A2CountAppartmentGarden"); ;
                int TempAppartmentsA3 = PlayerPrefs.GetInt("A3CountParkingLot") + PlayerPrefs.GetInt("A3CountAppartmentParkingLot") + PlayerPrefs.GetInt("A3CountAppartmentGarden"); ;
                int TempAppartmentsA4 = PlayerPrefs.GetInt("A4CountParkingLot") + PlayerPrefs.GetInt("A4CountAppartmentParkingLot") + PlayerPrefs.GetInt("A4CountAppartmentGarden"); ;

                int TempPayA1 = TempAppartmentsA1 / 4;
                int TempPayA2 = TempAppartmentsA2 / 4;
                int TempPayA3 = TempAppartmentsA3 / 4;
                int TempPayA4 = TempAppartmentsA4 / 4;

                int TempAssetA1 = PlayerPrefs.GetInt("A1MomAsset") - TempPayA1;
                int TempAssetA2 = PlayerPrefs.GetInt("A2MomAsset") - TempPayA2;
                int TempAssetA3 = PlayerPrefs.GetInt("A3MomAsset") - TempPayA3;
                int TempAssetA4 = PlayerPrefs.GetInt("A4MomAsset") - TempPayA4;

                int tempAppeal = PlayerPrefs.GetInt("Appeal") - 1;
                int tempApproval = PlayerPrefs.GetInt("Approval") - 1;

                PlayerPrefs.SetInt("A1MomAsset", TempAssetA1);
                PlayerPrefs.SetInt("A2MomAsset", TempAssetA2);
                PlayerPrefs.SetInt("A3MomAsset", TempAssetA3);
                PlayerPrefs.SetInt("A4MomAsset", TempAssetA4);

                PlayerPrefs.SetInt("Appeal", tempAppeal);
                PlayerPrefs.SetInt("Approval", tempApproval);
            }

            if (isServer)
            {
                using (StreamWriter sw = File.AppendText(@"Z:\people\schalaur\Globescape\13_RecordingGame\Log.txt"))
                {
                    sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " " + round + ". Event to show: " + currentEvent);
                    sw.Close();
                }
            }

        }

        else if (currentEvent == "Panel_Nachbardorf")
        {
            PlayerPrefs.SetInt("Nachbardorf", 1);
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);

            int tempAppeal = PlayerPrefs.GetInt("Appeal") - 1;

            PlayerPrefs.SetInt("Appeal", tempAppeal);

            if (isServer)
            {
                using (StreamWriter sw = File.AppendText(@"Z:\people\schalaur\Globescape\13_RecordingGame\Log.txt"))
                {
                    sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " " + round + ". Event to show: " + currentEvent);
                    sw.Close();
                }
            }
        }

        else if (currentEvent == "Panel_BewertungBraui")
        {
            PlayerPrefs.SetInt("BewertungBraui", 1);
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);

            int tempAppeal = PlayerPrefs.GetInt("Appeal") + 1;
            int tempAssetA4 = PlayerPrefs.GetInt("A4MomAsset") + 5;

            PlayerPrefs.SetInt("Appeal", tempAppeal);
            PlayerPrefs.SetInt("A4MomAsset", tempAssetA4);

            if (isServer)
            {
                using (StreamWriter sw = File.AppendText(@"Z:\people\schalaur\Globescape\13_RecordingGame\Log.txt"))
                {
                    sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " " + round + ". Event to show: " + currentEvent);
                    sw.Close();
                }
            }
        }

        else if (currentEvent == "Panel_ParkplaetzeVeranstaltungen")
        {
            PlayerPrefs.SetInt("ParkplaetzeVeranstaltungen", 1);
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);


            if (PlayerPrefs.GetInt("Appeal") > 0 && PlayerPrefs.GetInt("Tiefgarage") == 0)
            {
                int tempAppeal = PlayerPrefs.GetInt("Appeal") - 2;
                PlayerPrefs.SetInt("Appeal", tempAppeal);
            }
            if (isServer)
            {
                using (StreamWriter sw = File.AppendText(@"Z:\people\schalaur\Globescape\13_RecordingGame\Log.txt"))
                {
                    sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " " + round + ". Event to show: " + currentEvent);
                    sw.Close();
                }
            }
        }

        else if (currentEvent == "Panel_Nachtruhestoerung")
        {
            PlayerPrefs.SetInt("Nachtruhestoerung", 1);
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);


            if (PlayerPrefs.GetInt("Buvette") == 1 && PlayerPrefs.GetInt("Polizei") == 0)
            {
                int tempAppeal = PlayerPrefs.GetInt("Appeal") - 1;
                PlayerPrefs.SetInt("Appeal", tempAppeal);
                int tempApproval = PlayerPrefs.GetInt("Approval") - 1;
                PlayerPrefs.SetInt("Approval", tempApproval);
            }
            if (isServer)
            {
                using (StreamWriter sw = File.AppendText(@"Z:\people\schalaur\Globescape\13_RecordingGame\Log.txt"))
                {
                    sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " " + round + ". Event to show: " + currentEvent);
                    sw.Close();
                }

            }
        }

        else if (currentEvent == "Panel_Corona")
        {

            PlayerPrefs.SetInt("Corona", 1);
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);

            int tempShopA1 = 2 * PlayerPrefs.GetInt("A1CountShop");
            int tempParkplatzA1 = 2 * PlayerPrefs.GetInt("A1CountParkingLot");
            int tempAppartmentParkplatzA1 = 2 * PlayerPrefs.GetInt("A1CountAppartmentParkingLot");
            int tempTiefgarageA1 = 2 * PlayerPrefs.GetInt("A1CountTiefgarageParkingLot");
            int tempAssetA1 = PlayerPrefs.GetInt("A1MomAsset") - tempShopA1 - tempParkplatzA1 - tempAppartmentParkplatzA1 - tempTiefgarageA1;
            PlayerPrefs.SetInt("A1MomAsset", tempAssetA1);

            int tempShopA2 = 2 * PlayerPrefs.GetInt("A2CountShop");
            int tempParkplatzA2 = 2 * PlayerPrefs.GetInt("A2CountParkingLot");
            int tempAppartmentParkplatzA2 = 2 * PlayerPrefs.GetInt("A2CountAppartmentParkingLot");
            int tempTiefgarageA2 = 2 * PlayerPrefs.GetInt("A2CountTiefgarageParkingLot");
            int tempAssetA2 = PlayerPrefs.GetInt("A2MomAsset") - tempShopA2 - tempParkplatzA2 - tempAppartmentParkplatzA2 - tempTiefgarageA2;
            PlayerPrefs.SetInt("A2MomAsset", tempAssetA2);

            int tempShopA3 = 2 * PlayerPrefs.GetInt("A3CountShop");
            int tempParkplatzA3 = 2 * PlayerPrefs.GetInt("A3CountParkingLot");
            int tempAppartmentParkplatzA3 = 2 * PlayerPrefs.GetInt("A3CountAppartmentParkingLot");
            int tempTiefgarageA3 = 2 * PlayerPrefs.GetInt("A3CountTiefgarageParkingLot");
            int tempAssetA3 = PlayerPrefs.GetInt("A3MomAsset") - tempShopA3 - tempParkplatzA3 - tempAppartmentParkplatzA3 - tempTiefgarageA3;
            PlayerPrefs.SetInt("A3MomAsset", tempAssetA3);

            int tempShopA4 = 2 * PlayerPrefs.GetInt("A4CountShop");
            int tempParkplatzA4 = 2 * PlayerPrefs.GetInt("A4CountParkingLot");
            int tempAppartmentParkplatzA4 = 2 * PlayerPrefs.GetInt("A4CountAppartmentParkingLot");
            int tempTiefgarageA4 = 2 * PlayerPrefs.GetInt("A4CountTiefgarageParkingLot");
            int tempAssetA4 = PlayerPrefs.GetInt("A4MomAsset") - tempShopA4 - tempParkplatzA4 - tempAppartmentParkplatzA4 - tempTiefgarageA4;
            PlayerPrefs.SetInt("A4MomAsset", tempAssetA4);

            if (isServer)
            {
                using (StreamWriter sw = File.AppendText(@"Z:\people\schalaur\Globescape\13_RecordingGame\Log.txt"))
                {
                    sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " " + round + ". Event to show: " + currentEvent);
                    sw.Close();
                }
            }
        }

        else if (currentEvent == "Panel_Hitzewelle")
        {

            PlayerPrefs.SetInt("Hitzewelle", 1);
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);


            if (PlayerPrefs.GetInt("CreatingShadow") == 0)
            {
                int tempAppeal = PlayerPrefs.GetInt("Appeal") - 1;
                PlayerPrefs.SetInt("Appeal", tempAppeal);
                int tempApproval = PlayerPrefs.GetInt("Approval") - 1;
                PlayerPrefs.SetInt("Approval", tempApproval);
            }
            if (isServer)
            {
                using (StreamWriter sw = File.AppendText(@"Z:\people\schalaur\Globescape\13_RecordingGame\Log.txt"))
                {
                    sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " " + round + ". Event to show: " + currentEvent);
                    sw.Close();
                }
            }
        }

        else if (currentEvent == "Panel_Sitzgelegenheit")
        {

            PlayerPrefs.SetInt("Hitzewelle", 1);
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);


            if (PlayerPrefs.GetInt("StreetFurniture") == 1)
            {
                int tempAppeal = PlayerPrefs.GetInt("Appeal") + 1;
                PlayerPrefs.SetInt("Appeal", tempAppeal);
            }
            if (isServer)
            {
                using (StreamWriter sw = File.AppendText(@"Z:\people\schalaur\Globescape\13_RecordingGame\Log.txt"))
                {
                    sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " " + round + ". Event to show: " + currentEvent);
                    sw.Close();
                }

            }
        }

        else if (currentEvent == "Panel_Diskussion")
        {

            PlayerPrefs.SetInt("Diskussion", 1);
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);


            if (PlayerPrefs.GetInt("StreetFurniture") == 1 && PlayerPrefs.GetInt("Polizei") == 0)
            {
                int tempAppeal = PlayerPrefs.GetInt("Appeal") - 1;
                PlayerPrefs.SetInt("Appeal", tempAppeal);
                int tempApproval = PlayerPrefs.GetInt("Approval") - 1;
                PlayerPrefs.SetInt("Approval", tempApproval);
            }
            if (isServer)
            {
                using (StreamWriter sw = File.AppendText(@"Z:\people\schalaur\Globescape\13_RecordingGame\Log.txt"))
                {
                    sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " " + round + ". Event to show: " + currentEvent);
                    sw.Close();
                }

            }
        }

        else if (currentEvent == "Panel_WohnraumFamilien")
        {

            PlayerPrefs.SetInt("WohnraumFamilien", 1);
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);


            if (PlayerPrefs.GetInt("Arealantwicklung") == 0)
            {
                int tempAppeal = PlayerPrefs.GetInt("Appeal") - 1;
                PlayerPrefs.SetInt("Appeal", tempAppeal);
                int tempApproval = PlayerPrefs.GetInt("Approval") - 1;
                PlayerPrefs.SetInt("Approval", tempApproval);
            }
            if (isServer)
            {
                using (StreamWriter sw = File.AppendText(@"Z:\people\schalaur\Globescape\13_RecordingGame\Log.txt"))
                {
                    sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " " + round + ". Event to show: " + currentEvent);
                    sw.Close();
                }
            }
        }

        else if (currentEvent == "Panel_Ueberalterung")
        {
            PlayerPrefs.SetInt("Ueberalterung", 1);
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);


            if (PlayerPrefs.GetInt("Arealantwicklung") == 0 || PlayerPrefs.GetInt("Zentrum") == 0 || PlayerPrefs.GetInt("StreetFurniture") == 0)
            {
                int tempApproval = PlayerPrefs.GetInt("Approval") - 2;
                PlayerPrefs.SetInt("Approval", tempApproval);
            }
            if (isServer)
            {
                using (StreamWriter sw = File.AppendText(@"Z:\people\schalaur\Globescape\13_RecordingGame\Log.txt"))
                {
                    sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " " + round + ". Event to show: " + currentEvent);
                    sw.Close();
                }
            }
        }

        else if (currentEvent == "Panel_Jugendliche")
        {
            PlayerPrefs.SetInt("Jugendliche", 1);
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);


            if (PlayerPrefs.GetInt("Jugendtreff") == 0)
            {
                int tempApproval = PlayerPrefs.GetInt("Approval") - 1;
                PlayerPrefs.SetInt("Approval", tempApproval);
                int tempAppeal = PlayerPrefs.GetInt("Appeal") - 1;
                PlayerPrefs.SetInt("Appeal", tempAppeal);
            }
            if (isServer)
            {
                using (StreamWriter sw = File.AppendText(@"Z:\people\schalaur\Globescape\13_RecordingGame\Log.txt"))
                {
                    sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " " + round + ". Event to show: " + currentEvent);
                    sw.Close();
                }
            }
        }

        else if (currentEvent == "Panel_Fussgaengerzone")
        {
            PlayerPrefs.SetInt("Fussgaengerzone", 1);
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);


            if (PlayerPrefs.GetInt("Pedestrian") == 1)
            {
                int tempCountShopA1 = PlayerPrefs.GetInt("A1CountShop") * 2;
                int tempAssetA1 = PlayerPrefs.GetInt("A1MomAsset") + tempCountShopA1;
                PlayerPrefs.SetInt("A1MomAsset", tempAssetA1);

                int tempCountShopA2 = PlayerPrefs.GetInt("A2CountShop") * 2;
                int tempAssetA2 = PlayerPrefs.GetInt("A2MomAsset") + tempCountShopA2;
                PlayerPrefs.SetInt("A2MomAsset", tempAssetA2);

                int tempCountShopA3 = PlayerPrefs.GetInt("A3CountShop") * 2;
                int tempAssetA3 = PlayerPrefs.GetInt("A3MomAsset") + tempCountShopA3;
                PlayerPrefs.SetInt("A3MomAsset", tempAssetA3);

                int tempCountShopA4 = PlayerPrefs.GetInt("A4CountShop") * 2;
                int tempAssetA4 = PlayerPrefs.GetInt("A4MomAsset") + tempCountShopA4;
                PlayerPrefs.SetInt("A4MomAsset", tempAssetA4);

            }
            if (isServer)
            {
                using (StreamWriter sw = File.AppendText(@"Z:\people\schalaur\Globescape\13_RecordingGame\Log.txt"))
                {
                    sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " " + round + ". Event to show: " + currentEvent);
                    sw.Close();
                }
            }
        }

        else if (currentEvent == "Panel_AnpassungKlimawandel")
        {

            PlayerPrefs.SetInt("AnpassungKlimawandel", 1);
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);

            if (isServer)
            {
                using (StreamWriter sw = File.AppendText(@"Z:\people\schalaur\Globescape\13_RecordingGame\Log.txt"))
                {
                    sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " " + round + ". Event to show: " + currentEvent);
                    sw.Close();
                }
            }

        }

        else if (currentEvent == "Panel_FoerderungWohnraum")
        {

            PlayerPrefs.SetInt("FoerderungWohnraum", 1);
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);

            if (isServer)
            {
                using (StreamWriter sw = File.AppendText(@"Z:\people\schalaur\Globescape\13_RecordingGame\Log.txt"))
                {
                    sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " " + round + ". Event to show: " + currentEvent);
                    sw.Close();
                }
            }
        }

    }

    void ReadEventClient(string currentEvent)
    {
        if (currentEvent == "Panel_HeruntergekommeneFassaden")
        {
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);
        }

        else if (currentEvent == "Panel_Tempo30")
        {
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);
        }

        else if (currentEvent == "Panel_Dorfzentrum")
        {
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);
        }

        else if (currentEvent == "Panel_GrauesQuartier")
        {
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);
        }

        else if (currentEvent == "Panel_UnterhaltPark")
        {
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);
        }

        else if (currentEvent == "Panel_Graffiti")
        {
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);
        }

        else if (currentEvent == "Panel_Nachbardorf")
        {
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);
        }

        else if (currentEvent == "Panel_BewertungBraui")
        {
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);
        }

        else if (currentEvent == "Panel_ParkplaetzeVeranstaltungen")
        {
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);
        }

        else if (currentEvent == "Panel_Nachtruhestoerung")
        {
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);
        }

        else if (currentEvent == "Panel_Corona")
        {
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);
        }

        else if (currentEvent == "Panel_Hitzewelle")
        {
            PlayerPrefs.SetInt("Hitzewelle", 1);
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);
        }

        else if (currentEvent == "Panel_Sitzgelegenheit")
        {
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);
        }

        else if (currentEvent == "Panel_Diskussion")
        {
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);
        }

        else if (currentEvent == "Panel_WohnraumFamilien")
        {
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);
        }

        else if (currentEvent == "Panel_Ueberalterung")
        {
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);
        }

        else if (currentEvent == "Panel_Jugendliche")
        {
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);
        }

        else if (currentEvent == "Panel_Fussgaengerzone")
        {
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);
        }

        else if (currentEvent == "Panel_AnpassungKlimawandel")
        {
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
        }

        else if (currentEvent == "Panel_FoerderungWohnraum")
        {
            GameCurrentEvent = Panel.transform.Find(currentEvent).gameObject;
            GameCurrentEvent.SetActive(true);
            ButtonNextEvent.gameObject.SetActive(false);
        }

    }

    public void Scene06()
    {

        CmdUpdateScene06();

    }

    [Command(requiresAuthority = false)]
    void CmdUpdateScene06()
    {
        NetworkServer.SetAllClientsNotReady();
        NetworkManager.singleton.ServerChangeScene("06_Voting");
    }


}
