using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class Energy : MonoBehaviour
{
    [SerializeField]
    private float energy = 1f;
    [SerializeField]
    private float interval = 0.5f;
    [SerializeField]
    private float remove = -0.01f;
    [Inject]
    public IPublisher Publisher { get; set; }

    private void Start()
    {
        StartCoroutine(RemoveEnergy());
    }

    IEnumerator RemoveEnergy()
    {
        while(energy > 0f)
        {
            yield return new WaitForSeconds(interval);
            energy += remove;
            Publisher.Notify<float>(remove);
        }

        yield return new WaitForSeconds(interval);
    }
}
