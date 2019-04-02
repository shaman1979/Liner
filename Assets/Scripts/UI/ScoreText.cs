using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ScoreText : MonoBehaviour, ISubscriber<ScoreValue>
{
    private Text selfText;

    [Inject]
    public Publisher Publisher { get; set; }

    public void UpdateData(ScoreValue massage)
    {
        selfText.text = massage.Value.ToString();
    }

    private void Start()
    {
        selfText = GetComponent<Text>();
        Publisher.Subscribe(this);
    }
}

public class ScoreValue
{
    public int Value { get; set; }
}
