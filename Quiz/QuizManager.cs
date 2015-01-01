using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{

    public List<QuizSet> sets = new List<QuizSet>();
    public GameObject buttonPrefab;
    public int setNumber;
    Transform panel;
    public Text headerTxt;
    public Text finished;
    public static QuizManager Instance;

    void Awake()
    {
        Instance = this;
        setNumber = 0;
        panel = GameObject.Find("Answer Panel").transform;
        GetNextSet();
    }
    void GetNextSet()
    {
        foreach (Transform child in panel)
        {
            GameObject.Destroy(child.gameObject);
        }

        if (sets.Count > setNumber)
        {
            for (int i = 0; i < sets[setNumber].questions.Length; i++)
            {
                GameObject go = (GameObject)Instantiate(buttonPrefab);
                go.transform.SetParent(panel);
                go.name = i + "";
                go.GetComponentInChildren<Text>().text = sets[setNumber].questions[i];
            }
            headerTxt.text = sets[setNumber].title;
        }
        else Debug.Log("Out of questions");
    }

    public void Back()
    {
        if (setNumber > 0)
        {
            setNumber--;
            GetNextSet();
        }
    }

    public void Next()
    {
        if (setNumber < sets.Count - 1)
        {
            setNumber++;
            GetNextSet();
        }
    }
    public void SetSet(int number)
    {
        if (number < sets.Count - 1 && number > 0)
        {
            setNumber = number;
            GetNextSet();
        }
    }
    public void Finish(int buttonID)
    {
        if (buttonID == sets[setNumber].rightOne)
        {
            finished.text = "YES";
            finished.GetComponent<Animator>().SetTrigger("Won");
        }
        else if (buttonID != sets[setNumber].rightOne)
        {
            finished.text = "NO";
            finished.GetComponent<Animator>().SetTrigger("Won");
        }
    }
}
