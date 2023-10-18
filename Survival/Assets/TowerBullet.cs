using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBullet : MonoBehaviour
{
    public towerScript a;
    private Vector2 v;
    private Rigidbody2D rb;
    private float R;
    private Vector3 Range;
    public bool Damage;
    
    // Start is called before the first frame update
    void Start()
    {
        Damage = false;
        a=GetComponentInParent<towerScript>();
        rb = GetComponent<Rigidbody2D>();
        v = a.BulletSpeed.normalized;
        Range = a.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (v == null)
        {
            Destroy(gameObject);
        }
        R = Vector3.Magnitude(transform.position - Range);
        if (R > a.Range)
            Destroy(gameObject);
        rb.velocity = v * 60f;
    }
}
