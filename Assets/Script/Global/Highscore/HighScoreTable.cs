using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HighScoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;

    private void Awake() 
    {
        entryContainer = transform.Find("Entry Template");
        entryTemplate = entryContainer.Find("Entry Template");

        entryTemplate.gameObject.SetActive(false);

        float templateHeight = 20f;
        for (int i =0; i < 10; i++) 
        {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);
        }
    }
}
