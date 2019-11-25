using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public Vector3 desiredMenuPosition;


    private void Start()
    {
        OnSettingsClick();
    }
    // Update is called once per frame
    void Update()
    {
        OnSettingsClick();
    }

    void OnSettingsClick()
    {
        desiredMenuPosition = Vector3.right * 1920;
    }
}
