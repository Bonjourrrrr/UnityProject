using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ImageSlideshow : MonoBehaviour
{
    public Image displayImage; // Referencia al componente UI Image
    public Sprite[] imageSequence; // Array de im�genes (asignadas desde el Inspector)
    public Button nextButton; // Referencia al bot�n UI (asignado desde el Inspector)
    private int currentIndex = 0; // �ndice de la imagen actual

    public string nextSceneName; // Nombre de la escena del nivel 1

    private int level;

    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        //manager = this.gameObject;
        Debug.Log($"Level: {level}");


        // Configura la primera imagen
        if (imageSequence.Length > 0)
        {
            displayImage.sprite = imageSequence[currentIndex];
        }

        // Configura el bot�n para que llame a NextImage()
        nextButton.onClick.AddListener(NextImage);


    }

    public void NextImage()
    {
        if (currentIndex < imageSequence.Length - 1)
        {
            currentIndex++; // Avanza al siguiente �ndice
            displayImage.sprite = imageSequence[currentIndex]; // Cambia la imagen
            
        }
        else
        {
            MarkSlideshowAsShown(); // Marca como mostrado
            LoadNextScene(); // Carga el nivel
            SceneManager.LoadScene(level + 1);
        }
    }

    void MarkSlideshowAsShown()
    {
        PlayerPrefs.SetInt("SlideshowShown", 1);
        PlayerPrefs.Save();
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
