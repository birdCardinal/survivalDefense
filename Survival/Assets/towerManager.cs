using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class towerManager : MonoBehaviour
{
    public GameObject[] tower = new GameObject[6];
    public Rigidbody2D TowerBullet;
    public Button[] TowerBuy = new Button[6];
    public TextMeshProUGUI towerText; 
    private int[] BuyGold = new int[6];
    public GameObject TowerBuyPanel;
    public int id2;
    private Vector3 m;
    private RaycastHit2D[] hit;
    public List<int> Range;
    public List<float> attackspeed;
    public List<int> UpgradeGold;
    public List<int> attack;
    // Start is called before the first frame update

    void Start()
    {
        for (int i = 0; i < tower.Length; i++)
        {
                TowerBuy[i].interactable = false;
            switch (i)
            {
                case 0:
                    attack.Add(5);
                    attackspeed.Add(1f);
                    UpgradeGold.Add(3000);
                    Range.Add(6);
                    break;
                case 1:
                    attack.Add(15);
                    attackspeed.Add(2f);
                    UpgradeGold.Add(3500);
                    Range.Add(12);
                    break;
                case 2:
                    attack.Add(25);
                    attackspeed.Add(0.7f);
                    UpgradeGold.Add(4000);
                    Range.Add(8);
                    break;
                case 3:
                    attack.Add(32);
                    attackspeed.Add(0.9f);
                    UpgradeGold.Add(4500);
                    Range.Add(6);
                    break;
                case 4:
                    attack.Add(35);
                    attackspeed.Add(0.8f);
                    UpgradeGold.Add(5000);
                    Range.Add(9);
                    break;
                case 5:
                    attack.Add(45);
                    attackspeed.Add(0.8f);
                    UpgradeGold.Add(6000);
                    Range.Add(9);
                    break;
            }
        }
        for(int i = 0; i < BuyGold.Length; i++)
        { 
            BuyGold[i] = 500*(i+1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < tower.Length; i++)
        {
            if (GameManager.GetGameManager().Buff[i] == true && BuyGold[i] <=GameManager.GetGameManager().GoldT&&GameManager.GetGameManager().CountTower<GameManager.GetGameManager().MaxCountTower)
            {
                TowerBuy[i].interactable = true;
            }
            else
            {
                TowerBuy[i].interactable = false;
            }
        }
             m = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && GameManager.GetGameManager().TimerStop==false)
        {
            hit = Physics2D.RaycastAll(m, Vector2.zero, 0f);
            for (int i = 0; i < hit.Length; i++)
            {
                towerScript t = hit[i].collider.GetComponent<towerScript>();    
                if (t!=null)
                {
                    GameManager.GetGameManager().UpgradePanel.SetActive(true);
                    GameManager.GetGameManager().Upgrade(t);
                    t.RangeImage.gameObject.SetActive(true);
                    break;
                }
            }
        }
    }
    public void TowerClick(int id)
    {
        id2 = id;
        GameManager.GetGameManager().BuyText.text = "공격력: " + attack[id] + "\n" + "공격속도: "
                                + attackspeed[id] + "\n" + "사거리" + Range[id];
        TowerBuyPanel.SetActive(true);
    }
    public void TowerBuyButton()
    {
        GameManager.GetGameManager().GoldT -= BuyGold[id2];
        Instantiate(tower[id2], new Vector3(m.x,m.y,0), Quaternion.identity);
        TowerBuyPanel.SetActive(false);
    }
    public void BackButton()
    {
        TowerBuyPanel.SetActive(false);
    }

}
