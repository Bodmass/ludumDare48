using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerEssenceManager : MonoBehaviour
{
    [SerializeField] private GameObject essenceBuffGO;

    [SerializeField] private TextMeshProUGUI EssenceText;

    [SerializeField] private int essenceCount_ = 0;
    [SerializeField] private int essenceMax = 0;

    [SerializeField] private Animator whisperAnimator;
    [SerializeField] private float whisperDuration = 5f;
    private bool whisperActive;
    private float whisperTime;

    [SerializeField] private TextMeshProUGUI whisperText;

    public int essenceCount{
        get {return essenceCount_;}
    }
    [SerializeField] private Triggerable[] triggerableAt3;
    [SerializeField] private Triggerable[] triggerableAt6;


    void Start()
    {
        whisperActive = false;
        whisperTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(whisperActive){
            whisperTime += Time.deltaTime;
            if(whisperTime >= whisperDuration)
            {
                whisperActive = false;
                whisperAnimator.SetBool("whisperActive", false);
            }
        }

        if(essenceMax == 0)
        {
            EssenceText.text = "";

        }
        else
        {
            EssenceText.text = essenceCount_.ToString() + "/" + essenceMax.ToString(); 
        }
        
    }

    public void Whisper(string s){
        whisperText.text = s;
        whisperTime = 0;
        whisperActive = true;
        whisperAnimator.SetBool("whisperActive", true);

    }

    public void GainEssence(){
        GameObject newGO = GameObject.Instantiate(essenceBuffGO, Vector3.zero, Quaternion.identity, this.transform);
        newGO.transform.localPosition = Vector3.zero;
        essenceCount_+=1;
        if(essenceCount == 3)
        {
            foreach(Triggerable trig in triggerableAt3)
            {
                trig.TriggerMe();
            }
            Whisper("You become infused with a power of a dream essence.\nYou feel as if you can leap once more!");
            GetComponent<playerJump>().IncreaseMaxJumps(1);
        }
        else if(essenceCount == 6)
        {
            Whisper("You become infused with a power of a dream essence.\nYou feel as if a Gateway as opened somewhere.");
            foreach(Triggerable trig in triggerableAt6)
            {
                trig.TriggerMe();
            }
        }
        else{
            Whisper("You become infused with a power of a dream essence!");
        }
        Destroy(newGO, 10f);
    }

    public void IncreaseEssenceCap(int amountToIncrease)
    {
        Debug.Log("Essence Cap Increased by "+amountToIncrease);
        essenceMax += amountToIncrease;
    }
}
