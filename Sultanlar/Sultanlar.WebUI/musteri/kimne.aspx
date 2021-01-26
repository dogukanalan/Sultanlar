<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kimne.aspx.cs" Inherits="Sultanlar.WebUI.musteri.kimne" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

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
.font7
	{color:windowtext;
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
            height: 39.0pt;
            width: 96pt;
            color: black;
            font-size: 10.0pt;
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
            width: 115pt;
            color: black;
            font-size: 10.0pt;
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
            width: 60pt;
            color: black;
            font-size: 10.0pt;
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
            width: 76pt;
            color: black;
            font-size: 10.0pt;
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
            width: 437pt;
            color: black;
            font-size: 10.0pt;
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
            width: 92pt;
            color: black;
            font-size: 10.0pt;
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
        .auto-style7 {
            width: 74pt;
            color: black;
            font-size: 10.0pt;
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
        .auto-style8 {
            height: 25.5pt;
            width: 96pt;
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
        .auto-style9 {
            width: 115pt;
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
        .auto-style10 {
            width: 60pt;
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
        .auto-style11 {
            width: 76pt;
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
        .auto-style12 {
            width: 437pt;
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
        .auto-style13 {
            width: 92pt;
            color: blue;
            font-size: 8.0pt;
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
        .auto-style14 {
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
        .auto-style15 {
            height: 11.25pt;
            width: 96pt;
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
        .auto-style16 {
            width: 115pt;
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
        .auto-style17 {
            width: 60pt;
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
        .auto-style18 {
            width: 76pt;
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
        .auto-style19 {
            width: 437pt;
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
        .auto-style20 {
            width: 92pt;
            color: blue;
            font-size: 8.0pt;
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
        .auto-style21 {
            width: 74pt;
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
        .auto-style22 {
            height: 26.25pt;
            width: 96pt;
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
        .auto-style23 {
            height: 15.75pt;
            width: 96pt;
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
        .auto-style24 {
            height: 9.75pt;
            width: 96pt;
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
        .auto-style25 {
            height: 13.5pt;
            width: 96pt;
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
        .auto-style26 {
            width: 115pt;
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
        .auto-style27 {
            width: 60pt;
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
        .auto-style28 {
            width: 76pt;
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
        .auto-style29 {
            width: 437pt;
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
        .auto-style30 {
            width: 92pt;
            color: blue;
            font-size: 8.0pt;
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
        .auto-style31 {
            width: 74pt;
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
        .auto-style32 {
            height: 394.5pt;
            width: 96pt;
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
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style33 {
            width: 115pt;
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
        .auto-style34 {
            width: 60pt;
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
        .auto-style35 {
            width: 76pt;
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
        .auto-style36 {
            width: 437pt;
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
        .auto-style37 {
            width: 92pt;
            color: blue;
            font-size: 8.0pt;
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
        .auto-style38 {
            width: 74pt;
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
        .auto-style39 {
            height: 25.5pt;
            width: 115pt;
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
        .auto-style40 {
            width: 60pt;
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
            width: 76pt;
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
        .auto-style42 {
            width: 437pt;
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
        .auto-style43 {
            width: 74pt;
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
        .auto-style44 {
            height: 39.0pt;
            width: 115pt;
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
        .auto-style45 {
            width: 92pt;
            color: blue;
            font-size: 8.0pt;
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
        .auto-style46 {
            height: 45.0pt;
            width: 115pt;
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
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style47 {
            width: 60pt;
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
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style48 {
            width: 76pt;
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
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style49 {
            width: 92pt;
            color: blue;
            font-size: 8.0pt;
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
        .auto-style50 {
            height: 51.0pt;
            width: 115pt;
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
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style51 {
            height: 38.25pt;
            width: 115pt;
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
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style52 {
            height: 51.75pt;
            width: 115pt;
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
        .auto-style53 {
            height: 36.0pt;
            width: 115pt;
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
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style54 {
            height: 15.0pt;
            width: 115pt;
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
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style55 {
            width: 437pt;
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
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style56 {
            width: 92pt;
            color: blue;
            font-size: 8.0pt;
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
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style57 {
            width: 74pt;
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
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style58 {
            height: 15.75pt;
            width: 115pt;
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
        .auto-style59 {
            width: 60pt;
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
        .auto-style60 {
            width: 76pt;
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
        .auto-style61 {
            width: 437pt;
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
        .auto-style62 {
            width: 74pt;
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
        .auto-style63 {
            height: 15.75pt;
            width: 96pt;
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
        .auto-style64 {
            height: 25.5pt;
            width: 96pt;
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
        .auto-style65 {
            height: 144.75pt;
            width: 96pt;
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
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style66 {
            width: 115pt;
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
        .auto-style67 {
            height: 51.0pt;
            width: 115pt;
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
        .auto-style68 {
            height: 38.25pt;
            width: 115pt;
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
        .auto-style69 {
            height: 25.5pt;
            width: 96pt;
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
        .auto-style70 {
            height: 51.0pt;
            width: 96pt;
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
        .auto-style71 {
            height: 39.0pt;
            width: 96pt;
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
        .auto-style72 {
            height: 15.75pt;
            width: 96pt;
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
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style73 {
            width: 115pt;
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
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style74 {
            width: 60pt;
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
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style75 {
            width: 76pt;
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
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style76 {
            width: 437pt;
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
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style77 {
            width: 74pt;
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
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style78 {
            height: 39.0pt;
            width: 96pt;
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
        .auto-style79 {
            height: 15.75pt;
            width: 96pt;
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
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style80 {
            height: 26.25pt;
            width: 96pt;
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
        .auto-style81 {
            width: 115pt;
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
        .auto-style82 {
            height: 15.0pt;
            width: 96pt;
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
        .auto-style83 {
            width: 74pt;
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
        .auto-style84 {
            height: 66.0pt;
            width: 96pt;
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
        .auto-style85 {
            height: 39.0pt;
            width: 115pt;
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
        .auto-style86 {
            height: 129.0pt;
            width: 96pt;
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
        .auto-style87 {
            height: 30.0pt;
            width: 115pt;
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
        .auto-style88 {
            height: 30.0pt;
            width: 115pt;
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
        .auto-style89 {
            height: 39.0pt;
            width: 115pt;
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
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style90 {
            height: 24.75pt;
            width: 96pt;
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
        .auto-style91 {
            height: 112.5pt;
            width: 96pt;
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
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: 1.0pt solid windowtext;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style92 {
            width: 115pt;
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
        .auto-style93 {
            width: 74pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style94 {
            height: 25.5pt;
            width: 115pt;
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
        .auto-style95 {
            height: 15.0pt;
            width: 115pt;
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
        .auto-style96 {
            height: 15.75pt;
            width: 115pt;
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
        .auto-style97 {
            width: 74pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style98 {
            height: 28.5pt;
            width: 96pt;
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
        .auto-style99 {
            height: 28.5pt;
            width: 96pt;
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
        .auto-style100 {
            height: 12.0pt;
            width: 96pt;
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
        .auto-style101 {
            height: 68.25pt;
            width: 96pt;
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
        .auto-style102 {
            height: 51.0pt;
            width: 96pt;
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
        .auto-style103 {
            height: 23.25pt;
            width: 96pt;
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
        .auto-style104 {
            height: 39.75pt;
            width: 96pt;
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
            border-bottom: 1.0pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
    </style>

   </head>
    <body runat="server">
        <table border="0" cellpadding="0" cellspacing="0" style="border-collapse:
 collapse;width:950pt" width="1264">
            <colgroup>
                <col style="mso-width-source:userset;mso-width-alt:4681;width:96pt" width="128" />
                <col style="mso-width-source:userset;mso-width-alt:5595;width:115pt" width="153" />
                <col style="mso-width-source:userset;mso-width-alt:2925;width:60pt" width="80" />
                <col style="mso-width-source:userset;mso-width-alt:3693;width:76pt" width="101" />
                <col style="mso-width-source:userset;mso-width-alt:21284;width:437pt" width="582" />
                <col style="mso-width-source:userset;mso-width-alt:4461;width:92pt" width="122" />
                <col style="mso-width-source:userset;mso-width-alt:3584;width:74pt" width="98" />
            </colgroup>
            <tr height="52" style="mso-height-source:userset;height:39.0pt">
                <td class="auto-style1" height="52" width="128">KONUSU</td>
                <td class="auto-style2" width="153">AD SOYAD</td>
                <td class="auto-style3" width="80">KONUM</td>
                <td class="auto-style4" width="101">SON GÖREVLENDİRME TARİHİ</td>
                <td class="auto-style5" width="582">GÖREV VE SORULACAKLAR</td>
                <td class="auto-style6" width="122">MAİL</td>
                <td class="auto-style7" width="98">TELEFON</td>
            </tr>
            <tr height="34" style="mso-height-source:userset;height:25.5pt">
                <td class="auto-style8" height="34" width="128">YÖNETİM KURULU BAŞK.</td>
                <td class="auto-style9" width="153">MÜCAHİT YILDIZ</td>
                <td class="auto-style10" width="80">SANCAKTEPE</td>
                <td class="auto-style11" width="101">&nbsp;</td>
                <td class="auto-style12" width="582">GRUBUMUZUN İŞLEYİŞİYLE İLGİLİ BİRİMLERCE SONUÇLANMAYAN TÜM KONULARDA</td>
                <td class="auto-style13" style="text-underline-style: single;" width="122"><a href="mailto:my@sultanlar.com.tr"><span style="font-size:8.0pt">my@sultanlar.com.tr</span></a></td>
                <td class="auto-style14">&nbsp;</td>
            </tr>
            <tr height="15" style="mso-height-source:userset;height:11.25pt">
                <td class="auto-style15" height="15" width="128">&nbsp;</td>
                <td class="auto-style16" width="153">&nbsp;</td>
                <td class="auto-style17" width="80">&nbsp;</td>
                <td class="auto-style18" width="101">&nbsp;</td>
                <td class="auto-style19" width="582">&nbsp;</td>
                <td class="auto-style20" style="text-underline-style: single;" width="122"><u style="visibility:hidden;mso-ignore:visibility">&nbsp;</u></td>
                <td></td>
            </tr>
            <tr height="34" style="mso-height-source:userset;height:25.5pt">
                <td class="auto-style8" height="34" width="128">GENEL MÜDÜR</td>
                <td class="auto-style9" width="153">HALUK KÖSEOĞLU</td>
                <td class="auto-style10" width="80">KURTKÖY</td>
                <td align="right" class="auto-style11" width="101">10.06.2020</td>
                <td class="auto-style12" width="582">SATIŞ VE ORGANİZASYONUN TAMAMINDAN SORUMLU GENEL MÜDÜR</td>
                <td class="auto-style13" style="text-underline-style: single;" width="122"><a href="mailto:halukkoseoglu@tibet.com.tr"><span style="font-size:8.0pt">halukkoseoglu@tibet.com.tr</span></a></td>
                <td class="auto-style21" width="98">0216 595 05 00</td>
            </tr>
            <tr height="15" style="mso-height-source:userset;height:11.25pt">
                <td class="auto-style15" height="15" width="128">&nbsp;</td>
                <td class="auto-style16" width="153">&nbsp;</td>
                <td class="auto-style17" width="80">&nbsp;</td>
                <td class="auto-style18" width="101">&nbsp;</td>
                <td class="auto-style19" width="582">&nbsp;</td>
                <td class="auto-style20" style="text-underline-style: single;" width="122"><u style="visibility:hidden;mso-ignore:visibility">&nbsp;</u></td>
                <td></td>
            </tr>
            <tr height="35" style="height:26.25pt">
                <td class="auto-style22" height="35" width="128">TÜRKİYE SATIŞ MÜDÜRÜ</td>
                <td class="auto-style9" width="153">ŞEBNEM ÖNKAPTAN</td>
                <td class="auto-style10" width="80">SANCAKTEPE-KURTKÖY</td>
                <td align="right" class="auto-style11" width="101">1.10.2020</td>
                <td class="auto-style12" width="582">SATIŞIN İŞLEYİŞİLİ İLGİLİ SONUÇLANMAYAN, ÇÖZÜMSÜZ KALAN TÜM KONULARDA SATIŞ MÜDÜRÜ</td>
                <td class="auto-style13" style="text-underline-style: single;" width="122"><a href="mailto:sebnemonkaptan@tibet.com.tr"><span style="font-size:8.0pt">sebnemonkaptan@tibet.com.tr</span></a></td>
                <td class="auto-style21" width="98">0216 561 50 00</td>
            </tr>
            <tr height="21" style="height:15.75pt">
                <td class="auto-style23" height="21" width="128">&nbsp;</td>
                <td class="auto-style9" width="153">&nbsp;</td>
                <td class="auto-style10" width="80">&nbsp;</td>
                <td class="auto-style11" width="101">&nbsp;</td>
                <td class="auto-style12" width="582">&nbsp;</td>
                <td class="auto-style13" style="text-underline-style: single;" width="122"><u style="visibility:hidden;mso-ignore:visibility">&nbsp;</u></td>
                <td class="auto-style21" width="98">&nbsp;</td>
            </tr>
            <tr height="34" style="mso-height-source:userset;height:25.5pt">
                <td class="auto-style8" height="34" width="128">DENETİM MD.</td>
                <td class="auto-style9" width="153">ALİ SAYIN</td>
                <td class="auto-style10" width="80">SANCAKTEPE</td>
                <td align="right" class="auto-style11" width="101">20.03.2019</td>
                <td class="auto-style12" width="582">YÖNETİME BAĞLI OLARAK TÜM SATIŞ SÜREÇLERİNİN DENETLENMESİ RAPORLANMASI</td>
                <td class="auto-style13" style="text-underline-style: single;" width="122"><a href="mailto:asayin@sultanlar.com.tr"><span style="font-size:8.0pt">asayin@sultanlar.com.tr</span></a></td>
                <td class="auto-style21" width="98">0533 699 78 18 - 0216 561 50 00</td>
            </tr>
            <tr height="13" style="mso-height-source:userset;height:9.75pt">
                <td class="auto-style24" height="13" width="128">&nbsp;</td>
                <td class="auto-style16" width="153">&nbsp;</td>
                <td class="auto-style17" width="80">&nbsp;</td>
                <td class="auto-style18" width="101">&nbsp;</td>
                <td class="auto-style19" width="582">&nbsp;</td>
                <td class="auto-style20" style="text-underline-style: single;" width="122"><u style="visibility:hidden;mso-ignore:visibility">&nbsp;</u></td>
                <td></td>
            </tr>
            <tr height="35" style="height:26.25pt">
                <td class="auto-style22" height="35" width="128">EDT SATIŞ MÜDÜRÜ</td>
                <td class="auto-style9" width="153">İSMET ARPAGUŞ</td>
                <td class="auto-style10" width="80">KURTKÖY</td>
                <td align="right" class="auto-style11" width="101">1.01.2014</td>
                <td class="auto-style12" width="582">TİBTRAP-FULNET ENDÜSTRİYEL ÜRÜNLER YÖNETİCİSİ ÜRÜNLE İLGİLİ SORUNLAR MAİL YOLUYLA</td>
                <td class="auto-style13" style="text-underline-style: single;" width="122"><a href="mailto:iarpagus@tibet.com.tr"><span style="font-size:8.0pt">ismetarpagus@tibet.com.tr</span></a></td>
                <td class="auto-style21" width="98">0533 699 78 08 - 0216 595 05 00</td>
            </tr>
            <tr height="18" style="mso-height-source:userset;height:13.5pt">
                <td class="auto-style25" height="18" width="128"></td>
                <td class="auto-style26" width="153"></td>
                <td class="auto-style27" width="80"></td>
                <td class="auto-style28" width="101"></td>
                <td class="auto-style29" width="582"></td>
                <td class="auto-style30" style="text-underline-style: single;" width="122"></td>
                <td class="auto-style31" width="98"></td>
            </tr>
            <tr height="35" style="height:26.25pt">
                <td class="auto-style32" height="526" rowspan="11" width="128">PAZARLAMA</td>
                <td class="auto-style33" width="153">SALİH BIÇAK</td>
                <td class="auto-style34" width="80">KURTKÖY</td>
                <td align="right" class="auto-style35" width="101">1.07.2020</td>
                <td class="auto-style36" width="582">PAZARLAMA MÜDÜRÜ: TÜM MARKALARIN VE ÜRÜNLERİN MARKA- PAZARLAMA FAALİYETLERİNİ YÖNETMEKTEDİR. MAİL YOLUYLA İLETİŞİM</td>
                <td class="auto-style37" style="text-underline-style: single;" width="122"><a href="mailto:salihbicak@tibet.com.tr"><span style="font-size:8.0pt">salihbicak@tibet.com.tr</span></a></td>
                <td class="auto-style38" width="98">&nbsp;</td>
            </tr>
            <tr height="34" style="height:25.5pt">
                <td class="auto-style39" height="34" width="153">DENİZ YAMAN</td>
                <td class="auto-style40" width="80">KURTKÖY</td>
                <td class="auto-style41" width="101">&nbsp;</td>
                <td class="auto-style42" width="582">PAZARLAMA MD.YARD. TÜM MARKALARIN VE ÜRÜNLERİN MARKA- PAZARLAMA FAALİYETLERİNİ YÖNETMEKTEDİR. MAİL YOLUYLA İLETİŞİM</td>
                <td class="auto-style37" style="text-underline-style: single;" width="122"><a href="mailto:denizyaman@tibet.com.tr"><span style="font-size:8.0pt">denizyaman@tibet.com.tr</span></a></td>
                <td class="auto-style43" width="98">0216 595 05 00</td>
            </tr>
            <tr height="52" style="height:39.0pt">
                <td class="auto-style44" height="52" width="153">TURGAY YILMAZ (Asist.)</td>
                <td class="auto-style40" width="80">KURTKÖY</td>
                <td align="right" class="auto-style41" width="101">1.01.2018</td>
                <td class="auto-style42" width="582">NON-FOOD ÜRÜN ASİST. PİKNİK MARKASI VE ÜRÜNLERİ İLE ALAKALI BEDELSİZ NUMUNE, STAND, P.O.P, TADIM, BELGE GİBİ TÜM TALEPLER, TÜM MARKA-PAZARLAMA FAALİYETLERİNİ YÜRÜTMEKTEDİR. MAİL YOLUYLA İLETİŞİM. SALİH BEY&#39;E CC YAPILACAK</td>
                <td class="auto-style45" style="text-underline-style: single;" width="122"><a href="mailto:turgayyilmaz@tibet.com.tr"><span style="font-size:8.0pt">turgayyilmaz@tibet.com.tr</span></a></td>
                <td class="auto-style43" width="98">0544 827 19 49<span style="mso-spacerun:yes">&nbsp;</span></td>
            </tr>
            <tr height="60" style="mso-height-source:userset;height:45.0pt">
                <td class="auto-style46" height="60" width="153">YASİN KARTAL</td>
                <td class="auto-style47" width="80">KURTKÖY</td>
                <td align="right" class="auto-style48" width="101">1.01.2014</td>
                <td class="auto-style42" width="582">GIDA ÜRÜN MÜDÜRÜ:<span style="mso-spacerun:yes">&nbsp; </span>KENTON BÜNSA MARKALARINDAN SORUMLUDUR. KENDİSİNE BAĞLI MARKALAR VE ÜRÜNLER İLE İLGİLİ TÜM MARKA-PAZARLAMA FAALİYETLERİNİ YÜRÜTMEKTEDİR. ÜRÜN GÖRSELLERİ, BEDELSİZ NUMUNE, STAND, P.O.P, TADIM, BELGE GİBİ TÜM TALEPLER, ,ÜRÜNLE İLGİLİ SORUNLAR MAİL YOLUYLA<span style="mso-spacerun:yes">&nbsp;</span></td>
                <td class="auto-style49" style="text-underline-style: single;" width="122"><a href="mailto:ykartal@tibet.com.tr"><span style="font-size:8.0pt">ykartal@tibet.com.tr</span></a></td>
                <td class="auto-style43" width="98">0530 394 53 53 -<span style="mso-spacerun:yes">&nbsp;</span></td>
            </tr>
            <tr height="68" style="height:51.0pt">
                <td class="auto-style50" height="68" width="153">CİHAN TİRİŞ (Asist.)</td>
                <td class="auto-style47" width="80">KURTKÖY</td>
                <td class="auto-style48" width="101">&nbsp;</td>
                <td class="auto-style42" width="582">KENTON BÜNSA ASİSTAN:<span style="mso-spacerun:yes">&nbsp; </span>KENTON BÜNSA MARKALARINDAN SORUMLUDUR. KENDİSİNE BAĞLI MARKALAR VE ÜRÜNLER İLE İLGİLİ TÜM MARKA-PAZARLAMA FAALİYETLERİNİ YÜRÜTMEKTEDİR. ÜRÜN GÖRSELLERİ, BEDELSİZ NUMUNE, STAND, P.O.P, TADIM, BELGE GİBİ TÜM TALEPLER, ,ÜRÜNLE İLGİLİ SORUNLAR MAİL YOLUYLA<span style="mso-spacerun:yes">&nbsp;</span></td>
                <td class="auto-style49" style="text-underline-style: single;" width="122"><a href="mailto:ctiris@tibet.com.tr"><span style="font-size:8.0pt">ctiris@tibet.com.tr</span></a></td>
                <td class="auto-style43" width="98">0536 520 56 00</td>
            </tr>
            <tr height="68" style="height:51.0pt">
                <td class="auto-style50" height="68" width="153">ŞEBNEM KIVANÇ-</td>
                <td class="auto-style47" width="80">KURTKÖY</td>
                <td class="auto-style48" width="101">&nbsp;</td>
                <td class="auto-style42" width="582">ARI MARKALI ÜRÜN MÜDÜRÜ:<span style="mso-spacerun:yes">&nbsp; </span>MARKALARINDAN SORUMLUDUR. KENDİSİNE BAĞLI MARKALAR VE ÜRÜNLER İLE İLGİLİ TÜM MARKA-PAZARLAMA FAALİYETLERİNİ YÜRÜTMEKTEDİR. ÜRÜN GÖRSELLERİ, BEDELSİZ NUMUNE, STAND, P.O.P, TADIM, BELGE GİBİ TÜM TALEPLER, ,ÜRÜNLE İLGİLİ SORUNLAR MAİL YOLU</td>
                <td class="auto-style49" style="text-underline-style: single;" width="122"><a href="mailto:sebnemkivanc@tibet.com.tr"><span style="font-size:8.0pt">sebnemkivanc@tibet.com.tr</span></a></td>
                <td class="auto-style43" width="98">0533 505 65 16 0216 595 05 00</td>
            </tr>
            <tr height="51" style="height:38.25pt">
                <td class="auto-style51" height="51" width="153">AYÇA YILMAZ (Asist.)</td>
                <td class="auto-style47" width="80">KURTKÖY</td>
                <td class="auto-style48" width="101">&nbsp;</td>
                <td class="auto-style42" width="582">ASİSTAN ARI MARKASI:<span style="mso-spacerun:yes">&nbsp; </span>ARI MARKASINDAN SORUMLUDUR. KENDİSİNE BAĞLI MARKALAR VE ÜRÜNLER İLE İLGİLİ TÜM MARKA-PAZARLAMA FAALİYETLERİNİ YÜRÜTMEKTEDİR. ÜRÜN GÖRSELLERİ, BEDELSİZ NUMUNE, STAND, P.O.P, TADIM, BELGE GİBİ TÜM TALEPLER, ,ÜRÜNLE İLGİLİ SORUNLAR MAİL YOLU</td>
                <td class="auto-style49" style="text-underline-style: single;" width="122"><a href="mailto:aycayilmaz@tibet.com.tr"><span style="font-size:8.0pt">aycayilmaz@tibet.com.tr</span></a></td>
                <td class="auto-style43" width="98">0216 595 05 00</td>
            </tr>
            <tr height="69" style="mso-height-source:userset;height:51.75pt">
                <td class="auto-style52" height="69" width="153">GÜLSUN SEDA DEMIRHAN –
                    <br />
                    TURGAY YILMAZ<br />
                    (Asist.) Temizlik (Ernet-Camsil )</td>
                <td class="auto-style40" width="80">KURTKÖY</td>
                <td align="right" class="auto-style41" width="101">1.01.2018</td>
                <td class="auto-style42" width="582">KOZMETİK TEMİZLİK ÜRÜN MÜDÜRÜ: KENDİSİNE BAĞLI MARKALAR VE ÜRÜNLER İLE İLGİLİ TÜM MARKA- PAZARLAMA FAALİYETLERİNİ YÜRÜTMEKTEDİR. ÜRÜN GÖRSELLERİ, BEDELSİZ NUMUNE, STAND, P.O.P, TADIM, BELGE GİBİ TÜM TALEPLER, ÜRÜNLE İLGİLİ SORUNLAR MAİL YOLUYLA</td>
                <td class="auto-style49" style="text-underline-style: single;" width="122"><a href="javascript:OpenNewWindow('/Mondo/lang/sys/Forms/MAI/compose.aspx?MsgTo=gulsunsedademirhan%40tibet.com.tr&amp;MsgSubject=&amp;MsgCc=&amp;MsgBcc=&amp;MsgBody=',570,450)"><span style="font-size:8.0pt">gulsunsedademirhan@tibet.com.tr<span style="mso-spacerun:yes">&nbsp;</span></span></a></td>
                <td class="auto-style43" width="98">0216 595 05 00</td>
            </tr>
            <tr height="48" style="mso-height-source:userset;height:36.0pt">
                <td class="auto-style53" height="48" width="153">BİNNUR SERT<br />
                    (Asist.) Kozmetik (Saloon)</td>
                <td class="auto-style40" width="80">KURTKÖY</td>
                <td class="auto-style48" width="101">&nbsp;</td>
                <td class="auto-style42" width="582">KOZMETİK TEMİZLİK ASİSTAN: KENDİSİNE BAĞLI MARKALAR VE ÜRÜNLER İLE İLGİLİ TÜM MARKA- PAZARLAMA FAALİYETLERİNİ YÜRÜTMEKTEDİR. ÜRÜN GÖRSELLERİ, BEDELSİZ NUMUNE, STAND, P.O.P, TADIM, BELGE GİBİ TÜM TALEPLER, ÜRÜNLE İLGİLİ SORUNLAR MAİL YOLUYLA</td>
                <td class="auto-style49" style="text-underline-style: single;" width="122"><a href="mailto:binnursert@tibet.com.tr"><span style="font-size:8.0pt">binnursert@tibet.com.tr</span></a></td>
                <td class="auto-style43" width="98">0216 595 05 00</td>
            </tr>
            <tr height="20" style="height:15.0pt">
                <td class="auto-style54" height="20" width="153">ASLI YILDIZ</td>
                <td class="auto-style47" width="80">SANCAKTEPE</td>
                <td class="auto-style48" width="101">&nbsp;</td>
                <td class="auto-style55" width="582">YÖNETİM KURULU BAŞKAN ASİSTANI SOSYAL MEDYA RAPORLAMA SEKTÖREL ARAŞTIRMA</td>
                <td class="auto-style56" style="text-underline-style: single;" width="122"><u style="visibility:hidden;mso-ignore:visibility">&nbsp;</u></td>
                <td class="auto-style57" width="98">0216 561 50 00</td>
            </tr>
            <tr height="21" style="height:15.75pt">
                <td class="auto-style58" height="21" width="153">VİLDAN YILDIZ</td>
                <td class="auto-style59" width="80">SANCAKTEPE</td>
                <td class="auto-style60" width="101">&nbsp;</td>
                <td class="auto-style61" width="582">YÖNETİM KURULU BAŞKAN ASİSTANI SOSYAL MEDYA RAPORLAMA SEKTÖREL ARAŞTIRMA</td>
                <td class="auto-style45" style="text-underline-style: single;" width="122"><u style="visibility:hidden;mso-ignore:visibility">&nbsp;</u></td>
                <td class="auto-style62" width="98">0216 561 50 00</td>
            </tr>
            <tr height="21" style="mso-height-source:userset;height:15.75pt">
                <td class="auto-style63" height="21" width="128"></td>
                <td class="auto-style26" width="153"></td>
                <td class="auto-style27" width="80"></td>
                <td class="auto-style28" width="101"></td>
                <td class="auto-style29" width="582"></td>
                <td class="auto-style30" style="text-underline-style: single;" width="122"></td>
                <td class="auto-style31" width="98"></td>
            </tr>
            <tr height="34" style="mso-height-source:userset;height:25.5pt">
                <td class="auto-style64" height="34" width="128">TİCARİ PAZARLAMA MD.</td>
                <td class="auto-style33" width="153">SELAHATTİN ŞAHİN</td>
                <td class="auto-style34" width="80">KURTKÖY</td>
                <td class="auto-style35" width="101">&nbsp;</td>
                <td class="auto-style36" width="582">TİCARİ PAZARLAMA MD: TİCARİ PAZARLAMAYLA İLGİLİ ÇÖZÜLEMEYEN KONULARDA VE MERCH ORGANİZYONUNDA OLUŞABİLECEK GENEL AKSALIKLARDA ARANACAK<span style="mso-spacerun:yes">&nbsp;</span></td>
                <td class="auto-style37" style="text-underline-style: single;" width="122"><a href="mailto:selahattinsahin@tibet.com.tr"><span style="font-size:8.0pt">selahattinsahin@tibet.com.tr&nbsp;</span></a></td>
                <td class="auto-style38" width="98">0216 595 05 00 0546 567 11 22</td>
            </tr>
            <tr height="74" style="mso-height-source:userset;height:55.5pt">
                <td class="auto-style65" height="193" rowspan="3" width="128">TİCARİ PAZARLAMA MERKEZ</td>
                <td class="auto-style66" width="153">DEMET DOĞAN</td>
                <td class="auto-style40" width="80">KURTKÖY</td>
                <td align="right" class="auto-style41" width="101">1.12.2018</td>
                <td class="auto-style42" width="582">AKTİVİTE FİYATLANDIRILMASI, ÜRÜN FİYATI VERİLMESİ, ANLAŞMA ONAYLARI MAİL YOLUYLA HİZMET FATURALARI KONTROL, FATURADA İSKONTO ÇIKMAMIŞ TALEPLERİ FATURA NUMARALARIYLA BİRLİKTE TALEP EDİLEBİLİR. MÜŞTERİMİN MALİYETİ NE KADAR, GÜNCEL FİYAT LİSTESİ , MÜŞTERİ CİRO PRİMLERİ SORULACAK, 500&#39;LÜ KODLARIN TANIMLANMASI,500&#39;LÜ GÖRÜNMEYEN FİYATLAR,MÜŞTERİ MALİYETLERİ MAİL YOLUYLA</td>
                <td class="auto-style49" style="text-underline-style: single;" width="122"><a href="mailto:demetdogan@tibet.com.tr"><span style="font-size:8.0pt">demetdogan@tibet.com.tr&nbsp;</span></a></td>
                <td class="auto-style43" width="98">0530 324 71 44 -0216 595 05 00</td>
            </tr>
            <tr height="68" style="height:51.0pt">
                <td class="auto-style67" height="68" width="153">NESLİHAN DEMİRBAŞ<br />
                    (ULUSAL ZİNCİR)</td>
                <td class="auto-style40" width="80">KURTKÖY</td>
                <td align="right" class="auto-style41" width="101">1.12.2018</td>
                <td class="auto-style42" width="582">HİZMET FATURALARI KONTROL, FATURADA İSKONTO ÇIKMAMIŞ TALEPLERİ FATURA NUMARALARIYLA BİRLİKTE TALEP EDİLEBİLİR. GÜNCEL FİYAT LİSTESİ , MÜŞTERİ CİRO PRİMLERİ SORULACAK, 500&#39;LÜ KODLARIN TANIMLANMASI,500&#39;LÜ GÖRÜNMEYEN FİYATLAR GÜNCEL ULUSAL FİYAT LİSTESİ, ULUSAL İADE FATURA TAKİBİ<span style="mso-spacerun:yes">&nbsp;</span></td>
                <td class="auto-style49" style="text-underline-style: single;" width="122"><a href="mailto:ndemirbas@tibet.com.tr"><span style="font-size:8.0pt">ndemirbas@tibet.com.tr</span></a></td>
                <td class="auto-style43" width="98">0216 595 05 00</td>
            </tr>
            <tr height="51" style="height:38.25pt">
                <td class="auto-style68" height="51" width="153">NERMİN ÇELİK</td>
                <td class="auto-style40" width="80">&nbsp;</td>
                <td class="auto-style41" width="101">&nbsp;</td>
                <td class="auto-style42" width="582">HİZMET FATURALARI KONTROL, FATURADA İSKONTO ÇIKMAMIŞ TALEPLERİ FATURA NUMARALARIYLA BİRLİKTE TALEP EDİLEBİLİR. GÜNCEL FİYAT LİSTESİ , MÜŞTERİ CİRO PRİMLERİ SORULACAK, 500&#39;LÜ KODLARIN TANIMLANMASI,500&#39;LÜ GÖRÜNMEYEN FİYATLAR GÜNCEL<span style="mso-spacerun:yes">&nbsp;</span></td>
                <td class="auto-style49" style="text-underline-style: single;" width="122"><a href="mailto:nermincelik@tibet.com.tr"><span style="font-size:8.0pt">nermincelik@tibet.com.tr</span></a></td>
                <td class="auto-style43" width="98">0216 595 05 00</td>
            </tr>
            <tr height="34" style="height:25.5pt">
                <td class="auto-style69" height="34" width="128">TİC.PAZARLAMA /ADANA</td>
                <td class="auto-style66" width="153">MEHMET GÜLEKOĞLU</td>
                <td class="auto-style40" width="80">ADANA</td>
                <td align="right" class="auto-style41" width="101">1.12.2018</td>
                <td class="auto-style42" width="582">TÜM BAYİLERİN BÜTÇE İŞLEMLERİ &nbsp;İLE İLGİLİ, BAYİ MÜŞTERİLERİN SİSTEME AKTARILMASI, BAYİ MÜŞTERİLERİNİN SİSTEMSEL SORUNLARINDA ÖNCELİKLİ ARANACAK</td>
                <td class="auto-style49" style="text-underline-style: single;" width="122"><a href="mailto:mehmetgulekoglu@tibet.com.tr"><span style="font-size:8.0pt">mehmetgulekoglu@tibet.com.tr</span></a></td>
                <td class="auto-style43" width="98">0533 957 80 34<span style="mso-spacerun:yes">&nbsp;&nbsp;</span></td>
            </tr>
            <tr height="68" style="height:51.0pt">
                <td class="auto-style70" height="68" width="128">TİC.PAZARLAMA /EGE VE GÜNEY MARMARA</td>
                <td class="auto-style66" width="153">MÜGE ÖZDEMİR</td>
                <td class="auto-style40" width="80">İZMİR</td>
                <td align="right" class="auto-style41" width="101">1.12.2018</td>
                <td class="auto-style42" width="582">AKTİVİTE FİYATLANDIRILMASI, ÜRÜN FİYATI VERİLMESİ, ANLAŞMA ONAYLARI MAİL YOLUYLA HİZMET FATURALARI KONTROL, FATURADA İSKONTO ÇIKMAMIŞ TALEPLERİ FATURA NUMARALARIYLA BİRLİKTE TALEP EDİLEBİLİR. MÜŞTERİMİN MALİYETİ NE KADAR, MÜŞTERİ CİRO PRİMLERİ SORULACAK, BÖLGE SİPARİŞ GİRİŞLERİ</td>
                <td class="auto-style49" style="text-underline-style: single;" width="122">mugeozdemir@tibet.com.tr</td>
                <td class="auto-style43" width="98">0533 957 80 32 -
                    <br />
                    0232 390 91 00</td>
            </tr>
            <tr height="52" style="height:39.0pt">
                <td class="auto-style71" height="52" width="128">TİC.PAZARLAMA /İÇ ANADOLU-KARADENİZ-G.DOĞU AND.</td>
                <td class="auto-style16" width="153">SELÇUK TONYALI</td>
                <td class="auto-style40" width="80">ANKARA</td>
                <td align="right" class="auto-style41" width="101">1.10.2018</td>
                <td class="auto-style42" width="582">AKTİVİTE FİYATLANDIRILMASI, ÜRÜN FİYATI VERİLMESİ, ANLAŞMA ONAYLARI MAİL YOLUYLA HİZMET FATURALARI KONTROL, FATURADA İSKONTO ÇIKMAMIŞ TALEPLERİ FATURA NUMARALARIYLA BİRLİKTE TALEP EDİLEBİLİR. MÜŞTERİMİN MALİYETİ NE KADAR, MÜŞTERİ CİRO PRİMLERİ SORULACAK</td>
                <td class="auto-style20" style="text-underline-style: single;" width="122">selcuktonyali@tibet.com.tr</td>
                <td class="auto-style43" width="98">0312 397 82 14
                    <br />
                    0530 320 87 12</td>
            </tr>
            <tr height="35" style="height:26.25pt">
                <td class="auto-style22" height="35" width="128">SİPARİŞ GİRİŞİ</td>
                <td class="auto-style9" width="153">TUBA POLAT</td>
                <td class="auto-style10" width="80">KURTKÖY</td>
                <td align="right" class="auto-style11" width="101">1.01.2014</td>
                <td class="auto-style12" width="582">ULUSAL, İSTANBUL VE E-TİCARET<span style="mso-spacerun:yes">&nbsp; </span>SİPARİŞ GİRİŞİ, SİPARİŞ GİRİŞİ SİPARİŞ KONTROLÜ GİBİ KONULARDA ARANACAK</td>
                <td class="auto-style13" style="text-underline-style: single;" width="122"><a href="mailto:tubapolat@tibet.com.tr"><span style="font-size:8.0pt">tubapolat@tibet.com.tr</span></a></td>
                <td class="auto-style21" width="98">0216 595 05 00</td>
            </tr>
            <tr height="21" style="height:15.75pt">
                <td class="auto-style72" height="21" width="128">&nbsp;</td>
                <td class="auto-style73" width="153">&nbsp;</td>
                <td class="auto-style74" width="80">&nbsp;</td>
                <td class="auto-style75" width="101">&nbsp;</td>
                <td class="auto-style76" width="582">&nbsp;</td>
                <td class="auto-style37" style="text-underline-style: single;" width="122"><u style="visibility:hidden;mso-ignore:visibility">&nbsp;</u></td>
                <td class="auto-style77" width="98">&nbsp;</td>
            </tr>
            <tr height="52" style="height:39.0pt">
                <td class="auto-style78" height="52" width="128">SAT.OPERASYON-RAPORLAMA-</td>
                <td class="auto-style9" width="153">YÜCEL KAVANOZ</td>
                <td class="auto-style10" width="80">SANCAKTEPE</td>
                <td align="right" class="auto-style11" width="101">1.01.2014</td>
                <td class="auto-style12" width="582">TÜM RAPORLAMALARDAN SORUMLU, SİSTEMSEL SORUNLARIN AKTARIMI, SİPARİŞ, SATIŞ KONULARINDA TEKNİK KONULARDA,<span style="mso-spacerun:yes">&nbsp; </span>HEDEF VE PRİMLERİN DÜZENLENMESİ, SATIŞ PROSEDÜRLERİ, SATIŞ OPERASYONEL TÜM İŞLERMLER VE<span style="mso-spacerun:yes">&nbsp; </span>AÇIK BARKOD LİSTELERİ DÜZENLEME,DEĞİŞİKLİĞİ İŞLEMLERİNDE ARANACAK.<span style="mso-spacerun:yes">&nbsp;</span></td>
                <td class="auto-style37" style="text-underline-style: single;" width="122"><a href="mailto:yucelk@sultanlar.com.tr"><span style="font-size:8.0pt">yucelk@sultanlar.com.tr</span></a></td>
                <td class="auto-style21" width="98">0553 235 02 30</td>
            </tr>
            <tr height="21" style="height:15.75pt">
                <td class="auto-style79" height="21" width="128">&nbsp;</td>
                <td class="auto-style73" width="153">&nbsp;</td>
                <td class="auto-style74" width="80">&nbsp;</td>
                <td class="auto-style75" width="101">&nbsp;</td>
                <td class="auto-style76" width="582">&nbsp;</td>
                <td class="auto-style37" style="text-underline-style: single;" width="122"><u style="visibility:hidden;mso-ignore:visibility">&nbsp;</u></td>
                <td class="auto-style77" width="98">&nbsp;</td>
            </tr>
            <tr height="34" style="height:25.5pt">
                <td class="auto-style64" height="34" width="128">BİLGİ İŞLEM WEB YAZILIM</td>
                <td class="auto-style33" width="153">MEHMET İSTİF</td>
                <td class="auto-style34" width="80">KURTKÖY</td>
                <td align="right" class="auto-style35" width="101">1.01.2014</td>
                <td class="auto-style36" width="582">WEB İLE İLGİLİ TÜM KONULAR , WEB SİSTEM AKSAKLILARI ÇÖZÜMÜ, <font class="font6">MAİL YOLUYLA CEVAPLANIR</font></td>
                <td class="auto-style37" style="text-underline-style: single;" width="122"><a href="mailto:mehmetistif@tibet.com.tr"><span style="font-size:8.0pt">mehmetistif@tibet.com.tr</span></a></td>
                <td class="auto-style38" width="98">0555 436 65 50</td>
            </tr>
            <tr height="35" style="height:26.25pt">
                <td class="auto-style80" height="35" width="128">BİLGİ İŞLEM DONANIM</td>
                <td class="auto-style81" width="153">NURETTİN GÜNAY</td>
                <td class="auto-style59" width="80">SANCAKTEPE</td>
                <td align="right" class="auto-style60" width="101">1.01.2014</td>
                <td class="auto-style61" width="582">BİLGİ İŞLEM MD. BİLGİSAYAR DONANIMLARI, TELEFON YAZILIMI HAKKINDAKİ KONULARDA MAİL YADA TELEFON YOLUYLA CEVAPLANIR</td>
                <td class="auto-style45" style="text-underline-style: single;" width="122"><a href="mailto:ngunay@sultanlar.com.tr"><span style="font-size:8.0pt">ngunay@sultanlar.com.tr</span></a></td>
                <td class="auto-style62" width="98">0533 141 32 41</td>
            </tr>
            <tr height="20" style="height:15.0pt">
                <td class="auto-style82" height="20" width="128">&nbsp;</td>
                <td class="auto-style16" width="153">&nbsp;</td>
                <td class="auto-style17" width="80">&nbsp;</td>
                <td class="auto-style18" width="101">&nbsp;</td>
                <td class="auto-style19" width="582">&nbsp;</td>
                <td class="auto-style20" style="text-underline-style: single;" width="122"><u style="visibility:hidden;mso-ignore:visibility">&nbsp;</u></td>
                <td class="auto-style83" width="98">&nbsp;</td>
            </tr>
            <tr height="36" style="mso-height-source:userset;height:27.0pt">
                <td class="auto-style84" height="88" rowspan="2" width="128">LOJİSTİK</td>
                <td class="auto-style66" width="153">SİNAN YUTSEVER</td>
                <td class="auto-style40" width="80">KURTKÖY</td>
                <td align="right" class="auto-style41" width="101">1.01.2014</td>
                <td class="auto-style42" width="582">BAYİ SİPARİŞLERİ, ÜRÜNLER TESLİM EDİLMEMİŞ, EKSİK TESLİM EDİLMİŞ GİBİ LOJİSTİK KONULARI, ÜRÜN MÜŞTERİYE GİTMEDİ FATURA GİTTİ. HAMMALİYE FATULARI LOJİSİK İLE İLGİLİ KONULARDA ARANACAK</td>
                <td class="auto-style49" style="text-underline-style: single;" width="122"><a href="mailto:syurtsever@tibet.com.tr"><span style="font-size:8.0pt">syurtsever@tibet.com.tr</span></a></td>
                <td class="auto-style43" width="98">0530 320 67 20- 0216 595 05 00</td>
            </tr>
            <tr height="52" style="height:39.0pt">
                <td class="auto-style85" height="52" width="153">ERTUĞRUL DUYSAK<span style="mso-spacerun:yes">&nbsp; </span>- MURAT FETTAH</td>
                <td class="auto-style59" width="80">KURTKÖY</td>
                <td align="right" class="auto-style60" width="101">1.01.2014</td>
                <td class="auto-style61" width="582">YANLIŞ KESİLEN FATURALARDA ÖNCELİKLİ ARANMALI, FATURA GERİ DÖNÜŞLERİ ÜRÜNLERİ KİM TESLİM ALMIŞ GİBİ SORULARA CEVAP ALINABİLİR. İRSALİYE OLAN FATURA GÖRÜNTÜLERİ, SEVKİYAT ŞOFÖRÜNE TELEFON İLE ULAŞILAMADIĞINDAN, ÜRÜNLER SEVKİYATA ÇIKTIMI SORULARIDAN ARANACAK</td>
                <td class="auto-style45" style="text-underline-style: single;" width="122"><a href="mailto:mfettah@tibet.com.tr"><span style="font-size:8.0pt">ertugrulduysak@tibet.com.tr mfettah@tibet.com.tr</span></a></td>
                <td class="auto-style62" width="98">0530 370 61 73- 0532 769 81 12<span style="mso-spacerun:yes">&nbsp;&nbsp;&nbsp; </span>0216 595 05 00</td>
            </tr>
            <tr height="21" style="mso-height-source:userset;height:15.75pt">
                <td class="auto-style63" height="21" width="128"></td>
                <td class="auto-style26" width="153"></td>
                <td class="auto-style27" width="80"></td>
                <td class="auto-style28" width="101"></td>
                <td class="auto-style29" width="582"></td>
                <td class="auto-style30" style="text-underline-style: single;" width="122"></td>
                <td class="auto-style31" width="98"></td>
            </tr>
            <tr height="40" style="mso-height-source:userset;height:30.0pt">
                <td class="auto-style86" height="172" rowspan="4" width="128">MALİ İŞLER</td>
                <td class="auto-style33" width="153">GÖKHAN ÇELİK</td>
                <td class="auto-style34" width="80">KURTKÖY</td>
                <td align="right" class="auto-style35" width="101">1.01.2014</td>
                <td class="auto-style36" width="582">MUHASEBE MÜDÜRÜ BİRİM PERSONELLERİNE ULAŞILAMADIĞINDA , AVUKATLIK MÜŞTERİLER İLE İLGİLİ BİLGİ VERİLECEK</td>
                <td class="auto-style13" style="text-underline-style: single;" width="122"><a href="mailto:gokhancelik@tibet.com.tr"><span style="font-size:8.0pt">gokhancelik@tibet.com.tr</span></a></td>
                <td class="auto-style38" width="98">0530 825 19 80- 0216 595 05 00</td>
            </tr>
            <tr height="40" style="mso-height-source:userset;height:30.0pt">
                <td class="auto-style87" height="40" width="153">EMRULLAH SAGUN</td>
                <td class="auto-style40" width="80">KURTKÖY</td>
                <td align="right" class="auto-style41" width="101">1.01.2018</td>
                <td class="auto-style61" width="582">MASRAFLARIN İŞLENMESİ, YOL MASRAFLARI VE DİĞER MASRAFLAR</td>
                <td class="auto-style13" style="text-underline-style: single;" width="122"><a href="mailto:emrullahsagun@tibet.com.tr"><span style="font-size:8.0pt">emrullahsagun@tibet.com.tr</span></a></td>
                <td class="auto-style38" width="98">0216 595 05 00</td>
            </tr>
            <tr height="40" style="mso-height-source:userset;height:30.0pt">
                <td class="auto-style88" height="40" width="153">EYÜP SERTKAYA</td>
                <td class="auto-style40" width="80">KURTKÖY</td>
                <td align="right" class="auto-style41" width="101">1.01.2020</td>
                <td class="auto-style42" width="582">E-FATURALAR KONUSUNDA TÜM SORUNLARDA ÖNCELLİKLİ ARANACAK.</td>
                <td class="auto-style13" style="text-underline-style: single;" width="122"><a href="mailto:eyupsertkaya@tibet.com.tr"><span style="font-size:8.0pt">eyupsertkaya@tibet.com.tr</span></a></td>
                <td class="auto-style62" width="98">0216 595 05 00</td>
            </tr>
            <tr height="52" style="mso-height-source:userset;height:39.0pt">
                <td class="auto-style89" height="52" width="153">ZEHRA AKGÜL</td>
                <td class="auto-style47" width="80">KURTKÖY</td>
                <td align="right" class="auto-style48" width="101">1.05.2016</td>
                <td class="auto-style55" width="582">TÜM İADE VE MÜŞTERİ HİZMET FATURALARININ İŞLENMESİ, TAKİBİ GERİ DÖNÜŞLERİ. İSKONTO ÇIKMAMIŞLAR TİC.PAZ. TARAFINDAN BELİRLENDİKTEN SONRA MÜŞTERİYE FAT.GERİ DÖNÜŞÜ YAPAR. E-FATURALAR MÜŞTERİDE GÖZÜKMÜYOR SORULARI İÇİN.<span style="mso-spacerun:yes">&nbsp; </span>İMHA FATURALARI,BABS İÇİN ARAYANLARA CEVAP VERİLMESİ</td>
                <td class="auto-style56" style="text-underline-style: single;" width="122"><a href="mailto:zehraakgul@tibet.com.tr"><span style="font-size:8.0pt">zehraakgul@tibet.com.tr</span></a></td>
                <td class="auto-style57" width="98">0216 595 05 00</td>
            </tr>
            <tr height="33" style="mso-height-source:userset;height:24.75pt">
                <td class="auto-style90" height="33" width="128">İADE KABUL</td>
                <td class="auto-style9" width="153">MAHMUT AKDOĞAN</td>
                <td class="auto-style10" width="80">KURTKÖY</td>
                <td class="auto-style11" width="101">&nbsp;</td>
                <td class="auto-style12" width="582">HER TÜRLÜ İADE İŞLEMLERİ (NEDEN DÜŞÜLMEDİ VS.) İADELER İLE İLGİLİ TÜM AŞAMLAR İÇİN ÖNCELİKLİ ARANACAK</td>
                <td class="auto-style13" style="text-underline-style: single;" width="122"><a href="mailto:mahmutakdogan@tibet.com.tr"><span style="font-size:8.0pt">mahmutakdogan@tibet.com.tr</span></a></td>
                <td class="auto-style21" width="98">0537 287 47 86 0216 595 05 00</td>
            </tr>
            <tr height="21" style="mso-height-source:userset;height:15.75pt">
                <td class="auto-style63" height="21" width="128"></td>
                <td class="auto-style26" width="153"></td>
                <td class="auto-style27" width="80"></td>
                <td class="auto-style28" width="101"></td>
                <td class="auto-style29" width="582"></td>
                <td class="auto-style30" style="text-underline-style: single;" width="122"></td>
                <td class="auto-style31" width="98"></td>
            </tr>
            <tr height="21" style="mso-height-source:userset;height:15.75pt">
                <td class="auto-style91" height="150" rowspan="6" width="128">FİNANS</td>
                <td class="auto-style92" width="153">HÜSEYİN GÜZELKAYA</td>
                <td class="auto-style40" width="80">KURTKÖY</td>
                <td class="auto-style35" width="101">&nbsp;</td>
                <td class="auto-style36" width="582">MÜDÜR,FİNANS MÜDÜRÜ</td>
                <td class="auto-style49" style="text-underline-style: single;" width="122"><a href="mailto:hguzelkaya@tibet.com.tr"><span style="font-size:8.0pt">hguzelkaya@tibet.com.tr</span></a></td>
                <td class="auto-style93" width="98">0216 595 05 00</td>
            </tr>
            <tr height="34" style="height:25.5pt">
                <td class="auto-style94" height="34" width="153">İSMAİL DERECİ</td>
                <td class="auto-style40" width="80">KURTKÖY</td>
                <td align="right" class="auto-style41" width="101">1.01.2014</td>
                <td class="auto-style42" width="582">ŞEF, FİNANS İLE İLGİLİ ÖNCELİKLİ SORUMLU<span style="mso-spacerun:yes">&nbsp;</span></td>
                <td class="auto-style49" style="text-underline-style: single;" width="122"><a href="mailto:ismaildereci@tibet.com.tr"><span style="font-size:8.0pt">ismaildereci@tibet.com.tr</span></a></td>
                <td class="auto-style93" width="98">0536 239 99 22 - 0216 595 05 00</td>
            </tr>
            <tr height="20" style="height:15.0pt">
                <td class="auto-style95" height="20" width="153">FATİH AKSU</td>
                <td class="auto-style40" width="80">KURTKÖY</td>
                <td align="right" class="auto-style41" width="101">1.04.2020</td>
                <td class="auto-style42" width="582">FİNANS ELEMANI, MAİL ORDER,<span style="mso-spacerun:yes">&nbsp; </span>ÇEKLERİN SİSTEME İŞLENMESİ, MAİL VEYA TELEFON İLETİŞİME GEÇİLECEK</td>
                <td class="auto-style49" style="text-underline-style: single;" width="122"><a href="mailto:fatihaksu@tibet.com.tr"><span style="font-size:8.0pt">fatihaksu@tibet.com.tr</span></a></td>
                <td class="auto-style93" width="98">0216 595 05 00</td>
            </tr>
            <tr height="20" style="height:15.0pt">
                <td class="auto-style95" height="20" width="153">ALİ KARADAĞ</td>
                <td class="auto-style40" width="80">KURTKÖY</td>
                <td align="right" class="auto-style41" width="101">1.01.2014</td>
                <td class="auto-style42" width="582">FİNANS ELEMANI, MAİL VEYA TELEFON İLETİŞİME GEÇİLECEK</td>
                <td class="auto-style49" style="text-underline-style: single;" width="122"><a href="mailto:akaradag@tibet.com.tr"><span style="font-size:8.0pt">akaradag@tibet.com.tr</span></a></td>
                <td class="auto-style93" width="98">0216 595 05 00</td>
            </tr>
            <tr height="34" style="height:25.5pt">
                <td class="auto-style94" height="34" width="153">HATİCE ZIVALI</td>
                <td class="auto-style40" width="80">KURTKÖY</td>
                <td class="auto-style41" width="101">&nbsp;</td>
                <td class="auto-style42" width="582">NAKİT TAHSİLATIN İŞLENMESİ - MÜŞTERİDEN GELEN HAVALE İSTANBUL EKİBİ TAHSİLAT MAKBUZU TEMİNİ VE DİĞER GÖREVLERİ</td>
                <td class="auto-style49" style="text-underline-style: single;" width="122"><a href="mailto:hzivali@sultanlar.com.tr"><span style="font-size:8.0pt">hzivali@sultanlar.com.tr</span></a></td>
                <td class="auto-style93" width="98">0216 595 05 00</td>
            </tr>
            <tr height="21" style="height:15.75pt">
                <td class="auto-style96" height="21" width="153">GÜLZADE YAR</td>
                <td class="auto-style59" width="80">KURTKÖY</td>
                <td class="auto-style60" width="101">&nbsp;</td>
                <td class="auto-style61" width="582">TAHSİLATLARIN KAPAMA İŞLEMLERİ VE DİĞER GÖREVLER</td>
                <td class="auto-style45" style="text-underline-style: single;" width="122"><a href="mailto:satis@sultanlar.com.tr"><span style="font-size:8.0pt">satis@sultanlar.com.tr</span></a></td>
                <td class="auto-style97" width="98">0216 595 05 00</td>
            </tr>
            <tr height="21" style="height:15.75pt">
                <td class="auto-style63" height="21" width="128"></td>
                <td class="auto-style26" width="153"></td>
                <td class="auto-style27" width="80"></td>
                <td class="auto-style28" width="101"></td>
                <td class="auto-style29" width="582"></td>
                <td class="auto-style30" style="text-underline-style: single;" width="122"></td>
                <td class="auto-style31" width="98"></td>
            </tr>
            <tr height="38" style="mso-height-source:userset;height:28.5pt">
                <td class="auto-style98" height="38" width="128">İDARİ İŞLER</td>
                <td class="auto-style33" width="153">AHMET FETTAH</td>
                <td class="auto-style34" width="80">KURTKÖY</td>
                <td align="right" class="auto-style35" width="101">1.01.2016</td>
                <td class="auto-style36" width="582">İDARİ İŞLER MÜDÜR</td>
                <td class="auto-style37" style="text-underline-style: single;" width="122"><a href="mailto:afettah@tibet.com.tr"><span style="font-size:8.0pt">afettah@tibet.com.tr</span></a></td>
                <td class="auto-style38" width="98">0533 699 78 56 -0216 595 05 00</td>
            </tr>
            <tr height="38" style="mso-height-source:userset;height:28.5pt">
                <td class="auto-style99" height="38" width="128">İDARİ İŞLER</td>
                <td class="auto-style66" width="153">MUHSİN HUT</td>
                <td class="auto-style40" width="80">KURTKÖY</td>
                <td align="right" class="auto-style41" width="101">1.01.2017</td>
                <td class="auto-style42" width="582">İDARİ İŞLER KONULARINDA<font class="font6"> ÖNCELİKLİ ARANACAK. </font><font class="font7">ARAÇ SORUNLARI GİBİ KONULAR</font></td>
                <td class="auto-style49" style="text-underline-style: single;" width="122"><a href="mailto:muhsinhut@tibet.com.tr"><span style="font-size:8.0pt">muhsinhut@tibet.com.tr</span></a></td>
                <td class="auto-style43" width="98">0532 318 45 44 -0216 595 05 00</td>
            </tr>
            <tr height="38" style="mso-height-source:userset;height:28.5pt">
                <td class="auto-style99" height="38" width="128">İDARİ İŞLER</td>
                <td class="auto-style66" width="153">ZEKİ ÜNAL -YELİZ TOPAL</td>
                <td class="auto-style34" width="80">SANCAKTEPE</td>
                <td align="right" class="auto-style35" width="101">1.01.2014</td>
                <td class="auto-style42" width="582">YEMEK ÇEKLERİ-YOL ÜCRETLERİ- (<font class="font6">MARKET LİDERLERİ</font><font class="font5">) TELEFON HAT SORUNLARI-İNTERNET AZALMASIYLA İLGİLİ SORUN YAŞANDIĞINDA ARANACAK.</font></td>
                <td class="auto-style45" style="text-underline-style: single;" width="122"><a href="mailto:zunal@sultanlar.com.tr"><span style="font-size:8.0pt">zunal@sultanlar.com.tr</span></a></td>
                <td class="auto-style43" width="98">0543 441 24 36</td>
            </tr>
            <tr height="16" style="mso-height-source:userset;height:12.0pt">
                <td class="auto-style100" height="16" width="128">&nbsp;</td>
                <td class="auto-style16" width="153">&nbsp;</td>
                <td class="auto-style17" width="80">&nbsp;</td>
                <td class="auto-style18" width="101">&nbsp;</td>
                <td class="auto-style19" width="582">&nbsp;</td>
                <td class="auto-style20" style="text-underline-style: single;" width="122"><u style="visibility:hidden;mso-ignore:visibility">&nbsp;</u></td>
                <td class="auto-style83" width="98">&nbsp;</td>
            </tr>
            <tr height="39" style="mso-height-source:userset;height:29.25pt">
                <td class="auto-style101" height="91" rowspan="2" width="128">İNSAN KAYNAKLARI</td>
                <td class="auto-style33" width="153">ŞEREF TUNA -<span style="mso-spacerun:yes">&nbsp; </span>ADNAN NARAT</td>
                <td class="auto-style34" width="80">SANCAKTEPE</td>
                <td align="right" class="auto-style35" width="101">1.01.2016</td>
                <td class="auto-style36" width="582">ÖDÜL BİLGİLERİ, SGK İLE İLGİLİ BİLGİLER</td>
                <td class="auto-style37" style="text-underline-style: single;" width="122"><a href="mailto:stuna@tibet.com.tr;anarat@tibet.com.tr"><span style="font-size:
  8.0pt">stuna@tibet.com.tr;anarat@tibet.com.tr</span></a></td>
                <td class="auto-style38" width="98">0216 595 05 00</td>
            </tr>
            <tr height="52" style="height:39.0pt">
                <td class="auto-style85" height="52" width="153">MUHARREM GÜNDOĞDU -<span style="mso-spacerun:yes">&nbsp;&nbsp;&nbsp; </span>YASEMİN NARAT-YASEMİN YÜCEALAN-İREM YILMAZ</td>
                <td class="auto-style59" width="80">SANCAKTEPE</td>
                <td align="right" class="auto-style60" width="101">1.01.2014</td>
                <td class="auto-style61" width="582">ÖZLÜK HAKLARI BİLGİSİ, İZİNLER İLE İLGİLİ TALEPLER, YEMEK ÜCRETLERİ, YAKA KARTLARI, TŞÖRT TALEPLERİ, RESMİ TATİL GÜNLERİ BİLDİRİMLERİ</td>
                <td class="auto-style45" style="text-underline-style: single;" width="122"><a href="mailto:yyucalan@tibet.com.tr;mgundogdu@tibet.com.tr;ynarat@tibet.com.tr"><span style="font-size:8.0pt">yyucalan@tibet.com.tr;mgundogdu@tibet.com.tr;ynarat@tibet.com.tr</span></a></td>
                <td class="auto-style62" width="98">0216 595 05 00</td>
            </tr>
            <tr height="21" style="height:15.75pt">
                <td class="auto-style63" height="21" width="128"></td>
                <td class="auto-style26" width="153"></td>
                <td class="auto-style27" width="80"></td>
                <td class="auto-style28" width="101"></td>
                <td class="auto-style29" width="582"></td>
                <td class="auto-style30" style="text-underline-style: single;" width="122"></td>
                <td class="auto-style31" width="98"></td>
            </tr>
            <tr height="68" style="height:51.0pt">
                <td class="auto-style102" height="68" width="128">İADE FİYATLAMA, MÜŞTERİ AÇILIŞI,RUT<span style="mso-spacerun:yes">&nbsp; </span>PLANLAMA</td>
                <td class="auto-style33" width="153">FAHRETTİN KAYA</td>
                <td class="auto-style34" width="80">SANCAKTEPE</td>
                <td align="right" class="auto-style35" width="101">1.01.2014</td>
                <td class="auto-style36" width="582">İADE FİYATLANDIRMA, YENİ MÜŞTERİ VE ŞUBE AÇILIŞLARI, MÜŞTERİ BLOKAJA ALMA - MÜŞTERİ BLOKAJI AÇMA YÖNETİCİ ONAYLI, HALK GÜNLERİNİN TANIMLANMASI MAİL YOLUYLA İLETİŞİM RUT İLE İLGİLİ İŞLEMLER ADRES DEĞİŞİKLERİ MAİL OLARAK YÖN.ONAYLI, RUT GİRİŞ ÇIKIŞINLARINDA İZİNLERDE BİLGİ VERİLMELİ</td>
                <td class="auto-style37" style="text-underline-style: single;" width="122"><a href="mailto:fkaya@sultanlar.com.tr"><span style="font-size:8.0pt">fkaya@sultanlar.com.tr</span></a></td>
                <td class="auto-style38" width="98">0554 349 65 65- 0216 561 50 00</td>
            </tr>
            <tr height="31" style="mso-height-source:userset;height:23.25pt">
                <td class="auto-style103" height="31" width="128">MUTABAKAT</td>
                <td class="auto-style66" width="153">TÜMAY İLBEYLİ</td>
                <td class="auto-style40" width="80">SANCAKTEPE</td>
                <td align="right" class="auto-style41" width="101">1.02.2016</td>
                <td class="auto-style42" width="582">MUTABAKAT YAPILMASI</td>
                <td class="auto-style49" style="text-underline-style: single;" width="122"><a href="mailto:tilbeyli@sultanlar.com.tr"><span style="font-size:8.0pt">tilbeyli@sultanlar.com.tr</span></a></td>
                <td class="auto-style43" width="98">0532 377 85 02 -0216 561 50 00</td>
            </tr>
            <tr height="53" style="mso-height-source:userset;height:39.75pt">
                <td class="auto-style104" height="53" width="128">MÜŞTERİ İLİŞKİLERİ MOBİL RUT</td>
                <td class="auto-style81" width="153">İBRAHİM BAĞDATLI</td>
                <td class="auto-style59" width="80">SANCAKTEPE</td>
                <td align="right" class="auto-style60" width="101">1.02.2016</td>
                <td class="auto-style61" width="582">MÜŞTERİLERİMİZİN, ŞİRKETİMİZİN İŞ YAPIŞ ŞEKLİYLE İLGİLİ ŞİKAYET VE ÖNERİLERİ. (sikayetkutusu@sultanlar.com.tr)MOBİL RUT RAPORU. RUT GİRİŞ ÇIKIŞ KONTROLERİNDE SORUN OLDUMU SORULACAK. RUT GİRİŞ HATALARINDA İZİNLERDE BİLGİ VERİLMELİ</td>
                <td class="auto-style45" style="text-underline-style: single;" width="122"><a href="mailto:ibagdatli@sutanlar.com.tr"><span style="font-size:8.0pt">ibagdatli@sutanlar.com.tr</span></a></td>
                <td class="auto-style97" width="98">0533 498 35 65</td>
            </tr>
            <tr height="53" style="mso-height-source:userset;height:39.75pt">
                <td class="auto-style104" height="53" width="128">E-TİCARET</td>
                <td class="auto-style81" width="153">ÖZGÜR KAR</td>
                <td class="auto-style59" width="80">SANCAKTEPE</td>
                <td class="auto-style60" width="101">&nbsp;</td>
                <td class="auto-style61" width="582">E-TİCARET İLE İLGİLİ TÜM İŞLEYİŞ İLE İLGİLİ SORUMLU</td>
                <td class="auto-style13" style="text-underline-style: single;" width="122"><a href="mailto:okar@sultanlar.com.tr"><span style="font-size:8.0pt">okar@sultanlar.com.tr</span></a></td>
                <td class="auto-style97" width="98">0533 495 35 12</td>
            </tr>
        </table>
        </body>
</html>
