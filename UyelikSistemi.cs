using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
public class UyelikSistemi : MonoBehaviour {
    
    public Text log;
    FirebaseAuth auth;
   public  InputField email;
    public InputField password;
    void Start () {
   auth  = Firebase.Auth.FirebaseAuth.DefaultInstance;	
	}
	void Update () {
        logtut();
	}


    public void kayitol()
    {
        auth.CreateUserWithEmailAndPasswordAsync(email.text, password.text).ContinueWith(task => {
  if (task.IsCanceled) {
    Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                logtut("hata");
                return;
  }
  if (task.IsFaulted) {
    Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                logtut("hata");
                return;
  }

  // Firebase user has been created.
  Firebase.Auth.FirebaseUser newUser = task.Result;
  Debug.LogFormat("Firebase user created successfully: {0} ({1})",
      newUser.DisplayName, newUser.UserId);
            logtut("kayit basarili");
        });
      
    }


    public void giris()
    {
        auth.SignInWithEmailAndPasswordAsync(email.text, password.text).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                logtut("hata");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                logtut("hata");
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
            logtut("giris basarili");
        });
    }
    private void logtut(string logkaydi = "Log")
    {
        log.text = logkaydi;
    }
}
