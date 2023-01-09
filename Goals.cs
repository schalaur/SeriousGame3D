using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

using System.Linq;
using System.Text;
using System.IO;

public class Goals : NetworkBehaviour
{
    public GameObject PanelPlayer1;
    public GameObject PanelPlayer2;
    public GameObject PanelPlayer3;
    public GameObject PanelPlayer4;



    // Start is called before the first frame update
    void Start()
    {
        if (isServer)
        {
            using (StreamWriter sw = File.AppendText(@"E:\schalaur_globescape\01_Unity\UnityLog.txt"))
            {
                sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " " + "Scene 00_xGoals started");
                sw.Close();
            }
        }
  }

    void Update()
    {
        if (!isServer)
        {
            string LocalPlayer = NetworkClient.localPlayer.gameObject.name.ToString();

            if (LocalPlayer == "Gemeinde")
            {
                PanelPlayer1.SetActive(true);
            }

            if (LocalPlayer == "Landbesitzer")
            {
                PanelPlayer2.SetActive(true);
            }

            if (LocalPlayer == "Genossenschaft")
            {
                PanelPlayer3.SetActive(true);
            }

            if (LocalPlayer == "Kulturzentrum")
            {
                PanelPlayer4.SetActive(true);
            }
        }
    }
}
