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
    [SerializeField] GameObject _connectPanel;       //�����ϱ� ���� Name ����
    [SerializeField] GameObject _RespawnPanel;       //�׾��� ��
    [SerializeField] GameObject _selectWeaponPanel; //���� ���� �ǳ�



    private void Awake()
    {
        PhotonNetwork.SendRate = 60;        //�ʴ� ����̳� PhotonNetwork �� ��Ű���� �����ؾ� �ϴ��� ����
        PhotonNetwork.SerializationRate = 30;
    }

    private void Start()
    {
        _connectPanel.SetActive(true);
        _RespawnPanel.SetActive(false);
        _selectWeaponPanel.SetActive(true);

    }

    //�����Ϳ��� ������ Photon �� ����
    public void Connecting() => PhotonNetwork.ConnectUsingSettings();

    /// <summary>
    /// ���� ���� ��ư Ŭ��
    /// </summary>
    public void SelectBtnClick()
    {
        _selectWeaponPanel.SetActive(false);

    }

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
        _connectPanel.SetActive(false);
        Spawn();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        _selectWeaponPanel.SetActive(true);
        _connectPanel.SetActive(true);
        _RespawnPanel.SetActive(false);
    }
    public void Spawn()
    {
        PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
        _RespawnPanel.SetActive(false);

    }
}
