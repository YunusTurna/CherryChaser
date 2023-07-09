using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using TMPro;

public class RoomListPrefab : MonoBehaviour
{

    [SerializeField] TMP_Text text;

    RoomInfo info;

    public void SetInfo(RoomInfo _info)
    {
        info = _info;
        text.text = info.PlayerCount.ToString() + " / 5  " + info.Name;
    }

    public void ClickRoom()
    {
        Sunucu.Instance.RoomJoin(info);
    }
}
