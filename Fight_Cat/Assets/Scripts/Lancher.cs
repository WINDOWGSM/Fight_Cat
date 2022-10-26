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
        Connect();
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

}
