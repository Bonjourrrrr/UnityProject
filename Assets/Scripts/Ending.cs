using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SimpleSlideshow : MonoBehaviour
{
    public Image displayImage; // El componente Image que mostrará las diapositivas
    public Sprite[] imageSequence; // Array de imágenes
    public float slideDuration = 6f; // Duración de cada diapositiva (en segundos)
    public int menuPrincipal = 0; // Nombre de la escena al final del slideshow

    private int currentIndex = 0; // Índice de la imagen actual
    private float timer = 0f; // Temporizador para cambiar de imagen

    void Start()
    {
        // unlock the cursor and make it visible
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (imageSequence.Length == 0)
        {
            Debug.LogError("El array de imágenes está vacío. Por favor, asigna imágenes en el Inspector.");
            return;
        }

        // Configura la primera imagen
        displayImage.sprite = imageSequence[currentIndex];
        timer = slideDuration;
    }

    void Update()
    {
        // Cuenta regresiva del temporizador
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            NextSlide(); // Cambia a la siguiente diapositiva
        }
    }

    void NextSlide()
    {
        currentIndex++;

        if (currentIndex < imageSequence.Length)
        {
            // Cambia a la siguiente imagen
            displayImage.sprite = imageSequence[currentIndex];
            timer = slideDuration; // Reinicia el temporizador
        }
        else
        {
            // Final del slideshow: carga la escena principal
            SceneManager.LoadScene(menuPrincipal);
        }
    }
}
