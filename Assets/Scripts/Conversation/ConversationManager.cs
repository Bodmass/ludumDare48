using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConversationManager : MonoBehaviour
{
    private bool currentlyConversating = false;

    private Conversation currentConversation;

    private int currentIndex = -1;
    private int conversationLength = 0;
    [SerializeField] private CanvasGroup textBox;
    [SerializeField] private TextMeshProUGUI textBoxText;

    private string textToShow;

    private string currentText;
    [SerializeField] private float TextSpeed = 0.25f;

    public bool isTalking
    {
        get {return currentlyConversating;}
    }
    public void ParseConversation(Conversation conversation)
    {

        Debug.Log("Parsing Conversation!");
        currentConversation = conversation;
        conversationLength = currentConversation.conversationNodes.Length;
        textBox.alpha = 1.0f;
        currentIndex = -1;
        currentlyConversating = true;
        ProceedConversation();

    }

    private void EndConversation()
    {
        textBox.alpha = 0;
        currentlyConversating = false;
        currentIndex = -1;
        textBoxText.text = "";
        textToShow = "";
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void ProceedConversation()
    {
        currentIndex++;
        if(currentIndex < conversationLength)
        {
            Debug.Log("Conversation " + currentIndex+"/"+conversationLength);
            ConversationTextNode currentTextNode = (ConversationTextNode)currentConversation.conversationNodes[currentIndex];

            if(currentTextNode.GetType() != typeof(ConversationTextNode))
            {
                if(currentTextNode.GetType() == typeof(ConversationEssenceNode))
                {
                    ConversationEssenceNode essenceNode = (ConversationEssenceNode)currentTextNode;
                    if(essenceNode.obtained)
                    {
                        ProceedConversation();
                    }
                    else{
                        currentConversation.conversationNodes[currentIndex].UseNode();
                        textBoxText.text = "";
                        currentText = "";
                        textToShow = currentTextNode.text;
                        StartCoroutine(BuildText());
                    }
                }
                else if(currentTextNode.GetType() == typeof(ConversationTriggerNode))
                {
                    ConversationTriggerNode triggerNode = (ConversationTriggerNode)currentTextNode;
                    if(triggerNode.activated)
                    {
                        ProceedConversation();
                    }
                    else{
                        currentConversation.conversationNodes[currentIndex].UseNode();
                        textBoxText.text = "";
                        currentText = "";
                        textToShow = currentTextNode.text;
                        StartCoroutine(BuildText());
                    }
                }
                else{
                    ProceedConversation();
                }
            }
            else
            {

            currentConversation.conversationNodes[currentIndex].UseNode();
            textBoxText.text = "";
            currentText = "";
            textToShow = currentTextNode.text;
            StartCoroutine(BuildText());
            }
        }
        else{
            EndConversation();
        }
    }

    void Update()
    {
        if(currentlyConversating)
        {
            if(Input.GetButtonDown("Interact"))
            {
                if(textBoxText.text == textToShow)
                {
                    ProceedConversation();
                }
            }
            // if(textBoxText.text != textToShow)
            // {
            //     textToShow.text
            // }
        }
    }

     private IEnumerator BuildText(){
     for (int i = 0; i <= textToShow.Length; i++){
         currentText = textToShow.Substring(0, i);
         textBoxText.text = currentText;
         //Wait a certain amount of time, then continue with the for loop
         yield return new WaitForSeconds(TextSpeed);
     }
 }
}
