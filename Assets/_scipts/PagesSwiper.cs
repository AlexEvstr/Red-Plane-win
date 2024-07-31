using UnityEngine;

public class PagesSwiper : MonoBehaviour
{
    public GameObject[] pages;
    public RectTransform swipeDetectionArea;
    public float minimumSwipeDistance = 50f;

    private int currentPageIndex = 0;
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private bool isSwiping;

    void Start()
    {
        UpdateActivePage();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Vector2 localPoint;
                if (RectTransformUtility.ScreenPointToLocalPointInRectangle(swipeDetectionArea, touch.position, Camera.main, out localPoint))
                {
                    if (swipeDetectionArea.rect.Contains(localPoint))
                    {
                        isSwiping = true;
                        startTouchPosition = touch.position;
                    }
                }
            }
            else if (touch.phase == TouchPhase.Ended && isSwiping)
            {
                endTouchPosition = touch.position;
                isSwiping = false;
                DetectSwipe();
            }
        }
    }

    void DetectSwipe()
    {
        if (Vector2.Distance(startTouchPosition, endTouchPosition) >= minimumSwipeDistance)
        {
            Vector2 direction = endTouchPosition - startTouchPosition;
            Vector2 swipeDirection = direction.normalized;

            if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
            {
                if (swipeDirection.x > 0)
                {
                    OnSwipeLeft();
                }
                else
                {
                    OnSwipeRight();
                }
            }
        }
    }

    void OnSwipeRight()
    {
        currentPageIndex = (currentPageIndex + 1) % pages.Length;
        UpdateActivePage();
    }

    void OnSwipeLeft()
    {
        currentPageIndex = (currentPageIndex - 1 + pages.Length) % pages.Length;
        UpdateActivePage();
    }

    void UpdateActivePage()
    {
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(i == currentPageIndex);
        }
    }
}