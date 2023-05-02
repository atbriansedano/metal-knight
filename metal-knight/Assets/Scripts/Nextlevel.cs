using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Nextlevel : MonoBehaviour
{
    public string sceneBuildName;
    public int pointRequiremnt;
    public Points point;

    public TMP_Text pointText;
   
    // Start is called before the first frame update
    void Start()
    {
        pointText.text = "NEXT STAGE REQUIRMENT: " + pointRequiremnt.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other){
        
        print("before tag check");

        if(other.tag == "Player" && point.currentPoints >= pointRequiremnt)
        {
            print("Switching scenes");
            SceneManager.LoadScene(sceneBuildName);
        }
    }
}
