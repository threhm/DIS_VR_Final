using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartApple : MonoBehaviour
{
    BoxCollider boxCollider;

    public TMP_Text finalScoreText;

    public TMP_Text tutorialText1;

    public TMP_Text tutorialText2;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.isTrigger = true;
        boxCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider col)
    {
        
        if (col.CompareTag("sword"))
        {
            GameObject.Find("XR Origin").GetComponent<PlayerMover>().speed = 0.02f;
            finalScoreText.gameObject.SetActive(true);
            tutorialText1.gameObject.SetActive(false);
            tutorialText2.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}