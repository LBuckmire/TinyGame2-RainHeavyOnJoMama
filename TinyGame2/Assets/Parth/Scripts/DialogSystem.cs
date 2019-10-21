using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    public Text nametext;
    public Text dialogtext;
    

    public GameObject dialogui;
    public Transform dialogboxui;

    public float letterdelay = 0.1f;
    public float lettermultiplier = 0.5f;

    public KeyCode dialoginput = KeyCode.F;

    public string Names;

    public string[] dialoglines;

    public bool letterismultiplied = false;
    public bool dialogactive = false;
    public bool dialogenabled = false;
    public bool outofrange = true;

    public AudioClip audioclip;
    AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        dialogtext.text = "";
        
    }

    void Update()
    {

    }

    
    // Update is called once per frame

    public void EnterRangedOfNPC()
    {
        outofrange = false;
        dialogui.SetActive(true);
        if(dialogactive == true)
        {
            dialogui.SetActive(false);
        }
    }

    public void NPCName()
    {
        outofrange = false;
        dialogboxui.gameObject.SetActive(true);
        nametext.text = Names;
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(!dialogactive)
            {
                dialogactive = true;
                StartCoroutine(StartDialog());
            }
        }
        StartDialog();
    }

    private IEnumerator StartDialog()
    {
        if(outofrange == false)
        {
            int dialoglength = dialoglines.Length;
            int currentdialogindex = 0;

            while (currentdialogindex < dialoglength || !letterismultiplied)
            {
                if(!letterismultiplied)
                {
                    letterismultiplied = true;
                    StartCoroutine(DisplayString(dialoglines[currentdialogindex++]));

                    if(currentdialogindex >= dialoglength)
                    {
                        dialogenabled = true;
                    }
                }
                yield return 0;
            }

            while (true)
            {
                if(Input.GetKeyDown(dialoginput) && dialogenabled == false)
                {
                    break;
                }
                yield return 0;

            }
            dialogenabled = false;
                     
           dialogactive = false;
            DropDialog();
        }
    }

    private IEnumerator DisplayString(string stringToDisplay)
    {
        if(outofrange == false)
        {
            int stringlength = stringToDisplay.Length;
            int currentcharacterindex = 0;

            dialogtext.text = "";

            while (currentcharacterindex < stringlength)
            {
                dialogtext.text += stringToDisplay[currentcharacterindex];
                currentcharacterindex++;

                if(currentcharacterindex < stringlength)
                {
                    if (Input.GetKey(dialoginput))
                    {
                        yield return new WaitForSeconds(letterdelay * lettermultiplier);
                        if (audioclip) audiosource.PlayOneShot(audioclip, 0.5f);
                    }
                    else
                    {
                        yield return new WaitForSeconds(letterdelay);
                        if (audioclip) audiosource.PlayOneShot(audioclip, 0.5f);

                    }
                }else
                {
                    dialogenabled = false;
                    break;
                }
                
            }
            while (true)
            {
                if (Input.GetKeyDown(dialoginput))
                {
                    break;
                }

                yield return 0;
            }

            dialogenabled = false;
            letterismultiplied = false;
            dialogtext.text = "";
        }
    }

    public void DropDialog()
    {
        dialogui.SetActive(false);
        dialogboxui.gameObject.SetActive(false);
    }

    public void Outofrange()
    {
        outofrange = true;
        if (outofrange == true)
        {
            letterismultiplied = false;
            dialogactive = false;
            StopAllCoroutines();
            dialogui.SetActive(false);
            dialogboxui.gameObject.SetActive(false);
        }
    }

    // When are we tuning it on
    // Why
    // What time or state?
}
