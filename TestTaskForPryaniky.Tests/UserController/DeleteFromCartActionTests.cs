using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace TestTaskForPryaniky.Tests.UserController
{
    public class DeleteFromCartActionTests
    {
        [Fact]
        public void NullInParameter()
        {
            // Arrange
            Controllers.UserController controller = new Controllers.UserController();

            // act
            var result = controller.DeleteFromCart(0);
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
            var result = controller.DeleteFromCart(1);
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
            var result = controller.DeleteFromCart(-3);
            var badResult = result as BadRequestObjectResult;

            // assert
            Assert.NotNull(badResult);
            Assert.Equal(StatusCodes.Status400BadRequest, badResult.StatusCode);
        } 
    }
}
