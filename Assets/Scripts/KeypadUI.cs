using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KeypadUI : MonoBehaviour
{
    [SerializeField] private List<char> correctCombination;
    [SerializeField] private Door door;
    
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
    }

    public void DeleteKey()
    {
        if (currentCombination.Count > 0)
        {
            currentCombination.RemoveAt(currentCombination.Count - 1);
        }
    }

    public void QuitKey()
    {
        gameObject.SetActive(false);
    }
}
