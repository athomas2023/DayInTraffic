using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    [System.Serializable]
    public class DialogEntry
    {
        public string text;
        public TMP_FontAsset font;
        public int fontSize;
        public Color fontColor;
        public bool typeWriterEffect;
        public float typeWriterSpeed = 0.05f;
    }

    public TextMeshProUGUI dialogText;
    public int maxDialogEntries = 5;
    public DialogEntry[] dialogEntries;
    public string nextScene;

    private int currentDialogIndex = 0;
    private int dialogCount = 0;

    private bool isTyping = false;
    private string currentDialog = "";
    private float typeWriterTimer = 0.0f;

    void Start()
    {
        if (dialogEntries.Length > 0)
        {
            currentDialog = dialogEntries[currentDialogIndex].text;
            dialogText.text = "";
            dialogText.font = dialogEntries[currentDialogIndex].font;
            dialogText.fontSize = dialogEntries[currentDialogIndex].fontSize;
            dialogText.color = dialogEntries[currentDialogIndex].fontColor;
            isTyping = true;
            typeWriterTimer = 0.0f;
        }
    }

    void Update()
    {
        if (isTyping)
        {
            typeWriterTimer += Time.deltaTime;
            if (typeWriterTimer > dialogEntries[currentDialogIndex].typeWriterSpeed)
            {
                typeWriterTimer = 0.0f;
                if (currentDialog.Length > dialogText.text.Length)
                {
                    dialogText.text += currentDialog[dialogText.text.Length];
                }
                else
                {
                    isTyping = false;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) && dialogCount < maxDialogEntries)
        {
            currentDialogIndex++;
            if (currentDialogIndex >= dialogEntries.Length)
            {
                CloseDialog();
            }
            else
            {
                currentDialog = dialogEntries[currentDialogIndex].text;
                dialogText.text = "";
                dialogText.font = dialogEntries[currentDialogIndex].font;
                dialogText.fontSize = dialogEntries[currentDialogIndex].fontSize;
                dialogText.color = dialogEntries[currentDialogIndex].fontColor;
                isTyping = true;
                typeWriterTimer = 0.0f;
                dialogCount++;
            }
        }
        else if (dialogCount >= maxDialogEntries)
        {
            CloseDialog();
        }
    }

    void CloseDialog()
    {
        if (!string.IsNullOrEmpty(nextScene))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}