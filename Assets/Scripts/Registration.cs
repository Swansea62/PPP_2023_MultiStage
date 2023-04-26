using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Registration : MonoBehaviour
{

    public InputField nameField;
    public InputField passwordField;

    public Button submitButton;

    public void CallRegister() 
    {
        StartCoroutine(Register());
    }

    //Original code via tutorial with minor updates for outdated WWW class, replaced with some UnityWebRequests (Returned Error #)

    // IEnumerator Register() 
    // {
    //     WWWForm form = new WWWForm();
    //     form.AddField("name", nameField.text);
    //     form.AddField("password", passwordField.text);
    //     UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/register.php", form);
    //     yield return www.SendWebRequest();
    //     if (www.error == "0")
    //     {
    //         Debug.Log("User created successfully.");
    //         UnityEngine.SceneManagement.SceneManager.LoadScene(0);

    //     }
    //     else
    //     {
    //         Debug.Log("User creation failed. Error #" + www.error);
    //     }
    // }

    IEnumerator Register() 
{
    // List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
    WWWForm formData = new WWWForm();

    formData.AddField("username", nameField.text);
    formData.AddField("password", passwordField.text);

    UnityWebRequest www = UnityWebRequest.Post("http://localhost:8888/register", formData);
    yield return www.SendWebRequest();

    if (www.result == UnityWebRequest.Result.Success)
    {
        Debug.Log("User created successfully.");
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
    else
    {
        Debug.Log("User creation failed. Error #" + www.responseCode);
    }
}


    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }

}
