using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MergeButton : MonoBehaviour
{
    [SerializeField]
    string inactiveText, activeText;

    TextMeshProUGUI buttonText;
    Button button;



    private void Start()
    {
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        button = GetComponent<Button>();

        CannotMerge();
    }

    public void CanMerge()
    {
        buttonText.text = activeText;
        button.interactable = true;
    }

    public void CannotMerge()
    {
        if (buttonText != null)
        {
            buttonText.text = inactiveText;
            button.interactable = false;
        }
    }

    public void Finish()
    {
        buttonText.text = "Unlock Door";
        button.interactable = true;
    }
}
