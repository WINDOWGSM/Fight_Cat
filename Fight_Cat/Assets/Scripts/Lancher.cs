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

    [Tooltip("사용자가 이름을 입력하고, 시작을 연결하는 UI Panel")]
    [SerializeField] private GameObject controlPanel;
    [Tooltip("연결이 진행중임을 알려주는 사용자에게 알리는 Lable")]
    [SerializeField] private GameObject prograssLable;

    #endregion


    #region Private Fields

    /// <summary>
    /// 클라이언트 버전 번호
    /// </summary>
    string gameVersion = "1";

    #endregion



    #region MonoBehaviour CallBacks
    
    private void Awake()
    {
        //포톤 네트워크를 사용할 수 있다는 걸 확실하게 합니다.
        //마스터 클라이언트와 동일한 룸에 있는 모든 클라이언트들의 LoadLevel()은 자동으로 레벨을 동기화 합니다
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
    /// 연결 프로세스를 시작합니다.
    /// /// 이미 연결 되어 있는 경우 랜덤 룸 가입을 시도합니다
    /// /// 아직 연결 되어 있지 않은 경우 이 응용 프로그램 인스턴스를 Photon Cloud Network에 연결합니다.
    /// </summary>

    public void Connect()
    {
        prograssLable.SetActive(true);
        controlPanel.SetActive(false);

        // 연결 여부를 확인하고, 연결되면 가입하고, 그렇지 않으면 서버에 대한 연결을 시작합니다.
        if (PhotonNetwork.IsConnected)
        {
            // 이 시점에서 랜덤 룸 가입을 시도해야 합니다. 실패한 경우 OnjoinRandomFailed() (콜백메서드) 에서 알림을 받고 자동으로 룸을 생성합니다
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            //무엇보다 먼저 포톤 네트워크 서버에 연결되야 합니다.
            PhotonNetwork.GameVersion = gameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    #endregion

    #region MonoBehaviourPunCallbacks Callbacks

    public override void OnConnectedToMaster()
    {
        Debug.Log("PUN Basics Tutorial/Lancher: OnConnectedToMaster() was called by PUN");
        //가장 먼저 하려고 하는 것은 잠재적인 기존 방에 가입하려고 하는 것 입니다.
        //방이 있으면 굳, 없으면 OnJoinRandomFailed()로 다시 호출됩니다.
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

        //아무 방에도 들어가지 못했거나 아무도 없거나 모두 찼을 수도 있다. 그럴때 새로운 방을 만든다
        PhotonNetwork.CreateRoom(null, new RoomOptions{MaxPlayers = maxPlayersPerRoom });

    }

    public override void OnJoinedRoom()
    {

        Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
    }

    #endregion
}
