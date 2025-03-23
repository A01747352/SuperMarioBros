// AUTOR DIEGO CARREÓN AGUIRRE
// TUTOR ROBERTO MARTÍNEZ ROMÁN
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class RegresoController : MonoBehaviour
{
    private UIDocument BtnRegreso;
    private Button BtnRegresar;

    void OnEnable()
    {
        BtnRegreso = GetComponent<UIDocument>();
        var root = BtnRegreso.rootVisualElement;
        BtnRegresar = root.Q<Button>("BtnRegresar");

        BtnRegresar.RegisterCallback<ClickEvent>(Regresar);
    }

    private void Regresar(ClickEvent evt)
    {
        // Regresar a la escena anterior
        SceneManager.LoadScene("Menu");
    }
}