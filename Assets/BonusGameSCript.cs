using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusGameSCript : MonoBehaviour
{
    public GameObject[] cardObjects; // Array of card game objects containing card images
    int selectedCardType;
    public GameObject Reward,Wrong;
    void StartCardGame()
    {
        // Select a random card image
        int randomIndex = Random.Range(0, cardObjects.Length);
        GameObject selectedCard = cardObjects[randomIndex];

        // Display the selected card
        Debug.Log("The randomly selected card image is: " + selectedCard.name);
        selectedCard.SetActive(true);
        // Prompt the user to select a card type

        // Check if the user's prediction matches the selected card type
        CheckPrediction(selectedCardType, randomIndex);
    }
    public void SelectCard(int selectCardType)
    {
        selectedCardType = selectCardType;
        StartCardGame();
    }
    void CheckPrediction(int selectedType, int actualType)
    {
        if (selectedType == actualType)
        {
            Debug.Log("Congratulations! Your prediction was correct.");
            Reward.SetActive(true);
            PlayerPrefs.SetInt("NewAllGold", PlayerPrefs.GetInt("NewAllGold") + 1000);
            Invoke("ChangeScene", 5);

        }
        else
        {
            Wrong.SetActive(true);
            Invoke("ChangeScene", 5);
            Debug.Log("Sorry, your prediction was incorrect.");
        }
    }
    void ChangeScene()
    {
        Application.LoadLevel(0);
    }
}
