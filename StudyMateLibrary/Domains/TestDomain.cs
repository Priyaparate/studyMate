using StudyMateLibrary.Enities;
using StudyMateLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StudyMateLibrary.Domains
{
    //public class TestDomain<Test> :CommonDomain<Test>
    //{
    //    private IRepository<Question> _questionRepository;
    //    private IRepository<Test> _testRepository;
    //    public TestDomain()
    //    {
    //        _testRepository = new Repository<Test>();
    //        _questionRepository = new Repository<Question>();
    //    }

    //    public TestDomain(IRepository<Test> userRepository)
    //    {
    //        _testRepository = userRepository;
    //    }

    //    //public bool AddQuestion(Test test)
    //    //{
    //    //    // need to change logic for outincreament id generator
    //    //    test.TestId = _testRepository.Count() + 1;

    //    //    _testRepository.Add(test);

    //    //    return true;
    //    //}

    //    //public bool Delete(int id)
    //    //{
    //    //    _questionRepository.Delete(t => t.TestId == id);
    //    //    return _testRepository.Delete(t => t.TestId == id);
    //    //}

    //    //public void Dispose()
    //    //{
    //    //    _testRepository = null;
    //    //}

    //    //public Test GetQuestion(Expression<Func<Test, bool>> filter)
    //    //{
    //    //    return _testRepository.Get(filter);
    //    //}

    //    //public IEnumerable<Test> List(Func<Test, bool> filter = null)
    //    //{
    //    //    if (filter == null)
    //    //    {
    //    //        return _testRepository.List();
    //    //    }
    //    //    else
    //    //    {
    //    //        return _testRepository.List(filter);
    //    //    }
    //    //}

    //    //public bool UpdateQuestion(Expression<Func<Test, bool>> filter, Test test)
    //    //{
    //    //    return _testRepository.UpdateOne(filter, test);
    //    //}
    //}
}