using UnityEngine;

public class RateAppButton : MonoBehaviour
{
    private string appStoreUrl = "itms-apps://itunes.apple.com/app/id6584520850?action=write-review";

    public void RateApp()
    {
        Application.OpenURL(appStoreUrl);
    }
}