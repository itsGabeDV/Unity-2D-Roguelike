using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInput PlayerInput;
    private InputAction m_MoveAction;
    private BoardManager m_BoardManager;
    private Vector2Int m_CurrentPosition;

    public void Start()
    {
        m_MoveAction = PlayerInput.actions["Move"];
    }
    public void Update()
    {
        Vector2Int newCellTarget = m_CurrentPosition;
        bool hasMoved = false;
        if(m_MoveAction.WasPressedThisFrame()){
            Vector2 moveInput = m_MoveAction.ReadValue<Vector2>();
            if(moveInput.y > 0.5f)
            {
                newCellTarget.y += 1;
                hasMoved = true;
            }
            else if(moveInput.y < -0.5f)
            {
                newCellTarget.y -= 1;
                hasMoved = true;
            }
            else if(moveInput.x < -0.5f)
            {
                newCellTarget.x -=1;
                hasMoved = true;
            }
            else if(moveInput.x > 0.5f)
            {
                newCellTarget.x += 1;
                hasMoved = true;
            }
        }
        
        if(hasMoved)
        {
            //Check if new position is passable then move there if it is 
            BoardManager.CellData cellData = m_BoardManager.GetCellData(newCellTarget);

            if(cellData != null && cellData.Passable)
            {
                MoveTo(newCellTarget);
            }
        }
    }

    public void MoveTo(Vector2Int cell)
    {
        m_CurrentPosition = cell;
        transform.position = m_BoardManager.CellToWorld(cell);
    }
    public void Spawn(BoardManager manager, Vector2Int cell)
    {
        m_BoardManager = manager;
        MoveTo(cell);
    }
}
