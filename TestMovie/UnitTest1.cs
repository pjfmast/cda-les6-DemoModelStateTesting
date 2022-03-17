using DemoModelStateTesting.Controllers;
using DemoModelStateTesting.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace TestMovie {
    public class UnitTest1 {

        /*
         * MovieTitleCannotBeBlank tests validation of the model class
         */
        [Fact]
        public void MovieTitleCannotBeBlank() {

            // Arrange
            var validationResults = new List<ValidationResult>();
            var sut = new AddMovieVM() {
                Title = "",
                Description = "new release",
                RuntimeMinutes = 99
            };
            var ctx = new ValidationContext(sut, null, null);

            // Act
            Validator.TryValidateObject(sut, ctx, validationResults, true);

            // Assert
            Assert.Single(validationResults);
            Assert.Contains(validationResults,
                validationResult => validationResult.ErrorMessage.Contains("The Title cannot be blank."));

        }

        /*
         * MovieTitleAndDescriptionNotEqual tests the ModelState.AddModelError() calls in the controller
         */

        [Fact]
        public void MovieTitleAndDescriptionNotEqual() {

            // Arrange
            var sut = new MovieController();

            var movieVM = new AddMovieVM() {
                Title = "",
                Description = "",
                RuntimeMinutes = 99
            };

            // Act
            var result = sut.AddPost(movieVM);
            var viewResult = result as ViewResult;


            // Assert
            Assert.False(viewResult?.ViewData.ModelState.IsValid);

            string key = nameof(movieVM.Description);
            Assert.True(viewResult?.ViewData.ModelState.ContainsKey(key));
            Assert.Equal("The Description cannot exactly match the Title.",
                viewResult?.ViewData?.ModelState[key]?.Errors.First().ErrorMessage);
        }
    }
}