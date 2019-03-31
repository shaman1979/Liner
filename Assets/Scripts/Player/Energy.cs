using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Energy : MonoBehaviour, ISubscriber<int>
{
    [SerializeField]
    private int energy = 100;
    [SerializeField]
    private int interval = 1;
    [SerializeField]
    private int remove = -1;

    private void Start()
    {
        DataBus.Instance.Subscribe(this as ISubscriber);
    }

    public void StartGame()
    {
        StartCoroutine(RemoveEnergy());
    }

    IEnumerator RemoveEnergy()
    {
        while (energy > 0f)
        {
            yield return new WaitForSeconds(interval);
            energy += remove;
            DataBus.Instance.Notify(remove);
        }

        if (energy <= 0)
        {
            DataBus.Instance.Notify<EndGameValue>(new EndGameValue());
        }
        yield return new WaitForSeconds(interval);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void UpdateData(int massage)
    {
        if (energy + massage <= 100)
            energy += massage;
        else if (energy + massage > 100)
            energy = 100;
    }
}
