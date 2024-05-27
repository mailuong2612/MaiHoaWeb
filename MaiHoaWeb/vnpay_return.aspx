<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vnpay_return.aspx.cs" Inherits="VNPAY_CS_ASPX.vnpay_return" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>RETURN URL FROM VNPAY</title>
        <link href="Styles/bootstrap.min.css" rel="stylesheet" />
    </head>
    <body>
        <div class="container">
            <div class="header clearfix">
                
                <h3 class="text-muted">Kết quả thanh toán</h3>
            </div>
            <div class="table-responsive">
                 <div runat="server" id="displayMsg"></div>
            </div> 
            <div class="table-responsive">
                 <div runat="server" id="displayTmnCode"></div>
            </div>
             <div class="table-responsive">
                 <div runat="server" id="displayTxnRef"></div>
            </div> 
             <div class="table-responsive">
                 <div runat="server" id="displayVnpayTranNo"></div>
            </div> 
            <div class="table-responsive">
                 <div runat="server" id="displayAmount"></div>
            </div>
            <div class="table-responsive">
                 <div runat="server" id="displayBankCode"></div>
            </div> 
            <div class="table-responsive">
                <div  runat="server">
                    <a style="text-decoration:none; color:white; background-color:#FF4F4F;display:block;width:12%;line-height:2;text-align:center" href="/Home/Index/">Quay lại Trang chủ</a> 
                </div>
            </div>
        </div>
    </body>
</html>