using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{

    public Slider slider;
    public Text txt;

    public void Update()
    {
        txt.text = (slider.value).ToString("0"); //You can times the value by 100 if you want to convert a 0-1 basis to a 0-100 basis.
    }
}
