using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOpener : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("MainMenu");
    }
}