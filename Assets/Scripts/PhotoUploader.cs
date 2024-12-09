using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PhotoUploader : MonoBehaviour
{
    public RawImage previewImage;
    public Button uploadButton;
    public Button confirmButton;

    private Texture2D uploadedPhoto;

    void Start()
    {
        uploadButton.onClick.AddListener(SelectPhoto);
        confirmButton.onClick.AddListener(ConfirmPhoto);
    }

    void SelectPhoto()
    {
        string path = Application.dataPath + "/SampleImage.jpg"; // Placeholder path
        LoadPhoto(path);
    }

    void LoadPhoto(string filePath)
    {
        byte[] imageData = File.ReadAllBytes(filePath);
        uploadedPhoto = new Texture2D(2, 2);
        uploadedPhoto.LoadImage(imageData);
        previewImage.texture = uploadedPhoto;
    }

    void ConfirmPhoto()
    {
        // Deactivate Upload and Confirm buttons
        uploadButton.gameObject.SetActive(false);
        confirmButton.gameObject.SetActive(false);

        // Set initial opacity of the image to 0
        SetImageOpacity(0f);
    }

    public void SetImageOpacity(float opacity)
    {
        Color color = previewImage.color;
        color.a = opacity;
        previewImage.color = color;
    }
}
