using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    private void OnEnable() 
    {
        Finish.OnFinish += MiniGameStart;
    }
    private void OnDisable() 
    {
        Finish.OnFinish -= MiniGameStart;
    }

    public void MiniGameStart()
    {
        Debug.Log("Finish");
    }
}
