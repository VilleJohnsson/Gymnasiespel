using UnityEngine;

public class FitPanelToCamera : MonoBehaviour
{
    public RectTransform panelRectTransform;
    public Camera mainCamera;

    void Start()
    {
        if (panelRectTransform == null)
        {
            Debug.LogError("Panel RectTransform not assigned!");
            return;
        }

        if (mainCamera == null)
        {
            mainCamera = Camera.main;
            if (mainCamera == null)
            {
                Debug.LogError("Main camera not found!");
                return;
            }
        }

        FitPanel();
    }

    void FitPanel()
    {
        Vector2 panelSize = panelRectTransform.sizeDelta;

        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        float scaleFactorX = cameraWidth / 100f; // Assuming Canvas width is 100 units
        float scaleFactorY = cameraHeight / 100f; // Assuming Canvas height is 100 units

        // Apply the scale factor to the panel
        panelRectTransform.localScale = new Vector3(scaleFactorX, scaleFactorY, 1f);
    }
}
