<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="utf-8" />
        <title>GCM VB.NET Uygulaması</title>
        <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
        <meta name="viewport" content="width=device-width" />
        @Styles.Render("~/Content/css")
        @Scripts.Render("~/bundles/modernizr")
    </head>
    <body>
        <header>
            <div class="content-wrapper">
                <div class="float-left">
                    <p class="site-title"><a href="/"><img src="~/Content/google.png" width="32" />Cloud Messaging for VB.NET</a></p>
                </div>
                <div class="float-right">
                    <nav>
                        <ul id="menu">
                            <li>@Html.ActionLink("Ana Sayfa", "Index", "Home")</li>
                        </ul>
                    </nav>
                </div>
            </div>
        </header>
        <div id="body">
            @RenderSection("featured", required:=false)
            <section class="content-wrapper main-content clear-fix">
                @RenderBody()
            </section>
        </div>
        <footer>
            <div class="content-wrapper">
                <div class="float-left">
                    <p>&copy; @DateTime.Now.Year - My ASP.NET MVC Application</p>
                </div>
            </div>
        </footer>

 
    </body>
</html>
