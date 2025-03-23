// AUTOR DIEGO CARREÓN AGUIRRE
// TUTOR ROBERTO MARTÍNEZ ROMÁN
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{
    private UIDocument Menu;
    private Button Play;
    private Button Credits;
    private Button Help;
    private Button Exit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
void OnEnable()
    {
        Menu = GetComponent<UIDocument>(); // Obtener el documento de la interfaz de usuario
        var root = Menu.rootVisualElement;

        // Obtener los botones de la interfaz de usuario
        Play = root.Q<Button>("Play");
        Credits = root.Q<Button>("Credits");
        Help = root.Q<Button>("Ayuda");
        Exit = root.Q<Button>("Exit");
        // Registrar los eventos de los botones
        Exit.RegisterCallback<ClickEvent>(QuitGame);
        Help.RegisterCallback<ClickEvent>(AyudaMenu);
        Play.RegisterCallback<ClickEvent>(PlayGame);
        Credits.RegisterCallback<ClickEvent>(CreditsMenu);
    }

    private void QuitGame(ClickEvent evt)
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode(); // Stops play mode in the Unity Editor
        #else
            Application.Quit(); // Closes the game in a built application
        #endif
    }

    private void AyudaMenu(ClickEvent evt)
    {
        // Regresar a la escena de ayuda
        SceneManager.LoadScene("Ayuda");
    }
    private void PlayGame(ClickEvent evt)
    {
        // Regresar a la escena del juego
        SceneManager.LoadScene("SampleScene");
    }
        private void CreditsMenu(ClickEvent evt)
    {
        // Regresar a la escena de ayuda
        SceneManager.LoadScene("Credits");
    }
}
