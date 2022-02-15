using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public AudioClip scoreSound;

    private void OnTriggerEnter(Collider other)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = scoreSound;
        audioSource.Play();
        gameManager.OnGoalTrigger(this);
    }
}
