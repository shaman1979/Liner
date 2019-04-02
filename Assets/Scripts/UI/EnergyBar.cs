using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class EnergyBar : MonoBehaviour, ISubscriber<int>
{
    [Inject]
    public Publisher Publisher { get; set; }

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

    public void UpdateData(int massage)
    {       
        float value = (float)massage / 100;
        AddEnergy(value);
    }
}
