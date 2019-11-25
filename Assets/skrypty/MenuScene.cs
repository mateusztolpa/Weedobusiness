using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    private CanvasGroup fadeGroup;
    private float fadeInSpeed = 0.33f;

    public Transform ItemPanel;

    public RectTransform MenuContainer;
    public Transform PlayPanel; //dodane

    private Vector3 desiredMenuPosition;



    private void Start()
    {
        //Grab the only CanvasGroup in the scene
        fadeGroup = FindObjectOfType<CanvasGroup>();

        //Start with a white screen;
        fadeGroup.alpha = 1;

        //przejscie do sklepu cos takiego
        InitShop();

        //menu przed rozgrywka
        Zagraj();
    }

    private void Update()
    {
        //Fade-in
        fadeGroup.alpha = 1 - Time.timeSinceLevelLoad * fadeInSpeed;

        //menu navigation (zajebiste)
        MenuContainer.anchoredPosition3D = Vector3.Lerp(MenuContainer.anchoredPosition3D, desiredMenuPosition, 0.3f);
    }



    //sklep 
    private void InitShop()
    {
        // upewnij sie ze przdzieliles referencje
        if (ItemPanel == null)
            Debug.Log("XD");

        int i = 0;
        foreach (Transform t in ItemPanel)
        {
            int currentIndex = i;

            Button b = t.GetComponent<Button>();
            b.onClick.AddListener(() => OnItemSelect(currentIndex));

            i++;
        }

        // reset index 
        i = 0;

    }

   

    //panel rozgrywki
    private void Zagraj()
    {
        // na pewno czy wybralismy tryb rozgrywki
        if (PlayPanel == null)
            Debug.Log("aj kurwa nie wybrales");
    }

    private void NavigateTo(int menuIndex)
    {
        // 0 i default to mainmenu
        switch (menuIndex)
        {
            default:
            case 0:
                desiredMenuPosition = Vector3.zero;
                break;
            // 1=PlayMenu
            case 1:
                desiredMenuPosition = Vector3.right * 1920;
                break;
            //2=sklep
            case 2:
                desiredMenuPosition = Vector3.left * 1920;
                break;
            //3-ustawienia
            case 3:
                desiredMenuPosition = Vector3.down * -1280;
                break;


        }
    }

    //przyciski
    public void OnPlayClick()
    {
        NavigateTo(1);

        Debug.Log("PLAY");
    }
    public void OnShopClick()
    {
        NavigateTo(2);

        Debug.Log("SHOP");
    }
    public void OnSettingsClick()
    {
        NavigateTo(3);

        Debug.Log("Settings");
    }

    public void OnBackClick()
    {
        NavigateTo(0);

        Debug.Log("DZIALA");
    }

    public void OnSingleClick()
    {
        SceneManager.LoadScene("Game");
    }

    private void OnItemSelect(int currentIndex)
    {
        Debug.Log("Wybrales przycisk: " + currentIndex);
    }
}
