using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Monster : MonoBehaviour
{
    public int id;
    private static int monsterCount;
    public int monstercount;
    public float speed;
    public int hp;
    public Rigidbody2D rb;
    private CrystalHack crystalHack;
    private Vector3 vector3;
    private Vector3 v;
    public int dropgold;
    private float goldmultiple;
    public Slider hpSlider;
    public int attack;
    private bool Stealth;
    public float currentTime;
    public bool SlowDebuff;
    public bool decting;
    public float lastStealthTime;
    private SpriteRenderer[] meshRenderer;
    private Color coloralpha;
    // Start is called before the first frame update
    void Start()
    {
        SlowDebuff = false; 
        currentTime = 0f;
        decting = false;
        hpSlider = GetComponentInChildren<Slider>();
        switch (id)
        {
            case 0:
                hp = (int)(Random.Range(250, 400) * (GameManager.GetGameManager().currentTime/100));
                speed = 0.5f;
                attack = 1;
                break;
            case 1:
                hp = (int)(Random.Range(350, 550) * (GameManager.GetGameManager().currentTime / 100));
                speed = 0.7f;
                attack = 1;
                break;
            case 2:
                hp = (int)(Random.Range(800, 1500) * (GameManager.GetGameManager().currentTime / 100));
                speed = 0.3f;
                attack = 1;
                break;
            case 3:
                hp = (int)(Random.Range(420, 640) * (GameManager.GetGameManager().currentTime / 100));
                speed = 0.8f;
                attack = 1;
                break;
            case 4:
                hp = (int)(Random.Range(500, 1000) * (GameManager.GetGameManager().currentTime / 100));
                speed = 1.5f;
                attack = 1;
                break;
            case 5:
                hp = (int)(Random.Range(150, 300) * (GameManager.GetGameManager().currentTime / 100));
                speed = 1.1f;
                attack = 1;
                break;
        }
        dropgold = (int)((hp * speed) / (GameManager.GetGameManager().currentTime / 100));
        if (GameManager.GetGameManager().Buff[19] == true)
        {
            hp = (int)(hp * 0.9f);
        }
        if (id == 5)
        {
            gameObject.layer = LayerMask.NameToLayer("Stealth");
            StartCoroutine("StartStealth");
        }
        hpSlider.maxValue = hp;
        rb = GetComponent<Rigidbody2D>(); 
        crystalHack = FindObjectOfType<CrystalHack>();
        meshRenderer = gameObject.GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < meshRenderer.Length; i++)
        {
            coloralpha = meshRenderer[i].color;
        }
    }

    // Update is called once per frame  
    void Update()
    {
        hpSlider.value = hp;
      vector3 =  crystalHack.transform.position - transform.position;
        v = vector3.normalized;
        if(gameObject.layer == LayerMask.NameToLayer("Stealth"))
        {
            coloralpha.a = 0.3f;
            for(int i = 0; i < meshRenderer.Length; i++)
            {
                meshRenderer[i].material.color = coloralpha;
            }
        }
        else
        {
            coloralpha.a = 1f;
            for (int i = 0; i < meshRenderer.Length; i++)
            {
                meshRenderer[i].material.color = coloralpha;
            }
        }
        float angle = Mathf.Atan2(vector3.y, vector3.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        if (GameManager.GetGameManager().TimerStop == false)
        {
            rb.velocity = new Vector2(v.x, v.y) * speed;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else
        {
            rb.velocity = Vector2.zero;

        }
        if (hp <= 0)
        {
            hp = 0;
            Destroy(gameObject);
            GameManager.GetGameManager(). GoldT += dropgold;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "playerBullet")
        {
            Bullet bullet = collision.GetComponent<Bullet>();
            if (bullet != null)
            {
                GameManager.GetGameManager().TakeDamage(bullet.player,this);
            }
            if (GameManager.GetGameManager().Buff[12]==false)
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Bullet")
        {
            TowerBullet bullet2 = collision.GetComponent<TowerBullet>();
            if (bullet2.Damage == false && bullet2 != null)
            {
                if (bullet2.a.id == 1 && GameManager.GetGameManager().Buff[7] == true && SlowDebuff == false)
                {
                   SlowDebuff = true;
                    StartCoroutine("SlowTime");
                }
                if (bullet2.a.id != 3 && GameManager.GetGameManager().Buff[9] == false)
                {
                    bullet2.Damage = true;
                }
                GameManager.GetGameManager().TakeDamage(bullet2, this);
                if (bullet2.a.id != 4 && GameManager.GetGameManager().Buff[10] == false)
                {
                    Destroy(collision.gameObject);
                }
            }
        }
        if (collision.tag == "CryStalHack")
        {
            CrystalHack crystal = collision.GetComponent<CrystalHack>();
            if (crystal != null)
            {
                GameManager.GetGameManager().TakeDamage(crystal, this);
            }
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
       
    }
    IEnumerator SlowTime()
    {
        speed = speed * 0.5f;
        yield return new WaitForSeconds(2f);
        speed = speed * 2f;
        SlowDebuff = false;
    }
    IEnumerator StartStealth()
    {
        while (true)
        {
            while (lastStealthTime < 4f)
            {
                lastStealthTime += Time.deltaTime;
                if (decting == false)
                {
                    gameObject.layer = LayerMask.NameToLayer("Stealth");
                }
                else
                {
                    gameObject.layer = LayerMask.NameToLayer("Enemy");
                }
                yield return null;
            }
            lastStealthTime = 0;
            gameObject.layer = LayerMask.NameToLayer("Enemy");
            yield return new WaitForSeconds(2f);
        }
    }
}
