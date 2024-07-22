using UnityEngine;

public class BackgroundAnimation : MonoBehaviour
{
    public float minScale = 0.9f; // Scala minima
    public float maxScale = 1.1f; // Scala massima
    public float speed = 1f;      // Velocità dell'animazione

    private RectTransform rectTransform;
    private Vector3 originalScale;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        if (rectTransform == null)
        {
            Debug.LogError("RectTransform non trovato sull'oggetto!");
            return;
        }

        originalScale = rectTransform.localScale;
    }

    private void Update()
    {
        if (rectTransform != null)
        {
            float scale = Mathf.Lerp(minScale, maxScale, Mathf.PingPong(Time.time * speed, 1));
            rectTransform.localScale = originalScale * scale;
        }
    }
}
