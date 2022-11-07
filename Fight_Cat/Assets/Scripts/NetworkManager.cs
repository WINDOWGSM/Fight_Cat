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
    [SerializeField] GameObject connectPanel;       //�����ϱ� ���� Name ����
    [SerializeField] GameObject RespawnPanel;       //�׾��� ��


    private void Awake()
    {
        PhotonNetwork.SendRate = 60;        //�ʴ� ����̳� PhotonNetwork �� ��Ű���� �����ؾ� �ϴ��� ����
        PhotonNetwork.SerializationRate = 30;
    }

    //�����Ϳ��� ������ Photon �� ����
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
