using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip pressSound;

    public void LoadLivingRoomScene()
    {
        StartCoroutine(PlaySoundAndLoad());
    }

    private System.Collections.IEnumerator PlaySoundAndLoad()
    {
        if (audioSource && pressSound)
        {
            audioSource.PlayOneShot(pressSound);
            yield return new WaitForSeconds(pressSound.length);
        }
        SceneManager.LoadScene("username");
    }
}