using UnityEngine;

public class TurnManager
{
    public event System.Action OnTick;
    private int m_TurnCount;

    public TurnManager()
    {
        m_TurnCount = 1;
    }

    public void Tick()
    {
        m_TurnCount++;
        OnTick?.Invoke(); // invokes all callback methods that were registered to the OnTick event. 
        Debug.Log("Current turn count: " + m_TurnCount);
    }
}
