namespace PracaDyplomowaBackend.Models.Models.Common.Book
{
    public class AddBookReviewModel : ModelBase
    {
        public string UserEmailAddress { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BookId { get; set; }
    }
}
