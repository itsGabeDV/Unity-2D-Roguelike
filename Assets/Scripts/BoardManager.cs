using UnityEngine;
using UnityEngine.Tilemaps;
public class BoardManager : MonoBehaviour
{
    public int Width;
    public int Height;
    public Tile[] GroundTiles;
    public Tile[] WallTiles;
    public PlayerController Player;
    private Tilemap m_Tilemap;

    private Grid m_Grid;

    public class CellData
    {
        public bool Passable;
    }
    private CellData[,] m_BoardData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Tilemap = GetComponentInChildren<Tilemap>();
        m_Grid = GetComponentInChildren<Grid>();
        m_BoardData = new CellData[Width, Height];

        for(int y = 0; y < Height; y++)
        {
            for(int x = 0; x < Width; x++)
            {
                Tile tile;
                m_BoardData[x,y] = new CellData();

                if(x == 0 || y == 0 || x == Width-1 || y == Height-1)
                {
                    tile = WallTiles[Random.Range(0, WallTiles.Length)]; //Set Wall tiles if on border edge
                    m_BoardData[x,y].Passable = false; //Set Passable to false for wall tiles    
                }
                else
                {
                    tile = GroundTiles[Random.Range(0, GroundTiles.Length)]; //Set Ground tiles if not on border edge
                    m_BoardData[x,y].Passable = true; //Set Passable to true for ground tiles
                }
                
                m_Tilemap.SetTile(new Vector3Int(x,y,0), tile);
            }
        }

        Player.Spawn(this, new Vector2Int(1,1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 CellToWorld(Vector2Int cell)
    {
        return m_Grid.GetCellCenterWorld((Vector3Int)cell);
    }
    
    public CellData GetCellData(Vector2Int cellIndex)
    {   
        //Retrieve the search on the array to onlyt actual cells available in the level to avoid generating an exception
        //trying to index a cell that doesnt exist   
        if(cellIndex.x < 0 || cellIndex.x >= Width || cellIndex.y < 0 || cellIndex.y >= Height)
        {
            return null;
        }

        return m_BoardData[cellIndex.x, cellIndex.y];
    }
}