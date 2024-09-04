using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public void SetFullScreen(bool isFullscreen)
	{
		Screen.fullScreen = isFullscreen;
	}
	public void SetQuality(int qualityIntex)
	{
		QualitySettings.SetQualityLevel(qualityIntex);
	}
}
