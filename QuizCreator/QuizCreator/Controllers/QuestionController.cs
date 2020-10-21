using QuizCreator.Models;
using QuizeCreator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace QuizCreator.Controllers
{
    public class QuestionController : Controller
    {
        private QuizDB db = new QuizDB();

        // GET: Question
        [Authorize]
        public ActionResult Index()
        {
            int user__id = Convert.ToInt32(Session["user__id"]);
            var questions = db.Questions.Where(d => d.Account.IdAccount == user__id);
            return View(questions.ToList());
        }

        // GET: Question/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Question/Create
        [Authorize]
        public ActionResult Create(int Difficulty, int PartieModule, int QuestionType)
        {
            return View();
        }

        // POST: Question/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(int Difficulty, int PartieModule, int QuestionType, string Etat, string Accessible, string Question, string Reponse)
        {
            if (ModelState.IsValid)
            {
                Question qst = new Question();
                qst.IdAccount = Convert.ToInt32(Session["user__id"]);
                qst.Accessibilite = bool.Parse(Accessible);
                qst.IdTypeQuestion = QuestionType;
                qst.Niveau = Difficulty;
                int reponseLength = Reponse.Split(';').Length;
                if (reponseLength > 1)
                {
                    qst.QuestionReponse = Reponse.Trim();
                }
                else
                {
                    qst.QuestionReponse = Reponse.Trim() + ";";
                }
                qst.QuestionContenu = Question;
                qst.Etat = bool.Parse(Etat);
                qst.IdPartieModule = PartieModule;
                db.Questions.Add(qst);
                db.SaveChanges();
                //return Content("" + qst.IdTypeQuestion);
                if (qst.IdTypeQuestion.Value == 3)
                {
                    return RedirectToAction("Choice", "Choices", new { idQuestion = qst.IdQuestion });
                }
                else if (qst.IdTypeQuestion.Value == 2)
                {
                    return RedirectToAction("Choices", "Choices", new { idQuestion = qst.IdQuestion, reponseLength = (reponseLength - 1) });
                }
                else
                {
                    return RedirectToAction("Fill_In", "Choice", new { idQuestion = qst.IdQuestion });
                }
            }
            return View();
        }

        // GET: Question/Edit/5
        public ActionResult Edit(int idQuestion)
        {
            Question qst = db.Questions.Find(idQuestion);
            List<PartieModule> partieModule = db.PartieModules.Where(r => r.Module.IdModule == qst.PartieModule.IdModule).ToList();
            EditQuestioViewModel editForm = new EditQuestioViewModel
            {
                partieModule = partieModule,
                question = qst
            };
            return View(editForm);
        }

        // POST: Question/Edit/5
        [HttpPost]
        public ActionResult Edit(int idQuestion, Question question)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    var dbQuestion = db;
                    return RedirectToAction("Index");
                }
                else
                {
                    EditQuestioViewModel editForm = new EditQuestioViewModel
                    {
                        partieModule = db.PartieModules.ToList(),
                        question = question
                    };
                    return View(editForm);
                }
            }
            catch
            {
                EditQuestioViewModel editForm = new EditQuestioViewModel
                {
                    partieModule = db.PartieModules.ToList(),
                    question = question
                };
                return View(editForm);
            }
        }

        // GET: Question/Delete/5
        [Authorize]
        public ActionResult Delete(int idQuestion)
        {
            Question qst = db.Questions.Find(idQuestion);
            db.Questions.Remove(qst);
            db.SaveChanges();
            return RedirectToAction("index");
        }

        // POST: Question/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        [Authorize]
        public ActionResult Pick(int? Module)
        {
            ViewBag.PartieModule = new SelectList(db.PartieModules, "IdPartieModule", "Name");
            if (Module.HasValue)
            {
                var list = db.PartieModules.Where(w => w.IdModule == Module);
                ViewBag.PartieModule = new SelectList(list, "IdPartieModule", "Name");
            }
            ViewBag.Module = new SelectList(db.Modules, "IdModule", "Name", "Choose a Module");
            ViewBag.QuestionType = new SelectList(db.TypeQuestions, "IdTypeQuestion", "Type", "Choose Question Type");
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult Pick(int Difficulty, int PartieModule, int QuestionType)
        {
            return RedirectToAction("Create", new { Difficulty = Difficulty, PartieModule = PartieModule, QuestionType = QuestionType });
        }
    }
}
