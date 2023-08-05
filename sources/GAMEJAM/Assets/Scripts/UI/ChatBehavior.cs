using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using VoltstroStudios.UnityWebBrowser.Core;

public class ChatBehavior : MonoBehaviour
{
    [SerializeField] 
    private BaseUwbClientManager clientManager;
    [SerializeField]
    private Screamer _screamer;

    private WebBrowserClient webBrowserClient;
    private const string disableChangeMessageScript = "$(document).unbind('DOMNodeInserted');";


    private void OnEnable()
    {
        _screamer.asuPlay += ChangeMessagesToASUJDAUUUUUUUUUUUUU;
    }

    private void OnDisable()
    {
        _screamer.asuPlay -= ChangeMessagesToASUJDAUUUUUUUUUUUUU;
    }


    private void Start()
    {
        webBrowserClient = clientManager.browserClient;
    }

    void ChangeMessagesToASUJDAUUUUUUUUUUUUU()
    {
        string replacedText = "ÀÑÓ";
        webBrowserClient.ExecuteJs(disableChangeMessageScript);

        var js = $"$(document).bind('DOMNodeInserted', function(event) {{ let message = event.target.getElementsByClassName(\"message\"); if (message !== undefined && message[0] !== undefined) {{ message[0].innerHTML = '{replacedText}'; }} }});";
        webBrowserClient.ExecuteJs(js);
    }
}
