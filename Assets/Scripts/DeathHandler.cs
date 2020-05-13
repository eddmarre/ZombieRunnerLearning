using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    void Start()
    {
        gameOverCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        GetComponentInChildren<Weapon>().enabled=false;
        gameOverCanvas.enabled = true;
        //unlock cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //stop game time to prevent conflicts
        Time.timeScale = 0;
    }
}
