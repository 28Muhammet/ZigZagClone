using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject[] gameObjects;

    private void Update()
    {
        if (SphereController.fell == true)
        {
            gameObjects[3].SetActive(true);
        }
    }

    public void StartBtn()
    {
        SphereController.direction = transform.forward;
        SettingsCamera.control = true;
        SphereController.click = true;
        gameObjects[0].SetActive(true);
        gameObjects[1].SetActive(false);
        gameObjects[2].SetActive(true);
    }

    public void RetyBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SphereController.direction = Vector3.zero;
    }

    public void ExitBtn()
    {
        Application.Quit();
    }
}
