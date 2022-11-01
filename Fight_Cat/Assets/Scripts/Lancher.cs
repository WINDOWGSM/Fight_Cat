using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;
using UnityEngine.AI;

public class Lancher : MonoBehaviourPunCallbacks
{

    #region private Serializable Fields
    [SerializeField] private byte maxPlayersPerRoom = 4;

    [Tooltip("����ڰ� �̸��� �Է��ϰ�, ������ �����ϴ� UI Panel")]
    [SerializeField] private GameObject controlPanel;
    [Tooltip("������ ���������� �˷��ִ� ����ڿ��� �˸��� Lable")]
    [SerializeField] private GameObject prograssLable;

    #endregion


    #region Private Fields

    /// <summary>
    /// Ŭ���̾�Ʈ ���� ��ȣ
    /// </summary>
    string gameVersion = "1";

    #endregion



    #region MonoBehaviour CallBacks
    
    private void Awake()
    {
        //���� ��Ʈ��ũ�� ����� �� �ִٴ� �� Ȯ���ϰ� �մϴ�.
        //������ Ŭ���̾�Ʈ�� ������ �뿡 �ִ� ��� Ŭ���̾�Ʈ���� LoadLevel()�� �ڵ����� ������ ����ȭ �մϴ�
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Start()
    {
        prograssLable.SetActive(false);
        controlPanel.SetActive(true);
    }

    #endregion

    #region Public Method

    /// <summary>
    /// ���� ���μ����� �����մϴ�.
    /// /// �̹� ���� �Ǿ� �ִ� ��� ���� �� ������ �õ��մϴ�
    /// /// ���� ���� �Ǿ� ���� ���� ��� �� ���� ���α׷� �ν��Ͻ��� Photon Cloud Network�� �����մϴ�.
    /// </summary>

    public void Connect()
    {
        prograssLable.SetActive(true);
        controlPanel.SetActive(false);

        // ���� ���θ� Ȯ���ϰ�, ����Ǹ� �����ϰ�, �׷��� ������ ������ ���� ������ �����մϴ�.
        if (PhotonNetwork.IsConnected)
        {
            // �� �������� ���� �� ������ �õ��ؾ� �մϴ�. ������ ��� OnjoinRandomFailed() (�ݹ�޼���) ���� �˸��� �ް� �ڵ����� ���� �����մϴ�
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            //�������� ���� ���� ��Ʈ��ũ ������ ����Ǿ� �մϴ�.
            PhotonNetwork.GameVersion = gameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    #endregion

    #region MonoBehaviourPunCallbacks Callbacks

    public override void OnConnectedToMaster()
    {
        Debug.Log("PUN Basics Tutorial/Lancher: OnConnectedToMaster() was called by PUN");
        //���� ���� �Ϸ��� �ϴ� ���� �������� ���� �濡 �����Ϸ��� �ϴ� �� �Դϴ�.
        //���� ������ ��, ������ OnJoinRandomFailed()�� �ٽ� ȣ��˴ϴ�.
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        prograssLable.SetActive(false);
        controlPanel.SetActive(true);
        Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("PUN Basics Tutorial/Launcher:OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");

        //�ƹ� �濡�� ���� ���߰ų� �ƹ��� ���ų� ��� á�� ���� �ִ�. �׷��� ���ο� ���� �����
        PhotonNetwork.CreateRoom(null, new RoomOptions{MaxPlayers = maxPlayersPerRoom });

    }

    public override void OnJoinedRoom()
    {

        Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
    }

    #endregion
}
