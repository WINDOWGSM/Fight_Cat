using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    #region Photon Callbacks

    /// <summary>
    /// 로컬 플레이어가 방을 나갈 때 호출 됩니다.
    /// </summary>
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }

    #endregion

    #region Public Methods
    
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    #endregion



}
