using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ScoreText : MonoBehaviour, ISubscriber<ScoreValue>
{
    private Text selfText;

    public void UpdateData(ScoreValue massage)
    {
        selfText.text = massage.Value.ToString();
    }

    private void Start()
    {
        selfText = GetComponent<Text>();
        DataBus.Instance.Subscribe(this);
    }
}

public class ScoreValue
{
    public int Value { get; set; }
}
