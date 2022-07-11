using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionManager : MonoBehaviour
{
    public UserData userData;
    [SerializeField]
    public Ress[] resList;
    private Ress actualRes;
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetDisplayScreenMode(bool fullscreenBool)
    {
        if(fullscreenBool == true)
        {
            Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
            Screen.SetResolution(1920, 1080, true);
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
            Screen.SetResolution(actualRes.width, actualRes.height, false);
        }

    }

    public void SetResolution(int numList)
    {
        actualRes = resList[numList];
        if(Screen.fullScreenMode == FullScreenMode.Windowed) Screen.SetResolution(resList[numList].width, resList[numList].height, false);

    }
    public void SetDisplay()
    {
        /*if(userData)
        {
            if (userData.displayMode.ToString() == Display.displays[0].ToString())
            {

            }
        }*/
        
        //Screen.fullScreenMode = FullScreenMode;
    }
}
[System.Serializable]
public class Ress
{
    public int width;
    public int height;
    
}
