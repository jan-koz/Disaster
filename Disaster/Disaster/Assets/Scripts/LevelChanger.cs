using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerFire")
        {
            Debug.Log("jazda");
            SceneManager.LoadScene("Pokemon", LoadSceneMode.Single);
        }
    }
}
