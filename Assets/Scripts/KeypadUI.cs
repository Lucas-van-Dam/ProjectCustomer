using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class KeypadUI : MonoBehaviour
{
    [SerializeField] private List<char> correctCombination;
    [SerializeField] private Door door;
    [SerializeField] private TextMeshProUGUI codeText;

    private GameObject interactor;
    
    private List<char> currentCombination = new List<char>();
    
    private void OnEnable()
    {
        
        UpdateScreen();
    }

    public void Enable(GameObject interactor)
    {
        this.interactor = interactor;
    }

    public void KeyPressed(string key)
    {
        if (currentCombination.Count == 4)
        {
            currentCombination.Clear();
        }
        
        currentCombination.Add(key.ToCharArray().FirstOrDefault());

        if (currentCombination.SequenceEqual(correctCombination))
        {
            door.Locked = false;
            gameObject.SetActive(false);
            interactor.GetComponent<Movement>().Paralyse();
        }
        UpdateScreen();
    }

    public void DeleteKey()
    {
        if (currentCombination.Count > 0)
        {
            currentCombination.RemoveAt(currentCombination.Count - 1);
            UpdateScreen();
        }
    }

    public void QuitKey()
    {
        gameObject.SetActive(false);
        interactor.GetComponent<Movement>().Paralyse();
    }

    private void UpdateScreen()
    {
        var combination = string.Empty;
        currentCombination.ForEach(x => string.Concat(combination, x));
        codeText.text = combination;
    }
}
