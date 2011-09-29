<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="json.aspx.cs" Inherits="WebApplication1.json" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script type="text/javascript">
//        $(document).ready(function () {
//            $('#letter-b a').click(function () {
//                $.getJSON('b.json', function (data) {
//                    $('#dictionary').empty();
//                    $.each(data, function (index, entry) {
//                        var html = '<div class="entry">';
//                        html += '<h3 class="term">' + entry['term'] + "</h3>";
//                        html += '<div class="part">' + entry['part'] + "</div>";
//                        html += '<div class="definition">';
//                        html += entry['definition'];
//                        html += '</div>';
//                        html += '</div>';
//                        $('#dictionary').append(html);
//                    });
//                });
//                return false;
//            });

//            $('#letter-a a').click(function () {
//                $.get('b.json', function (data) {
//                    alert(data);
//                });
//            });
        //        });

        $(document).ready(function () {
            $("#letter-a a").click(function () {
                $.ajax({
                    type: "POST",
                    url: "json.aspx/SayHello",
                    data: "{}",
                    contentType: "application/json",
                    dataType: "json",
                    success: function (msg) { AjaxSucceeded(msg) },
                    error: function (msg) { AjaxFailed(msg) }
                });
            });
        });

    function AjaxSucceeded(result) 
    {
        alert(result.d);
    }
    function AjaxFailed(result) 
    {
        alert(result.status + ' ' + result.statusText);
    } 

//    $(document).ready(function () {
//        $("#divLoader").css("display","none");
//        $("#divJobs").css("display","block")
//    };

    $(document).ready(function () {
        $("#divLoader").show();
        $(".letters").hide();
    });
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="divLoader">
            <img src="Images/calendar.gif" alt=""/>
        </div>
        <div id="dictionary">
        </div>    
        <div class="letters">
            <div class="letter" id="letter-a">
                <h3><a href="#">A</a></h3>
            </div>
            <div class="letter" id="letter-b">
                <h3><a href="#">B</a></h3>
            </div>
            <div class="letter" id="letter-c">
                <h3><a href="#">C</a></h3>
            </div>
            <div class="letter" id="letter-d">
                <h3><a href="#">D</a></h3>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
