using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nextlevel : MonoBehaviour
{
    public string sceneBuildName;

    private void OnTriggerEnter2D(Collider2D other){
        
        print("before tag check");

        if(other.tag == "Player")
        {
            print("Switching scenes");
            SceneManager.LoadScene(sceneBuildName);
        }
    }
}
