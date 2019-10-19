using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class NPC : MonoBehaviour
{
    public Transform Background;
    public Transform character;

    private DialogSystem dialogsystem;
    public string Name;

    [TextArea(5, 15)]
    public string[] sentences;
      
    // Start is called before the first frame update
    void Start()
    {
        dialogsystem = FindObjectOfType<DialogSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        Background.position = Camera.main.WorldToScreenPoint(character.position + Vector3.up * 7f);
        Vector3 pos = Camera.main.WorldToScreenPoint(character.position);
        pos.y += 175;
        Background.position = pos;
    }

    public void OnTriggerStay(Collider other)
    {
        this.gameObject.GetComponent<NPC>().enabled = true;
        FindObjectOfType<DialogSystem>().EnterRangedOfNPC();
        if((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F))
        {
            this.gameObject.GetComponent<NPC>().enabled = true;
            dialogsystem.Names = name;
            dialogsystem.dialoglines = sentences;
            FindObjectOfType<DialogSystem>().NPCName();
        }
    }

    public void OnTriggerExit()
    {
        FindObjectOfType<DialogSystem>().Outofrange();
        this.gameObject.GetComponent<NPC>().enabled = false;
    }

}
