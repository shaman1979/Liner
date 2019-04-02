using UnityEngine;
using UnityEngine.Events;
using Zenject;
public class EndGame : MonoBehaviour, ISubscriber<EndGameValue>
{
    public UnityEvent OnEndGame;

    [Inject]
    public Publisher Publisher { get; set; }
    private void Start()
    {
        Publisher.Subscribe(this as ISubscriber<EndGameValue>);    
    }

    public void UpdateData(EndGameValue massage)
    {
        Debug.Log("End Game");
        OnEndGame.Invoke();       
    }
}

public class EndGameValue
{
    [Inject]
    public ScoreValue Score { get; set; }
}
