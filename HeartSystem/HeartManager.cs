using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class HeartManager : MonoBehaviour
{

    public List<Heart> rHearts = new List<Heart>();
    public List<Heart> bHearts = new List<Heart>();
    public Sprite[] collectionHearts;
    public int maxHearts = 12;
    public Image[] outputList;
    public int heartNumber;
    public int currentHearts;
    public int lastDone;
    public Text txtHeart;
    public Text txtHalf;
    public HeartChoices heartAdd;
    public HalfChoices halfFull;
    private int oldMaxHearts = 12;

    public enum HeartChoices
    {
        Red,
        Black,
        Blue
    }
    public enum HalfChoices
    {
        half,
        full
    }

    public void Awake()
    {
        oldMaxHearts = maxHearts;
        halfFull = HalfChoices.full;
        heartAdd = HeartChoices.Red;
        Refresh();
    }
    public void Update()
    {
        if (maxHearts > outputList.Length)
        {
            maxHearts = outputList.Length;
        }
        currentHearts = rHearts.Count + bHearts.Count;
        txtHalf.text = "Adding/Removing a " + halfFull + " heart";
        txtHeart.text = "Current Heart: " + heartAdd;
        if (oldMaxHearts != maxHearts)
        {
            Refresh();
            oldMaxHearts = maxHearts;
        }
    }

    public void AddHeart()
    {
        if (currentHearts < maxHearts)
        {
            if (currentHearts > 0)
            {
                if (heartAdd == HeartChoices.Red)
                {
                    if (rHearts.Count > 0)
                    {
                        if (halfFull == HalfChoices.full)
                        {
                            if (rHearts[rHearts.Count - 1].isHalf)
                            {
                                Sprite interchange;
                                rHearts[rHearts.Count - 1].isHalf = false;
                                interchange = rHearts[rHearts.Count - 1].mainHeart;
                                rHearts[rHearts.Count - 1].mainHeart = rHearts[rHearts.Count - 1].otherHeart;
                                rHearts[rHearts.Count - 1].otherHeart = interchange;
                                rHearts.Add(new Heart(collectionHearts[heartNumber], true, collectionHearts[heartNumber + 1], heartNumber));
                            }
                            else if (!rHearts[rHearts.Count - 1].isHalf)
                            {
                                rHearts.Add(new Heart(collectionHearts[heartNumber], false, collectionHearts[heartNumber + 1], heartNumber));
                            }
                        }
                        else if (halfFull == HalfChoices.half)
                        {
                            if (rHearts[rHearts.Count - 1].isHalf)
                            {
                                Sprite interchange;
                                rHearts[rHearts.Count - 1].isHalf = false;
                                interchange = rHearts[rHearts.Count - 1].mainHeart;
                                rHearts[rHearts.Count - 1].mainHeart = rHearts[rHearts.Count - 1].otherHeart;
                                rHearts[rHearts.Count - 1].otherHeart = interchange;
                            }
                            else if (!rHearts[rHearts.Count - 1].isHalf)
                            {
                                rHearts.Add(new Heart(collectionHearts[heartNumber], true, collectionHearts[heartNumber + 1], heartNumber));
                            }
                        }
                    }
                    else
                    {
                        if (heartAdd == HeartChoices.Red)
                        {
                            if (halfFull == HalfChoices.full)
                            {
                                rHearts.Add(new Heart(collectionHearts[heartNumber], false, collectionHearts[heartNumber + 1], heartNumber));
                            }
                            else if (halfFull == HalfChoices.half)
                            {
                                rHearts.Add(new Heart(collectionHearts[heartNumber], true, collectionHearts[heartNumber + 1], heartNumber));
                            }
                        }
                    }
                }
                else if (heartAdd == HeartChoices.Black || heartAdd == HeartChoices.Blue)
                {
                    if (bHearts.Count > 0)
                    {
                        if (halfFull == HalfChoices.full)
                        {
                            if (bHearts[bHearts.Count - 1].isHalf)
                            {
                                Sprite interchange;
                                bHearts[bHearts.Count - 1].isHalf = false;
                                interchange = bHearts[bHearts.Count - 1].mainHeart;
                                bHearts[bHearts.Count - 1].mainHeart = bHearts[bHearts.Count - 1].otherHeart;
                                bHearts[bHearts.Count - 1].otherHeart = interchange;
                                bHearts.Add(new Heart(collectionHearts[heartNumber], true, collectionHearts[heartNumber + 1], heartNumber));
                            }
                            else if (!bHearts[bHearts.Count - 1].isHalf)
                            {
                                bHearts.Add(new Heart(collectionHearts[heartNumber], false, collectionHearts[heartNumber + 1], heartNumber));
                            }
                        }
                        else if (halfFull == HalfChoices.half)
                        {
                            if (bHearts[bHearts.Count - 1].isHalf)
                            {
                                Sprite interchange;
                                bHearts[bHearts.Count - 1].isHalf = false;
                                interchange = bHearts[bHearts.Count - 1].mainHeart;
                                bHearts[bHearts.Count - 1].mainHeart = bHearts[bHearts.Count - 1].otherHeart;
                                bHearts[bHearts.Count - 1].otherHeart = interchange;
                            }
                            else if (!bHearts[bHearts.Count - 1].isHalf)
                            {
                                bHearts.Add(new Heart(collectionHearts[heartNumber], true, collectionHearts[heartNumber + 1], heartNumber));
                            }
                        }
                    }
                    else
                    {
                        if (heartAdd == HeartChoices.Black || heartAdd == HeartChoices.Blue)
                        {
                            if (halfFull == HalfChoices.full)
                            {
                                bHearts.Add(new Heart(collectionHearts[heartNumber], false, collectionHearts[heartNumber + 1], heartNumber));
                            }
                            else if (halfFull == HalfChoices.half)
                            {
                                bHearts.Add(new Heart(collectionHearts[heartNumber], true, collectionHearts[heartNumber + 1], heartNumber));
                            }
                        }
                    }
                }
            }
            else
            {
                if (heartAdd == HeartChoices.Blue || heartAdd == HeartChoices.Black)
                {
                    if (halfFull == HalfChoices.full)
                    {
                        bHearts.Add(new Heart(collectionHearts[heartNumber], false, collectionHearts[heartNumber + 1], heartNumber));
                    }
                    else if (halfFull == HalfChoices.half)
                    {
                        bHearts.Add(new Heart(collectionHearts[heartNumber], true, collectionHearts[heartNumber + 1], heartNumber));
                    }
                }
                else if (heartAdd == HeartChoices.Red)
                {
                    if (halfFull == HalfChoices.full)
                    {
                        rHearts.Add(new Heart(collectionHearts[heartNumber], false, collectionHearts[heartNumber + 1], heartNumber));
                    }
                    else if (halfFull == HalfChoices.half)
                    {
                        rHearts.Add(new Heart(collectionHearts[heartNumber], true, collectionHearts[heartNumber + 1], heartNumber));
                    }
                }

            }
        }
        Refresh();
    }

    public void RemoveHeart()
    {
        if (bHearts.Count > 0)
        {
            if (!bHearts[0].isHalf)
            {
                if (halfFull == HalfChoices.full)
                {
                    if (!bHearts[bHearts.Count - 1].isHalf)
                    {
                        bHearts.Remove(bHearts[bHearts.Count - 1]);
                    }
                    else if (bHearts[bHearts.Count - 1].isHalf)
                    {
                        bHearts.Remove(bHearts[bHearts.Count - 1]);
                        Sprite interchange;
                        bHearts[bHearts.Count - 1].isHalf = true;
                        interchange = bHearts[bHearts.Count - 1].mainHeart;
                        bHearts[bHearts.Count - 1].mainHeart = bHearts[bHearts.Count - 1].otherHeart;
                        bHearts[bHearts.Count - 1].otherHeart = interchange;
                    }
                }
                else if (halfFull == HalfChoices.half)
                {
                    if (bHearts[bHearts.Count - 1].isHalf)
                    {
                        bHearts.Remove(bHearts[bHearts.Count - 1]);
                    }
                    else if (!bHearts[bHearts.Count - 1].isHalf)
                    {
                        Sprite interchange;
                        bHearts[bHearts.Count - 1].isHalf = true;
                        interchange = bHearts[bHearts.Count - 1].mainHeart;
                        bHearts[bHearts.Count - 1].mainHeart = bHearts[bHearts.Count - 1].otherHeart;
                        bHearts[bHearts.Count - 1].otherHeart = interchange;
                    }
                }
            }
            else
            {
                bHearts.Remove(bHearts[0]);
            }
        }
        else if (rHearts.Count > 0)
        {
            if (!rHearts[0].isHalf)
            {
                if (halfFull == HalfChoices.full)
                {
                    if (!rHearts[rHearts.Count - 1].isHalf)
                    {
                        rHearts.Remove(rHearts[rHearts.Count - 1]);
                    }
                    else if (rHearts[rHearts.Count - 1].isHalf)
                    {
                        rHearts.Remove(rHearts[rHearts.Count - 1]);
                        Sprite interchange;
                        rHearts[rHearts.Count - 1].isHalf = true;
                        interchange = rHearts[rHearts.Count - 1].mainHeart;
                        rHearts[rHearts.Count - 1].mainHeart = rHearts[rHearts.Count - 1].otherHeart;
                        rHearts[rHearts.Count - 1].otherHeart = interchange;
                    }
                }
                else if (halfFull == HalfChoices.half)
                {
                    if (rHearts[rHearts.Count - 1].isHalf)
                    {
                        rHearts.Remove(rHearts[rHearts.Count - 1]);
                    }
                    else if (!rHearts[rHearts.Count - 1].isHalf)
                    {
                        Sprite interchange;
                        rHearts[rHearts.Count - 1].isHalf = true;
                        interchange = rHearts[rHearts.Count - 1].mainHeart;
                        rHearts[rHearts.Count - 1].mainHeart = rHearts[rHearts.Count - 1].otherHeart;
                        rHearts[rHearts.Count - 1].otherHeart = interchange;
                    }
                }
            }
            else
            {
                rHearts.Remove(rHearts[0]);
            }
        }
        Refresh();
    }

    public void Refresh()
    {
        lastDone = 0;
        for (int i = 0; i < outputList.Length; i++)
        {
            outputList[i].sprite = collectionHearts[6];
            outputList[i].color = Color.white;
        }
        for (int i = 0; i < rHearts.Count; i++)
        {
            outputList[lastDone].sprite = rHearts[i].mainHeart;
            lastDone += 1;
        }
        for (int i = 0; i < bHearts.Count; i++)
        {
            outputList[lastDone].sprite = bHearts[i].mainHeart;
            lastDone += 1;
        }
        for (int i = 0; i < outputList.Length; i++)
        {
            if (i >= maxHearts)
            {
                outputList[i].sprite = null;
                outputList[i].color = Color.clear;
            }
        }

    }

    public void SwitchHeartMode()
    {
        switch (heartAdd)
        {
            case HeartChoices.Red:
                heartAdd = HeartChoices.Black;
                heartNumber = 4;
                break;
            case HeartChoices.Black:
                heartAdd = HeartChoices.Blue;
                heartNumber = 2;
                break;
            case HeartChoices.Blue:
                heartAdd = HeartChoices.Red;
                heartNumber = 0;
                break;
        }
    }
    public void AddHalf()
    {
        switch (halfFull)
        {
            case HalfChoices.full:
                halfFull = HalfChoices.half;
                break;
            case HalfChoices.half:
                halfFull = HalfChoices.full;
                break;
        }
    }
    public void RemoveAddHearts(int number, HalfChoices hF, int howManyTimes, bool removeAdd, HeartChoices hC) //False is remove, true is add
    {
        heartAdd = hC;
        halfFull = hF;
        heartNumber = number;
        for (int i = 0; i < howManyTimes; i++)
        {
            if (!removeAdd)
            {
                RemoveHeart();
            }
            else if (removeAdd)
            {
                AddHeart();
            }
        }
    }
}
