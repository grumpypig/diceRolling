using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

//This project took ~16 hours to do so please don't just go and fork it and call it your own!!!  You can go use it without permission!!
//But don't use it for making other videos!  If you want to extend it you can ask permission on my youtube (bit.ly/ShadowRealm)

public class HeartManager : MonoBehaviour
{

    public List<Heart> rHearts = new List<Heart>(); //An array of red hearts
    public List<Heart> bHearts = new List<Heart>(); //An array of blue hearts
    public Sprite[] collectionHearts; //All the hearts in an array (make sure it goes full, half, full half etc...)
    public int maxHearts = 12; //Max hearts (heart containers)
    public Image[] outputList; //All the heart spaces (heart containers)
    public int heartNumber;
    public int currentHearts;
    public int lastDone;
    public Text txtHeart;
    public Text txtHalf;
    public HeartChoices heartAdd;
    public HalfChoices halfFull;
    private int oldMaxHearts = 12;

    public enum HeartChoices //All your choices of hearts
    {
        Red,
        Black,
        Blue
    }
    public enum HalfChoices //The kinds of hearts you can have
    {
        half,
        full
    }

    public void Awake() //On start
    {
        oldMaxHearts = maxHearts; //This is only so we can change how many heart containers you see
        halfFull = HalfChoices.full; //Setting adding mode to half
        heartAdd = HeartChoices.Red; //Setting adding mode to red
        Refresh(); //Refresh screen!
    }
    public void Update()
    {
        if (maxHearts > outputList.Length) //So we can't have 1000000 max hearts and only have space for 12
        {
            maxHearts = outputList.Length;
        }
        currentHearts = rHearts.Count + bHearts.Count; //This is the total of hearts you have
        txtHalf.text = "Adding/Removing a " + halfFull + " heart"; //Just setting the text to say whether or not your adding half a heart
        txtHeart.text = "Current Heart: " + heartAdd; //Just setting the text ot say which heart your adding (red, blue, black)
        if (oldMaxHearts != maxHearts) //If you have more/less maxhearts than you did have before just refresh and reset trap
        {
            Refresh();
            oldMaxHearts = maxHearts;
        }
    }

    public void AddHeart() //This is the big code :)
    {
        if (currentHearts < maxHearts) //If you have less hearts than max
        {
                if (heartAdd == HeartChoices.Red) //if your adding a red
                {
                    if (rHearts.Count > 0) //If your red heart count is over 0
                    {
                        if (halfFull == HalfChoices.full) //If your adding a full heart
                        {
                            if (rHearts[rHearts.Count - 1].isHalf) //if your last heart is half
                            {
                                Sprite interchange; //creating a variable to store a sprite
                                rHearts[rHearts.Count - 1].isHalf = false; //The half heart bool is false
                                interchange = rHearts[rHearts.Count - 1].mainHeart; //Storing main heart sprite
                                rHearts[rHearts.Count - 1].mainHeart = rHearts[rHearts.Count - 1].otherHeart; //main heart = other heart
                                rHearts[rHearts.Count - 1].otherHeart = interchange; //Other heart is equal to the stored one
                                rHearts.Add(new Heart(collectionHearts[heartNumber], true, collectionHearts[heartNumber + 1], heartNumber)); //Add another half heart
                            }
                            else if (!rHearts[rHearts.Count - 1].isHalf) //Else if the last one is full
                            {
                                rHearts.Add(new Heart(collectionHearts[heartNumber], false, collectionHearts[heartNumber + 1], heartNumber)); //Just add a full heart
                            }
                        }
                        else if (halfFull == HalfChoices.half) //Else if your adding half
                        {
                            if (rHearts[rHearts.Count - 1].isHalf) //If the last one is half
                            {
                                //Same as the one for full but not adding an extra heart just making the last one full
                                Sprite interchange;
                                rHearts[rHearts.Count - 1].isHalf = false;
                                interchange = rHearts[rHearts.Count - 1].mainHeart;
                                rHearts[rHearts.Count - 1].mainHeart = rHearts[rHearts.Count - 1].otherHeart;
                                rHearts[rHearts.Count - 1].otherHeart = interchange;
                            }
                            else if (!rHearts[rHearts.Count - 1].isHalf) //If the last heart is half just add a half heart
                            {
                                rHearts.Add(new Heart(collectionHearts[heartNumber], true, collectionHearts[heartNumber + 1], heartNumber));
                            }
                        }
                    }
                    else //Else if you have 0 red hearts
                    {
                        if (heartAdd == HeartChoices.Red) //If you are adding a red heart
                        {
                            if (halfFull == HalfChoices.full) //If your are adding full heart add it otherwise add a half heart
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
                else if (heartAdd == HeartChoices.Black || heartAdd == HeartChoices.Blue) //If your adding a blue/black heart instead of a red heart
                {
                    if (bHearts.Count > 0) //If you have blue hearts to avoid the weird error thing
                    {
                        if (halfFull == HalfChoices.full) //if your adding a full heart
                        {
                            if (bHearts[bHearts.Count - 1].isHalf) //If the last one is half then do the same thing as the red hearts but for the blue/black hearts
                            {
                                Sprite interchange;
                                bHearts[bHearts.Count - 1].isHalf = false;
                                interchange = bHearts[bHearts.Count - 1].mainHeart;
                                bHearts[bHearts.Count - 1].mainHeart = bHearts[bHearts.Count - 1].otherHeart;
                                bHearts[bHearts.Count - 1].otherHeart = interchange;
                                bHearts.Add(new Heart(collectionHearts[heartNumber], true, collectionHearts[heartNumber + 1], heartNumber));
                            }
                            else if (!bHearts[bHearts.Count - 1].isHalf) //If the last one is full then just add a full heart
                            {
                                bHearts.Add(new Heart(collectionHearts[heartNumber], false, collectionHearts[heartNumber + 1], heartNumber));
                            }
                        }
                        else if (halfFull == HalfChoices.half) //if your adding a half heart
                        {
                            if (bHearts[bHearts.Count - 1].isHalf)
                            {
                                //Same as the red one but for blue
                                Sprite interchange;
                                bHearts[bHearts.Count - 1].isHalf = false;
                                interchange = bHearts[bHearts.Count - 1].mainHeart;
                                bHearts[bHearts.Count - 1].mainHeart = bHearts[bHearts.Count - 1].otherHeart;
                                bHearts[bHearts.Count - 1].otherHeart = interchange;
                            }
                            else if (!bHearts[bHearts.Count - 1].isHalf) //if the last one is full then add a half heart
                            {
                                bHearts.Add(new Heart(collectionHearts[heartNumber], true, collectionHearts[heartNumber + 1], heartNumber));
                            }
                        }
                    }
                    else //if you have 0 blue/black hearts
                    {
                        if (heartAdd == HeartChoices.Black || heartAdd == HeartChoices.Blue) //just double check that your adding blue/black hearts
                        {
                            if (halfFull == HalfChoices.full) //If your adding full then add a full heart otherwise add a half heart
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
        Refresh(); //Refresh
    }

    public void RemoveHeart() //Removing a heart
    {
        if (bHearts.Count > 0) //If your blue/black hearts is over 0 then remove them before red
        {
            if (!bHearts[0].isHalf) //if the first one isn't half
            {
                if (halfFull == HalfChoices.full) //if your removing a full
                {
                    if (!bHearts[bHearts.Count - 1].isHalf) //if the last one is full
                    {
                        bHearts.Remove(bHearts[bHearts.Count - 1]); //Remove it
                    }
                    else if (bHearts[bHearts.Count - 1].isHalf) //Else if the last one is half
                    {
                        bHearts.Remove(bHearts[bHearts.Count - 1]); //Remove the last one
                        Sprite interchange; //Store a var sprite
                        bHearts[bHearts.Count - 1].isHalf = true; //Make the last one half
                        interchange = bHearts[bHearts.Count - 1].mainHeart; //Do a switch
                        bHearts[bHearts.Count - 1].mainHeart = bHearts[bHearts.Count - 1].otherHeart;
                        bHearts[bHearts.Count - 1].otherHeart = interchange;
                    }
                }
                else if (halfFull == HalfChoices.half) //Else if your removing half
                {
                    if (bHearts[bHearts.Count - 1].isHalf) //If your last one's half
                    {
                        bHearts.Remove(bHearts[bHearts.Count - 1]); //Remove it
                    }
                    else if (!bHearts[bHearts.Count - 1].isHalf) //if you last one is full
                    {
                        Sprite interchange; //Same as above but not removing one
                        bHearts[bHearts.Count - 1].isHalf = true;
                        interchange = bHearts[bHearts.Count - 1].mainHeart;
                        bHearts[bHearts.Count - 1].mainHeart = bHearts[bHearts.Count - 1].otherHeart;
                        bHearts[bHearts.Count - 1].otherHeart = interchange;
                    }
                }
            }
            else //Else if your only have 1 blue/black heart just remove it
            {
                bHearts.Remove(bHearts[0]);
            }
        }
        else if (rHearts.Count > 0) //if you have no more black/blue hearts but have red ones
        {
            if (!rHearts[0].isHalf) //if your first one is full
            {
                if (halfFull == HalfChoices.full) //if your removing a full
                {
                    if (!rHearts[rHearts.Count - 1].isHalf) //if the last one is full
                    {
                        rHearts.Remove(rHearts[rHearts.Count - 1]); //Remove it
                    }
                    else if (rHearts[rHearts.Count - 1].isHalf) //if the last one is half
                    {
                        rHearts.Remove(rHearts[rHearts.Count - 1]); //Same as blue/black
                        Sprite interchange;
                        rHearts[rHearts.Count - 1].isHalf = true;
                        interchange = rHearts[rHearts.Count - 1].mainHeart;
                        rHearts[rHearts.Count - 1].mainHeart = rHearts[rHearts.Count - 1].otherHeart;
                        rHearts[rHearts.Count - 1].otherHeart = interchange;
                    }
                }
                else if (halfFull == HalfChoices.half) //Else if your removing half
                {
                    if (rHearts[rHearts.Count - 1].isHalf) //if the last one is half
                    {
                        rHearts.Remove(rHearts[rHearts.Count - 1]); //Remove it
                    }
                    else if (!rHearts[rHearts.Count - 1].isHalf)
                    {
                        //Same as blue/black
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
                rHearts.Remove(rHearts[0]); //Else just remove the first one
            }
        }
        Refresh(); //Refresh
    }

    public void Refresh()
    {
        lastDone = 0; //Last done is so we now which one has been done so when we go from red to blue we don't start again at 0
        for (int i = 0; i < outputList.Length; i++) //Just setting all the hearts to default and white (we clear those that we don't want)
        {
            outputList[i].sprite = collectionHearts[6];
            outputList[i].color = Color.white;
        }
        for (int i = 0; i < rHearts.Count; i++) //Doing red hearts first this is why we have last done so when we go back to blue/black
        {
            outputList[lastDone].sprite = rHearts[i].mainHeart;
            lastDone += 1;
        }
        for (int i = 0; i < bHearts.Count; i++) //Last done shows its magic here so we don't need to keep track on what red hearts have been done
        {
            outputList[lastDone].sprite = bHearts[i].mainHeart;
            lastDone += 1;
        }
        for (int i = 0; i < outputList.Length; i++) //Just going through all our hearts
        {
            if (i >= maxHearts) //if i is greater than max hearts basically if we have 10 max hearts if we have 12 hearts spaces we want to make them null and clear
            {
                outputList[i].sprite = null;
                outputList[i].color = Color.clear;
            }
        }

    }

    public void SwitchHeartMode() //For switching heart modes (red to black to blue)
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
    public void AddHalf() //For switching halffull modes (full to half vice versa)
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
    //This code is just for games that say remove 8 hearts or add 2 hearts
    public void RemoveAddHearts(int number, HalfChoices hF, int howManyTimes, bool removeAdd, HeartChoices hC) //False is remove, true is add
    {
        heartAdd = hC; //We set the heart adding mode to the local var
        halfFull = hF; //Same for half full ^^
        heartNumber = number; //Setting our heart number to local var
        for (int i = 0; i < howManyTimes; i++) //How many times is like 3 for 3 hearts and so on
        {
            if (!removeAdd) //If your removing (false is remove) remove a heart
            {
                RemoveHeart();
            }
            else if (removeAdd) //if your adding (true is adding) add a heart
            {
                AddHeart();
            }
        }
    }
}
