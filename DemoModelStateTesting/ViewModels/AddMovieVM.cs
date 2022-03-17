using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DemoModelStateTesting.ViewModels {
    public class AddMovieVM {

        [Required(ErrorMessage = "The Title cannot be blank.")]
        [DisplayName("Title: ")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The Description cannot be blank.")]
        [DisplayName("Description: ")]
        public string Description { get; set; }

        [DisplayName("Release Date: ")]
        public DateTime ReleaseDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "The Runtime Minutes cannot be blank.")]
        [Range(1, int.MaxValue,
          ErrorMessage = "The Runtime Minutes must be greater than 0.")]
        [DisplayName("Runtime Minutes: ")]
        public int RuntimeMinutes { get; set; }
    }
}
