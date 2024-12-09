using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PuzzleManager : MonoBehaviour
{
    public GameObject cardPrefab;
    public Transform cardParent;
    public PhotoUploader photoUploader;
    public GameObject nextPuzzleButton;

    private List<GameObject> cards = new List<GameObject>();
    private List<Color> cardColors = new List<Color> { Color.red, Color.green, Color.blue, Color.yellow };
    private int correctPairs = 0;
    private GameObject firstSelectedCard;
    private GameObject secondSelectedCard;

    void Start()
    {
        InitializeCards(4); // Start with 4 cards
    }

    void InitializeCards(int cardCount)
    {
        // Double the colors list to create pairs
        List<Color> colors = new List<Color>();
        for (int i = 0; i < cardCount / 2; i++)
        {
            colors.Add(cardColors[i]);
            colors.Add(cardColors[i]);
        }
        Shuffle(colors);

        // Instantiate and assign colors to cards
        for (int i = 0; i < cardCount; i++)
        {
            GameObject card = Instantiate(cardPrefab, cardParent);
            CardController cardController = card.GetComponent<CardController>();
            cardController.frontImage.GetComponent<Image>().color = colors[i];
            cards.Add(card);

            // Add a listener for when the card is clicked
            int index = i; // local copy for lambda closure
            card.GetComponent<Button>().onClick.AddListener(() => OnCardClicked(card));
        }
    }

    void Shuffle(List<Color> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Color temp = list[i];
            int randomIndex = Random.Range(0, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    void OnCardClicked(GameObject selectedCard)
    {
        if (firstSelectedCard == null)
        {
            firstSelectedCard = selectedCard;
            firstSelectedCard.GetComponent<CardController>().FlipCard();
        }
        else if (secondSelectedCard == null && selectedCard != firstSelectedCard)
        {
            secondSelectedCard = selectedCard;
            secondSelectedCard.GetComponent<CardController>().FlipCard();
            CheckForMatch();
        }
    }

    void CheckForMatch()
    {
        if (firstSelectedCard.GetComponent<CardController>().frontImage.GetComponent<Image>().color ==
            secondSelectedCard.GetComponent<CardController>().frontImage.GetComponent<Image>().color)
        {
            Debug.Log("Correct!");
            correctPairs++;

            photoUploader.SetImageOpacity(correctPairs * 0.33f); // Increase opacity (assuming 3 matches = ~full)

            // Reset selected cards
            firstSelectedCard = null;
            secondSelectedCard = null;

            // If we've matched all pairs (assuming 4 total pairs for full reveal)
            if (correctPairs == 4)
            {
                // Fully revealed, show Next Puzzle button
                nextPuzzleButton.SetActive(true);
            }
            else
            {
                // If correctPairs == 1, add 4 more cards
                if (correctPairs == 1)
                {
                    InitializeCards(4);
                }
            }
        }
        else
        {
            // Hide cards again if they don't match
            Invoke("ResetCards", 0.5f);
        }
    }
    public void OnNextPuzzleButtonPressed()
    {
        // Load next scene or puzzle logic
        UnityEngine.SceneManagement.SceneManager.LoadScene("2nPuzzle");
    }



    void ResetCards()
    {
        firstSelectedCard.GetComponent<CardController>().FlipCard();
        secondSelectedCard.GetComponent<CardController>().FlipCard();
        firstSelectedCard = null;
        secondSelectedCard = null;
    }
}
