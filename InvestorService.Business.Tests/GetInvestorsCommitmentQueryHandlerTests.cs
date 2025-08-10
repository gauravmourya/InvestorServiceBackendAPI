using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using InvestorService.Business.BusinessModels.RequestDtos;
using InvestorService.Business.BusinessModels.ResponseDtos;
using InvestorService.Business.Handlers.QueryHandlers.InvestorQueries;
using InvestorService.Repository.DatabaseOperations.Interface;
using InvestorService.Repository.Models;
using Microsoft.Extensions.Logging;
using Moq;

namespace InvestorService.Business.Tests
{
    public class GetInvestorsCommitmentQueryHandlerTests
    {
        private readonly IFixture _fixture;
        private readonly Mock<IInvestorRepository> _investorRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ILogger<GetInvestorsCommitmentQueryHandler>> _loggerMock;
        private readonly GetInvestorsCommitmentQueryHandler _handler;

        public GetInvestorsCommitmentQueryHandlerTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());

            _investorRepositoryMock = _fixture.Freeze<Mock<IInvestorRepository>>();
            _mapperMock = _fixture.Freeze<Mock<IMapper>>();
            _loggerMock = _fixture.Freeze<Mock<ILogger<GetInvestorsCommitmentQueryHandler>>>();

            _handler = new GetInvestorsCommitmentQueryHandler(
                _loggerMock.Object,
                _mapperMock.Object,
                _investorRepositoryMock.Object);
        }

        [Fact]
        public async Task ExecuteQuery_CallsRepositoryWithCorrectParameters_AndReturnsMappedResponse()
        {
            // Arrange
            var request = _fixture.Create<GetInvestorsCommitmentRequestDto>();

            var dbModel = _fixture.Build<InvestorCommitmentModel>()
                .Create();

            var groupedAssetClassResponseList = _fixture.Create<List<GroupedAssetClassResponse>>();
            var commitmentsResponseList = _fixture.Create<List<GetInvestorsCommitmentResponse>>();

            _investorRepositoryMock
                .Setup(r => r.GetInvestorsCommitment(request.InvestorId, request.AssetClass, request.PageNumber, request.PageSize))
                .ReturnsAsync(dbModel);

            _mapperMock
                .Setup(m => m.Map<List<GroupedAssetClassResponse>>(dbModel.AssetClasses))
                .Returns(groupedAssetClassResponseList);

            _mapperMock
                .Setup(m => m.Map<List<GetInvestorsCommitmentResponse>>(dbModel.Commitments.Items))
                .Returns(commitmentsResponseList);

            // Act
            var result = await _handler.ExecuteQuery(request);

            // Assert
            _investorRepositoryMock.Verify(r => r.GetInvestorsCommitment(request.InvestorId, request.AssetClass, request.PageNumber, request.PageSize), Times.Once);

            _mapperMock.Verify(m => m.Map<List<GroupedAssetClassResponse>>(dbModel.AssetClasses), Times.Once);
            _mapperMock.Verify(m => m.Map<List<GetInvestorsCommitmentResponse>>(dbModel.Commitments.Items), Times.Once);

            Assert.Equal(dbModel.Commitments.PageNumber, result.PageNumber);
            Assert.Equal(dbModel.Commitments.PageSize, result.PageSize);
            Assert.Equal(dbModel.Commitments.TotalCount, result.TotalCount);
            Assert.Equal(dbModel.Commitments.TotalPages, result.TotalPages);
            Assert.Same(groupedAssetClassResponseList, result.GroupedAssetClassDetails);
            Assert.Same(commitmentsResponseList, result.Commitments);
        }
    }
}
