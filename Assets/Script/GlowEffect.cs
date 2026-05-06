using UnityEngine;

public class GlowEffect : MonoBehaviour
{
    public float glowDistance = 2f;
    public Color glowColor = new Color(1f, 0.9f, 0f);
    public float glowIntensity = 0.2f;

    private Renderer objectRenderer;
    private Material objectMaterial;
    private Transform playerTransform;
    private bool isGlowing = false;
    private Color originalEmissionColor;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        objectMaterial = objectRenderer.material;
        playerTransform = Camera.main.transform;

        // Store the original emission color
        originalEmissionColor = objectMaterial.GetColor("_EmissionColor");
        objectMaterial.EnableKeyword("_EMISSION");
    }

    void Update()
    {
        float distance = Vector3.Distance(
            transform.position, playerTransform.position);

        if (distance <= glowDistance && !isGlowing)
        {
            StartGlow();
        }
        else if (distance > glowDistance && isGlowing)
        {
            StopGlow();
        }
    }

    void StartGlow()
    {
        isGlowing = true;
        objectMaterial.SetColor("_EmissionColor",
            glowColor * glowIntensity);
    }

    void StopGlow()
    {
        isGlowing = false;
        // Restore original emission color
        objectMaterial.SetColor("_EmissionColor", originalEmissionColor);
    }
}