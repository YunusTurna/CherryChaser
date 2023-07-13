using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;


public class ServerManager : MonoBehaviourPunCallbacks
{
    public Sunucu snc;

    void Start()
    {
        snc = new Sunucu();
        PhotonNetwork.ConnectUsingSettings();
        //snc.KarakterSeçimi();

        /*if (snc.birinciKarakter==true)
        {
            PhotonNetwork.Instantiate("Pumpkin", new Vector3(4, 4, 14), Quaternion.identity, 0, null);
            Debug.Log("111111111111111");
        }
        else if (snc.ikinciKarakter == true)
        {
            PhotonNetwork.Instantiate("Pumpkin", new Vector3(4, 4, 14), Quaternion.identity, 0, null);
            Debug.Log("222222222222");
        }
        else if (snc.üçüncüKarakter == true)
        {
            PhotonNetwork.Instantiate("Pumpkin", new Vector3(4, 4, 14), Quaternion.identity, 0, null);
            Debug.Log("33333333333333333333333");
        }
        else if (snc.dördüncüKarakter == true)
        {
            PhotonNetwork.Instantiate("Pumpkin", new Vector3(4, 4, 14), Quaternion.identity, 0, null);
            Debug.Log("444444444444444");
        } */



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
