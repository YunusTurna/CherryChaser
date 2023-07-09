using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class Sunucu : MonoBehaviourPunCallbacks
{
    //benim
    public static Sunucu Instance;
    [SerializeField] TMP_InputField RoomName;
    [SerializeField] TMP_Text RoomNameText;
    [SerializeField] TMP_Dropdown maxPlayer;
    [SerializeField] TMP_Text Error;
    [SerializeField] Transform RoomContent;
    [SerializeField] GameObject RoomList;

    private int maxplayers;

     void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();    
    }


    public override void OnConnectedToMaster()
    {
        //base.OnConnectedToMaster();
        Debug.Log("SERVERE BAÐLANILDI ");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        //base.OnJoinedLobby();
        Debug.Log("LOBÝYE BAÐLANILDI");
        MenuManager.Instance.OpenMenu("Title");
    }

    public void OdaKur()
    {
        if (string.IsNullOrEmpty(RoomName.text))
            return;
        RoomOptions roomOptions = new RoomOptions();
        if (maxPlayer.value==0)
        {
            roomOptions.MaxPlayers = 5;
        }
        PhotonNetwork.CreateRoom(RoomName.text, roomOptions, TypedLobby.Default, null);
        MenuManager.Instance.OpenMenu("Loading");

        
    }

    public override void OnJoinedRoom()
    {
        //base.OnJoinedRoom();
        Debug.Log("odaya girildi");
        MenuManager.Instance.OpenMenu("RoomMenü");
        RoomNameText.text = RoomName.text + "  " + PhotonNetwork.CountOfPlayers.ToString() + " /  5 " ;
       
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Error.text = "oda kurulurken hata meydana geld," + message;
        base.OnCreateRoomFailed(returnCode, message);
        MenuManager.Instance.OpenMenu("Error");
    }
    public void Odadancik()
    {
        PhotonNetwork.LeaveRoom();
        MenuManager.Instance.OpenMenu("Loading");
    }

    public void RoomJoin(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
        MenuManager.Instance.OpenMenu("Loading");
    }

    public void RandomJoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
        MenuManager.Instance.OpenMenu("Loading");
    }
    public void FindRoom()
    {
        
        MenuManager.Instance.OpenMenu("FindRoom");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        base.OnRoomListUpdate(roomList);
        foreach (Transform transform in RoomContent)
        {
            Destroy(transform.gameObject);
        }
        for (int i = 0; i < roomList.Count; i++)
        {
            Instantiate(RoomList, RoomContent).GetComponent<RoomListPrefab>().SetInfo(roomList[i]);
        }
    }


}
