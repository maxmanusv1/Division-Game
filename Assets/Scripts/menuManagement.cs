using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menuManagement : MonoBehaviour
{
    [SerializeField]
    private GameObject startBtn, exitBtn;
    private Vector3 startbtnPoint = new Vector3(638,442,0);
    private Vector3 exitbtnPoint = new Vector3(-2,6,0);
    IEnumerator fadeOut()
    {

        for (float i = 0.01f; i <= 1.1f; i += 0.01f)
        {
            startBtn.GetComponent<CanvasGroup>().alpha = i;
            exitBtn.GetComponent<CanvasGroup>().alpha = i;
            yield return new WaitForSeconds(0.010f);
        }
    }
    public void startBtnClick()
    {
        SceneManager.LoadScene("gameScene");
    }
    public void exitBtnClick()
    {
        Application.Quit();
    }

    void Start()
    {
        StartCoroutine(fadeOut());
    }
    private void Update()
    {
    }
}
