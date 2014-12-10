using UnityEngine;
using System.Collections;

[System.Serializable]
public class Hearts
{
    public Sprite heart;
    public Sprite other;
    public bool isHalf;
    public int Number;

    public Hearts(Sprite img, bool half, Sprite hH, int HeartNumber)
    {
        Number = HeartNumber;
        isHalf = half;
        if (isHalf)
        {
            heart = hH;
            other = img;
        }
        if (!isHalf)
        {
            heart = img;
            other = hH;
        }
        
    }
}
