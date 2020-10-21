using QuizCreator.Models;
using System.Collections.Generic;
namespace QuizeCreator.ViewModels
{
    public class EditQuestioViewModel
    {
        public List<PartieModule> partieModule = new List<PartieModule>();
        public List<int> level = new List<int>
        {
            1, 2, 3
        };
        public List<string> Accessibilite = new List<string> { "Accessible", "Not accessible" };
        public List<bool> Etat = new List<bool> { true, false };
        public Question question = new Question();
    }
}