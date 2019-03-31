using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Points : MonoBehaviour
{
    [Inject]
    public ScoreValue ScoreValue { get; set; }

    [SerializeField]
    private float interval;
    [SerializeField]
    private int point;

    public void StartGame()
    {
        StartCoroutine(AddPoint());
    }

    public void StopGame()
    {
        StopAllCoroutines();
    }

    IEnumerator AddPoint()
    {
        while(true)
        {
            ScoreValue.Value += point;
            DataBus.Instance.Notify(ScoreValue);
            yield return new WaitForSeconds(interval);
        }
    }
}
