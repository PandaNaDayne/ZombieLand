using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelAnim : MonoBehaviour
{
    private RectTransform panel;
    private float animationDuration = 0.15f;
    private Vector2 startPosition;

    private Vector2 targetPosition;
    private float currentTime = 0f;
    private bool isAnimating = false;

    private void Start()
    {
        startPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 500);
        panel = gameObject.GetComponent<RectTransform>();
        targetPosition = panel.anchoredPosition;
    }

    private void Update()
    {
        if (isAnimating)
        {
            currentTime += Time.deltaTime;
            float t = Mathf.Clamp01(currentTime / animationDuration);

            // »нтерпол€ци€ между начальной и целевой позицией
            Vector2 newPosition = Vector2.Lerp(startPosition, targetPosition, t);
            panel.anchoredPosition = newPosition;

            if (t >= 1f)
            {
                isAnimating = false;
            }
        }
    }

    public void StartAnimation()
    {
        currentTime = 0f;
        isAnimating = true;
    }



    private void OnEnable()
    {
        StartAnimation();
    }
}
