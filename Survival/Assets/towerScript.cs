using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerScript : MonoBehaviour
{
    public LayerMask NoTouch;
    public LayerMask Tower;
    public Transform RangeImage;
    public bool SearchTower;
    private float lastTime;
    private float currentTime;
    private Vector3 towerTransform;
    public Rigidbody2D Bullet;
    public Rigidbody2D BulletShot;
    public Vector2 BulletSpeed;
    public Collider2D coll;
    public LayerMask WhatisEnemy;
    public int Range;
    public float attackspeed;
    public int UpgradeGold;
    public int attack;
    public int id;
    private RaycastHit2D[] hit;
    public bool towerBuffid0;
    private int RadomPercent;
    public float FeverTime;
    public bool CrystalHackBuff;
    // Start is called before the first frame update
    void Start()
    {
        CrystalHackBuff = false;
        RangeImage = transform.GetChild(0);
        SearchTower = false;
        currentTime = 0f;
        lastTime = 0f;
        switch (id)
        {
            case 0:
                attack= 5;
                attackspeed = 1f;
                UpgradeGold = 3000;
                Range = 6;
                break;
            case 1:
                attack = 15;
                attackspeed = 2f;
                UpgradeGold = 3500;
                Range = 12;
                break;
            case 2:
                attack = 25;
                attackspeed = 0.7f;
                UpgradeGold = 4000;
                Range = 8;
                break;
            case 3:
                attack = 32;
                attackspeed = 0.9f;
                UpgradeGold = 4500;
                Range = 6;
                break;
            case 4:
                attack = 35;
                attackspeed = 0.8f;
                UpgradeGold = 5000;
                Range = 9;
                break;
            case 5:
                attack = 45;
                attackspeed = 0.8f;
                UpgradeGold = 6000;
                Range = 9;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        towerTransform = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
         if(SearchTower == true)
        {
            currentTime += Time.deltaTime;
            coll = Physics2D.OverlapCircle(transform.position, Range, WhatisEnemy);
            if (id == 5 && GameManager.GetGameManager().Buff[11] == true)
            {
                Collider2D[] coll = Physics2D.OverlapCircleAll(transform.position, Range, WhatisEnemy);
                for(int i = 0; i < coll.Length; i++)
                {
                   Monster monster = coll[i].GetComponent<Monster>();
                    if(monster != null)
                    {
                        monster.decting = true;
                    }
                }
            }
            if (GameManager.GetGameManager().TimerStop == false)
            {
                if ((lastTime + 1 / attackspeed) < currentTime && coll != null)
                {
                    BulletSpeed = coll.transform.position - transform.position;
                    BulletShot = Instantiate(GameManager.GetGameManager().TowerBullet, transform.position, transform.rotation);
                    RadomPercent = Random.Range(0, 20);
                    if (RadomPercent == 0)
                    {
                        if (GameManager.GetGameManager().Buff[6] == true && towerBuffid0==false&&id==0)
                        {
                            towerBuffid0 = true;
                            StartCoroutine("BuffTowerid0");
                        }
                    }
                    BulletShot.transform.parent = this.transform;
                    lastTime = currentTime;
                }
            }
        }
        else
        {
            RangeImage.localScale = new Vector3(Range, Range, 1);
            transform.position = new Vector3(towerTransform.x, towerTransform.y, 0);
            if (Input.GetMouseButtonDown(0))
            {
                hit = Physics2D.RaycastAll(towerTransform, Vector2.zero, 0f, NoTouch);
                if (hit.Length==1)
                {
                    SearchTower = true;
                    RangeImage.gameObject.SetActive(false);
                    if (GameManager.GetGameManager().Buff[8] == true && id == 2)
                    {
                        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, Range, Tower);
                        if (col.Length != 0)
                        {
                            for (int i = 0; i < col.Length; i++)
                            {
                                towerScript t = col[i].GetComponent<towerScript>();
                                t.attack = (int)(t.attack * 1.15f);
                            }
                        }
                    }
                    if (GameManager.GetGameManager().Buff[18] == true&&Vector3.Magnitude(transform.position-Vector3.zero)>5f)
                    {
                        attack = (int)(attack * 1.25f);
                        attackspeed = attackspeed * 1.25f;
                    }
                    GameManager.GetGameManager().CountTower++;
                }
            }
        }

    }
    IEnumerator BuffTowerid0()
    {
        attack *= 2;
        attackspeed *= 2;
        yield return new WaitForSeconds(5f);
        attack /= 2;
        attackspeed /= 2;
        towerBuffid0 = false;
    }
}