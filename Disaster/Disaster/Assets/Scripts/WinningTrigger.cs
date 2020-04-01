using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (player)
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerFire")
        {
            BoolStorage.lvl2beaten = true;
            SceneManager.LoadScene("LevelChoser", LoadSceneMode.Single);
        }

    }
}
