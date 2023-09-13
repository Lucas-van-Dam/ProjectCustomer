using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KeypadUI : MonoBehaviour
{
    [SerializeField] private List<char> correctCombination;

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
        currentCombination.Add(key.ToCharArray().FirstOrDefault());
    }
}
