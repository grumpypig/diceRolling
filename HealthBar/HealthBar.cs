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
    public float maxHP;
    public float divideRange;
    public GameObject dead;
    public bool canDie;
    public string textHealth = " HP: ";
    public bool Y;

    public void Update()
    {
        HP = slider.value;
        slider.maxValue = maxHP;
        divideRange = HP / maxHP;
        txtHealth.text = textHealth + HP;
        if (!Y)
        {
            mask.rectTransform.localScale = new Vector2(divideRange, 1);
        }
        else if (Y)
        {
            mask.rectTransform.localScale = new Vector2(1, divideRange);
        }

        if (HP <= .25 * maxHP)
        {
            healthBar.sprite = bars[0];
            outline.sprite = outlines[0];
        }
        if (HP <= .6 * maxHP && HP > .25 * maxHP)
        {
            healthBar.sprite = bars[1];
            outline.sprite = outlines[1];
        }
        if (HP > .6 * maxHP)
        {
            healthBar.sprite = bars[2];
            outline.sprite = outlines[2];
        }
        if (canDie)
        {
            if (HP <= 0)
            {
                dead.SetActive(true);
            }else {
                dead.SetActive (false);
            }
        }

    }
}
