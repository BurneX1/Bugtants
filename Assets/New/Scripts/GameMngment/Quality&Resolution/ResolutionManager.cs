using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionManager : MonoBehaviour
{
    public UserData userData;
    [SerializeField]
    public Display[] dis = Display.displays;
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

    public void SetDisplay()
    {
        if(userData)
        {
            //if (userData.displayMode.ToString == Display.displays[0].ToString)
        }
        
        //Screen.fullScreenMode = FullScreenMode;
    }
}
