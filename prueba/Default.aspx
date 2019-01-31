<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">   
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <title></title>   
    <script>
        function myfunction() {
            if (typeof FormData == "undefined") {
                alert("Please Use Latest Version Of Google Chrome Or Mozilla Firefox To Upload Documents");
                return false;
            }
            var data = new FormData();

            var files = $("#fileUpload").get(0).files;

            // Add the uploaded image content to the form data collection
            if (files.length > 0) {
                data.append("UploadedImage", files[0]);
            }
            else{
                alert('Please Select File');
                return;
            }

            $.ajax({
                type: "POST",
                headers: { "Cache-Control": "no-cache" },
                url: "Handler.ashx",
                contentType: false,
                processData: false,
                data: data,                
                success: function (data) {
                    console.log(data);
                    alert("done");
                }
            });                     
        }
    </script>
</head>
<body>
    <form runat="server">
        <asp:ScriptManager runat="server" />
        
                <input id="fileUpload" type="file" />
                <input id="btnUploadFile" type="button" value="Upload File" onclick="myfunction();" />        
                
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:Button Text="dentro de update" runat="server" ID="validar" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <select>
            <option value="value">text</option>
        </select>    
    </form> 
    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</body>
</html>
