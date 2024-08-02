using UnityEngine;

public class PolicyButton : MonoBehaviour
{
    [SerializeField] private UniWebView webViewComponent;
    private string privacyPolicyUrl = "https://www.freeprivacypolicy.com/live/8dae8e72-98ae-4ce0-ac58-71612bb7feab";

    void Start()
    {
        webViewComponent.OnPageFinished += HandlePageFinished;
        webViewComponent.OnShouldClose += HandleShouldClose;
        webViewComponent.Load(privacyPolicyUrl);
    }

    private void HandlePageFinished(UniWebView webView, int statusCode, string url)
    {
        string script = @"
            document.body.style.userSelect = 'none';
            var interactiveElements = document.querySelectorAll('a, input, button, textarea, select');
            interactiveElements.forEach(function(element) {
                element.onclick = function(event) { event.preventDefault(); };
                element.onmousedown = function(event) { event.preventDefault(); };
                element.onmouseup = function(event) { event.preventDefault(); };
                element.onmouseover = function(event) { event.preventDefault(); };
                element.onmouseout = function(event) { event.preventDefault(); };
                element.onmousemove = function(event) { event.preventDefault(); };
                element.onmousewheel = function(event) { event.preventDefault(); };
                element.onblur = function(event) { event.preventDefault(); };
                element.onfocus = function(event) { event.preventDefault(); };
                element.onchange = function(event) { event.preventDefault(); };
                element.onsubmit = function(event) { event.preventDefault(); };
                element.onreset = function(event) { event.preventDefault(); };
                element.onselect = function(event) { event.preventDefault(); };
                element.oninput = function(event) { event.preventDefault(); };
                element.ondblclick = function(event) { event.preventDefault(); };
                element.ondrag = function(event) { event.preventDefault(); };
                element.ondrop = function(event) { event.preventDefault(); };
                element.onkeypress = function(event) { event.preventDefault(); };
                element.onkeydown = function(event) { event.preventDefault(); };
                element.onkeyup = function(event) { event.preventDefault(); };
            });
        ";
        webView.EvaluateJavaScript(script);
    }

    private bool HandleShouldClose(UniWebView webView)
    {
        return false;
    }

    private void OnDestroy()
    {
        if (webViewComponent != null)
        {
            webViewComponent.OnShouldClose -= HandleShouldClose;
            webViewComponent.OnPageFinished -= HandlePageFinished;
        }
    }
}