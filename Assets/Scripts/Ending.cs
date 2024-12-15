using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SimpleSlideshow : MonoBehaviour
{
    public Image displayImage; // El componente Image que mostrar� las diapositivas
    public Sprite[] imageSequence; // Array de im�genes
    public float slideDuration = 6f; // Duraci�n de cada diapositiva (en segundos)
    public int menuPrincipal = 0; // Nombre de la escena al final del slideshow

    private int currentIndex = 0; // �ndice de la imagen actual
    private float timer = 0f; // Temporizador para cambiar de imagen

    void Start()
    {
        // unlock the cursor and make it visible
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (imageSequence.Length == 0)
        {
            Debug.LogError("El array de im�genes est� vac�o. Por favor, asigna im�genes en el Inspector.");
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
