using UnityEngine;
using UnityEngine.Events;

public class EndGame : MonoBehaviour, ISubscriber<EndGameValue>
{
    public UnityEvent OnEndGame;

    private void Start()
    {
        DataBus.Instance.Subscribe(this as ISubscriber<EndGameValue>);    
    }

    public void UpdateData(EndGameValue massage)
    {
        Debug.Log("End Game");
        OnEndGame.Invoke();       
    }
}

public class EndGameValue
{
    public float Score { get { return Score; } set { Score = value; } }
}
