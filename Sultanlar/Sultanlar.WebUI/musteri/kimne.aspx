<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kimne.aspx.cs" Inherits="Sultanlar.WebUI.musteri.kimne" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <style type="text/css">

td
	{border-style: none;
            border-color: inherit;
            border-width: medium;
            padding-top:1px;
	        padding-right:1px;
	        padding-left:1px;
	        color:black;
	        font-size:11.0pt;
	        font-weight:400;
	        font-style:normal;
	        text-decoration:none;
	        font-family:Calibri, sans-serif;
	        text-align:general;
	        vertical-align:bottom;
	        white-space:nowrap;
	}
.font6
	{color:red;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Calibri, sans-serif;
	}
.font5
	{color:black;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Calibri, sans-serif;
	}
        .auto-style1 {
            height: 25.5pt;
            width: 83pt;
            color: black;
            font-size: 11.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style2 {
            width: 92pt;
            color: black;
            font-size: 11.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style3 {
            width: 476pt;
            color: black;
            font-size: 11.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style4 {
            width: 125pt;
            color: black;
            font-size: 11.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style5 {
            width: 79pt;
            color: black;
            font-size: 11.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style6 {
            height: 25.5pt;
            width: 83pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style7 {
            width: 92pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style8 {
            width: 476pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style9 {
            width: 125pt;
            color: blue;
            font-size: 9.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: underline;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style10 {
            color: black;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border-left: .5pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style11 {
            height: 11.25pt;
            width: 83pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right: .5pt solid windowtext;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style12 {
            width: 92pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style13 {
            width: 476pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style14 {
            width: 125pt;
            color: blue;
            font-size: 9.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: underline;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style15 {
            height: 26.25pt;
            width: 83pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style16 {
            width: 79pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right: 1.0pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style17 {
            height: 13.5pt;
            width: 83pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style18 {
            width: 92pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style19 {
            width: 476pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style20 {
            width: 125pt;
            color: blue;
            font-size: 9.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: underline;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style21 {
            width: 79pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style22 {
            height: 166.5pt;
            width: 83pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: left;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style23 {
            width: 92pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style24 {
            width: 476pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style25 {
            width: 125pt;
            color: blue;
            font-size: 9.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: underline;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style26 {
            width: 79pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right: 1.0pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style27 {
            height: 38.25pt;
            width: 92pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style28 {
            width: 476pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style29 {
            width: 125pt;
            color: blue;
            font-size: 9.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: underline;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style30 {
            width: 79pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right: 1.0pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style31 {
            height: 25.5pt;
            width: 92pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style32 {
            height: 39.0pt;
            width: 92pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style33 {
            width: 476pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style34 {
            width: 125pt;
            color: blue;
            font-size: 9.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: underline;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style35 {
            width: 79pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right: 1.0pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style36 {
            height: 15.75pt;
            width: 83pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style37 {
            height: 127.5pt;
            width: 83pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style38 {
            height: 51.0pt;
            width: 92pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style39 {
            height: 25.5pt;
            width: 83pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style40 {
            width: 92pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style41 {
            height: 26.25pt;
            width: 83pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style42 {
            width: 92pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style43 {
            height: 15.75pt;
            width: 83pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style44 {
            color: black;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right: .5pt solid windowtext;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style45 {
            height: 25.5pt;
            width: 83pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style46 {
            width: 79pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right: .5pt solid windowtext;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style47 {
            height: 15.0pt;
            width: 83pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style48 {
            height: 64.5pt;
            width: 83pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: left;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style49 {
            height: 69.0pt;
            width: 83pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: left;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style50 {
            height: 51.75pt;
            width: 83pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: left;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style51 {
            height: 26.25pt;
            width: 92pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style52 {
            height: 26.25pt;
            width: 83pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style53 {
            height: 77.25pt;
            width: 83pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: left;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style54 {
            height: 51.75pt;
            width: 92pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style55 {
            height: 15.0pt;
            width: 83pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style56 {
            height: 38.25pt;
            width: 83pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style57 {
            width: 79pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style58 {
            height: 25.5pt;
            width: 83pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style59 {
            width: 79pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
    </style>
    
    </head>
<body>
    <table border="0" cellpadding="0" cellspacing="0" style="border-collapse:
 collapse;width:855pt" width="1139">
        <colgroup>
            <col style="mso-width-source:userset;mso-width-alt:4022;width:83pt" width="110" />
            <col style="mso-width-source:userset;mso-width-alt:4498;width:92pt" width="123" />
            <col style="mso-width-source:userset;mso-width-alt:23186;width:476pt" width="634" />
            <col style="mso-width-source:userset;mso-width-alt:6107;width:125pt" width="167" />
            <col style="mso-width-source:userset;mso-width-alt:3840;width:79pt" width="105" />
        </colgroup>
        <tr height="34" style="mso-height-source:userset;height:25.5pt">
            <td class="auto-style1" height="34" width="110">KONUSU</td>
            <td class="auto-style2" width="123">AD SOYAD</td>
            <td class="auto-style3" width="634">GÖREV VE SORULACAKLAR</td>
            <td class="auto-style4" width="167">MAİL</td>
            <td class="auto-style5" width="105">TELEFON</td>
        </tr>
        <tr height="34" style="mso-height-source:userset;height:25.5pt">
            <td class="auto-style6" height="34" width="110">YÖNETİM<span style="mso-spacerun:yes">&nbsp;</span></td>
            <td class="auto-style7" width="123">MÜCAHİT YILDIZ</td>
            <td class="auto-style8" width="634">GRUBUMUZUN İŞLEYİŞİYLE İLGİLİ BİRİMLERCE SONUÇLANMAYAN TÜM KONULARDA</td>
            <td class="auto-style9" style="text-underline-style: single;" width="167"><a href="mailto:my@sultanlar.com.tr"><span style="font-size:9.0pt">my@sultanlar.com.tr</span></a></td>
            <td class="auto-style10">&nbsp;</td>
        </tr>
        <tr height="15" style="mso-height-source:userset;height:11.25pt">
            <td class="auto-style11" height="15" width="110">&nbsp;</td>
            <td class="auto-style12" width="123">&nbsp;</td>
            <td class="auto-style13" width="634">&nbsp;</td>
            <td class="auto-style14" style="text-underline-style: single;" width="167"><u style="visibility:hidden;mso-ignore:visibility">&nbsp;</u></td>
            <td></td>
        </tr>
        <tr height="35" style="height:26.25pt">
            <td class="auto-style15" height="35" width="110">EDT SATIŞ MÜDÜRÜ</td>
            <td class="auto-style7" width="123">İSMET ARPAGUŞ</td>
            <td class="auto-style8" width="634">TIBTRAP-FULNET ENDÜSTRİYEL ÜRÜNLER YÖNETİCİSİ ÜRÜNLE İLGİLİ SORUNLAR MAİL YOLUYLA</td>
            <td class="auto-style9" style="text-underline-style: single;" width="167"><a href="mailto:iarpagus@tibet.com.tr"><span style="font-size:9.0pt">iarpagus@tibet.com.tr</span></a></td>
            <td class="auto-style16" width="105">0533 699 78 08 - 0216 595 05 00</td>
        </tr>
        <tr height="18" style="mso-height-source:userset;height:13.5pt">
            <td class="auto-style17" height="18" width="110"></td>
            <td class="auto-style18" width="123"></td>
            <td class="auto-style19" width="634"></td>
            <td class="auto-style20" style="text-underline-style: single;" width="167"></td>
            <td class="auto-style21" width="105"></td>
        </tr>
        <tr height="34" style="height:25.5pt">
            <td class="auto-style22" height="222" rowspan="5" width="110">PAZARLAMA</td>
            <td class="auto-style23" width="123">ESİN SETOL</td>
            <td class="auto-style24" width="634">PAZARLAMA MÜDÜRÜ: TÜM MARKALARIN VE ÜRÜNLERİN MARKA- PAZARLAMA FAALİYETLERİNİ YÖNETMEKTEDİR. MAİL YOLUYLA İLETİŞİM</td>
            <td class="auto-style25" style="text-underline-style: single;" width="167">esinsetol@tibet.com.tr</td>
            <td class="auto-style26" width="105">0216 595 05 00</td>
        </tr>
        <tr height="51" style="height:38.25pt">
            <td class="auto-style27" height="51" width="123">İSLAM YILDIZ</td>
            <td class="auto-style28" width="634">ÜRGE MD.İHRACAT ÜRÜN YÖNETİCİSİ. YENİ ÜRÜN FİKİRLERİ İÇİN <font class="font6">birfikrimvar@sultanlar.com.tr</font><font class="font5"> ADRESİ ÜZERİNDEN BİLGİ GEÇİLEBİLİR. BİR FİKRİM VAR ÜZERİNDEN İŞİMİZİN İLERLEMESİ VE GELİŞMESİ AMACIYLA HER TÜRLÜ ÜRÜN VE YENİ FİKİRLERİNİZİ BEKLİYORUZ.<span style="mso-spacerun:yes">&nbsp;</span></font></td>
            <td class="auto-style29" style="text-underline-style: single;" width="167"><a href="mailto:islamyildiz@tibet.com.tr"><span style="font-size:9.0pt">islamyildiz@tibet.com.tr</span></a></td>
            <td class="auto-style30" width="105">0216 595 05 00</td>
        </tr>
        <tr height="34" style="height:25.5pt">
            <td class="auto-style31" height="34" width="123">SALİH BIÇAK</td>
            <td class="auto-style28" width="634">NON-FOOD ÜRÜN YÖNETİCİSİ:&nbsp; PİKNİK MARKASI VE ÜRÜNLERİ İLE ALAKALI TÜM MARKA-PAZARLAMA FAALİYETLERİNİ YÜRÜTMEKTEDİR. MAİL YOLUYLA İLETİŞİM<span style="mso-spacerun:yes">&nbsp;</span></td>
            <td class="auto-style29" style="text-underline-style: single;" width="167"><a href="mailto:salihbicak@tibet.com.tr"><span style="font-size:9.0pt">salihbicak@tibet.com.tr</span></a></td>
            <td class="auto-style30" width="105">0216 595 05 00</td>
        </tr>
        <tr height="51" style="height:38.25pt">
            <td class="auto-style27" height="51" width="123">YASİN KARTAL</td>
            <td class="auto-style28" width="634">GIDA ÜRÜN MÜDÜRÜ: KENTON-ARI-BÜNSA VE ALTIN MARKALARINDAN SORUMLUDUR. KENDİSİNE BAĞLI MARKALAR VE ÜRÜNLER İLE İLGİLİ TÜM MARKA-PAZARLAMA FAALİYETLERİNİ YÜRÜTMEKTEDİR. ÜRÜN GÖRSELLERİ ,ÜRÜNLE İLGİLİ SORUNLAR MAİL YOLUYLA<span style="mso-spacerun:yes">&nbsp;</span></td>
            <td class="auto-style29" style="text-underline-style: single;" width="167"><a href="mailto:ykartal@tibet.com.tr"><span style="font-size:9.0pt">ykartal@tibet.com.tr</span></a></td>
            <td class="auto-style30" width="105">0216 595 05 00</td>
        </tr>
        <tr height="52" style="height:39.0pt">
            <td class="auto-style32" height="52" width="123">GÜLSUN SEDA DEMIRHAN</td>
            <td class="auto-style33" width="634">TEMİZLİK VE KOZMETİK ÜRÜN MÜDÜRÜ:CAMSİL-SALOON-ERNET-TİBTRAP MARKALARINDAN SORUMLUDUR. KENDİSİNE BAĞLI MARKALAR VE ÜRÜNLER İLE İLGİLİ TÜM MARKA- PAZARLAMA FAALİYETLERİNİ YÜRÜTMEKTEDİR. ÜRÜN GÖRSELLERİ, ÜRÜNLE İLGİLİ SORUNLAR MAİL YOLUYLA</td>
            <td class="auto-style34" style="text-underline-style: single;" width="167"><a href="javascript:OpenNewWindow('/Mondo/lang/sys/Forms/MAI/compose.aspx?MsgTo=gulsunsedademirhan%40tibet.com.tr&amp;MsgSubject=&amp;MsgCc=&amp;MsgBcc=&amp;MsgBody=',570,450)"><span style="font-size:9.0pt">gulsunsedademirhan@tibet.com.tr<span style="mso-spacerun:yes">&nbsp;</span></span></a></td>
            <td class="auto-style35" width="105">0216 595 05 00</td>
        </tr>
        <tr height="21" style="mso-height-source:userset;height:15.75pt">
            <td class="auto-style36" height="21" width="110"></td>
            <td class="auto-style18" width="123"></td>
            <td class="auto-style19" width="634"></td>
            <td class="auto-style20" style="text-underline-style: single;" width="167"></td>
            <td class="auto-style21" width="105"></td>
        </tr>
        <tr height="34" style="height:25.5pt">
            <td class="auto-style37" height="170" rowspan="3" width="110">TİCARİ PAZARLAMA</td>
            <td class="auto-style23" width="123">SERDAL YALVAÇ</td>
            <td class="auto-style24" width="634">TİCARİ PAZARLAMA MD. BÖLÜM ÇALIŞANLARINA ULAŞILAMADIĞINDA YÜKSEK HACİMLİ SATIŞ İŞLEMLERİNDE ARANACAK<span style="mso-spacerun:yes">&nbsp;</span></td>
            <td class="auto-style25" style="text-underline-style: single;" width="167">serdalyalvac@tibet.com.tr</td>
            <td class="auto-style26" width="105">0533 699 78 12</td>
        </tr>
        <tr height="68" style="height:51.0pt">
            <td class="auto-style38" height="68" width="123">DEMET GÜLEÇ</td>
            <td class="auto-style28" width="634">AKTİVİTE FİYATLANDIRILMASI, ÜRÜN FİYATI VERİLMESİ, ANLAŞMA ONAYLARI MAİL YOLUYLA HİZMET FATURALARI KONTROL, FATURADA İSKONTO ÇIKMAMIŞ TALEPLERİ FATURA NUMARALARIYLA BİRLİKTE TALEP EDİLEBİLİR. MÜŞTERİMİN MALİYETİ NE KADAR, GÜNCEL FİYAT LİSTESİ , MÜŞTERİ CİRO PRİMLERİ SORULACAK, 500&#39;LÜ KODLARIN TANIMLANMASI,500&#39;LÜ GÖRÜNMEYEN FİYATLAR,MÜŞTERİ MALİYETLERİ MAİL YOLUYLA</td>
            <td class="auto-style29" style="text-underline-style: single;" width="167">demetgulec@tibet.com.tr</td>
            <td class="auto-style30" width="105">0530 324 71 44 -0216 595 05 00</td>
        </tr>
        <tr height="68" style="height:51.0pt">
            <td class="auto-style38" height="68" width="123">NESLİHAN DEMİRBAŞ<br />
                (ULUSAL ZİNCİR)</td>
            <td class="auto-style28" width="634">ULUSAL SİPARİŞ GİRİŞİ, HİZMET FATURALARI KONTROL, FATURADA İSKONTO ÇIKMAMIŞ TALEPLERİ FATURA NUMARALARIYLA BİRLİKTE TALEP EDİLEBİLİR. GÜNCEL FİYAT LİSTESİ , MÜŞTERİ CİRO PRİMLERİ SORULACAK, 500&#39;LÜ KODLARIN TANIMLANMASI,500&#39;LÜ GÖRÜNMEYEN FİYATLAR GÜNCEL ULUSAL FİYAT LİSTESİ, ULUSAL İADE FATURA TAKİBİ<span style="mso-spacerun:yes">&nbsp;</span></td>
            <td class="auto-style29" style="text-underline-style: single;" width="167"><a href="mailto:ndemirbas@tibet.com.tr"><span style="font-size:9.0pt">ndemirbas@tibet.com.tr</span></a></td>
            <td class="auto-style30" width="105">0216 595 05 00</td>
        </tr>
        <tr height="34" style="height:25.5pt">
            <td class="auto-style39" height="34" width="110">TİC.PAZARLAMA /ADANA</td>
            <td class="auto-style40" width="123">MEHMET GÜLEKOĞLU</td>
            <td class="auto-style28" width="634">TÜM BAYİLERİN BÜTÇE İŞLEMLERİ &nbsp;İLE İLGİLİ</td>
            <td class="auto-style29" style="text-underline-style: single;" width="167"><a href="mailto:mgulekoglu@stgrup.com.tr"><span style="font-size:9.0pt">mgulekoglu@stgrup.com.tr</span></a></td>
            <td class="auto-style30" width="105">0533 957 80 34<span style="mso-spacerun:yes">&nbsp;&nbsp;</span></td>
        </tr>
        <tr height="35" style="height:26.25pt">
            <td class="auto-style41" height="35" width="110">İADE KABUL</td>
            <td class="auto-style42" width="123">ADNAN BAĞDATLI</td>
            <td class="auto-style33" width="634">HER TÜRLÜ İADE İŞLEMLERİ (NEDEN DÜŞÜLMEDİ VS.) İADELER İLE İLGİLİ ÖNCELİKLİ</td>
            <td class="auto-style34" style="text-underline-style: single;" width="167"><a href="mailto:unalyildirim@tibet.com.tr"><span style="font-size:9.0pt">unalyildirim@tibet.com.tr</span></a></td>
            <td class="auto-style30" width="105">0533 699 78 58 - 0216 595 05 00</td>
        </tr>
        <tr height="21" style="height:15.75pt">
            <td class="auto-style43" height="21" width="110">&nbsp;</td>
            <td class="auto-style12" width="123">&nbsp;</td>
            <td class="auto-style13" width="634">&nbsp;</td>
            <td class="auto-style14" style="text-underline-style: single;" width="167"><u style="visibility:hidden;mso-ignore:visibility">&nbsp;</u></td>
            <td class="auto-style44">&nbsp;</td>
        </tr>
        <tr height="34" style="height:25.5pt">
            <td class="auto-style45" height="34" width="110">BİLGİ İŞLEM WEB YAZILIM</td>
            <td class="auto-style23" width="123">MEHMET İSTİF</td>
            <td class="auto-style24" width="634">WEB İLE İLGİLİ TÜM KONULAR , WEB SİSTEM AKSAKLILARI ÇÖZÜMÜ, <font class="font6">MAİL YOLUYLA CEVAPLANIR</font></td>
            <td class="auto-style25" style="text-underline-style: single;" width="167"><a href="mailto:mehmetistif@tibet.com.tr"><span style="font-size:9.0pt">mehmetistif@tibet.com.tr</span></a></td>
            <td class="auto-style30" width="105">0216 595 05 00</td>
        </tr>
        <tr height="35" style="height:26.25pt">
            <td class="auto-style41" height="35" width="110">BİLGİ İŞLEM DONANIM</td>
            <td class="auto-style42" width="123">NURETTİN GÜNAY</td>
            <td class="auto-style33" width="634">BİLGİ İŞLEM MD. BİLGİSAYAR DONANIMLARI, TELEFON YAZILIMI HAKKINDAKİ KONULARDA MAİL YADA TELEFON YOLUYLA CEVAPLANIR</td>
            <td class="auto-style34" style="text-underline-style: single;" width="167"><a href="mailto:ngunay@sultanlar.com.tr"><span style="font-size:9.0pt">ngunay@sultanlar.com.tr</span></a></td>
            <td class="auto-style35" width="105">0533 141 32 41</td>
        </tr>
        <tr height="21" style="height:15.75pt">
            <td class="auto-style43" height="21" width="110">&nbsp;</td>
            <td class="auto-style12" width="123">&nbsp;</td>
            <td class="auto-style13" width="634">&nbsp;</td>
            <td class="auto-style14" style="text-underline-style: single;" width="167"><u style="visibility:hidden;mso-ignore:visibility">&nbsp;</u></td>
            <td class="auto-style46" width="105">&nbsp;</td>
        </tr>
        <tr height="20" style="height:15.0pt">
            <td class="auto-style47" height="20" width="110">SİPARİŞ GİRİŞİ</td>
            <td class="auto-style23" width="123">TUBA POLAT</td>
            <td class="auto-style24" width="634">SİPARİŞ GİRİŞİ SİPARİŞ KONTROLÜ GİBİ KONULARDA ARANACAK</td>
            <td class="auto-style25" style="text-underline-style: single;" width="167"><a href="mailto:tubapolat@tibet.com.tr"><span style="font-size:9.0pt">tubapolat@tibet.com.tr</span></a></td>
            <td class="auto-style26" width="105">0216 595 05 00</td>
        </tr>
        <tr height="34" style="height:25.5pt">
            <td class="auto-style48" height="86" rowspan="2" width="110">LOJİSTİK</td>
            <td class="auto-style40" width="123">SİNAN YUTSEVER</td>
            <td class="auto-style28" width="634">ÜRÜNLER TESLİM EDİLMEMİŞ, EKSİK TESLİM EDİLMİŞ GİBİ LOJİSTİK KONULARI, ÜRÜN MÜŞTERİYE GİTMEDİ FATURA GİTTİ. HAMMALİYE FATULARI LOJİSİK İLE İLGİLİ KONULARDA ARANACAK</td>
            <td class="auto-style29" style="text-underline-style: single;" width="167"><a href="mailto:syurtsever@tibet.com.tr"><span style="font-size:9.0pt">syurtsever@tibet.com.tr</span></a></td>
            <td class="auto-style30" width="105">0530 320 67 20- 0216 595 05 00</td>
        </tr>
        <tr height="52" style="height:39.0pt">
            <td class="auto-style32" height="52" width="123">ERTUĞRUL DUYSAK<span style="mso-spacerun:yes">&nbsp; </span>- MURAT FETTAH</td>
            <td class="auto-style33" width="634">YANLIŞ KESİLEN FATURALARDA ÖNCELİKLİ ARANMALI, FATURA GERİ DÖNÜŞLERİ ÜRÜNLERİ KİM TESLİM ALMIŞ GİBİ SORULARA CEVAP ALINABİLİR. İRSALİYE OLAN FATURA GÖRÜNTÜLERİ, SEVKİYAT ŞOFÖRÜNE TELEFON İLE ULAŞILAMADIĞINDAN, ÜRÜNLER SEVKİYATA ÇIKTIMI SORULARIDAN ARANACAK</td>
            <td class="auto-style34" style="text-underline-style: single;" width="167"><a href="mailto:mfettah@tibet.com.tr"><span style="font-size:9.0pt">ertugrulduysak@tibet.com.tr mfettah@tibet.com.tr</span></a></td>
            <td class="auto-style35" width="105">0530 370 61 73- 0532 769 81 12<span style="mso-spacerun:yes">&nbsp;&nbsp;&nbsp; </span>0216 595 05 00</td>
        </tr>
        <tr height="21" style="mso-height-source:userset;height:15.75pt">
            <td class="auto-style36" height="21" width="110"></td>
            <td class="auto-style18" width="123"></td>
            <td class="auto-style19" width="634"></td>
            <td class="auto-style20" style="text-underline-style: single;" width="167"></td>
            <td class="auto-style21" width="105"></td>
        </tr>
        <tr height="40" style="mso-height-source:userset;height:30.0pt">
            <td class="auto-style49" height="92" rowspan="2" width="110">MALİ İŞLER</td>
            <td class="auto-style23" width="123">GÖKHAN ÇELİK</td>
            <td class="auto-style24" width="634">MUHASEBE MÜDÜRÜ BİRİM PERSONELLERİNE ULAŞILAMADIĞINDA E-FATURANIN GİB E GÖNDERİLMESİNDE</td>
            <td class="auto-style9" style="text-underline-style: single;" width="167"><a href="mailto:gokhancelik@tibet.com.tr"><span style="font-size:9.0pt">gokhancelik@tibet.com.tr</span></a></td>
            <td class="auto-style26" width="105">0530 825 19 80- 0216 595 05 00</td>
        </tr>
        <tr height="52" style="mso-height-source:userset;height:39.0pt">
            <td class="auto-style32" height="52" width="123">ZEHRA AKGÜL</td>
            <td class="auto-style33" width="634">TÜM İADE VE MÜŞTERİ HİZMET FATURALARININ İŞLENMESİ, TAKİBİ GERİ DÖNÜŞLERİ. İSKONTO ÇIKMAMIŞLAR TİC.PAZ. TARAFINDAN BELİRLENDİKTEN SONRA MÜŞTERİYE FAT.GERİ DÖNÜŞÜ YAPAR. E-FATURALAR MÜŞTERİDE GÖZÜKMÜYOR SORULARI İÇİN.<span style="mso-spacerun:yes">&nbsp; </span>İMHA FATURALARI,BABS İÇİN ARAYANLARA CEVAP VERİLMESİ</td>
            <td class="auto-style34" style="text-underline-style: single;" width="167"><a href="mailto:zehraakgul@tibet.com.tr"><span style="font-size:9.0pt">zehraakgul@tibet.com.tr</span></a></td>
            <td class="auto-style35" width="105">0216 595 05 00</td>
        </tr>
        <tr height="21" style="mso-height-source:userset;height:15.75pt">
            <td class="auto-style36" height="21" width="110"></td>
            <td class="auto-style18" width="123"></td>
            <td class="auto-style19" width="634"></td>
            <td class="auto-style20" style="text-underline-style: single;" width="167"></td>
            <td class="auto-style21" width="105"></td>
        </tr>
        <tr height="34" style="height:25.5pt">
            <td class="auto-style50" height="69" rowspan="2" width="110">FİNANS</td>
            <td class="auto-style23" width="123">İSMAİL DERECİ</td>
            <td class="auto-style24" width="634">ŞEF, FİNANS İLE İLGİLİ ÖNCELİKLİ SORMLU ÖZLEM HANIMA ULAŞILMADIĞINDA ARANACAK</td>
            <td class="auto-style25" style="text-underline-style: single;" width="167"><a href="mailto:ismaildereci@tibet.com.tr"><span style="font-size:9.0pt">ismaildereci@tibet.com.tr</span></a></td>
            <td class="auto-style26" width="105">0536 239 99 22 - 0216 595 05 00</td>
        </tr>
        <tr height="35" style="height:26.25pt">
            <td class="auto-style51" height="35" width="123">ÖZLEM AVCI</td>
            <td class="auto-style33" width="634">FİNANS ELEMANI, MAİL ORDER, ORTALAMA VADE HESAPLAMA, ÇEKLERİN SİSTEME İŞLENMESİ,BANKA İLE İLGİLİ SORULARDA MAİL VEYA TELEFON İLETİŞİME GEÇİLECEK</td>
            <td class="auto-style34" style="text-underline-style: single;" width="167"><a href="mailto:ozlemavci@tibet.com.tr"><span style="font-size:9.0pt">ozlemavci@tibet.com.tr</span></a></td>
            <td class="auto-style35" width="105">0216 595 05 00</td>
        </tr>
        <tr height="21" style="height:15.75pt">
            <td class="auto-style36" height="21" width="110"></td>
            <td class="auto-style18" width="123"></td>
            <td class="auto-style19" width="634"></td>
            <td class="auto-style20" style="text-underline-style: single;" width="167"></td>
            <td class="auto-style21" width="105"></td>
        </tr>
        <tr height="35" style="height:26.25pt">
            <td class="auto-style52" height="35" width="110">RAPORLAMA</td>
            <td class="auto-style7" width="123">ÖZGÜR KAR</td>
            <td class="auto-style8" width="634">TÜM RAPORLAR, MÜŞTERİ AKTİF PASİF (YÖN.ONAY DAHİLİNDE), MÜŞTERİ AKTARIMI, (YÖN.ONAY DAHİLİNDE), YÜKLÜ EKSTRE GÖNDERİMLERİ, (WEB ÜZERİNDEN ALINAMIYORSA)<span style="mso-spacerun:yes">&nbsp; </span>HEDEF VE PRİMLERİN DÜZENLENMESİ</td>
            <td class="auto-style9" style="text-underline-style: single;" width="167"><a href="mailto:okar@sultanlar.com.tr"><span style="font-size:9.0pt">okar@sultanlar.com.tr</span></a></td>
            <td class="auto-style16" width="105">0533 498 35 12</td>
        </tr>
        <tr height="21" style="height:15.75pt">
            <td class="auto-style36" height="21" width="110"></td>
            <td class="auto-style18" width="123"></td>
            <td class="auto-style19" width="634"></td>
            <td class="auto-style20" style="text-underline-style: single;" width="167"></td>
            <td class="auto-style21" width="105"></td>
        </tr>
        <tr height="34" style="height:25.5pt">
            <td class="auto-style45" height="34" width="110">İDARİ İŞLER</td>
            <td class="auto-style23" width="123">AHMET FETTAH</td>
            <td class="auto-style24" width="634">İDARİ İŞLER MÜDÜR</td>
            <td class="auto-style25" style="text-underline-style: single;" width="167"><a href="mailto:afettah@tibet.com.tr"><span style="font-size:9.0pt">afettah@tibet.com.tr</span></a></td>
            <td class="auto-style26" width="105">0533 699 78 56 -0216 595 05 00</td>
        </tr>
        <tr height="34" style="height:25.5pt">
            <td class="auto-style39" height="34" width="110">İDARİ İŞLER</td>
            <td class="auto-style40" width="123">MUHSİN HUT</td>
            <td class="auto-style28" width="634">İDARİ İŞLER KONULARINDA<font class="font6"> ÖNCELİKLİ ARANACAK.</font></td>
            <td class="auto-style29" style="text-underline-style: single;" width="167"><a href="mailto:muhsinhut@tibet.com.tr"><span style="font-size:9.0pt">muhsinhut@tibet.com.tr</span></a></td>
            <td class="auto-style30" width="105">0532 318 45 44 -0216 595 05 00</td>
        </tr>
        <tr height="35" style="height:26.25pt">
            <td class="auto-style41" height="35" width="110">İDARİ İŞLER</td>
            <td class="auto-style42" width="123">ERDİ AYDIN</td>
            <td class="auto-style33" width="634">İDARİ İŞLER<span style="mso-spacerun:yes">&nbsp;</span></td>
            <td class="auto-style34" style="text-underline-style: single;" width="167"><a href="mailto:erdiaydin@tibet.com.tr"><span style="font-size:9.0pt">erdiaydin@tibet.com.tr</span></a></td>
            <td class="auto-style35" width="105">0542 464 07 74- 0216 595 05 00</td>
        </tr>
        <tr height="21" style="height:15.75pt">
            <td class="auto-style43" height="21" width="110">&nbsp;</td>
            <td class="auto-style12" width="123">&nbsp;</td>
            <td class="auto-style13" width="634">&nbsp;</td>
            <td class="auto-style14" style="text-underline-style: single;" width="167"><u style="visibility:hidden;mso-ignore:visibility">&nbsp;</u></td>
            <td class="auto-style46" width="105">&nbsp;</td>
        </tr>
        <tr height="34" style="mso-height-source:userset;height:25.5pt">
            <td class="auto-style53" height="103" rowspan="2" width="110">İNSAN KAYNAKLARI</td>
            <td class="auto-style23" width="123">ŞEREF TUNA -<span style="mso-spacerun:yes">&nbsp; </span>ADNAN NARAT</td>
            <td class="auto-style24" width="634">ÖDÜL BİLGİLERİ, SGK İLE İLGİLİ BİLGİLER</td>
            <td class="auto-style25" style="text-underline-style: single;" width="167"><a href="mailto:stuna@tibet.com.tr;anarat@tibet.com.tr"><span style="font-size:
  9.0pt">stuna@tibet.com.tr;anarat@tibet.com.tr</span></a></td>
            <td class="auto-style26" width="105">0216 595 05 00</td>
        </tr>
        <tr height="69" style="height:51.75pt">
            <td class="auto-style54" height="69" width="123">MUHARREM GÜNDOĞDU -<span style="mso-spacerun:yes">&nbsp;&nbsp;&nbsp; </span>YASEMİN NARAT-YASEMİN YÜCEALAN</td>
            <td class="auto-style33" width="634">MAAŞ BİLGİSİ, İZİNLER İLE İLGİLİ TALEPLER, YEMEK ÜCRETLERİ VE DİĞER ÖZLÜK BİLGİLERİ<span style="mso-spacerun:yes">&nbsp;</span></td>
            <td class="auto-style34" style="text-underline-style: single;" width="167"><a href="mailto:yyucalan@tibet.com.tr;mgundogdu@tibet.com.tr;ynarat@tibet.com.tr"><span style="font-size:9.0pt">yyucalan@tibet.com.tr;mgundogdu@tibet.com.tr;ynarat@tibet.com.tr</span></a></td>
            <td class="auto-style35" width="105">0216 595 05 00</td>
        </tr>
        <tr height="20" style="height:15.0pt">
            <td class="auto-style55" height="20" width="110"></td>
            <td class="auto-style18" width="123"></td>
            <td class="auto-style19" width="634"></td>
            <td class="auto-style20" style="text-underline-style: single;" width="167"></td>
            <td class="auto-style21" width="105"></td>
        </tr>
        <tr height="51" style="height:38.25pt">
            <td class="auto-style56" height="51" width="110">İADE FİYATLAMA, MÜŞTERİ AÇILIŞI</td>
            <td class="auto-style40" width="123">FAHRETTİN KAYA</td>
            <td class="auto-style28" width="634">İADE FİYATLANDIRMA, ÜNAL BEYE ULAŞILAMAYINCA İADE AKIBETİ YENİ AÇILIŞ TALEPLERİ, YENİ MÜŞTERİ VE ŞUBE AÇILIŞLARI, MÜŞTERİ BLOKAJA ALMA - MÜŞTERİ BLOKAJI AÇMA YÖNETİCİ ONAYLI, HALK GÜNLERİNİN TANIMLANMASI MAİL YOLUYLA İLETİŞİM RUT İLE İLGİLİ İŞLEMLER ADRES DEĞİŞİKLERİ MAİL OLARAK YÖN.ONAYLI</td>
            <td class="auto-style29" style="text-underline-style: single;" width="167"><a href="mailto:fkaya@sultanlar.com.tr"><span style="font-size:9.0pt">fkaya@sultanlar.com.tr</span></a></td>
            <td class="auto-style57" width="105">0554 349 65 65- 0216 561 50 00</td>
        </tr>
        <tr height="34" style="height:25.5pt">
            <td class="auto-style58" height="34" width="110">MUTABAKAT, RUT<span style="mso-spacerun:yes">&nbsp; </span>PLANLAMA</td>
            <td class="auto-style40" width="123">TÜMAY İLBEYLİ</td>
            <td class="auto-style28" width="634"><span style="mso-spacerun:yes">&nbsp;</span>SATIŞ GÜNLÜK YAPILAN İŞLER TUTANAĞI, MUTABAKAT YAPILMASI,EKSTRE GÖNDERİMİ</td>
            <td class="auto-style29" style="text-underline-style: single;" width="167"><a href="mailto:tilbeyli@sultanlar.com.tr"><span style="font-size:9.0pt">tilbeyli@sultanlar.com.tr</span></a></td>
            <td class="auto-style57" width="105">0532 377 85 02 -0216 561 50 00</td>
        </tr>
        <tr height="34" style="height:25.5pt">
            <td class="auto-style58" height="34" width="110">MÜŞTERİ İLİŞKİLERİ</td>
            <td class="auto-style40" width="123">İBRAHİM BAĞDATLI</td>
            <td class="auto-style28" width="634">MÜŞTERİLERİMİZİN, ŞİRKETİMİZİN İŞ YAPIŞ ŞEKLİYLE İLGİLİ ŞİKAYET VE ÖNERİLERİ. (sikayetkutusu@sultanlar.com.tr)<span style="mso-spacerun:yes">&nbsp;</span></td>
            <td class="auto-style29" style="text-underline-style: single;" width="167"><a href="mailto:ibagdatli@sutanlar.com.tr"><span style="font-size:9.0pt">ibagdatli@sutanlar.com.tr</span></a></td>
            <td class="auto-style59" width="105">0533 498 35 65</td>
        </tr>
    </table>
    </body>
</html>
