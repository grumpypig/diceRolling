using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class HeartHandler : MonoBehaviour
{
    public Sprite[] hearts;
    public int hn;
    public Image[] heartPhoto;
    public Sprite empty;
    public List<Hearts> lHearts = new List<Hearts>();
    public InputField set;
    public bool switchBI;
    public float halfHearts;
    public int MaxHearts = 12;
    public HeartChoices choicesH;
    public int HeartsNumber;
    public Text txt;
    public addHalf isHalfH;
    public int LastDone;
    public bool HasBlueBlack;
    public int BlueBlack;
    public int RedHCount;

    public enum addHalf
    {
        half,
        full
    }

    public enum HeartChoices
    {
        Red,
        Black,
        Blue
    }
    public void Awake()
    {
        LastDone = -1;
        isHalfH = addHalf.full;
        choicesH = HeartChoices.Red;
    }

    public void Update()
    {
        RedHCount = -1;
        if (lHearts.Count > 0)
        {
            for (int i = 0; i < lHearts.Count; i++)
            {
                if (lHearts[i].Number == 2 || lHearts[i].Number == 4)
                {
                    if (!HasBlueBlack)
                    {
                        HasBlueBlack = true;
                    }
                    BlueBlack = i;
                }
                else if (HasBlueBlack)
                {
                    if (lHearts[i].Number == 0)
                    {
                        RedHCount += 1;
                    }
                }
            }
            if (RedHCount == lHearts.Count-1)
            {
                HasBlueBlack = false;
            }
        }
        if (choicesH == HeartChoices.Red)
        {
            HeartsNumber = 0;
        }
        else if (choicesH == HeartChoices.Black)
        {
            HeartsNumber = 4;
        }
        else if (choicesH == HeartChoices.Blue)
        {
            HeartsNumber = 2;
        }
        if (isHalfH == addHalf.half)
        {
            txt.text = "Current Heart: " + choicesH;
            txt.text += "\nRemoving a: Half Heart";
        }
        else if (isHalfH == addHalf.full)
        {
            txt.text = "Current Heart: " + choicesH;
            txt.text += "\nRemoving a: Full Heart";
        }
    }

    public void DoHearts()
    {
        if (switchBI)
        {
            float.TryParse(set.text, out halfHearts);
            if (halfHearts != 0.5f)
            {
                for (float i = 0; i < halfHearts; i += 0.5f)
                {
                    if (lHearts.Count < MaxHearts)
                    {
                        if (i < halfHearts && i % 1 == 0)
                        {
                            if (halfHearts % 1 == 0.5 && i == halfHearts - 1.5f)
                            {

                            }
                            else
                            {
                                lHearts.Add(new Hearts(hearts[HeartsNumber], false, hearts[HeartsNumber + 1], HeartsNumber));
                            }
                        }
                        if (halfHearts % 1 == 0.5 && i == halfHearts - 0.5f)
                        {
                            lHearts.Add(new Hearts(hearts[HeartsNumber], true, hearts[HeartsNumber + 1], HeartsNumber));
                        }
                    }
                }
            }
            else lHearts.Add(new Hearts(hearts[HeartsNumber], true, hearts[HeartsNumber + 1], HeartsNumber));
        }
        Refresh();
    }
    public void RemoveHeart()
    {
        if (isHalfH == addHalf.full)
        {
            if (HasBlueBlack)
            {
                lHearts.Remove(lHearts[BlueBlack]);
            }else
                lHearts.Remove(lHearts[lHearts.Count - 1]);
        }
        else if (isHalfH == addHalf.half)
        {
            if (HasBlueBlack)
            {
                if (lHearts[BlueBlack].isHalf)
                {
                    lHearts.Remove(lHearts[BlueBlack]);
                }
                else
                {
                    Sprite interchange;
                    lHearts[lHearts.Count - 1].isHalf = true;
                    interchange = lHearts[lHearts.Count - 1].heart;
                    lHearts[lHearts.Count - 1].heart = lHearts[lHearts.Count - 1].other;
                    lHearts[lHearts.Count - 1].other = interchange;
                }
            }
            else
            {
                if (lHearts[lHearts.Count - 1].isHalf)
                {
                    lHearts.Remove(lHearts[lHearts.Count - 1]);
                }
                else if (!lHearts[lHearts.Count - 1].isHalf)
                {
                    Sprite interchange;
                    lHearts[lHearts.Count - 1].isHalf = true;
                    interchange = lHearts[lHearts.Count - 1].heart;
                    lHearts[lHearts.Count - 1].heart = lHearts[lHearts.Count - 1].other;
                    lHearts[lHearts.Count - 1].other = interchange;
                }
            }
        }
        Refresh();
    }
    public void Switch()
    {
        if (choicesH == HeartChoices.Red)
        {
            choicesH = HeartChoices.Black;
            HeartsNumber = 4;
        }
        else if (choicesH == HeartChoices.Black)
        {
            choicesH = HeartChoices.Blue;
            HeartsNumber = 2;
        }
        else if (choicesH == HeartChoices.Blue)
        {
            choicesH = HeartChoices.Red;
            HeartsNumber = 0;
        }
    }
    public void AddHalf()
    {
        if (isHalfH == addHalf.full)
        {
            isHalfH = addHalf.half;
        }
        else if (isHalfH == addHalf.half)
        {
            isHalfH = addHalf.full;
        }
    }
    public void Refresh()
    {
        for (int i = 0; i < heartPhoto.Length; i++)
        {
            heartPhoto[i].sprite = empty;
            LastDone = 0;
        }
        for (int i = 0; i < lHearts.Count; i++)
        {//For the red hearts
            if (lHearts[i].Number == 0 && heartPhoto[LastDone].sprite == empty)
            {
                heartPhoto[LastDone].sprite = lHearts[i].heart;
                LastDone += 1;
            }
        }
        for (int i = 0; i < lHearts.Count; i++)
        {//For the both
            if (lHearts[i].Number == 4 && heartPhoto[LastDone].sprite == empty)
            {
                heartPhoto[LastDone].sprite = lHearts[i].heart;
                LastDone += 1;
            }
            if (lHearts[i].Number == 2 && heartPhoto[LastDone].sprite == empty)
            {
                heartPhoto[LastDone].sprite = lHearts[i].heart;
                LastDone += 1;
            }
        }
    }
}
