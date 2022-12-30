function SearchData(path) {
    var content = $("input[name='q']").val();
    $.ajax({
        url: path,
        type: 'post',
        data: {
            content: content
        },
        error: function (xhr) {

        },
        success: function (response) {
            $("#ArticleContent").html(response);
        }
    });
}