using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Sprite[] bars;
    public Sprite[] outlines;
    public Text txtHealth;
    public Image healthBar;
    public Image outline;
    public Mask mask;
    public float HP;
    public float divideRange;
    public GameObject dead;
    public bool canDie;
    public float maxHealth = 100;
    public string textHealth = "HP: ";

    public void Update()
    {
        HP = slider.value; //This line and below is just for the sliders so if you are doing a game that doesn't have 
        //health that is influenced by sliders don't use this!
        slider.maxValue = maxHealth;
        divideRange = HP / maxHealth;
        txtHealth.text = textHealth + HP;
        mask.rectTransform.localScale = new Vector2(divideRange, 1); //Remember to do your current hp / max hp to get a decimal that will be used for the scaling!

        if (HP <= .6*maxHealth && HP > .25*maxHealth) // if your hp is less or equal to 60% and over 25% (mid range) 
        {
            healthBar.sprite = bars[1]; //For each set of these its just changing the color of the bars and outlines
            outline.sprite = outlines[1];
        }
        if (HP > .6 * maxHealth) //Greater than 60%
        {
            healthBar.sprite = bars[2];
            outline.sprite = outlines[2];
        }
        if (HP <= .25*maxHealth) //Less than or equal to 25 %
        {
            healthBar.sprite = bars[0];
            outline.sprite = outlines[0];
        }
        if (canDie) //If can die (for stuff like hp) and turn off the bool for stuff like mana!
        {
            if (HP <= 0) //if hp is less or equal to 0
            {
                dead.SetActive(true); //Text element to show that your dead you can use a die () function
            }
            else
                dead.SetActive(false); //Don't use else if your building a game!
        }
    }
}
