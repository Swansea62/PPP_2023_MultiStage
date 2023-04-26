using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    [Header("Volume Setting")]
    [SerializeField]
    private TMP_Text volTextValue = null;

    [SerializeField]
    private Slider volSlider = null;

    [SerializeField]
    private GameObject confirmationPrompt = null;

    public bool isApplied;

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volTextValue.text = volume.ToString("0.0");
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(ConfirmationBox());

        isApplied = true;
    }

    public IEnumerator ConfirmationBox()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false);
    }

    public void Update()
    {
        if (isApplied == true)
        {
            Debug.Log("This setting has been applied");
        }
    }
}
