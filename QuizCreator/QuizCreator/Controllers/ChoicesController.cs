using QuizCreator.Models;
using System.Web.Mvc;

namespace QuizCreator.Controllers
{
    public class ChoicesController : Controller
    {
        private QuizDB db = new QuizDB();
        // GET: Choices
        public ActionResult Choice(int idQuestion)
        {
            var Question = db.Questions.Find(idQuestion);
            ViewBag.Question = Question.QuestionContenu + " ?";
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult Choice(int idQuestion, string[] wrong_answers)
        {
            if (ModelState.IsValid)
            {
                foreach (string answer in wrong_answers)
                {
                    ChoixReponse wrong_answer = new Models.ChoixReponse();
                    wrong_answer.IdQuestion = idQuestion;
                    wrong_answer.Contenu = answer;
                    db.ChoixReponses.Add(wrong_answer);
                    db.SaveChanges();
                }
                return RedirectToAction("Pick", "Question", null);
            }
            return View();
        }
        public ActionResult Choices(int idQuestion, int reponseLength)
        {
            ViewBag.Question = db.Questions.Find(idQuestion).QuestionContenu;
            return View();
        }
        [HttpPost]
        public ActionResult Choices(int idQuestion, string[] wrong_answers)
        {
            if (ModelState.IsValid)
            {
                foreach (string answer in wrong_answers)
                {
                    ChoixReponse wrong_answer = new Models.ChoixReponse();
                    wrong_answer.IdQuestion = idQuestion;
                    wrong_answer.Contenu = answer;
                    db.ChoixReponses.Add(wrong_answer);
                    db.SaveChanges();
                }
                return RedirectToAction("Pick", "Question", null);
            }
            return View();
        }
    }
}