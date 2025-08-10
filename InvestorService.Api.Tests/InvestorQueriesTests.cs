using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using FluentValidation;
using FluentValidation.Results;
using InvestorService.Api.Controllers.Queries;
using InvestorService.Business.BusinessModels.RequestDtos;
using InvestorService.Business.BusinessModels.ResponseDtos;
using InvestorService.Business.Handlers.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
using Moq;
using System.Text.Json;

namespace InvestorService.Api.Tests
{
    public class InvestorQueriesTests
    {
        private readonly IFixture _fixture;

        public InvestorQueriesTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
        }

        [Theory, AutoData]
        public async Task GetAllInvestorDetails_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var requestDto = _fixture.Create<GetAllInvestorDetailRequestDto>();
            var responseDto = _fixture.Create<GetAllInvestorDetailResponseDto>();

            var validatorMock = new Mock<IValidator<GetAllInvestorDetailRequestDto>>();
            validatorMock
                .Setup(v => v.ValidateAsync(requestDto, default))
                .ReturnsAsync(new ValidationResult());

            var handlerMock = new Mock<IGetAllQueryHandler<GetAllInvestorDetailRequestDto, Task<GetAllInvestorDetailResponseDto>>>();
            handlerMock
                .Setup(h => h.ExecuteQuery(requestDto))
                .ReturnsAsync(responseDto);

            var loggerMock = new Mock<ILogger<InvestorQueries>>();

            var controller = new InvestorQueries(
                loggerMock.Object,
                handlerMock.Object,
                validatorMock.Object,
                Mock.Of<IGetAllQueryHandler<GetInvestorsCommitmentRequestDto, Task<GetInvestorsCommitmentResponseDto>>>(),
                Mock.Of<IValidator<GetInvestorsCommitmentRequestDto>>());

            // Act
            var response = await controller.GetAllInvestorDetails(requestDto);
            var statusCode = ((Ok<GetAllInvestorDetailResponseDto>)response.Result).StatusCode;
            var result = ((Ok<GetAllInvestorDetailResponseDto>)response.Result).Value;

            validatorMock.Verify(v => v.ValidateAsync(requestDto, default), Times.Once);
            handlerMock.Verify(h => h.ExecuteQuery(requestDto), Times.Once);

            Assert.True(statusCode == StatusCodes.Status200OK);
            Assert.NotNull(result);
            Assert.Equal(JsonSerializer.Serialize(responseDto), JsonSerializer.Serialize(result));
        }

        [Theory, AutoData]
        public async Task GetAllInvestorDetails_InvalidRequest_ThrowsValidationException()
        {
            // Arrange
            var requestDto = _fixture.Create<GetAllInvestorDetailRequestDto>();

            var failures = new[]
            {
            new ValidationFailure("Property", "ErrorMessage")
        };
            var validationResult = new ValidationResult(failures);

            var validatorMock = new Mock<IValidator<GetAllInvestorDetailRequestDto>>();
            validatorMock
                .Setup(v => v.ValidateAsync(requestDto, default))
                .ReturnsAsync(validationResult);

            var loggerMock = new Mock<ILogger<InvestorQueries>>();

            var controller = new InvestorQueries(
                loggerMock.Object,
                Mock.Of<IGetAllQueryHandler<GetAllInvestorDetailRequestDto, Task<GetAllInvestorDetailResponseDto>>>(),
                validatorMock.Object,
                Mock.Of<IGetAllQueryHandler<GetInvestorsCommitmentRequestDto, Task<GetInvestorsCommitmentResponseDto>>>(),
                Mock.Of<IValidator<GetInvestorsCommitmentRequestDto>>());

            // Act & Assert
            await Assert.ThrowsAsync<ValidationException>(() => controller.GetAllInvestorDetails(requestDto));

            validatorMock.Verify(v => v.ValidateAsync(requestDto, default), Times.Once);
        }


        [Theory, AutoData]
        public async Task GetInvestorsCommitments_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var requestDto = _fixture.Create<GetInvestorsCommitmentRequestDto>();
            var responseDto = _fixture.Create<GetInvestorsCommitmentResponseDto>();

            var validatorMock = new Mock<IValidator<GetInvestorsCommitmentRequestDto>>();
            validatorMock
                .Setup(v => v.ValidateAsync(requestDto, default))
                .ReturnsAsync(new ValidationResult());

            var handlerMock = new Mock<IGetAllQueryHandler<GetInvestorsCommitmentRequestDto, Task<GetInvestorsCommitmentResponseDto>>>();
            handlerMock
                .Setup(h => h.ExecuteQuery(requestDto))
                .ReturnsAsync(responseDto);

            var loggerMock = new Mock<ILogger<InvestorQueries>>();

            var controller = new InvestorQueries(
                loggerMock.Object,
                Mock.Of<IGetAllQueryHandler<GetAllInvestorDetailRequestDto, Task<GetAllInvestorDetailResponseDto>>>(),
                Mock.Of<IValidator<GetAllInvestorDetailRequestDto>>(),
                handlerMock.Object,
                validatorMock.Object);

            // Act
            var response = await controller.GetInvestorsCommitments(requestDto);
            var statusCode = ((Ok<GetInvestorsCommitmentResponseDto>)response.Result).StatusCode;
            var result = ((Ok<GetInvestorsCommitmentResponseDto>)response.Result).Value;

            validatorMock.Verify(v => v.ValidateAsync(requestDto, default), Times.Once);
            handlerMock.Verify(h => h.ExecuteQuery(requestDto), Times.Once);

            Assert.True(statusCode == StatusCodes.Status200OK);
            Assert.NotNull(result);
            Assert.Equal(JsonSerializer.Serialize(responseDto), JsonSerializer.Serialize(result));
        }

        [Theory, AutoData]
        public async Task GetInvestorsCommitments_InvalidRequest_ThrowsValidationException()
        {
            // Arrange
            var requestDto = _fixture.Create<GetInvestorsCommitmentRequestDto>();

            var failures = new[]
            {
            new ValidationFailure("Property", "ErrorMessage")
        };
            var validationResult = new ValidationResult(failures);

            var validatorMock = new Mock<IValidator<GetInvestorsCommitmentRequestDto>>();
            validatorMock
                .Setup(v => v.ValidateAsync(requestDto, default))
                .ReturnsAsync(validationResult);

            var loggerMock = new Mock<ILogger<InvestorQueries>>();

            var controller = new InvestorQueries(
                loggerMock.Object,
                Mock.Of<IGetAllQueryHandler<GetAllInvestorDetailRequestDto, Task<GetAllInvestorDetailResponseDto>>>(),
                Mock.Of<IValidator<GetAllInvestorDetailRequestDto>>(),
                Mock.Of<IGetAllQueryHandler<GetInvestorsCommitmentRequestDto, Task<GetInvestorsCommitmentResponseDto>>>(),
                validatorMock.Object);

            // Act & Assert
            await Assert.ThrowsAsync<ValidationException>(() => controller.GetInvestorsCommitments(requestDto));

            validatorMock.Verify(v => v.ValidateAsync(requestDto, default), Times.Once);
        }
    }

}
