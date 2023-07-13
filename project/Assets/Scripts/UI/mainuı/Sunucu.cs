using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;


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
    [SerializeField] GameObject PlayerList;
    [SerializeField] Transform PlayerContent;
    [SerializeField] TMP_Text Nick;
    [SerializeField] TMP_Dropdown Maps;
    [SerializeField] Button baslat;

    private int maxplayers;

     void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
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
        PhotonNetwork.NickName = "Player" + Random.Range(0, 1000).ToString();
        Nick.text = PhotonNetwork.NickName;
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
        RoomNameText.text = RoomName.text + "  " + PhotonNetwork.CountOfPlayers.ToString() + " / 5 " ;


        Player[] players = PhotonNetwork.PlayerList;

        foreach (Transform child in PlayerContent)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < players.Length; i++)
        {
            Instantiate(PlayerList, PlayerContent).GetComponent<PlayerListPrefab>().SetPlayer(players[i]);
        }
        if (PhotonNetwork.CountOfPlayers>=1)
        {
            baslat.interactable=true;
        }
        else
        {
            baslat.interactable = false;
        }
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

    public override void OnLeftRoom()
    {
        MenuManager.Instance.OpenMenu("Title");
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
            if (roomList[i].RemovedFromList)
                continue;
            

            
            Instantiate(RoomList, RoomContent).GetComponent<RoomListPrefab>().SetInfo(roomList[i]);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        //base.OnPlayerEnteredRoom(newPlayer);
        Instantiate(PlayerList, PlayerContent).GetComponent<PlayerListPrefab>().SetPlayer(newPlayer);
    }

    public void OyunuBaslat()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (Maps.value==0)
            {
                PhotonNetwork.LoadLevel("CherryBombMulti");
            }
            if (Maps.value==1)
            {
                PhotonNetwork.LoadLevel("CherryRunMap");
            }
        }
       
    }


}
