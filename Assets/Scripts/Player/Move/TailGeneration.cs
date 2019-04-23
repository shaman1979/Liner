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

    private Tail[] tails = new Tail[10];
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
            CreatingTail(index);
            isActive = false;
        }
    }

    public void Generating()
    {
        if (index < tails.Length - 1)
        {
            tails[index].Target = null;
            CreatingTail(++index);
        }

        else
        {
            tails[index].Target = null;
            index = 0;
            CreatingTail(index);
        }
    }

    public void CreatingTail(int index)
    {
        tails[index].transform.position = Target.position;
        tails[index].Target = Target;
        tails[index].IsActive = true;
    }
}
