using StudyMateLibrary.Enities;
using StudyMateLibrary.Repository;
using System;

namespace StudyMateLibrary.Domains
{
    public class QuestionDomain : CommonDomain<Question>
    {
        //add options related logic
        public QuestionDomain()
        {
            _repository = new Repository<Question>();
        }

        public QuestionDomain(IRepository<Question> userRepository)
        {
            _repository = userRepository;
        }

        
      


    }
}