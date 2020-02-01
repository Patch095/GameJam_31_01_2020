using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    public GameObject MainMenuUI;
    public GameObject InGameUI;
    public GameObject ScoreboardMenuUI;
    public ReadScoreboard scoreboardMng;

    void OnEnable()
    {
        MainMenuUI.SetActive(true);
        InGameUI.SetActive(false);
        ScoreboardMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGameStart()
    {
        MainMenuUI.SetActive(false);
        InGameUI.SetActive(true);
        ScoreboardMenuUI.SetActive(false);
    }

    private void UpdateScoreboardMenu()
    {
        ScoreboardMenuUI.SetActive(true);

        string[] scoreboardText = scoreboardMng.GetScoreboard();
        for (int i = 0; i < scoreboardText.Length; i++)
        {
            //set text.text = scoreboardText[i]
        }
    }

    public void OpenScoreBoardMenu()
    {
        MainMenuUI.SetActive(false);
        InGameUI.SetActive(false);
        //ScoreboardMenuUI.SetActive(true);
        UpdateScoreboardMenu();
    }
    public void CloseScoreBoardMenu()
    {
        MainMenuUI.SetActive(true);
        InGameUI.SetActive(false);
        ScoreboardMenuUI.SetActive(false);
    }

}
