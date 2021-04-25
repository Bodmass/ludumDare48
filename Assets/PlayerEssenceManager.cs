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
        Whisper("You become infused with a power of a dream essence!");
        Destroy(newGO, 10f);
    }

    public void IncreaseEssenceCap(int amountToIncrease)
    {
        essenceMax =+ amountToIncrease;
    }
}
