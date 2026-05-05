using UnityEngine;
using UnityEngine.UI;

public sealed class TransitionHelper : MonoBehaviour
{
    [SerializeField] private Image image;

    protected void MakeVisible()
    {
        Debug.Log(nameof(MakeVisible), this);
        image.enabled = true;
    }

    protected void MakeInvisible()
    {
        Debug.Log(nameof(MakeInvisible), this);
        image.color = Color.magenta;
        image.enabled = false;
    }
}
