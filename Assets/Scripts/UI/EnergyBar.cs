using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class EnergyBar : MonoBehaviour, ISubscriber<float>
{
    [Inject]
    public IPublisher Publisher { get; set; }

    private Image selfImage;

    private void Start()
    {
        Publisher.Subscribe(this as ISubscriber);
        selfImage = GetComponent<Image>();
    }

    private void AddEnergy(float value)
    {
        selfImage.fillAmount += value;
    }

    private void RemoveEnergy(float value)
    {
        selfImage.fillAmount += value;
    }

    public void Update(float massage)
    {
        if(massage > 0)
        {
            AddEnergy(massage);
        }
        else
        {
            RemoveEnergy(massage);
        }
    }
}
