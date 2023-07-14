using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;


public class ServerManager : MonoBehaviourPunCallbacks
{
    //public Sunucu snc;
    public GameObject Chamb;
    public GameObject panel;

    public bool birinciKarakter;
    public bool ikinciKarakter;
    public bool ucuncuKarakter;
    public bool dorduncuKarakter;


    void Start()
    {
        //snc = new Sunucu();
        PhotonNetwork.ConnectUsingSettings();

        Time.timeScale = 0;
        //snc.KarakterSeçimi();

       



         //Chamb = (GameObject)PhotonNetwork.Instantiate("Pumpkin", new Vector3(4, 4, 14), Quaternion.identity, 0, null);

        


    }
    
   
    public void birlo()
    {
        
        panel.SetActive(false);
        ikinciKarakter = true;

        
        //Chamb.transform.Find("Pumpkin2").gameObject.SetActive(true);
        //panel.SetActive(false);
        Time.timeScale = 1;

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
        secým();
        base.OnJoinedRoom();
        Debug.Log("odaya girildi");
        //PhotonNetwork.Instantiate("Pumpkin", new Vector3(4, 4, 14), Quaternion.identity, 0, null);
    }
    
    public void secým()
    {
        if (birinciKarakter == true)
        {
            PhotonNetwork.Instantiate("Pumpkin", new Vector3(4, 4, 14), Quaternion.identity, 0, null);
            Debug.Log("111111111111111");
        }
        else if (ikinciKarakter == true)
        {
            PhotonNetwork.Instantiate("Pumpkin", new Vector3(4, 4, 14), Quaternion.identity, 0, null);
            Debug.Log("222222222222");
        }
        else if (ucuncuKarakter == true)
        {
            PhotonNetwork.Instantiate("Pumpkin", new Vector3(4, 4, 14), Quaternion.identity, 0, null);
            Debug.Log("33333333333333333333333");
        }
        else if (dorduncuKarakter == true)
        {
            PhotonNetwork.Instantiate("Pumpkin", new Vector3(4, 4, 14), Quaternion.identity, 0, null);
            Debug.Log("444444444444444");
        }
    }
   

}
