using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJolt.API;
using GameJolt.API.Core;
using GameJolt.API.Internal;
using GameJolt.API.Objects;
using GameJolt.External;
using GameJolt.UI;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;
using System.Linq;

public class GmJoltMethods : MonoBehaviour
{


	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void SignInButtonClicked()
	{
		GameJoltUI.Instance.ShowSignIn(success => {
			GameJoltUI.Instance.QueueNotification(success ? "Bienvenido" : "Cerraste la ventana");
		});
	}

	public void SignOutButtonClicked()
	{
		if (!GameJoltAPI.Instance.HasUser)
		{
			GameJoltUI.Instance.QueueNotification("No has iniciado sesion");
		}
		else
		{
			GameJoltAPI.Instance.CurrentUser.SignOut();
			GameJoltUI.Instance.QueueNotification("Has cerrado sesion");
		}
	}

	public void IsSignedInButtonClicked()
	{
		if (GameJoltAPI.Instance.HasUser)
		{
			GameJoltUI.Instance.QueueNotification(
				"Has iniciado sesion como " + GameJoltAPI.Instance.CurrentUser.Name);
		}
		else
		{
			GameJoltUI.Instance.QueueNotification("No has iniciado sesion");
		}
	}


	//Trofeos
	public void UnlockTrophy(string trophyID)
	{
		Debug.Log("Unlock Trophy. Click to see source.");

		var trophyId = trophyID != string.Empty ? int.Parse(trophyID) : 0;
		Trophies.Unlock(trophyId, success => {
			//AddConsoleLine("Unlock Trophy {0}.", success ? "Successful" : "Failed");
		});
	}

	public void TryUnlockTrophy(string trophyID)
	{
		Debug.Log("Try Unlock Trophy. Click to see source.");

		var trophyId = trophyID != string.Empty ? int.Parse(trophyID) : 0;
		Trophies.TryUnlock(trophyId, success => {
			//AddConsoleLine("Unlock Trophy {0}.", success);
		});
	}


}
