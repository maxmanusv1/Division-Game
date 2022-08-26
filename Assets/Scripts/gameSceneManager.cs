using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class gameSceneManager : MonoBehaviour
{
    [SerializeField]
    GameObject kup, canvas, firstValue, secondValue, scoreText, health1, health2, health3, returnMenu, winmenu;
    [SerializeField]
    Sprite correctanswer;
    private int chancesLeft = 3;
    private int point = 0;
    Vector3 changePoints = new Vector3(-275, 170, 0);
    int[] _randomNumbers_1 = new int[21];
    int[] randomNumbers_2 = new int[21];
    int[] answers = new int[21];
    List<int> randomnumbers_1 = new List<int>();
    List<int> randomnumbers_2 = new List<int>();
    List<int> _answers = new List<int>();
    void Start()
    {
      
        for (int i = 0; i < 20; i++)
        {
            int randomValue = Random.Range(2,15);
            int secondRandomValue = Random.Range(2,13);
            randomnumbers_1.Add(randomValue * secondRandomValue);
            randomnumbers_2.Add(secondRandomValue);
            _answers.Add(randomnumbers_1[i] / randomnumbers_2[i]);
           // Debug.Log("first random nubmer : " + randomnumbers_1[i] + " second random number:   " + randomnumbers_2[i] + " answer is :  " + _answers[i] +" index: "+ i);
        }

        int counter = 0; 
        for (int z = 0; z < 4; z++)
        {
            for (int a = 1; a <= 5; a++)
            {
                GameObject gameObject = Instantiate(kup,changePoints,Quaternion.identity) as GameObject;
                gameObject.transform.SetParent(canvas.transform,false);
                gameObject.GetComponentInChildren<Text>().text = _answers[counter].ToString();
                changePoints.x += 125;
                counter++;
                StartCoroutine(fadeOut(gameObject));
            }
            changePoints.x = -275;
            changePoints.y -= 110;
        }
        int randomValue2 = Random.Range(0,randomnumbers_1.Count-1);
        Debug.Log(randomValue2);
        firstValue.GetComponent<Text>().text = randomnumbers_1[randomValue2].ToString();
        secondValue.GetComponent<Text>().text = randomnumbers_2[randomValue2].ToString();
        randomnumbers_1.RemoveAt(randomValue2);
        randomnumbers_2.RemoveAt(randomValue2);
        _answers.RemoveAt(randomValue2);

    }
    IEnumerator fadeOut(GameObject obj)
    {

        for (float i = 0.01f; i <= 1.1f; i += 0.01f)
        {
            obj.GetComponent<CanvasGroup>().alpha = i;
            yield return new WaitForSeconds(0.010f);
        }
    }
    public void onBtnClick(Button button)
    {
        if (randomnumbers_1.Count!=0)
        { 
        int buttonValue = int.Parse(button.GetComponentInChildren<Text>().text);
        int firsttext = int.Parse(firstValue.GetComponent<Text>().text);
        int secondtext = int.Parse(secondValue.GetComponent<Text>().text);
        if ((firsttext / secondtext) == buttonValue)
        {
            button.image.sprite = correctanswer;
            button.GetComponentInChildren<Text>().text = null;
            button.interactable = false;
        
            int randomValue2 = Random.Range(0, randomnumbers_1.Count-1);
            firstValue.GetComponent<Text>().text = randomnumbers_1[randomValue2].ToString();
            secondValue.GetComponent<Text>().text = randomnumbers_2[randomValue2].ToString();
            randomnumbers_1.RemoveAt(randomValue2);
            randomnumbers_2.RemoveAt(randomValue2);
            _answers.RemoveAt(randomValue2);
            if (buttonValue >= 10)
                point += 15;
            else
                point += 10;

            scoreText.GetComponent<Text>().text = point.ToString();
             
        }
        else
        {
            if (chancesLeft==3)
            {
                Destroy(health3);
                chancesLeft--;
            }
            else if (chancesLeft==2)
            {
                Destroy(health2);
                chancesLeft--;
            }
            else if (chancesLeft==1)
            {
                Destroy(health3);
                returnMenu.GetComponent<RectTransform>().SetAsLastSibling();
                returnMenu.SetActive(true);
            }
        }
        }
        else
        {
            winmenu.GetComponent<RectTransform>().SetAsLastSibling();
            winmenu.SetActive(true);
        }
    }

    void Update()
    {
       
    }
}
