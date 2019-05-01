using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Реализация паттерна Стратегия 
public interface ISpawnType
{}

public interface ISpawnType<T> : ISpawnType
{
    Vector2 SetPosition(T points);
}

public class RandomSpawn : ISpawnType<Vector2[]>
{
    /// <summary>
    /// Реализация интерсейса ISpawnType для элементов которые создаются в рандомной позиции 
    /// </summary>
    /// <param name="points">Левая и правая сторона</param>
    /// <returns>Рандомное значение относительно pointsp[1] и points[0]</returns>
    public Vector2 SetPosition(Vector2[] points)
    {
        return new Vector2(Random.Range(points[0].x, 0), points[0].y); 
    }
}

public class AnchorSpawn : ISpawnType<Vector2>
{
    /// <summary>
    ///Реализация интерсейса ISpawnType для элементов которые создаются в определенной позиции 
    /// </summary>
    /// <param name="points">Точка создания </param>
    /// <returns> Возвращает точку создания </returns>
    public Vector2 SetPosition(Vector2 points)
    {
        return points;
    }
}
