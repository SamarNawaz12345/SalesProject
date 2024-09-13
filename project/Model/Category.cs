using System.ComponentModel.DataAnnotations;

namespace project.Model
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Category Name is required.")]
        public string CategoryName { get; set; }
        [StringLength(200, ErrorMessage = "Description can't be longer than 200 characters.")]
        public string Description { get; set; }
    }
}
