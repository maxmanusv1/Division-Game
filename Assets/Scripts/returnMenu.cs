using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class returnMenu : MonoBehaviour
{
    public void menuClick()
    {
        SceneManager.LoadScene("menuLevel");
    }
    public void restartClick()
    {
        SceneManager.LoadScene("gameScene");
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
