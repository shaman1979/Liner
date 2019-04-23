using System.Collections;
using UnityEngine;
using Zenject;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private float interval;
    [SerializeField]
    private GameObject[] objects;
    [SerializeField]
    private Transform parent;

    [Inject]
    public Publisher Publisher { get; set; }
    [Inject]
    public GameConfig GameConfig { get; set; }

    public void StartGame()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            var position = GetPosition();
            Score obj = Instantiate(objects[0],parent).GetComponent<Score>() as Score;
            obj.Publisher = Publisher;
            obj.transform.position = position;
            yield return new WaitForSeconds(interval);
        }
    }

    private Vector2 GetPosition()
    {
        return new Vector2
        (
            Random.Range
            (
                GameConfig.SpawnZone.LeftX,
                GameConfig.SpawnZone.RightX
            ),
            GameConfig.SpawnZone.UpY
        );
    }
}
