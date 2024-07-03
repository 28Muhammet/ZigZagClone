using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsCamera : MonoBehaviour
{
    public static bool control;
    Vector3 direction;

    private void Start()
    {
        control = false;
        direction = Vector3.up;
    }

    private void Update()
    {
        if (control == true && SphereController.fell == false)
        {
            transform.position += direction * SphereController.speed / 2 * Time.deltaTime;
        }
    }
}
