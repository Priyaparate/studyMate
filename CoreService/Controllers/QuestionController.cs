using StudyMateLibrary.Domains;
using StudyMateLibrary.Enities;
using System.Collections.Generic;

namespace CoreService.Controllers
{
    public class QuestionController : BaseController<Question>
    {
        private QuestionDomain _questionDomain;

        public QuestionController()
        {
            _questionDomain = new QuestionDomain();
        }

        public IEnumerable<Question> ListQestionByTestId(int id)
        {
            return _questionDomain.List(Question => Question.TestId == id);
        }
    }
}