using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    private void Awake()
    {
        DataBus.Instance = new DataBus();    
    }

    public void Restart()
    {
        DataBus.Instance = null;
        var index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
       
    }
}
