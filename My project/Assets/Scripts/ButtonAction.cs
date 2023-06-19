using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using TMPro;

public class ButtonAction : MonoBehaviour
{
    NetworkManager NetworkManager;
    public TextMeshProUGUI text;
    
    void Start()
    {
        NetworkManager = GetComponentInParent<NetworkManager>();
    }

    public void StartHost()
    {
        NetworkManager.StartHost();
        InitMovementText();
    }
    public void StartClient()
    {
        NetworkManager.StartClient();
        InitMovementText();
    }
    public void InitMovementText()
    {
        if(NetworkManager.Singleton.IsServer || NetworkManager.Singleton.IsHost)
        {
            text.text = "Move";
        }
        else if(NetworkManager.Singleton.IsClient)
        {
            text.text = "Request Move";


        }
        

    }
}
