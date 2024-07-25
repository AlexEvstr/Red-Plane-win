using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionDatabase", menuName = "Quiz/QuestionDatabase")]
public class QuestionDatabase : ScriptableObject
{
    public Question[] questions;

    [System.Serializable]
    public class Question
    {
        public string key;
        public bool isTrue;
    }
}
