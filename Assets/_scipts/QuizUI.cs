using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizUI : MonoBehaviour
{
    public GameObject questionPanel;
    public TMP_Text questionText;
    public Button trueButton;
    public Button falseButton;
    private LocalizedText localizedText;

    private bool isAnswered = false;
    private bool userAnswer;

    public bool IsAnswered { get { return isAnswered; } }
    public bool UserAnswer { get { return userAnswer; } }

    private void Start()
    {
        trueButton.onClick.AddListener(() => OnAnswer(true));
        falseButton.onClick.AddListener(() => OnAnswer(false));

        if (questionText == null)
        {
            return;
        }

        localizedText = questionText.GetComponent<LocalizedText>();

        if (localizedText == null)
        {
        }

        HideQuestion();
    }

    public void DisplayQuestion(QuestionDatabase.Question question)
    {
        if (localizedText != null)
        {
            localizedText.SetKey(question.key);
            questionPanel.SetActive(true);
            isAnswered = false;
        }
    }

    public void HideQuestion()
    {
        questionPanel.SetActive(false);
    }

    private void OnAnswer(bool answer)
    {
        userAnswer = answer;
        isAnswered = true;
    }
}