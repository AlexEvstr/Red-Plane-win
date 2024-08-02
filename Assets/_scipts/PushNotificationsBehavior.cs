using OneSignalSDK;
using UnityEngine;

public class PushNotificationsBehavior : MonoBehaviour
{
    void Start()
    {
        CheckEnter();
    }

    private void CheckEnter()
    {
        OneSignal.Initialize("f37fb1bc-4111-4412-ac65-18480e422cc6");

        if (PlayerPrefs.GetInt("HasRequestedPushPermission", 0) == 0)
        {
            RequestPushPermissions();
            PlayerPrefs.SetInt("HasRequestedPushPermission", 1);
            PlayerPrefs.Save();
        }
    }

    async void RequestPushPermissions()
    {
        await OneSignal.Notifications.RequestPermissionAsync(false);
    }
}