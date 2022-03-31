using System.Linq.Expressions;
using AutoMapper;
using Data;
using Models.ResponseModels;
using Moq;
using NUnit.Framework;
using Services.Repository;

namespace RepositoryTest;

[TestFixture]
public class RepositoryTests
{
    private class T
    {
        public string TypeName { get; set; }
    }
    private class TDto
    {
        public string TypeName { get; set; }
    }
    private class TCreate
    {
        public string TypeName { get; set; }
    }

    private Mock<IRepository<T, TDto, TCreate>> _Irepository;
    private Mock<ApplicationDbContext> _db;
    private Mock<IMapper> _mapper;
    private Repository<T,TDto,TCreate> _repository;

    private List<T> TList;
    private List<TDto> TdtoList;
    private List<TCreate> tcreateList;
    private Response<TDto> _response;

    [SetUp]
    public void Setup()
    {
        _Irepository = new Mock<IRepository<T, TDto, TCreate>>();
        _db = new Mock<ApplicationDbContext>();
        _mapper = new Mock<IMapper>();
        _repository = new Repository<T, TDto, TCreate>(_db.Object,_mapper.Object);

        TList = new();
        TdtoList = new();
        tcreateList = new();
        _response = new Response<TDto>
        {
            ResponseObject = TdtoList
        };
    }

    [Test]
    public async Task GetAllByAsync_Verify_ReturnType()
    {
        //Arrange
        _Irepository.Setup(method=>method.GetAllByAsync(
            It.IsAny<Expression<Func<T,bool>>>(),
            It.IsAny<CancellationToken>(),
            It.IsAny<Expression<Func<T,object>>[]>()
            )).ReturnsAsync(_response).Verifiable();

        //Act
        var result = _repository.GetAllByAsync(predicate: null, CancellationToken.None, i => i.TypeName);

        //Assert
        Assert.NotNull(result);
        Assert.AreEqual(_response, result);
    }
}


