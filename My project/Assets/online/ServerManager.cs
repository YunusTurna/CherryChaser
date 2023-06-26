using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ServerManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("servere ba�land�");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("lobiye ba�land�");
        PhotonNetwork.JoinOrCreateRoom(roomName: "odaismi", new RoomOptions { MaxPlayers=5,IsOpen= true,IsVisible=true}, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("odaya girildi");
        PhotonNetwork.Instantiate("PlayerVariant", new Vector3(337, 36, 527), Quaternion.identity, 0, null);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
