using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class Spawner : MonoBehaviour
{
    [SerializeField]
    private float interval;
    [SerializeField]
    private GameObject[] objects;
    [SerializeField]
    private float minX;
    [SerializeField]
    private float maxX;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            var position = GetPosition();
            GameObject obj = Instantiate(objects[0], position, Quaternion.identity);
            yield return new WaitForSeconds(interval);
        }
    }

    private Vector2 GetPosition()
    {
        return new Vector2(UnityEngine.Random.Range(minX, maxX) + transform.position.x, 5);
    }
}
