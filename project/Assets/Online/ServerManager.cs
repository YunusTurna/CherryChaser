using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class ServerManager : MonoBehaviourPunCallbacks
{
    

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.Instantiate("Pumpkin", new Vector3(4, 4, 14), Quaternion.identity, 0, null);
    }

    
        
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("servere baðlandý");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("lobiye baðlandý");
        PhotonNetwork.JoinOrCreateRoom(roomName: "odaismi", new RoomOptions { MaxPlayers=5,IsOpen= true,IsVisible=true}, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("odaya girildi");
        PhotonNetwork.Instantiate("Pumpkin", new Vector3(4, 4, 14), Quaternion.identity, 0, null);
    }
    
   

}
