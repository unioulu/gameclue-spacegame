using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UI = UnityEngine.UI;

public class SplashScreenController : MonoBehaviour
{

    [SerializeField]
    GameNameGenerator nameGenerator = null;

    [SerializeField]
    UI.Text gameNameLabel = null;


    // Start is called before the first frame update
    void Start()
    {
        EventLogger.SetName(nameGenerator.Name());
        gameNameLabel.text = nameGenerator.Name();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyUp(KeyCode.Return))
        {
            SceneManager.LoadScene("SampleScene");
        }

    }
}
