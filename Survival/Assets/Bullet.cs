using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Player player;
    private Vector3 a;
    private Rigidbody2D rb;
    private float R;
    private Vector3 Range;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponentInParent<Player>();
       
        a = player.Bulletposition.normalized;
        Range = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        R = Vector3.Magnitude(transform.position - Range);
        if (R > player.Range)
            Destroy(gameObject);
        rb.velocity = a * 60f;
    }

}
