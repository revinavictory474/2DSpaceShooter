using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class EnemyWaves 
{
    public float timeToStart;
    public GameObject wave;
    public bool isLastWave;
}

public class LevelController : MonoBehaviour
{
    public static LevelController instance;
    public GameObject[] playerShips;
    public EnemyWaves[] enemyWaves;
    public bool isFinal = false;
    public GameObject panel;
    private bool isPause;
    public GameObject[] btnPause;
    public Text textScore;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        Time.timeScale = 1;

        for(int i = 0; i<DataBase.instance.playerShipsInfo.Length; i++)
        {
            if(DataBase.instance.playerShipsInfo[i][0] == 1)
            {
                LoadPlayer(i);
            }
        }
        for ( int i = 0; i< enemyWaves.Length; i++)
        {
            StartCoroutine(CreateEnemyWave(enemyWaves[i].timeToStart,enemyWaves[i].wave, enemyWaves[i].isLastWave));
        }
    }

    private void Update()
    {
        if(isFinal == true && GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && !isPause)
        {
            GamePause();
            btnPause[1].SetActive(false);
        }
        if(Player.instance == null && !isPause)
        {
            GamePause();
        }
    }

    public void ScoreInGame(int score)
    {
        DataBase.instance.ScoreGame += score;
        textScore.text = "Score: " + DataBase.instance.ScoreGame.ToString();
    }

    public void LoadPlayer(int ship)
    {
        Instantiate(playerShips[ship]);
        Player.instance.playerHealth = DataBase.instance.playerShipsInfo[ship][2];
        PlayerMove.instance.speedPlayer = DataBase.instance.playerShipsInfo[ship][3];
        Player.instance.shieldHealth = DataBase.instance.playerShipsInfo[ship][4];
    }

    public void GamePause()
    {
        if(!isPause)
        {
            isPause = true;
            Time.timeScale = 0;
            panel.SetActive(true);
            if (Player.instance != null)
            {
                btnPause[0].SetActive(false);
                btnPause[1].SetActive(true);
            }
            else
            {
                btnPause[0].SetActive(true);
                btnPause[1].SetActive(false);
            }
        }
        else
        {
            isPause = false;
            Time.timeScale = 1;
            panel.SetActive(false);
        }
    }

    public void BtnRestartGame()
    {
        DataBase.instance.ScoreGame = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BtnExitGame()
    {
        DataBase.instance.SaveGame();
        DataBase.instance.GameLoadScene("Menu");
    }

    private IEnumerator CreateEnemyWave(float delay, GameObject wave, bool final)
    {
        if (delay != 0)
            yield return new WaitForSeconds(delay);
        if (Player.instance != null)
            Instantiate(wave);
        if (final == true)
            isFinal = true;
    }
}
