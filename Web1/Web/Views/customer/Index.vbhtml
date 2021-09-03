@*@Code
    Layout = Nothing
    ViewData("Title") = "Home Page"
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title></title>
</head>
<body>
    <div>
        <h2>Index</h2>
        <div>
            @Using (Html.BeginForm())

                @Html.AntiForgeryToken()
                ' テキストボックス等の入力項目の設定

            End Using
        </div>
        <div>


            @Using (Html.BeginForm())

                @Html.AntiForgeryToken()




            End Using
            <input type="submit" name="Search" value="検索"></input>
            <input type="submit" name="Clear" value="クリア"></input>
        </div>

        <form asp-controller="Movies" asp-action="Index" method="get">
            <p>

                <select asp-For="MovieGenre" asp-items="Model.Genres">
                    <option value=""> All</option>
                </select>

                Title: <input type="text" asp-For="SearchString" />
                <input type="submit" value="Filter" />
            </p>
        </form>

        <p>
            @Html.ActionLink("Create New", "Create")
        </p>




        <tr>



            <th>
                @Html.ActionLink("Last Name", "Index")
            </th>
            <th>
                First Name
            </th>
            <th>
                @Html.ActionLink("Enrollment Date", "Index")
            </th>
            <th></th>



        </tr>

        <table class="table">
            <tr>

                <th>
                    @Html.DisplayNameFor(Function(model) model.id)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.顧客名)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.フリガナ)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.性別)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.会社名)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.住所)
                </th>
                <th></th>
            </tr>

            @For Each item In Model
                @<tr>
                    <td>
                        @Html.DisplayFor(Function(modelItem) item.Id)
                    </td>
                    <td>
                        @Html.DisplayFor(Function(modelItem) item.顧客名)
                    </td>
                    <td>
                        @Html.DisplayFor(Function(modelItem) item.フリガナ)
                    </td>
                    <td>
                        @Html.DisplayFor(Function(modelItem) item.性別)
                    </td>
                    <td>
                        @Html.DisplayFor(Function(modelItem) item.会社名)
                    </td>
                    <td>
                        @Html.DisplayFor(Function(modelItem) item.住所)
                    </td>
                    <td>
                        @Html.ActionLink("Edit", "Edit", New With {.id = item.Id}) |
                        @Html.ActionLink("Details", "Details", New With {.id = item.Id}) |
                        @Html.ActionLink("Delete", "Delete", New With {.id = item.Id})
                    </td>
                </tr>
            Next

        </table>
    </div>
</body>
</html>*@
