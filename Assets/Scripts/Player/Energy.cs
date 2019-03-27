using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Energy : MonoBehaviour, ISubscriber<int>
{
    public UnityEvent OnDestroy;

    [SerializeField]
    private int energy = 100;
    [SerializeField]
    private int interval = 5;
    [SerializeField]
    private int remove = -1;

    private void Start()
    {
        StartCoroutine(RemoveEnergy());
        DataBus.Instance.Subscribe(this as ISubscriber);
    }

    IEnumerator RemoveEnergy()
    {
        while(energy > 0f)
        {
            yield return new WaitForSeconds(interval);
            energy += remove;
            DataBus.Instance.Notify<float>(remove);

            if(energy <= 0)
            {
                OnDestroy.Invoke();
            }
        }
        yield return new WaitForSeconds(interval);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void Update(int massage)
    {
        if (energy + massage <= 100)
            energy += massage;
        else if (energy + massage > 100)
            energy = 100;
    }
}
