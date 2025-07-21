using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public AudioClip hoverSound;
    public AudioClip clickSound;
    public AudioSource audioSource;
    public AudioSource audioSource1;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverSound && audioSource)
            audioSource.PlayOneShot(hoverSound);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (clickSound && audioSource1)
            audioSource1.PlayOneShot(clickSound);
    }
}