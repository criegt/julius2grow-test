namespace Julius2GrowTest.Application.UseCases.Posts.AddPost
{
    public class AddPostPresenter : IOutputPort
    {
        public bool OkOutput { get; private set; }
        public bool ErrorOutput { get; private set; }

        public void Ok() => OkOutput = true;
        public void Error() => ErrorOutput = true;
    }
}
