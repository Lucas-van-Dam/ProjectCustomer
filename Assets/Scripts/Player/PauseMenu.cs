using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            OpenCloseMenu();
        }
    }


    public void OpenCloseMenu()
    {
        movement.Paralyse();

        menu.SetActive(isMenuOpen);

        isMenuOpen = !isMenuOpen;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu Screen Alex", LoadSceneMode.Single);
    }
}
