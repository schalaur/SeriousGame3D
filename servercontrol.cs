using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

using System.Linq;
using System.Text;
using System.IO;

public class servercontrol : NetworkBehaviour
{
    public Text servertext;
    public GameObject PanelServer;

    [SyncVar]
    bool Player1 = false;
    [SyncVar]
    bool Player2 = false;
    [SyncVar]
    bool Player3 = false;
    [SyncVar]
    bool Player4 = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isServer)
        {
            PanelServer.SetActive(true);
            FindAll();
        }



    }

    private void FindAll()
    {
        Object[] tempList = Resources.FindObjectsOfTypeAll(typeof(GameObject));
        List<GameObject> realList = new List<GameObject>();
        GameObject temp;

        foreach (Object obj in tempList)
        {
            if (obj is GameObject)
            {
                temp = (GameObject)obj;
                if (temp.hideFlags == HideFlags.None)
                    realList.Add((GameObject)obj);
            }
        }

        string result = "eingeloggt: ";
        foreach (var item in realList)
        {
            if (item.name == "Gemeinde")
            {
                result += item.name.ToString() + ", ";
            }
            if (item.name == "Landbesitzer")
            {
                result += item.name.ToString() + ", ";
            }
            if (item.name == "Kulturzentrum")
            {
                result += item.name.ToString() + ", ";
            }
            if (item.name == "Genossenschaft")
            {
                result += item.name.ToString() + ", ";
            }

        }

        servertext.text = result;
    }

    public void Scene00x()
    {
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
}
