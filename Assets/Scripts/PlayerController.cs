using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private BoardManager m_BoardManager;
    private Vector2Int m_CurrentPosition;

    public void Spawn(BoardManager manager, Vector2Int cell)
    {
        m_BoardManager = manager;
        m_CurrentPosition = cell;

        //Move to the correct position
        transform.position = m_BoardManager.CellToWorld(cell);
    }
}
