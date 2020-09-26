using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class KillCoefficientLabel : MonoBehaviour
{
    private Text _label;

    // Start is called before the first frame update
    void Start()
    {
        _label = GetComponent<Text>();
        GameManager.Instance.OnKillCoefficientChanged += (value) => { _label.text = "K.C : " + value.ToString(); };
    }

}
