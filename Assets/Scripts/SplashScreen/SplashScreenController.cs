using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UI = UnityEngine.UI;

public class SplashScreenController : MonoBehaviour
{

    [SerializeField]
    UI.Text gameNameLabel = null;

    [SerializeField]
    private bool hasCues = true;

    [SerializeField]
    private SpriteRenderer cueIndicator = null;

    [SerializeField]
    private SpriteRenderer noCueIndicator = null;


    // Start is called before the first frame update
    void Start()
    {
        EventLogger.SetName(GameNameManger.Name());
        gameNameLabel.text = GameNameManger.Name();
        CueManager.SetCues(hasCues);
        EventLogger.Log(EventLog.EventCode.GameHasCues(CueManager.HasCues()));

        UpdateCueIndicator();
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyUp(KeyCode.Return))
        {
            SceneManager.LoadScene(MutationManager.MutationName()+"");
        }
        if (Input.GetKeyUp(KeyCode.F12))
        {
            hasCues = !hasCues;
            CueManager.SetCues(hasCues);
            EventLogger.Log(EventLog.EventCode.GameHasCues(CueManager.HasCues()));
            UpdateCueIndicator();
        }
    }

    void UpdateCueIndicator()
    {
        cueIndicator.enabled = CueManager.HasCues();
        noCueIndicator.enabled = !CueManager.HasCues();
    }
}
