using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Lancher : MonoBehaviour
{

    #region private Serializable Fields

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
        Connect();
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

}
