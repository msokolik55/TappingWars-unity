using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    //public GameObject leaderboardPanel;
    public GameObject listingPrefab;
    public Transform listingContainer;

    void Start()
    {
        PlayFabController.PFC.listingPrefab = listingPrefab;
        PlayFabController.PFC.listingContainer = listingContainer;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void UploadStats()
    {
        //PlayFabController.PFC.SetStats();
        PlayFabController.PFC.StartCloudUpdatePlayerStats();
    }

    public void GetLeaderboard()
    {
        PlayFabController.PFC.GetLeaderboarder();
    }

    public void CloseLeaderboard()
    {

        PlayFabController.PFC.CloseLeaderboardPanel();
    }
}
