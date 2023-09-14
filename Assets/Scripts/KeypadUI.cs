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
    
    private List<char> currentCombination;
    
    // Start is called before the first frame update
    void Start()
    {
        currentCombination = new List<char>(4){'a', 'b', 'c', 'd'};
        KeyPressed("2");
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }

    private void UpdateScreen()
    {
        var combination = string.Empty;
        currentCombination.ForEach(x => string.Concat(combination, x));
        codeText.text = combination;
    }
}
