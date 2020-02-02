using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static PlayFabController;
using static MPManager;
using TMPro;

public class MenuController : MonoBehaviour
{
    public GameObject listingPrefab;
    public Transform listingContainer;

    public static MenuController MC; //Singleton
    public GameObject[] buttonLocks; //All the lock buttons game objects
    public Button[] unlockedButtons; //All the "Skin" buttons

    public Transform friendListing;
    public TextMeshProUGUI connectionState;

    private void OnEnable()
    {
        MC = this;
    }

    void Start()
    {
        PFC.listingPrefab = listingPrefab;
        PFC.listingContainer = listingContainer;

        PFC.friendListing = friendListing;

        //MPM.connectionState = connectionState;

        SetUpStore();
    }

    private void FixedUpdate()
    {
        MC.connectionState.text = PhotonNetwork.connectionStateDetailed.ToString();
    }

    #region PlayerData
    //Unlock buttons based on the all skins array
    public void SetUpStore()
    {
        for (int i = 0; i < PersistentData.PD.allSkins.Length; i++)
        {
            buttonLocks[i].SetActive(!PersistentData.PD.allSkins[i]);
            unlockedButtons[i].interactable = PersistentData.PD.allSkins[i];
        }
    }
    
    //Public function paired to the Lock buttons
    public void UnlockSkin(int index)
    {
        PersistentData.PD.allSkins[index] = true;
        PlayFabController.PFC.SetUserData(PersistentData.PD.SkinsDataToString());
        SetUpStore();
    }
    
    //selects the skin you click on when the button is unlocked. Paired to the Unlocked buttons
    public void SetMySkin(int whichSkin)
    {
        PersistentData.PD.mySkin = whichSkin;
    }
    #endregion

    public void QuitGame()
    {
        Application.Quit();
    }

    public void UploadStats()
    {
        //PlayFabController.PFC.SetStats();
        PlayFabController.PFC.StartCloudUpdatePlayerStats();
    }

    #region LeaderBoard
    public void GetLeaderboard()
    {
        PlayFabController.PFC.GetLeaderboarder();
    }

    public void CloseLeaderboard()
    {
        PlayFabController.PFC.CloseLeaderboardPanel();
    }
    #endregion

    #region Friends
    public void InputFriendID(string idIn)
    {
        PFC.InputFriendID(idIn);
    }

    public void SubmitFriendRequest()
    {
        PFC.SubmitFriendRequest();
    }

    public void GetFriends()
    {
        PFC.GetFriends();
    }

    public void RunWaitFunction()
    {
        PFC.RunWaitFunction();
    }

    #endregion

    public void CreateOrJoin()
    {
        MPM.CreateOrJoin();
    }
}
