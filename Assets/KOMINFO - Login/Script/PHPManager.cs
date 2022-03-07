using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

[RequireComponent(typeof(PHPHelper))]

public class PHPManager : MonoBehaviour
{
    private PHPHelper phphelper;
    [Header("Login Setting"), Space(5)]
    public TMP_InputField nameLoginField;
    public TMP_InputField passwordLoginField;
    public Button loginButton;
    [Header("Register Setting"), Space(5)]
    public TMP_InputField nameRegisterField;
    public TMP_InputField passwordRegisterField;
    public Button registerButton;

    [Header("Panel"), Space(5)]
    [SerializeField] GameObject loginpanel;
    [SerializeField] GameObject registerpanel;
    [SerializeField] TextMeshProUGUI buttonText;
    [SerializeField] UnityEvent onLoginSuccess;
    private bool isLogin;

    public Text Textfield;

    

    void Start()
    {
        isLogin = false;
        SwitchRegisterLogin();
        phphelper = GetComponent<PHPHelper>();
    }

    public void SetText()
    {
        Textfield.text = "username or password is incorrect";
    }

    public void Login()
    {
        phphelper.CallLogin(nameLoginField.text, passwordLoginField.text, (string success) =>
        {
            char[] texted = success.ToCharArray();
            if (texted[0] == '0')
            {
                DBManager.username = nameLoginField.text;
                Debug.Log(success);
                onLoginSuccess.Invoke();
                
            }
            else
            {
                Debug.Log($"user login failed. error # {success}");
                SetText();
            }
        }, (string failed) =>
        {
            Debug.Log(failed);
        });
    }

    public void Register()
    {
        phphelper.CallRegister(nameRegisterField.text, passwordRegisterField.text, (string success) =>
        {
            char[] texted = success.ToCharArray();
            if (texted[0] == '0')
            {
                DBManager.username = nameRegisterField.text;
                Debug.Log(DBManager.username);
                SceneManager.LoadScene("mainmenu");
            }
            else
            {
                Debug.Log($"user login failed. error # {success}");
            }
        }, (string failed) =>
        {
            Debug.Log(failed);
        });
    }

    public void VerifyLoginInputs()
    {
        loginButton.interactable = (nameLoginField.text.Length >= 8 && passwordLoginField.text.Length >= 8);
    }

    public void VerifyRegisterInputs()
    {
        registerButton.interactable = (nameRegisterField.text.Length >= 8 && passwordRegisterField.text.Length >= 8);
    }

    public void SwitchRegisterLogin()
    {
        isLogin = !isLogin;
        if (!isLogin)
        {
            loginpanel.SetActive(false);
            registerpanel.SetActive(true);
            buttonText.text = "Login";
        }
        else
        {
            loginpanel.SetActive(true);
            registerpanel.SetActive(false);
            buttonText.text = "Register";
        }
        
    }

}
