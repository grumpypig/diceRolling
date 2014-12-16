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
        isHalf = half;
        number = heartNumber;
        if (isHalf)
        {
            mainHeart = otherImg;
            otherHeart = mainImg;
        }
        else if (!isHalf)
        {
            mainHeart = mainImg;
            otherHeart = otherImg;
        }
    }
}
