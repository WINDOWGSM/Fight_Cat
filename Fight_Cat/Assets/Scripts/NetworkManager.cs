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
    [SerializeField] GameObject connectPanel;
    [SerializeField] GameObject RespawnPanel;


    private void Awake()
    {
        PhotonNetwork.SendRate = 60;        //�ʴ� ����̳� PhotonNetwork �� ��Ű���� �����ؾ� �ϴ��� ����
        PhotonNetwork.SerializationRate = 30;
    }

    //�����Ϳ��� ������ Photon �� ����
    public void Connecting() => PhotonNetwork.ConnectUsingSettings();   

}
