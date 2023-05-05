using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextChanger : MonoBehaviour
{
    // Start is called before the first frame update

    private BoxCollider boxCollider;

    public TMP_Text finalScoreText;

    public TMP_Text tutorialText1;

    public TMP_Text tutorialText2;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("player")) // Sliced fruits
        {
            finalScoreText.gameObject.SetActive(true);
            tutorialText1.gameObject.SetActive(false);
            tutorialText2.gameObject.SetActive(false);
        }
    }
}
