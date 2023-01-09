using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;


using System.Linq;
using System.Text;
using System.IO;

public class S01_PlayerDependent : NetworkBehaviour
{
    public Text PlayerName;
    public Text PlayerAsset;

    [SyncVar]
    int AssetPlayer1;
    [SyncVar]
    int AssetPlayer2;
    [SyncVar]
    int AssetPlayer3;
    [SyncVar]
    int AssetPlayer4;

    // Start is called before the first frame update
    void Start()
    {
        if (isServer)
        {
        }

        if (isServer)
        {
            using (StreamWriter sw = File.AppendText(@"Z:\people\schalaur\Globescape\13_RecordingGame\Log.txt"))
            {
                sw.WriteLine(System.DateTime.Now.ToString("HH:mm:ss").ToString() + " Started Scene 01 Appeal & Approval");
                sw.Close();
            }
            AssetPlayer1 = PlayerPrefs.GetInt("A1MomAsset");
            AssetPlayer2 = PlayerPrefs.GetInt("A2MomAsset");
            AssetPlayer3 = PlayerPrefs.GetInt("A3MomAsset");
            AssetPlayer4 = PlayerPrefs.GetInt("A4MomAsset");
        }
        Starting(AssetPlayer1, AssetPlayer2, AssetPlayer3, AssetPlayer4);
    }

    // Update is called once per frame
    void Update()
    {
        if (isServer)
        {
            AssetPlayer1 = PlayerPrefs.GetInt("A1MomAsset");
            AssetPlayer2 = PlayerPrefs.GetInt("A2MomAsset");
            AssetPlayer3 = PlayerPrefs.GetInt("A3MomAsset");
            AssetPlayer4 = PlayerPrefs.GetInt("A4MomAsset");
        }

        Starting(AssetPlayer1, AssetPlayer2, AssetPlayer3, AssetPlayer4);
    }

    void Starting(int AssetPlayer1, int AssetPlayer2, int AssetPlayer3, int AssetPlayer4)
    {
        if (!isServer)
        {
            string LocalPlayer = NetworkClient.localPlayer.gameObject.name.ToString();

            if (LocalPlayer == "Gemeinde")
            {
                PlayerName.text = "Gemeinde";
                PlayerAsset.text = AssetPlayer1.ToString() + " CHF";
            }

            if (LocalPlayer == "Landbesitzer")
            {
                PlayerName.text = "Landbesitzer";
                PlayerAsset.text = AssetPlayer2.ToString() + " CHF";
            }

            if (LocalPlayer == "Genossenschaft")
            {
                PlayerName.text = "Genossenschaft";
                PlayerAsset.text = AssetPlayer3.ToString() + " CHF";
            }

            if (LocalPlayer == "Kulturzentrum")
            {
                PlayerName.text = "Kulturzentrum";
                PlayerAsset.text = AssetPlayer4.ToString() + " CHF";
            }
        }
    }
    
}
