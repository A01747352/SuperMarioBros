// AUTOR DIEGO CARREÓN AGUIRRE
// TUTOR ROBERTO MARTÍNEZ ROMÁN
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class AYuda : MonoBehaviour
{
    private UIDocument Ayuda;
    private Button Ayudin;

    void OnEnable()
    {
        Ayuda = GetComponent<UIDocument>();
        var root = Ayuda.rootVisualElement;
        Ayudin = root.Q<Button>("Exit");

        Ayudin.RegisterCallback<ClickEvent>(Regresar);
    }

    private void Regresar(ClickEvent evt)
    {
        // Regresar a la escena anterior
        SceneManager.LoadScene("Menu");
    }
}

