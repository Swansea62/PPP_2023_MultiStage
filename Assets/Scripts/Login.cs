using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Login : MonoBehaviour
{

    public InputField nameField;
    public InputField passwordField;

    public Button submitButton;

    public void CallLogin() 
    {
        StartCoroutine(LoginPlayer());
    }

    IEnumerator LoginPlayer()
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("name", nameField.text));
        formData.Add(new MultipartFormDataSection("password", passwordField.text));

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/login.php", formData);
        yield return www.SendWebRequest();
        string result = www.downloadHandler.text;
        // Debug.Log("Result: " + result);
        if(result[0] == '0')
        {
            DBManager.username = nameField.text;
            DBManager.score = int.Parse(result.Split('\t')[1]);
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else
        {
            Debug.Log("User login failed. Error #" + www.result);
        }
    }

    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }
}
