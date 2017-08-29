namespace StudyMateLibrary.Domains
{
    //public class CategoryDomain
    //{
    //    private IRepository<Test> _testRepository;
    //    private IRepository<TestCategory> _testCategoryRepository;

    //    public CategoryDomain()
    //    {
    //        _testRepository = new Repository<Test>();
    //        _testCategoryRepository = new Repository<TestCategory>();
    //    }

    //    public CategoryDomain(IRepository<Test> testCaegoty, IRepository<TestCategory> testCategoryRepository)
    //    {
    //        _testRepository = testCaegoty;
    //        _testCategoryRepository = testCategoryRepository;
    //    }

    //    public bool Add(TestCategory test)
    //    {
    //        test.CategoryId = _testRepository.Count() + 1;

    //        _testCategoryRepository.Add(test);

    //        return true;
    //    }

    //    public void Dispose()
    //    {
    //        _testRepository = null;
    //    }

    //    public TestCategory Get(Expression<Func<TestCategory, bool>> filter)
    //    {
    //        return _testCategoryRepository.Get(filter);
    //    }

    //    public IEnumerable<TestCategory> List(Func<TestCategory, bool> filter)
    //    {
    //        if (filter == null)
    //        {
    //            return _testCategoryRepository.List();
    //        }
    //        else
    //        {
    //            return _testCategoryRepository.List(filter);
    //        }
    //    }

    //    public bool Update(Expression<Func<TestCategory, bool>> filter, TestCategory test)
    //    {
    //        return _testCategoryRepository.UpdateOne(filter, test);
    //    }

    //    public bool Delete(int id)
    //    {
    //        validateExistigTest(id);

    //        return _testRepository.Delete(t => t.TestId == id);
    //    }

    //    private void validateExistigTest(int id)
    //    {
    //        var tests = _testRepository.List(x => x.TestId == id).Select(y => y.TestName);

    //        var testCount = tests.Count();
    //        if (testCount > 0)
    //        {
    //            var testname = string.Concat(tests, ",");
    //            throw new Exception($"Cannot delete Categoy. following {testname} tests are associated with it.");
    //        }
    //    }
    //}
}