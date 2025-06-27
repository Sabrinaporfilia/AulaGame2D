using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogueObj; // janela do dialogo
    public Image profileSprite; //sprite do perfil
    public Text speachText; // texto da fala
    public Text actorNameText; //nome do npc

    [Header("Settings")]

    public float typingSpeed; //velocidade da fala


    //variaveis de controle
    private bool isShowing; // se janela esta visivel
    private int index; // index das sentenças, falas, textos
    private string[] sentences;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TypeSentence()
    {
        foreach (char letter in  sentences[index].ToCharArray())
        {
            speachText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    //pular para proxima fala
    public void NextSentence()
    {

    }

    // chamar a fala do npc
    public void Speech(string[] txt)
    {
        if (!isShowing)
        {
            dialogueObj.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }
}
