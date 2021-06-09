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

    public int Score = 0;
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
    public Text Score;

    [Header("Shop Panel")]
    public GameObject[] shopShips;
    public Text[] shopShipText;
    public GameObject btnShopBuy;
    public Text shopBtnBuyCostText;

    [Header("Upgrade panel")]
    public Sprite[] upgradeSpriteShips;
    public GameObject upgradeSpriteShip;
    public Slider[] upgradeSliders;
    public Text[] upgradeShowCost;

    private int _index;
    private int _indexBuy;


    #region Buttons

    public void BtnSave()
    {
        DataBase.instance.SaveGame();
    }

    public void BtnLoadGameSave()
    {
        DataBase.instance.LoadGameSave();
    }

    //public void BtnDeleteSaveGameDEBUG()
    //{
    //    PlayerPrefs.DeleteAll();
    //}

    public void BtnChoiseLevelGame(string name)
    {
        DataBase.instance.GameLoadScene(name);
    }

    public void BtnExitGame()
    {
        BtnSave();
        Application.Quit();
    }

    #endregion

    #region Shop

    public void ShopShipHighlighting()
    {
        for (int i = 0; i<DataBase.instance.playerShipsInfo.Length; i++)
        {
            if (DataBase.instance.playerShipsInfo[i][0] == 1)
            {
                shopShips[i].GetComponent<Image>().color = Color.white;
                shopShipText[i].color = Color.green;
                _index = i;
            }
            else
            {
                shopShips[i].GetComponent<Image>().color = Color.gray;
                shopShipText[i].color = Color.red;
            }
            if (DataBase.instance.playerShipsInfo[i][1] == 0)
                shopShipText[i].text = "Open";
            else
                shopShipText[i].text = "Cost: " + DataBase.instance.playerShipsInfo[i][1].ToString();
        }
    }

    public void ShopCheckPlayerShip(int num)
    {

        if (DataBase.instance.playerShipsInfo[num][1] == 0)
        {
            for (int i = 0; i < DataBase.instance.playerShipsInfo.Length; i++)
            {
                DataBase.instance.playerShipsInfo[i][0] = 0;
            }
            DataBase.instance.playerShipsInfo[num][0] = 1;
            _index = num;
            btnShopBuy.SetActive(false);
        }

        if (DataBase.instance.playerShipsInfo[num][1] != 0 &&
            DataBase.instance.playerShipsInfo[num][1] <= DataBase.instance.Score)
        {
            btnShopBuy.SetActive(true);
            shopBtnBuyCostText.text = "Buy " + DataBase.instance.playerShipsInfo[num][1].ToString();
            _indexBuy = num;
        }

        if (DataBase.instance.playerShipsInfo[num][1] != 0 &&
            DataBase.instance.playerShipsInfo[num][1] > DataBase.instance.Score)
        {
            btnShopBuy.SetActive(false);
        }

        ShopShipHighlighting();
    }

    public void BtnShopBuyShip()
    {
        _index = _indexBuy;
        DataBase.instance.Score = DataBase.instance.Score - DataBase.instance.playerShipsInfo[_index][1];
        DataBase.instance.playerShipsInfo[_index][1] = 0;
        UpdateScore();
        ShopCheckPlayerShip(_index);
        for (int i = 0; i < DataBase.instance.playerShipsInfo.Length; i++)
        {
            DataBase.instance.playerShipsInfo[i][0] = 0;
        }
        DataBase.instance.playerShipsInfo[_index][0] = 1;
        ShopShipHighlighting();
    }

    #endregion

    #region Upgrade

    public void UpgradesGetInformation()
    {
        upgradeSpriteShip.GetComponent<Image>().sprite = upgradeSpriteShips[_index];

        upgradeShowCost[0].text = "Cost: " + DataBase.instance.costHP.ToString();
        upgradeShowCost[1].text = "Cost: " + DataBase.instance.costSpeed.ToString();
        upgradeShowCost[2].text = "Cost: " + DataBase.instance.costShield.ToString();

        upgradeSliders[0].value = (float)DataBase.instance.playerShipsInfo[_index][2] / 15;
        upgradeSliders[1].value = (float)DataBase.instance.playerShipsInfo[_index][3] / 20;
        upgradeSliders[2].value = (float)DataBase.instance.playerShipsInfo[_index][4] / 6;
    }

    public void BtnUpgrade(int index)
    {
        if (index == 0 && DataBase.instance.Score > DataBase.instance.costHP && DataBase.instance.playerShipsInfo[_index][2] < 15)
        {
            upgradeShowCost[0].text = "Cost: " + DataBase.instance.costHP.ToString();
            DataBase.instance.Score -= DataBase.instance.costHP;
            DataBase.instance.playerShipsInfo[_index][2] += 1;
            upgradeSliders[0].value += (float)1 / 15;
        }

        if (index == 1 && DataBase.instance.Score > DataBase.instance.costSpeed && DataBase.instance.playerShipsInfo[_index][3] < 20)
        {
            upgradeShowCost[1].text = "Cost: " + DataBase.instance.costSpeed.ToString();
            DataBase.instance.Score -= DataBase.instance.costSpeed;
            DataBase.instance.playerShipsInfo[_index][3] += 1;
            upgradeSliders[1].value += (float)1 / 20;
        }

        if (index == 2 && DataBase.instance.Score > DataBase.instance.costShield && DataBase.instance.playerShipsInfo[_index][4] < 6)
        {
            upgradeShowCost[2].text = "Cost: " + DataBase.instance.costShield.ToString();
            DataBase.instance.Score -= DataBase.instance.costShield;
            upgradeSliders[2].value += (float)1 / 6;
            DataBase.instance.playerShipsInfo[_index][4] += 1;
        }
        UpdateScore();
    }

    #endregion

    private void Start()
    {
        if(PlayerPrefs.HasKey("InfoSaveScore"))
        {
            BtnLoadGameSave();
        }

        UpdateScore();
        ShopShipHighlighting();
    }

    public void UpdateScore()
    {
        Score.text = DataBase.instance.Score.ToString();
    }

    public void ShowChangePanel(int index)
    {
        ShopShipHighlighting();
        gamePanels[index].SetActive(true);
    }

    public void HideChangePanel(int index)
    {
        BtnSave();
        gamePanels[index].SetActive(false);
    }
}
