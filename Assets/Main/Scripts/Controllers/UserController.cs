using Firebase;
using Firebase.Database;
using System;
using UnityEngine;
using TMPro;
using Firebase.Auth;
using System.Collections;
using DG.Tweening;

public class UserController : MonoBehaviour
{
    public TMP_InputField email;
    public TMP_InputField password;
    public TMP_InputField emailReg;
    public TMP_InputField passwordReg;
    public GameObject LogIn;
    public Action ActionSample;
    public TMP_Text DebugText;
    public AuthenticationView AuthenticationView;

    private DatabaseReference dbReference;
    private FirebaseAuth auth;

    private async void Start()
    {
        var dependencyStatus = await FirebaseApp.CheckAndFixDependenciesAsync();
        if (dependencyStatus == DependencyStatus.Available)
        {
            FirebaseApp app = FirebaseApp.DefaultInstance;
            dbReference = FirebaseDatabase.DefaultInstance.RootReference;
            auth = FirebaseAuth.DefaultInstance;
        }
        else
        {
            Debug.LogError("Could not resolve all Firebase dependencies.");
        }
    }

    public IEnumerator LoginAsync(string email, string password)
    {
        var loginTask = auth.SignInWithEmailAndPasswordAsync(email, password);

        yield return new WaitUntil(() => loginTask.IsCompleted);

        if (loginTask.Exception != null)
        {
            FirebaseException firebaseException = loginTask.Exception.GetBaseException() as FirebaseException;
            AuthError authError = (AuthError)firebaseException.ErrorCode;

            string failedMessage = "Login Failed! Because ";

            switch (authError)
            {
                case AuthError.InvalidEmail:
                    failedMessage += "Email is invalid";
                    break;
                case AuthError.WrongPassword:
                    failedMessage += "Wrong Password";
                    break;
                case AuthError.MissingEmail:
                    failedMessage += "Email is missing";
                    break;
                case AuthError.MissingPassword:
                    failedMessage += "Password is missing";
                    break;
                default:
                    failedMessage = "Login Failed";
                    break;
            }

            DebugRemoveTime(failedMessage);
        }
        else
        {
            AuthenticationView.OnDashboard();
        }
    }

    private void DebugRemoveTime(string message)
    {
        Sequence mySequence = DOTween.Sequence();

        mySequence.AppendCallback(() => DebugText.text = message)
          .Append(DebugText.DOFade(1, 0.25f))
          .AppendInterval(5)
          .AppendCallback(() => DebugText.text = string.Empty)
          .Append(DebugText.DOFade(0, 0.25f));
    }

    public void CreateUser(UserModel newUser)
    {
        auth.CreateUserWithEmailAndPasswordAsync(emailReg.text, passwordReg.text).ContinueWith(task =>
        {
            if (task.IsCanceled || task.IsFaulted)
            {
                string message = "User creation failed. Error: " + task.Exception;
                DebugRemoveTime(message);
                return;
            }

            if (task.IsCompleted)
            {
                AuthResult authResult = task.Result;
                FirebaseUser user = authResult.User;

                string json = JsonUtility.ToJson(newUser);
                dbReference.Child("users").Child(newUser.userName).SetRawJsonValueAsync(json)
                    .ContinueWith(databaseTask =>
                    {
                        if (databaseTask.Exception == null)
                        {
                            string message = "Registration successful: " + task.Exception;
                            DebugRemoveTime(message);
                        }
                        else
                        {
                            string message = "User creation failed. Error: " + databaseTask.Exception;
                            DebugRemoveTime(message);
                        }
                    });
            }
        });
    }

    public void CheckUserExists(string email, Action<bool> callback)
    {
        dbReference.Child("users").Child(email).GetValueAsync()
            .ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    DataSnapshot snapshot = task.Result;
                    bool exists = snapshot.Exists;
                    callback?.Invoke(exists);
                }
                else
                {
                    string message = "Error checking user existence: " + task.Exception;
                    DebugRemoveTime(message);
                    callback?.Invoke(false);
                }
            });
    }
}