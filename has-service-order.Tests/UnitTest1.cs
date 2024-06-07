
using OsDsII.api.Controllers;

namespace has_service_order.Tests;

public class UnitTest1
{
    [Fact]
    public void Teste1()
    {
        CommentController commentController = new CommentController();
        string aaaaa = "tentativa";


        string comentario = commentController.GetCommentsAsync(aaaaa);

        Assert.Equal(aaaaa, comentario);

    }
}