using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class StartGame : MonoBehaviour
{
    public UnityEvent OnStartGame;

    private void Update()
    {
        if (Input.touchCount > 0 || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            OnStartGame.Invoke();
            Destroy(this);
        }
    }
}
