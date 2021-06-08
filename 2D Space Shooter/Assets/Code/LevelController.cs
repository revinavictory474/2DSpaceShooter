using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public bool isFinal;
    public GameObject panel;
    private bool isPause;
    public GameObject[] btnPause;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        for ( int i = 0; i< enemyWaves.Length; i++)
        {
            StartCoroutine(CreateEnemyWave(enemyWaves[i].timeToStart,enemyWaves[i].wave, enemyWaves[i].isLastWave));
        }
    }

    private void Update()
    {
        if(isFinal == true && GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && !isPause)
        {
            Debug.Log("WIN");
            GamePause();
            btnPause[1].SetActive(false);
        }
        if(Player.instance == null && !isPause)
        {
            Debug.Log("LOSE");
            GamePause();
        }
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
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
