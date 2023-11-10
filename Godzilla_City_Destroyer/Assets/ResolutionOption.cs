using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionOption : MonoBehaviour
{
   [SerializeField] Dropdown resolutionDropDown;
   [SerializeField] Toggle toggle;

   Resolution[] resolutions;

   void Start(){
        resolutions = Screen.resolutions;
        bool setDefault = false;

        if(PlayerPrefs.GetInt("set default resolution") == 0){
            setDefault = true;
            PlayerPrefs.GetInt("set default resolution",1);
        }
        toggle.isOn = PlayerPrefs.GetInt("fullscreen") == 0;
        for(int i = 0; i < resolutions.Length; i++){
            string resolutionString = resolutions[i].width.ToString() + " x " + resolutions[i].height.ToString();
            resolutionDropDown.options.Add(new Dropdown.OptionData(resolutionString));
            if(setDefault && resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height){
                resolutionDropDown.value = i;
            }
        }
        resolutionDropDown.value = PlayerPrefs.GetInt("resolution selection");
   }

   public void ChangeResolution(){
        Screen.SetResolution(resolutions[resolutionDropDown.value].width,resolutions[resolutionDropDown.value].height, toggle.isOn);
        PlayerPrefs.SetInt("resolution selection", resolutionDropDown.value);
        if(toggle.isOn){
            PlayerPrefs.SetInt("fullscreen", 0);
        }else{
            PlayerPrefs.SetInt("fullscreen", 1);
        }
   }
}
