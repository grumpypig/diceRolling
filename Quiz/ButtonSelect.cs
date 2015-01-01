using UnityEngine;
using System.Collections;

public class ButtonSelect : MonoBehaviour
{

    int id;

    public void OnClick()
    {
        int.TryParse(this.name, out id);
        QuizManager.Instance.Finish(id);
    }
}
