using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public BoardManager Board;
    public PlayerController Player;
    public TurnManager TurnManager { get; private set;}

    private int m_FoodAmount = 100;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TurnManager = new TurnManager();
        TurnManager.OnTick += OnTurnHappen;

        Board.Init();
        Player.Spawn(Board, new Vector2Int(1,1)); //Spawn the player on the Board at position 1,1 
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTurnHappen()
    {
        m_FoodAmount -= 1;
        Debug.Log("Current amount of food: " + m_FoodAmount);
    }
}
