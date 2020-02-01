using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    static float timer_duration = 180f;

    public float CurrentTimer { get { return CurrentTimer; } }
    float currentTimer;

    bool is_game_started;

    public Transform time_image;

    public ReadScoreboard ScoreboardMng;
    public UImanager UImng;

    //aggiungere player

    void OnEnable()
    {
        is_game_started = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (is_game_started && currentTimer > 0)
        {
            //get player input

            currentTimer -= Time.deltaTime;

            float time_remain = currentTimer / timer_duration;
            Mathf.Clamp01(time_remain);
            time_image.localScale = new Vector3(time_remain, 1, 1);

            /* change bar color
            if (hpFillGauge > 0.6f)
                HPBar.color = Color.green;
            else if (hpFillGauge < 0.2f)
                HPBar.color = Color.red;
            else
                HPBar.color = Color.yellow;
            */

            //get player score, draw player score
        }

        //if ()
        //{

        //}

        //1: main menu
        /*

         [  LEADERBOARD ]
         [  QUIT    ]
         */

        //2: start



        //goto scoreboar

        //check/add new score
    }

    public void StartGame()
    {
        if(is_game_started == false)
        {
            is_game_started = true;
            currentTimer = timer_duration;
        }
    }

    public void OnGameEnd()
    {
        //ScoreboardMng.OnGameEnd(/* player.name, player.score */);

        UImng.OpenScoreBoardMenu();
    }

    public void Quit()
    {
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
}
