using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using TMPro;
public class GameManager : MonoBehaviour
{
    public int stage;
    public int GoldT;
    public float currentTime;
    private towerScript tower;
    private Player player;
    public TextMeshProUGUI StatText;
    public TextMeshProUGUI BuyText;
    public Rigidbody2D TowerBullet;
    public GameObject UpgradePanel;
    public GameObject playerUpgradePanel;
    public TextMeshProUGUI playerStatText;
    public TextMeshProUGUI playerBuyText;
    public bool TimerStop;
    private static GameManager gameManager;
    public bool winer;
    public bool loser;
    public bool[] Buff = new bool[21];
    public int CountTower;
    public int MaxCountTower;
    public static GameManager GetGameManager()
    {
        return gameManager;
    }
    // Start is called before the first frame update
    void Awake()
    {
        winer = false;
        loser = false;
        stage = 1;
        currentTime = 0f;
        gameManager = this;
        CountTower = 0;
        MaxCountTower = 10;
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Buff[20] == true)
        {
            MaxCountTower = 20;
        }
        if (GoldT<=0)
        {
            GoldT = 0;
        }
        if (TimerStop == false)
        {
            currentTime += Time.deltaTime;
   
        }
        if (stage == 1 && currentTime >= 10)
        {
            stage++;
            TimerStop = true;
        }
        if (stage == 2 && currentTime >= 20)
        {
            stage++;
            TimerStop = true;
        }
        if (stage == 3 && currentTime >= 40)
        {
            stage++;
            TimerStop = true;
        }
        if (stage == 4 && currentTime >= 80)
        {
            stage++;
            TimerStop = true;
        }
        if (stage == 5 &&currentTime >= 160)
        {
            stage++;
            TimerStop = true;
        }
        if (stage == 6 && currentTime >= 320)
        {
            stage++;
            TimerStop = true;
        }
        if (stage == 7 && currentTime >= 640)
        {
            stage++;
            TimerStop = true;
        }
        if (stage == 8 && currentTime >= 1280)
        {
            stage++;
            TimerStop = true;
        }
        if(stage == 9 && currentTime>=1800)
        {
            winer = true;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            playerUpgradePanel.SetActive(true);
        }
        playerStatText.text = "Attack:" + player.attack + "\n" + "AttackSpeed:" + player.attackspeed + "\n" + "Range"+player.Range+"\n"+"playerUpgradeGold"+player.playerUpgradeGold;
    }
    public void TakeDamage(Player player,Monster monster)
    {
        monster.hp -= player.attack;
    }
    public void TakeDamage(TowerBullet bullet, Monster monster)
    {
        monster.hp -= bullet.a.attack;
   
    }
    public void TakeDamage(CrystalHack crystalHack,Monster monster)
    {
        crystalHack.hp -= monster.attack;
    }
    public void BackButton2()
    {
        UpgradePanel.SetActive(false);
        tower.RangeImage.gameObject.SetActive(false);
    }
    public void Upgrade(towerScript t)
    {
        tower = t;
    StatText.text = "공격력: " + tower.attack + "\n" + "공격속도: "
                           + tower.attackspeed + "\n" + "Upgrade Gold"+
                           tower.UpgradeGold;
    }
    public void UpgradeButton()
    {
        if (GoldT >= tower.UpgradeGold)
        {
            GoldT -= tower.UpgradeGold;
            tower.attack = (int)(tower.attack * 1.8f);
            tower.UpgradeGold = (int)(tower.UpgradeGold * 2f);
            StatText.text = "공격력: " + tower.attack + "\n" + "공격속도: "
                          + tower.attackspeed + "\n" + "Upgrade Gold" +
                          tower.UpgradeGold;
        }
    }
    public void playerUpgradeButton()
    {
        if (GoldT >= player.playerUpgradeGold)
        {
            GoldT -= player.playerUpgradeGold;
            player.attack = (int)(player.attack*1.05f);
            player.attackspeed = (player.attackspeed * 1.05f);
            player.Range = player.Range * 1.05f;
            player.playerUpgradeGold = (int)(player.playerUpgradeGold*1.1f);
        }
    }
    public void BackButton3()
    {
        playerUpgradePanel.SetActive(false);
    }
}
