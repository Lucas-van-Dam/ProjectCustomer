using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    Movement movement;

    [SerializeField]
    GameObject menu;

    private bool isMenuOpen = true;

    private void Start()
    {
        movement = GetComponent<Movement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            movement.Paralyse();

            menu.SetActive(isMenuOpen);

            isMenuOpen = !isMenuOpen;
        }
    }
}
