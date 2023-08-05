using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HintScript : MonoBehaviour
{
    [SerializeField]
    private string _text;

    [SerializeField]
    private TMP_Text _uiText;

    public void Hint()
    {
        _uiText.text = _text;
    }
}
