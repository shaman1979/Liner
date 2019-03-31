using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EndGame : MonoBehaviour, ISubscriber<EndGameValue>
{
    public UnityEvent OnEndGame;

    public void UpdateData(EndGameValue massage)
    {
        OnEndGame.Invoke();
    }
}

public class EndGameValue
{
    public float Score { get; set; }
}
