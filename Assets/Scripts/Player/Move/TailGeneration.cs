using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TailGeneration : MonoBehaviour
{
    [Inject(Id = TransformType.Player)]
    public Transform Target { get; set; }

    [SerializeField]
    private Tail prefab;

    private Tail[] tails = new Tail[15];
    private bool isActive = true;
    private int index = 0;
    public void SetActive(bool flag)
    {
        isActive = flag;
    }

    public void StartGame()
    {
        if (isActive)
        {
            for (int i = 0; i < tails.Length; i++)
            {
                tails[i] = Instantiate(prefab) as Tail;
                tails[i].transform.position = new Vector3(100, 100, 1f);
            }
            CreatingTail(index, PlayerMove.Direction.Left);
            isActive = false;
        }
    }

    public void Generating(PlayerMove.Direction direction)
    {
        if (index < tails.Length - 1)
        {
            tails[index].Target = null;
            CreatingTail(++index, direction);
        }

        else
        {
            tails[index].Target = null;
            index = 0;
            CreatingTail(index, direction);
        }
    }

    public void CreatingTail(int index, PlayerMove.Direction direction)
    {
        tails[index].transform.position = 
            new Vector3
            (
                Target.position.x - (direction == PlayerMove.Direction.Left ? 0.05f : -0.05f), 
                Target.position.y - 0.05f, 
                0f
            );
        tails[index].Target = Target;
        tails[index].IsActive = true;
    }
}
