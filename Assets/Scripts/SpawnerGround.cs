using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerGround : MonoBehaviour
{
    public GameObject final_Ground;
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
        for (int i = 0; i < 100; i++)
        {
            crate_Ground();
        }
    }

    public void crate_Ground()
    {
        Vector3 direction;

        if (Random.Range(0, 2) == 0)
        {
            direction = Vector3.left;
        }
        else
        {
            direction = Vector3.forward;
        }

        Vector3 newPosition = final_Ground.transform.position + direction;

        // Kameranýn görünüm sýnýrlarýný kontrol et
        Vector3 viewportPoint = mainCamera.WorldToViewportPoint(newPosition);
        if (viewportPoint.x >= .2f && viewportPoint.x <= .8f && viewportPoint.y >= .2f && viewportPoint.y <= 100)
        {
            final_Ground = Instantiate(final_Ground, newPosition, final_Ground.transform.rotation);
        }
    }
}
