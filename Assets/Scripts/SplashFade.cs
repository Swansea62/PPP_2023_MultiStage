using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashFade : MonoBehaviour
{
    public Image splashImg;

    IEnumerator Start()
    {
        splashImg.canvasRenderer.SetAlpha(0.0f);

        FadeIn();
        yield return new WaitForSeconds(2.5f);
        FadeOut();
        yield return new WaitForSeconds(2.5f);
        Loader.Load(Loader.Scene.MainMenuScreen);
    }

    void FadeIn()
    {
        splashImg.CrossFadeAlpha(1.0f, 2.0f, false);
    }

    void FadeOut()
    {
        splashImg.CrossFadeAlpha(0.0f, 2.5f, false);
    }
}
