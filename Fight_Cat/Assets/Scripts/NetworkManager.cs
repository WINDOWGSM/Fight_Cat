using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField _InputField;
    [SerializeField] GameObject connectPanel;       //연결하기 위해 Name 받음
    [SerializeField] GameObject RespawnPanel;       //죽었을 때


    private void Awake()
    {
        PhotonNetwork.SendRate = 60;        //초당 몇번이나 PhotonNetwork 가 패키지를 전송해야 하는지 정의
        PhotonNetwork.SerializationRate = 30;
    }

    //에디터에서 설정된 Photon 에 연결
    public void Connecting() => PhotonNetwork.ConnectUsingSettings();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Disconnect();
        }
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.LocalPlayer.NickName = _InputField.text;
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 6 }, null);

    }

    public override void OnJoinedRoom()
    {
        connectPanel.SetActive(false);    
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        connectPanel.SetActive(true);
        RespawnPanel.SetActive(false);
    }

}
