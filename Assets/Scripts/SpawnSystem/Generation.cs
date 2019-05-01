using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Generation : MonoBehaviour
{
    [Inject]
    public Libriary Libriary { get; set; }

    [Inject]
    public GameConfig GameConfig { get; set; }

    private float timeOffset = 1f;

    public void StartGame()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeOffset);
            CreatingEnemy();
        }
    }

    private void CreatingEnemy()
    {
        var enemes = Libriary.Search((ZoneType)UnityEngine.Random.Range(0,3));

        for (int i = 0; i < enemes.Count; i++)
        {
            var enemy = Instantiate(enemes[i]);

            enemy.GetPosition
                (
                new Vector2[]
                    {
                        new Vector2(GameConfig.SpawnZone.LeftX, GameConfig.SpawnZone.UpY),
                        new Vector2(GameConfig.SpawnZone.RightX, GameConfig.SpawnZone.UpY)
                    }
                );
        }

    }
}
