using UnityEngine;
using System.Collections;

[System.Serializable]
public class Heart
{

    public Sprite mainHeart;
    public Sprite otherHeart;
    public bool isHalf;
    public int number;

    public Heart(Sprite mainImg, bool half, Sprite otherImg, int heartNumber)
    {
        isHalf = half; //setting the half to local var
        number = heartNumber; //same as ^^
        if (isHalf) //if your half
        {
            mainHeart = otherImg; //than make your main heart the half one and your other heart the full one
            otherHeart = mainImg;
        }
        else if (!isHalf) //if your full
        {
            mainHeart = mainImg; //Make your main one full and your other half.
            otherHeart = otherImg;
        }
    }
}
