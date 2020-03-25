using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChoser : MonoBehaviour
{
    public static bool lvl1beaten = false;
    public static bool lvl2beaten = false;
    public Button button1;
    public Button button2;
    public Button button3;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        button1.interactable = true;
        button2.interactable = false;
        button3.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (lvl1beaten)
        {
            button2.interactable = true;
            slider.value = slider.maxValue / 3;
        }
        else if (lvl2beaten)
        {
            button3.interactable = true;
            slider.value = slider.maxValue * 2 / 3;
        }
    }

    public void On1LvlButtonClick()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void On2LvlButtonClick()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void On3LvlButtonClick()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
