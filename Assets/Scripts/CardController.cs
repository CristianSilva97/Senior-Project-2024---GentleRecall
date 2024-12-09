using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    public GameObject frontImage;
    public GameObject backImage;

    private bool isFlipped = false;

    public void FlipCard()
    {
        isFlipped = !isFlipped;
        frontImage.SetActive(isFlipped);
        backImage.SetActive(!isFlipped);
    }
}
