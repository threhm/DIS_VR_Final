using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextChanger : MonoBehaviour
{
    // Start is called before the first frame update

    BoxCollider boxCollider;

    public TMP_Text finalScoreText;

    public TMP_Text tutorialText1;

    public TMP_Text tutorialText2;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.isTrigger = true;
        boxCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider col)
    {
        //Debug.Log("hit");
        if (col.CompareTag("player")) // Sliced fruits
        {
            //Debug.Log("got here");
            finalScoreText.gameObject.SetActive(true);
            tutorialText1.gameObject.SetActive(false);
            tutorialText2.gameObject.SetActive(false);
        }
    }
}
