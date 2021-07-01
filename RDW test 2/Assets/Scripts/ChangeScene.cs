using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    redirection ovr;
    
    // Start is called before the first frame update
    void Start()
    {
        ovr=FindObjectOfType<redirection>();
        Invoke("changeC", 20f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changeC() {
        ovr.save();

        if(SceneManager.GetActiveScene().name == "r") {
            SceneManager.LoadScene("t 0.8");
        }
        if(SceneManager.GetActiveScene().name == "t 0.5") {
            SceneManager.LoadScene("t 1");
        }
        if(SceneManager.GetActiveScene().name == "t 0.8") {
            SceneManager.LoadScene("t 0.5");
        }
        if(SceneManager.GetActiveScene().name == "t 1") {
            SceneManager.LoadScene("t 1.26");
        }
        if(SceneManager.GetActiveScene().name == "t 1.26") {
            SceneManager.LoadScene("t 2");
        }
        if(SceneManager.GetActiveScene().name == "t 2") {
            SceneManager.LoadScene("r");
        }

        SceneManager.sceneLoaded += this.sceneLoaded;

//         UnityEvent aaa=new UnityEvent();
//         aaa.AddListener(changeC);
//         aaa.AddListener(changeC);
//         aaa.AddListener(changeC);

// aaa.Invoke();
    }

    void sceneLoaded(Scene next,LoadSceneMode mode){
        ovr.load();
        SceneManager.sceneLoaded-=this.sceneLoaded;
    }
}
