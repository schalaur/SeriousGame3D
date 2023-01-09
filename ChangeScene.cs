using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using Mirror;

using System.Linq;
using System.Text;
using System.IO;

public class ChangeScene : NetworkBehaviour
{
    [SyncVar]
    GameObject firingPlayerId;
    [SyncVar]
    bool Player1 = false;
    [SyncVar]
    bool Player2 = false;
    [SyncVar]
    bool Player3 = false;
    [SyncVar]
    bool Player4 = false;

    public void Scene00()
    {
        NetworkServer.SetAllClientsNotReady();
        NetworkManager.singleton.ServerChangeScene("00_Start");
    }

    public void Scene00x()
    {
        if (!isServer)
        {
            string PlayerName = NetworkClient.localPlayer.gameObject.name.ToString();

            CmdUpdateScene00x(PlayerName);
        }
        if (isServer)
        {
            NetworkServer.SetAllClientsNotReady();
            NetworkManager.singleton.ServerChangeScene("00_xGoals");

            Player1 = false;
            Player2 = false;
            Player3 = false;
            Player4 = false;
        }
    }

    [Command(requiresAuthority = false)]
    void CmdUpdateScene00x(string PlayerName)
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

        //TODO! 
        if (Player1 && Player2 && Player3 && Player4)
        //if (Player1 && Player2)

        {
            NetworkServer.SetAllClientsNotReady();
            NetworkManager.singleton.ServerChangeScene("00_xGoals");
            //NetworkManager.singleton.ServerChangeScene("01_AppealEffect"); //TODO
            //NetworkManager.singleton.ServerChangeScene("04_ProjectsActions");
            //NetworkManager.singleton.ServerChangeScene("05_Events");
            //NetworkManager.singleton.ServerChangeScene("03_Taxes");
            //NetworkManager.singleton.ServerChangeScene("02_PayOff");

            Player1 = false;
            Player2 = false;
            Player3 = false;
            Player4 = false;
        }
    }

    public void Scene01()
    {
        if (!isServer)
        {
            string PlayerName = NetworkClient.localPlayer.gameObject.name.ToString();

            CmdUpdateScene01(PlayerName);
        }

        if (isServer)
        {
            Player1 = false;
            Player2 = false;
            Player3 = false;
            Player4 = false;

            if (PlayerPrefs.GetInt("GameRunde") < 3) 
            {
                NetworkServer.SetAllClientsNotReady();
                NetworkManager.singleton.ServerChangeScene("01_AppealEffect");

                int GameRunde = PlayerPrefs.GetInt("GameRunde") + 1;

                PlayerPrefs.SetInt("GameRunde", GameRunde);
            }
            else if (PlayerPrefs.GetInt("GameRunde") == 3)
            {
                NetworkServer.SetAllClientsNotReady();
                NetworkManager.singleton.ServerChangeScene("Hochdorf");

                PlayerPrefs.SetInt("SpielEnde", 1);
            }
        }
    }

    [Command(requiresAuthority = false)]
    void CmdUpdateScene01(string PlayerName)
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

        if (Player1 && Player2 && Player3 && Player4)
        //if (Player1 && Player2)
        {
            if (PlayerPrefs.GetInt("GameRunde") < 3) 
            {
                NetworkServer.SetAllClientsNotReady();
                NetworkManager.singleton.ServerChangeScene("01_AppealEffect");

                Player1 = false;
                Player2 = false;
                Player3 = false;
                Player4 = false;
                int GameRunde = PlayerPrefs.GetInt("GameRunde") + 1;

                PlayerPrefs.SetInt("GameRunde", GameRunde);
            }
            else if (PlayerPrefs.GetInt("GameRunde") == 3)
            {
                NetworkServer.SetAllClientsNotReady();
                NetworkManager.singleton.ServerChangeScene("Hochdorf");

                PlayerPrefs.SetInt("SpielEnde", 1);
            }

        }
    }


    public void Scene02()
    {
        if (!isServer)
        {
            string PlayerName = NetworkClient.localPlayer.gameObject.name.ToString();

            CmdUpdateScene02(PlayerName);
        }

        if (isServer)
        {
            NetworkServer.SetAllClientsNotReady();
            NetworkManager.singleton.ServerChangeScene("02_PayOff");

            Player1 = false;
            Player2 = false;
            Player3 = false;
            Player4 = false;
        }
    }

    [Command(requiresAuthority = false)]
    void CmdUpdateScene02(string PlayerName)
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

        if (Player1 && Player2 && Player3 && Player4)
        //if (Player1 && Player2)
        {
            NetworkServer.SetAllClientsNotReady();
            NetworkManager.singleton.ServerChangeScene("02_PayOff");

            Player1 = false;
            Player2 = false;
            Player3 = false;
            Player4 = false;


        }
    }

    public void Scene03()
    {
        if (!isServer)
        {
            string PlayerName = NetworkClient.localPlayer.gameObject.name.ToString();

            CmdUpdateScene03(PlayerName);
        }

        if (isServer)
        {
            NetworkServer.SetAllClientsNotReady();
            NetworkManager.singleton.ServerChangeScene("03_Taxes");

            Player1 = false;
            Player2 = false;
            Player3 = false;
            Player4 = false;
        }
    }

    [Command(requiresAuthority = false)]
    void CmdUpdateScene03(string PlayerName)
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

        if (Player1 && Player2 && Player3 && Player4)
        //if (Player1 && Player2)
        {
            NetworkServer.SetAllClientsNotReady();
            NetworkManager.singleton.ServerChangeScene("03_Taxes");

            Player1 = false;
            Player2 = false;
            Player3 = false;
            Player4 = false;

        }
    }

    public void Scene04()
    {
        if (!isServer)
        {
            string PlayerName = NetworkClient.localPlayer.gameObject.name.ToString();

            CmdUpdateScene04(PlayerName);

        }
        if (isServer)
        {
            NetworkServer.SetAllClientsNotReady();
            NetworkManager.singleton.ServerChangeScene("04_ProjectsActions");

            Player1 = false;
            Player2 = false;
            Player3 = false;
            Player4 = false;
        }
    }

    [Command(requiresAuthority = false)] // Only Mun needs to accept; the others do not need to press any Button 
    void CmdUpdateScene04(string PlayerName)
    {
        NetworkServer.SetAllClientsNotReady();
        NetworkManager.singleton.ServerChangeScene("04_ProjectsActions");
    }

    public void Scene05()
    {
        if (!isServer)
        {
            string PlayerName = NetworkClient.localPlayer.gameObject.name.ToString();

            CmdUpdateScene05(PlayerName);
        }
        if (isServer)
        {
            NetworkServer.SetAllClientsNotReady();
            NetworkManager.singleton.ServerChangeScene("05_Events");

            Player1 = false;
            Player2 = false;
            Player3 = false;
            Player4 = false;
        }
    }

    [Command(requiresAuthority = false)]
    void CmdUpdateScene05(string PlayerName)
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

        if (Player1 && Player2 && Player3 && Player4)
        //if (Player1 && Player2)
        {
            NetworkServer.SetAllClientsNotReady();
            NetworkManager.singleton.ServerChangeScene("05_Events");

            Player1 = false;
            Player2 = false;
            Player3 = false;
            Player4 = false;

        }
    }

    public void SceneErkundung()
    {
        if (!isServer)
        {
            string PlayerName = NetworkClient.localPlayer.gameObject.name.ToString();

            CmdUpdateSceneErkundung(PlayerName);
        }

        if (isServer)
        {
            NetworkServer.SetAllClientsNotReady();
            NetworkManager.singleton.ServerChangeScene("Erkundung");

            Player1 = false;
            Player2 = false;
            Player3 = false;
            Player4 = false;
        }
    }

    [Command(requiresAuthority = false)]
    void CmdUpdateSceneErkundung(string PlayerName)
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

        if (Player1 && Player2 && Player3 && Player4)
        //if (Player1 && Player2)
        {
            NetworkServer.SetAllClientsNotReady();
            NetworkManager.singleton.ServerChangeScene("Erkundung");

            Player1 = false;
            Player2 = false;
            Player3 = false;
            Player4 = false;
        }
    }
    public void Scene06()
    {
        if (!isServer)
        {
            string PlayerName = NetworkClient.localPlayer.gameObject.name.ToString();

            CmdUpdateScene06(PlayerName);
        }

        if (isServer)
        {
            NetworkServer.SetAllClientsNotReady();
            NetworkManager.singleton.ServerChangeScene("06_Voting");

            Player1 = false;
            Player2 = false;
            Player3 = false;
            Player4 = false;
        }
    }

    [Command(requiresAuthority = false)]
    void CmdUpdateScene06(string PlayerName)
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

        if (Player1 && Player2 && Player3 && Player4)
        //if (Player1 && Player2)
        {
            NetworkServer.SetAllClientsNotReady();
            NetworkManager.singleton.ServerChangeScene("06_Voting");

            Player1 = false;
            Player2 = false;
            Player3 = false;
            Player4 = false;

        }
    }
}
