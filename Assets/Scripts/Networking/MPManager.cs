using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Photon;

public class MPManager : Photon.MonoBehaviour
{
    public static MPManager MPM;

    public string GameVersion;
    public TextMeshProUGUI connectionState;

    private void OnEnable()
    {
        if (MPM == null)
        {
            MPM = this;
        }
        else
        {
            if (MPM != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    //private void FixedUpdate()
    //{
    //    connectionState.text = PhotonNetwork.connectionState.ToString();
    //}

    public void ConnectToMaster()
    {
        PhotonNetwork.ConnectUsingSettings(GameVersion);
    }

    public virtual void OnConnectedToMaster()
    {
        SceneManager.LoadScene("Menu");
    }

    public void CreateOrJoin()
    {
        if(!PhotonNetwork.JoinRandomRoom())
            OnPhotonRandomJoinFailed();
    }

    public virtual void OnPhotonRandomJoinFailed()
    {
        RoomOptions rm = new RoomOptions
        {
            MaxPlayers = 4,
            IsVisible = true
        };

        int rndID = Random.Range(0, 3000);
        PhotonNetwork.CreateRoom(rndID.ToString(), rm, TypedLobby.Default);
    }
}
