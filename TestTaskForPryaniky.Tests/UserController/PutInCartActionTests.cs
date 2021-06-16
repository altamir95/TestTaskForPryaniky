using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestTaskForPryaniky.ViewModels;
using Xunit;

namespace TestTaskForPryaniky.Tests.UserController
{
    public class PutInCartActionTests
    {
        [Fact]
        public void NullInParameter()
        {
            // Arrange
            Controllers.UserController controller = new Controllers.UserController();

            // act
            var result = controller.PutInCart(null);
            var badResult = result as BadRequestObjectResult;

            // assert
            Assert.NotNull(badResult);
            Assert.Equal(StatusCodes.Status400BadRequest, badResult.StatusCode);
        }

        [Fact]
        public void CorrectParametr()
        {
            // Arrange
            Controllers.UserController controller = new Controllers.UserController();

            // act
            var result = controller.PutInCart(new PutInCartViewModel() { ProductId = 1 });
            var okResult = result as OkObjectResult;

            // assert
            Assert.NotNull(okResult);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        [Fact]
        public void ProductIdInParametrIsLessOne()
        {
            // Arrange
            Controllers.UserController controller = new Controllers.UserController();

            // act
            var result = controller.PutInCart(new PutInCartViewModel() { ProductId = -3 });
            var badResult = result as BadRequestObjectResult;

            // assert
            Assert.NotNull(badResult);
            Assert.Equal(StatusCodes.Status400BadRequest, badResult.StatusCode);
        }
        [Fact]
        public void InParameterUnexistentProduct()
        {
            // Arrange
            Controllers.UserController controller = new Controllers.UserController();

            // act
            var result = controller.PutInCart(new PutInCartViewModel() { ProductId = 100 });
            var badResult = result as BadRequestObjectResult;

            // assert
            Assert.NotNull(badResult);
            Assert.Equal(StatusCodes.Status400BadRequest, badResult.StatusCode); 
        } 
    }
}
