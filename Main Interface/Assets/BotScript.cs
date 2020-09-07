using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIMLbot;
using UnityEngine.UI;

public class BotScript : MonoBehaviour
{
    Bot AI = new Bot();
    User myuser;

    public Text outputText;
    public InputField inputText;


    // Start is called before the first frame update
    void Start()
    {

        AI.loadSettings();
        AI.loadAIMLFromFiles();
        AI.isAcceptingUserInput = false; //With this Code it will Disable UserInput For Now
        myuser = new User("NEOMI", AI); //With This Code We Will Add The User Through AI/Bot
        AI.isAcceptingUserInput = true; //Now The User Input is Enabled Again with this Code
    }

    public void reply()
    {
        string inputUser = inputText.text;
        Request r = new Request(inputUser, myuser, AI);
        Result res = AI.Chat(r);
        outputText.text = res.Output; 
        inputText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            reply();
        }

    }
}
