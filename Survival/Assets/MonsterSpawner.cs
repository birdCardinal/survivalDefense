using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject[] Monster = new GameObject[6];
    public Tilemap tilemap;
    public TilemapCollider2D tilemapCollider2D;
    public Vector3 worldPos;
    List<Vector3Int> outline = new List<Vector3Int>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (Vector3Int pos in tilemap.cellBounds.allPositionsWithin)
        {
            TileBase tile = tilemap.GetTile(pos);
            if (tile != null)
                outline.Add(pos);
        }
        StartCoroutine("spawnerMonster");
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator spawnerMonster()
    {
        while (GameManager.GetGameManager().currentTime<=1800)
        {
            if (GameManager.GetGameManager().TimerStop == false)
            {
                int a = Random.Range(0, outline.Count);
                worldPos = outline[a];
                Vector3Int worldToCellPos = tilemap.WorldToCell(worldPos);
                int i = Random.Range(0, Monster.Length);
                Instantiate(Monster[i], worldToCellPos, transform.rotation);
                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }
    }

}
