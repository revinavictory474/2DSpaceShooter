using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataBase
{
    public static DataBase instance = new DataBase();

    public int[][] playerShipsInfo =
    {
        new int[] {1,000,1,15,0,},
        new int[] {0,550,2,8,0},
        new int[] {0,1250,3,6,0}
    };

    public int costHP = 250;
    public int costSpeed = 400;
    public int costShield = 950;

    public int Score = 99999;
    public int ScoreGame = 0;


    public void GameLoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void SaveGame()
    {
        Score += ScoreGame;
        for (int i = 0; i < playerShipsInfo.Length; i++)
        {
            for (int j = 0; j < playerShipsInfo[i].Length; j++)
            {
                PlayerPrefs.SetInt("InfoSave" + i + j, playerShipsInfo[i][j]);
            }
        }
        PlayerPrefs.SetInt("InfoSaveScore", Score);
    }

    public void LoadGameSave()
    {
        for(int i = 0; i<playerShipsInfo.Length; i++)
        {
            for (int j = 0; j < playerShipsInfo[i].Length; j++)
            {
                playerShipsInfo[i][j] = PlayerPrefs.GetInt("InfoSave" + i + j);
            }
        }
        Score = PlayerPrefs.GetInt("InfoSaveScore");
    }
}

public class MainMenu : MonoBehaviour
{
    public GameObject[] gamePanels;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ShowChangePanel(int index)
    {
        gamePanels[index].SetActive(true);
    }

    public void HideChangePanel(int index)
    {
        gamePanels[index].SetActive(false);
    }
}
