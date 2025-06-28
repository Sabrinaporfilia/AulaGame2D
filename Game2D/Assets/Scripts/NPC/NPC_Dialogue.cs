using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{

    public float dialogueRange;
    public LayerMask playerLayer;

    bool playerHit;

    private List<string> sentences = new List<string>();

    public DialogueSettings dialogue;

   

    private void Start()
    {
        GetTextsNpc();
    }


    // é chamado a cada frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerHit)
        {
            DialogueControl.instance.Speech(sentences.ToArray());
        }
    }

    //método para pegar variaveis do codigo dialogue settings
    void GetTextsNpc()
    {
        for (int i = 0; i < dialogue.dialogues.Count; i++)
        {
            switch (DialogueControl.instance.language)
            {

                case DialogueControl.idiom.pt:
                    sentences.Add(dialogue.dialogues[i].sentence.portuguese);
                    break;
                case DialogueControl.idiom.eng:
                    sentences.Add(dialogue.dialogues[i].sentence.english);
                    break;
                case DialogueControl.idiom.spa:
                    sentences.Add(dialogue.dialogues[i].sentence.spanish);
                    break;
            }
        }
    }

    // é usado pela física
    void FixedUpdate()
    {
        ShowDialogue();
    }

    public void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);

        if(hit != null)
        {
            playerHit = true;

        }
        else
        {
            playerHit = false;
   
        }
    }

    //pular para próxima frase
    public void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }

  
}
