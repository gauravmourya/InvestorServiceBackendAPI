using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using InvestorService.Business.BusinessModels.RequestDtos;
using InvestorService.Business.BusinessModels.ResponseDtos;
using InvestorService.Business.Handlers.QueryHandlers.InvestorQueries;
using InvestorService.Repository.DatabaseOperations.Interface;
using RepoModel = InvestorService.Repository.Models;
using Microsoft.Extensions.Logging;
using Moq;

namespace InvestorService.Business.Tests
{
    public class GetAllInvestorDetailQueryHandlerTests
    {
        private readonly IFixture _fixture;
        private readonly Mock<IInvestorRepository> _investorRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ILogger<GetAllInvestorDetailQueryHandler>> _loggerMock;
        private readonly GetAllInvestorDetailQueryHandler _handler;

        public GetAllInvestorDetailQueryHandlerTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());

            _investorRepositoryMock = _fixture.Freeze<Mock<IInvestorRepository>>();
            _mapperMock = _fixture.Freeze<Mock<IMapper>>();
            _loggerMock = _fixture.Freeze<Mock<ILogger<GetAllInvestorDetailQueryHandler>>>();

            _handler = new GetAllInvestorDetailQueryHandler(
                _loggerMock.Object,
                _investorRepositoryMock.Object,
                _mapperMock.Object);
        }

        [Fact]
        public async Task ExecuteQuery_CallsRepositoryWithCorrectParams_AndReturnsMappedResponse()
        {
            // Arrange
            var request = _fixture.Create<GetAllInvestorDetailRequestDto>();

            var repoPagedResult = new RepoModel.PagedResult<RepoModel.InvestorDetails>
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalCount = 100,
                Items = _fixture.Create<List<RepoModel.InvestorDetails>>()
            };

            var mappedInvestorDetails = _fixture.Create<List<InvestorDetails>>();

            _investorRepositoryMock
                .Setup(r => r.GetInvestorDetailsAsync(request.PageNumber, request.PageSize))
                .ReturnsAsync(repoPagedResult);

            _mapperMock
                .Setup(m => m.Map<List<InvestorDetails>>(repoPagedResult.Items))
                .Returns(mappedInvestorDetails);

            // Act
            var result = await _handler.ExecuteQuery(request);

            // Assert
            _investorRepositoryMock.Verify(r => r.GetInvestorDetailsAsync(request.PageNumber, request.PageSize), Times.Once);
            _mapperMock.Verify(m => m.Map<List<InvestorDetails>>(repoPagedResult.Items), Times.Once);

            Assert.NotNull(result);
            Assert.Equal(repoPagedResult.PageNumber, result.PageNumber);
            Assert.Equal(repoPagedResult.PageSize, result.PageSize);
            Assert.Equal(repoPagedResult.TotalCount, result.TotalCount);
            Assert.Equal(repoPagedResult.TotalPages, result.TotalPages);
            Assert.Same(mappedInvestorDetails, result.InvestorDetails);
        }
    }
}
