using UnityEngine;
using UnityEngine.Tilemaps;
public class BoardManager : MonoBehaviour
{
    public int width;
    public int height;
    public Tile[] groundTiles;
    public Tile[] wallTiles;
    private Tilemap tilemap;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tilemap = GetComponentInChildren<Tilemap>();

        for(int y = 0; y<height; y++)
        {
            for(int x = 0; x < width; x++)
            {
                Tile tile;

                if(x == 0 || y == 0 || x == width-1 || y == height-1)
                {
                    tile = wallTiles[Random.Range(0, wallTiles.Length)]; //Set Wall tiles if on border edge
                }
                else
                {
                    tile = groundTiles[Random.Range(0, groundTiles.Length)]; //Set Ground tiles if not on border edge
                }
                
                tilemap.SetTile(new Vector3Int(x,y,0), tile);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
