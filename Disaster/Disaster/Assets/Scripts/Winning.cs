using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Winning : MonoBehaviour
{
    public Slider mainSlider;

    private void Start()
    {
    }
    private void Update()
    {
        Win();
    }
    public void Win()
    {
        if(TreeObject.currentFireHexAmount == mainSlider.maxValue)
        {
            GameObject hexpackage = GameObject.Find("HexPackage");
            hexpackage.SetActive(false);
            GameObject []players = GameObject.FindGameObjectsWithTag("Player");
            GameObject []firePlayers = GameObject.FindGameObjectsWithTag("PlayerFire");
            GameObject[] cleys = GameObject.FindGameObjectsWithTag("cley");
            foreach (GameObject g in players)
                g.SetActive(false);
            foreach (GameObject g in firePlayers)
                g.SetActive(false);
            foreach (GameObject g in cleys)
                g.SetActive(false);
            BoolStorage.lvl1beaten = true;
            SceneManager.LoadScene("LevelChoser", LoadSceneMode.Single);
        }
    }
}
