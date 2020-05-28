using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public DialougBox dialoug;

    public Text placeHolder;
    public GameObject dialougBoxObject;

    public bool onDialoug = false;
    public bool started = false;

    private int index;

    void Update()
    {
        if (started&& Input.GetKeyDown(KeyCode.Space))
        {
            if (index < dialoug.texts.Length -1  && !onDialoug )
            {
                index++;
                showOnCanvas();
            }
            else
            {
                end();
            }
        }
    }

    public void showOnCanvas()
    {
        StopCoroutine(typeText());

        //onDialoug = true;
        placeHolder.text = "";
        if (!onDialoug)
            StartCoroutine(typeText());
    }

    IEnumerator typeText()
    {
        onDialoug = true;

        int i = 0;
        while (i < dialoug.texts[index].Length)
        {

            placeHolder.text += dialoug.texts[index][i++];
            if (i >= dialoug.texts[index].Length)
            {
           
            }
            yield return new WaitForSeconds(0.006f);

        }
        onDialoug = false;
        
    }

    public void begin()
    {
        StopCoroutine(typeText());

        index = 0;
        started = true;
        dialougBoxObject.SetActive(true);
        showOnCanvas();

    }

    public void end()
    {
        started = false;
        StopCoroutine(typeText());
        dialougBoxObject.SetActive(false);
    }
}
