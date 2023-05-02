using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nextlevel : MonoBehaviour
{
    public string sceneBuildName;
    public int pointRequiremnt;
    public Points point;

    private void OnTriggerEnter2D(Collider2D other){
        
        print("before tag check");

        if(other.tag == "Player" && point.currentPoints >= pointRequiremnt)
        {
            print("Switching scenes");
            SceneManager.LoadScene(sceneBuildName);
        }
    }
}
