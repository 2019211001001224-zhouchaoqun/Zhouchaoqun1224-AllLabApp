﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ads.aspx.cs" Inherits="LabAss6.ads" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 731px;
            height: 149px;
        }
        .auto-style1 {
            width: 433px;
            height: 250px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style2">
            Ads 1<asp:AdRotator ID="AdRotator2" runat="server" AdvertisementFile="~/ads/AdListXMLFile.xml" KeywordFilter="ads1" />
        </div>
        <div>
            <h2>This is mv advertisement page </h2></div>
        <div class="auto-style1">
            Ads 2<asp:AdRotator ID="AdRotator1" runat="server" AdvertisementFile="~/ads/AdListXMLFile.xml" KeywordFilter="ads2" />
        </div>'

    </form>
</body>
</html>