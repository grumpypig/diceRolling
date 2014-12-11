using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class HeartAdding : MonoBehaviour
{

    public List<Hearts> rHearts = new List<Hearts>();
    public List<Hearts> bHearts = new List<Hearts>();
    public Sprite[] sHearts;
    public int maxHearts = 12;
    public Image[] heartList;
    public int heartNumber;
    public HeartChoices heartToAdd;
    public HalfChoices halfFull;
    public int currentHearts;
    public int lastDone;
    public bool Test;
    public Text txtHeart;
    public Text txtHalf;

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
        halfFull = HalfChoices.full;
        heartToAdd = HeartChoices.Red;
    }
    public void Update()
    {
        currentHearts = rHearts.Count + bHearts.Count;
        txtHalf.text = "Adding/Removing a " + halfFull + " heart";
        txtHeart.text = "Current Heart: " + heartToAdd;
    }

    public void AddHeart()
    {
        if (currentHearts < maxHearts)
        {
            if (currentHearts > 0)
            {
                if (heartToAdd == HeartChoices.Red)
                {
                   if (rHearts.Count > 0)
                        {
                    if (halfFull == HalfChoices.full)
                    {
                            if (rHearts[rHearts.Count - 1].isHalf)
                            {
                                Sprite interchange;
                                rHearts[rHearts.Count - 1].isHalf = false;
                                interchange = rHearts[rHearts.Count - 1].heart;
                                rHearts[rHearts.Count - 1].heart = rHearts[rHearts.Count - 1].other;
                                rHearts[rHearts.Count - 1].other = interchange;
                                rHearts.Add(new Hearts(sHearts[heartNumber], true, sHearts[heartNumber + 1], heartNumber));
                            }
                            else if (!rHearts[rHearts.Count - 1].isHalf)
                            {
                                rHearts.Add(new Hearts(sHearts[heartNumber], false, sHearts[heartNumber + 1], heartNumber));
                            }
                        }
                            else if (halfFull == HalfChoices.half)
                            {
                                if (rHearts[rHearts.Count - 1].isHalf)
                                {
                                    Sprite interchange;
                                    rHearts[rHearts.Count - 1].isHalf = false;
                                    interchange = rHearts[rHearts.Count - 1].heart;
                                    rHearts[rHearts.Count - 1].heart = rHearts[rHearts.Count - 1].other;
                                    rHearts[rHearts.Count - 1].other = interchange;
                                }
                                else if (!rHearts[rHearts.Count - 1].isHalf)
                                {
                                    rHearts.Add(new Hearts(sHearts[heartNumber], true, sHearts[heartNumber + 1], heartNumber));
                                }
                            }
                   }
                        else
                        {
                            if (halfFull == HalfChoices.full)
                            {
                                if (heartToAdd == HeartChoices.Red)
                                {
                                    rHearts.Add(new Hearts(sHearts[heartNumber], false, sHearts[heartNumber + 1], heartNumber));
                                }
                            }
                            else if (halfFull == HalfChoices.half)
                            {
                                if (heartToAdd == HeartChoices.Red)
                                {
                                    rHearts.Add(new Hearts(sHearts[heartNumber], true, sHearts[heartNumber + 1], heartNumber));
                                }
                            }
                        }
                    }
                else if (heartToAdd == HeartChoices.Black || heartToAdd == HeartChoices.Blue)
                {
                    if (bHearts.Count > 0) {
                    if (halfFull == HalfChoices.full)
                    {
                        if (bHearts[bHearts.Count - 1].isHalf)
                        {
                            Sprite interchange;
                            bHearts[bHearts.Count - 1].isHalf = false;
                            interchange = bHearts[bHearts.Count - 1].heart;
                            bHearts[bHearts.Count - 1].heart = bHearts[bHearts.Count - 1].other;
                            bHearts[bHearts.Count - 1].other = interchange;
                            bHearts.Add(new Hearts(sHearts[heartNumber], true, sHearts[heartNumber + 1], heartNumber));
                        }
                        else if (!bHearts[bHearts.Count - 1].isHalf)
                        {
                            bHearts.Add(new Hearts(sHearts[heartNumber], false, sHearts[heartNumber + 1], heartNumber));
                        }
                    }
                    else if (halfFull == HalfChoices.half)
                    {
                        if (bHearts[bHearts.Count - 1].isHalf)
                        {
                            Sprite interchange;
                            bHearts[bHearts.Count - 1].isHalf = false;
                            interchange = bHearts[bHearts.Count - 1].heart;
                            bHearts[bHearts.Count - 1].heart = bHearts[bHearts.Count - 1].other;
                            bHearts[bHearts.Count - 1].other = interchange;
                        }
                        else if (!bHearts[bHearts.Count - 1].isHalf)
                        {
                            bHearts.Add(new Hearts(sHearts[heartNumber], true, sHearts[heartNumber + 1], heartNumber));
                        }
                    }
                }  else
                        {
                            if (halfFull == HalfChoices.full)
                            {
                                if (heartToAdd == HeartChoices.Black || heartToAdd == HeartChoices.Blue)
                                {
                                    bHearts.Add(new Hearts(sHearts[heartNumber], false, sHearts[heartNumber + 1], heartNumber));
                                }
                            }
                            else if (halfFull == HalfChoices.half)
                            {
                                if (heartToAdd == HeartChoices.Black || heartToAdd == HeartChoices.Blue)
                                {
                                    bHearts.Add(new Hearts(sHearts[heartNumber], true, sHearts[heartNumber + 1], heartNumber));
                                }
                            }
                        }
                }
            }else {
                if (halfFull == HalfChoices.full)
                {
                    if (heartToAdd == HeartChoices.Black || heartToAdd == HeartChoices.Blue)
                    {
                        bHearts.Add(new Hearts(sHearts[heartNumber], false, sHearts[heartNumber + 1], heartNumber));
                    }
                    else if (heartToAdd == HeartChoices.Red)
                    {
                        rHearts.Add(new Hearts(sHearts[heartNumber], false, sHearts[heartNumber + 1], heartNumber));
                    }
                }
                else if (halfFull == HalfChoices.half)
                {
                    if (heartToAdd == HeartChoices.Black || heartToAdd == HeartChoices.Blue)
                    {
                        bHearts.Add(new Hearts(sHearts[heartNumber], true, sHearts[heartNumber + 1], heartNumber));
                    }
                    else if (heartToAdd == HeartChoices.Red)
                    {
                        rHearts.Add(new Hearts(sHearts[heartNumber], true, sHearts[heartNumber + 1], heartNumber));
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
            bHearts.Remove(bHearts[bHearts.Count - 1]);
        }
        else
            rHearts.Remove(rHearts[rHearts.Count - 1]);
    }
    public void Refresh()
    {
        lastDone = 0;
        for (int i = 0; i < heartList.Length; i++)
        {
            heartList[i].sprite = sHearts[6];
        }
            for (int i = 0; i < rHearts.Count; i++)
            {
                heartList[lastDone].sprite = rHearts[i].heart;
                lastDone += 1;
            }
            for (int i = 0; i < bHearts.Count; i++)
            {
                heartList[lastDone].sprite = bHearts[i].heart;
                lastDone += 1;
            }
        }
    public void Switch()
    {
        if (heartToAdd == HeartChoices.Red)
        {
            heartToAdd = HeartChoices.Black;
            heartNumber = 4;
        }
        else if (heartToAdd == HeartChoices.Black)
        {
            heartToAdd = HeartChoices.Blue;
            heartNumber = 2;
        }
        else if (heartToAdd == HeartChoices.Blue)
        {
            heartToAdd = HeartChoices.Red;
            heartNumber = 0;
        }
    }
    public void AddHalf()
    {
        if (halfFull == HalfChoices.full)
        {
            halfFull = HalfChoices.half;
        }
        else if (halfFull == HalfChoices.half)
        {
            halfFull = HalfChoices.full;
        }
    }
}
