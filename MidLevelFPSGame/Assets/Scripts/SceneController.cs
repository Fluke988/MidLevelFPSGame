using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public void OnPlayButtonClicked()
    {
        Initiate.Fade("TerrainScene2", Color.black, 1.0f);
    }

    public void OnRestartButtonClicked()
    {
        Initiate.Fade("TerrainScene2", Color.black, 1.0f);
    }

    public void OnHomeButtonClicked()
    {
        Initiate.Fade("HomeScene", Color.white, 1.0f);
    }

}
