using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class SmoothSnapScroll : MonoBehaviour, IEndDragHandler
{
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private RectTransform contentPanel;
    [SerializeField] private float snapSpeed = 5f;
    [SerializeField] private float snapThreshold = 0.1f;

    private List<float> itemPositions;
    private bool isSnapping = false;

    void Start()
    {
        InitializeItemPositions();
    }

    void Update()
    {
        if (isSnapping)
        {
            SnapToNearestItem();
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isSnapping = true;
    }

    private void InitializeItemPositions()
    {
        itemPositions = new List<float>();
        for (int i = 0; i < contentPanel.childCount; i++)
        {
            float position = (float)i / (contentPanel.childCount - 1);
            itemPositions.Add(position);
        }
    }

    private void SnapToNearestItem()
    {
        float nearestPosition = FindNearestItem();
        float targetX = -nearestPosition * (contentPanel.rect.width - scrollRect.viewport.rect.width);
        float newX = Mathf.Lerp(contentPanel.anchoredPosition.x, targetX, Time.deltaTime * snapSpeed);
        contentPanel.anchoredPosition = new Vector2(newX, contentPanel.anchoredPosition.y);

        if (Mathf.Abs(newX - targetX) < snapThreshold)
        {
            isSnapping = false;
            contentPanel.anchoredPosition = new Vector2(targetX, contentPanel.anchoredPosition.y);
        }
    }

    private float FindNearestItem()
    {
        float minDistance = float.MaxValue;
        float nearestPosition = 0;

        foreach (float position in itemPositions)
        {
            float targetX = -position * (contentPanel.rect.width - scrollRect.viewport.rect.width);
            float distance = Mathf.Abs(contentPanel.anchoredPosition.x - targetX);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestPosition = position;
            }
        }

        return nearestPosition;
    }
}