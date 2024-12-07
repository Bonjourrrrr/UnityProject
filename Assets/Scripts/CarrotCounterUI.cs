using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // import TextMeshPro

public class CarrotCounterUI : MonoBehaviour
{
    private TextMeshProUGUI carrotCounterText;
    // Start is called before the first frame update
    void Start()
    {
        // Get the TextMeshProUGUI component
        carrotCounterText = GetComponent<TextMeshProUGUI>();

        // Initialize the text
        UpdateCarrotCounterUI();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCarrotCounterUI();
    }
    void UpdateCarrotCounterUI()
    {
        // Get the carrot count from GameManager and update the UI
        carrotCounterText.text = $"Carrots Eaten: {GameManager.Instance.GetCarrotsEaten()}";
    }
}
