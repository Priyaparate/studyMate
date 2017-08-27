using StudyMateLibrary.Enities;
using StudyMateLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudyMateLibrary.Domains
{
    public class QuestionDomain : CommonDomain<Question>, IDisposable
    {
        private IRepository<Question> _questionRepository;

        public QuestionDomain()
        {
            _questionRepository = new Repository<Question>();
        }

        public QuestionDomain(IRepository<Question> userRepository)
        {
            _questionRepository = userRepository;
        }

        public bool AddQuestion(Question question)
        {

           
            _questionRepository.Add(question);

            return true;
        }



        public void Dispose()
        {
            _questionRepository = null;
        }

        //public Question GetQuestion(Expression<Func<Question, bool>> filter)
        //{

        //    return _questionRepository.Get(filter);
        //}

        //public IEnumerable<Question> List(Func<Question, bool> filter)
        //{
        //    return _questionRepository.List(filter);


        //}

        //public bool UpdateQuestion(Expression<Func<Question, bool>> filter, Question question)
        //{

        //    return _questionRepository.UpdateOne(filter, question);

        //}

        //public bool Delete(Expression<Func<Question, bool>> filter)
        //{
        //    return _questionRepository.Delete(filter);

        //}

    }
}
