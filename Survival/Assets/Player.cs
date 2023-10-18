using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private int speed;
    public int attack;
    public float attackspeed;
    public int playerUpgradeGold;
    public Rigidbody2D Bullet;
    public Rigidbody2D BulletShot;
    public Rigidbody2D BulletShot2;
    public Vector3 t;
    private float lastTime;
    public Vector3 Bulletposition;
    public Vector2 normailzedBullet;
    public float Range;
    public Collider2D[] coll;
    public LayerMask WhatisEnemy;
    public int RandomTarget;
    private float playerdamageLastTime;
    // Start is called before the first frame update
    void Start()
    {
        speed = 4;
        attack = 30;
        attackspeed = 1.0f;
        rb = GetComponent<Rigidbody2D>();
        lastTime = 0;
        Range = 5f;
        playerUpgradeGold = 3000;
    }

    // Update is called once per frame
    void Update()
    {
        float InputX = Input.GetAxis("Horizontal");
        float InputY = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(InputX*speed, InputY*speed);

        coll = Physics2D.OverlapCircleAll(transform.position, Range, WhatisEnemy);

        if (coll.Length == 0)
        {
            return;
        }
    
        int b = Random.Range(0, coll.Length);
       
        if (GameManager.GetGameManager().TimerStop == false)
        {
 
            if (GameManager.GetGameManager().Buff[13] == true)
            {
                if (GameManager.GetGameManager().currentTime > playerdamageLastTime + 5f)
                {
                    for (int i = 0; i < coll.Length; i++)
                    {
                        Monster monster = coll[i].GetComponent<Monster>();
                        GameManager.GetGameManager().TakeDamage(this, monster);
                    }
                    playerdamageLastTime = GameManager.GetGameManager().currentTime;
                }
            }
            if (GameManager.GetGameManager().Buff[14] == true)
            {
                for (int i = 0; i < coll.Length; i++)
                {
                    Monster monster = coll[i].GetComponent<Monster>();
                    if (monster.decting==false)
                    {
                        monster.decting = true;
                    }
                }
            }
            if ((lastTime + 1 / attackspeed) < GameManager.GetGameManager().currentTime)
            {
                int maxCount=1;
                if (GameManager.GetGameManager().Buff[17] == true)
                {
                    maxCount = 2;
                }
                for (int i = 0; i < maxCount; i++)
                {
                    Collider2D c = coll[b];
                    Bulletposition = c.transform.position - transform.position;
                    BulletShot = Instantiate(Bullet, transform.position, transform.rotation);
                    BulletShot.transform.parent = this.transform;
                }
                lastTime = GameManager.GetGameManager().currentTime;
            }
        }
    }
}
