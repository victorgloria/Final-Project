using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class screenOptions : MonoBehaviour
{
    public Dropdown resolutionDrop;
    Resolution[] resolutions;

    public Toggle isFullScreen;
    void Start(){
        resolutions = Screen.resolutions;
        isFullScreen.isOn = Screen.fullScreen;
        for(int i=0; i<resolutions.Length; i++){
            string resolutionString = resolutions[i].width.ToString() + "x" + resolutions[i].height.ToString();
            resolutionDrop.options.Add(new Dropdown.OptionData(resolutionString));

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height){
                resolutionDrop.value = i;
            }
        }
    }

    public void setResolution(){
        Screen.SetResolution(resolutions[resolutionDrop.value].width, resolutions[resolutionDrop.value].height,isFullScreen.isOn);

    }
}
