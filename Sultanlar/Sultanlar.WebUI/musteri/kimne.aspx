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
.font5
	{color:black;
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
        .auto-style1 {
            height: 43.5pt;
            width: 96pt;
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
            width: 86pt;
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
            width: 89pt;
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
            width: 464pt;
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
            width: 110pt;
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
            width: 74pt;
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
        .auto-style7 {
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
        .auto-style8 {
            width: 86pt;
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
            width: 89pt;
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
            width: 464pt;
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
            width: 110pt;
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
        .auto-style12 {
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
        .auto-style13 {
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
        .auto-style14 {
            width: 86pt;
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
        .auto-style15 {
            width: 89pt;
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
        .auto-style16 {
            width: 464pt;
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
            width: 110pt;
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
        .auto-style18 {
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
        .auto-style19 {
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
        .auto-style20 {
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
        .auto-style21 {
            width: 86pt;
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
        .auto-style22 {
            width: 89pt;
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
        .auto-style23 {
            width: 464pt;
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
        .auto-style24 {
            width: 110pt;
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
        .auto-style25 {
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
        .auto-style26 {
            height: 204.75pt;
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
        .auto-style27 {
            width: 86pt;
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
        .auto-style28 {
            width: 89pt;
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
        .auto-style29 {
            width: 464pt;
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
        .auto-style30 {
            width: 110pt;
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
        .auto-style32 {
            height: 38.25pt;
            width: 86pt;
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
        .auto-style33 {
            width: 89pt;
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
        .auto-style34 {
            width: 464pt;
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
        .auto-style35 {
            width: 110pt;
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
        .auto-style36 {
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
        .auto-style37 {
            height: 25.5pt;
            width: 86pt;
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
        .auto-style38 {
            height: 38.25pt;
            width: 86pt;
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
        .auto-style39 {
            width: 89pt;
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
        .auto-style40 {
            height: 39.0pt;
            width: 86pt;
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
        .auto-style42 {
            height: 102.0pt;
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
        .auto-style43 {
            width: 86pt;
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
        .auto-style44 {
            height: 51.0pt;
            width: 86pt;
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
        .auto-style46 {
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
            border-top: .5pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style47 {
            width: 86pt;
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
        .auto-style48 {
            width: 89pt;
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
        .auto-style49 {
            width: 464pt;
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
        .auto-style50 {
            width: 110pt;
            color: blue;
            font-size: 11.0pt;
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
        .auto-style51 {
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
        .auto-style52 {
            width: 86pt;
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
        .auto-style53 {
            width: 464pt;
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
            width: 110pt;
            color: blue;
            font-size: 11.0pt;
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
        .auto-style55 {
            height: 38.25pt;
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
        .auto-style56 {
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
        .auto-style57 {
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
            border-bottom: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style58 {
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
        .auto-style59 {
            width: 86pt;
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
        .auto-style60 {
            width: 89pt;
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
        .auto-style61 {
            width: 464pt;
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
            border-top: 1.0pt solid windowtext;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style63 {
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
        .auto-style64 {
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
        .auto-style65 {
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
        .auto-style66 {
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
        .auto-style67 {
            width: 110pt;
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
        .auto-style68 {
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
        .auto-style69 {
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
        .auto-style70 {
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
        .auto-style71 {
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
        .auto-style72 {
            height: 39.0pt;
            width: 86pt;
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
        .auto-style73 {
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
        .auto-style74 {
            height: 30.0pt;
            width: 86pt;
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
        .auto-style75 {
            width: 110pt;
            color: blue;
            font-size: 11.0pt;
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
            border-bottom: 1.0pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style76 {
            height: 30.0pt;
            width: 86pt;
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
        .auto-style77 {
            height: 22.5pt;
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
        .auto-style78 {
            height: 41.25pt;
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
        .auto-style79 {
            height: 15.75pt;
            width: 86pt;
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
            border-bottom: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style81 {
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
            border-left: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style82 {
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
            height: 77.25pt;
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
        .auto-style84 {
            height: 51.75pt;
            width: 86pt;
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
        .auto-style85 {
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
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style86 {
            height: 38.25pt;
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
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style87 {
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
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style88 {
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
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style89 {
            height: 39.75pt;
            width: 96pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: left;
            vertical-align: top;
            white-space: normal;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style90 {
            width: 74pt;
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
    <body runat="server">
        <table border="0" cellpadding="0" cellspacing="0" style="border-collapse:
 collapse;width:919pt" width="1225">
            <colgroup>
                <col style="mso-width-source:userset;mso-width-alt:4681;width:96pt" width="128" />
                <col style="mso-width-source:userset;mso-width-alt:4205;width:86pt" width="115" />
                <col style="mso-width-source:userset;mso-width-alt:4315;width:89pt" width="118" />
                <col style="mso-width-source:userset;mso-width-alt:22637;width:464pt" width="619" />
                <col style="mso-width-source:userset;mso-width-alt:5376;width:110pt" width="147" />
                <col style="mso-width-source:userset;mso-width-alt:3584;width:74pt" width="98" />
            </colgroup>
            <tr height="58" style="mso-height-source:userset;height:43.5pt">
                <td class="auto-style1" height="58" width="128">KONUSU</td>
                <td class="auto-style2" width="115">AD SOYAD</td>
                <td class="auto-style3" width="118">SON GÖREVLENDİRME TARİHİ</td>
                <td class="auto-style4" width="619">GÖREV VE SORULACAKLAR</td>
                <td class="auto-style5" width="147">MAİL</td>
                <td class="auto-style6" width="98">TELEFON</td>
            </tr>
            <tr height="34" style="mso-height-source:userset;height:25.5pt">
                <td class="auto-style7" height="34" width="128">YÖNETİM<span style="mso-spacerun:yes">&nbsp;</span></td>
                <td class="auto-style8" width="115">MÜCAHİT YILDIZ</td>
                <td class="auto-style9" width="118">&nbsp;</td>
                <td class="auto-style10" width="619">GRUBUMUZUN İŞLEYİŞİYLE İLGİLİ BİRİMLERCE SONUÇLANMAYAN TÜM KONULARDA</td>
                <td class="auto-style11" style="text-underline-style: single;" width="147"><a href="mailto:my@sultanlar.com.tr"><span style="font-size:9.0pt">my@sultanlar.com.tr</span></a></td>
                <td class="auto-style12">&nbsp;</td>
            </tr>
            <tr height="15" style="mso-height-source:userset;height:11.25pt">
                <td class="auto-style13" height="15" width="128">&nbsp;</td>
                <td class="auto-style14" width="115">&nbsp;</td>
                <td class="auto-style15" width="118">&nbsp;</td>
                <td class="auto-style16" width="619">&nbsp;</td>
                <td class="auto-style17" style="text-underline-style: single;" width="147"><u style="visibility:hidden;mso-ignore:visibility">&nbsp;</u></td>
                <td></td>
            </tr>
            <tr height="35" style="height:26.25pt">
                <td class="auto-style18" height="35" width="128">TÜRKİYE SATIŞ TAKIM LİDERİ</td>
                <td class="auto-style8" width="115">OSMAN UYSUN</td>
                <td align="right" class="auto-style9" width="118">1.01.2015</td>
                <td class="auto-style10" width="619">SATIŞIN İŞLEYİŞİLİ İLGİLİ SONUÇLANMAYAN ÇÖZÜM KALAN TÜM KONULARDA</td>
                <td class="auto-style11" style="text-underline-style: single;" width="147"><a href="mailto:ouysun@sultanlar.com.tr"><span style="font-size:9.0pt">ouysun@sultanlar.com.tr</span></a></td>
                <td class="auto-style19" width="98">0533 699 78 07 - 0216 561 50 00</td>
            </tr>
            <tr height="15" style="mso-height-source:userset;height:11.25pt">
                <td class="auto-style13" height="15" width="128">&nbsp;</td>
                <td class="auto-style14" width="115">&nbsp;</td>
                <td class="auto-style15" width="118">&nbsp;</td>
                <td class="auto-style16" width="619">&nbsp;</td>
                <td class="auto-style17" style="text-underline-style: single;" width="147"><u style="visibility:hidden;mso-ignore:visibility">&nbsp;</u></td>
                <td></td>
            </tr>
            <tr height="35" style="height:26.25pt">
                <td class="auto-style18" height="35" width="128">EDT SATIŞ MÜDÜRÜ</td>
                <td class="auto-style8" width="115">İSMET ARPAGUŞ</td>
                <td align="right" class="auto-style9" width="118">1.01.2014</td>
                <td class="auto-style10" width="619">TIBTRAP-FULNET ENDÜSTRİYEL ÜRÜNLER YÖNETİCİSİ ÜRÜNLE İLGİLİ SORUNLAR MAİL YOLUYLA</td>
                <td class="auto-style11" style="text-underline-style: single;" width="147"><a href="mailto:iarpagus@tibet.com.tr"><span style="font-size:9.0pt">iarpagus@tibet.com.tr</span></a></td>
                <td class="auto-style19" width="98">0533 699 78 08 - 0216 595 05 00</td>
            </tr>
            <tr height="18" style="mso-height-source:userset;height:13.5pt">
                <td class="auto-style20" height="18" width="128"></td>
                <td class="auto-style21" width="115"></td>
                <td class="auto-style22" width="118"></td>
                <td class="auto-style23" width="619"></td>
                <td class="auto-style24" style="text-underline-style: single;" width="147"></td>
                <td class="auto-style25" width="98"></td>
            </tr>
            <tr height="34" style="height:25.5pt">
                <td class="auto-style26" height="273" rowspan="6" width="128">PAZARLAMA</td>
                <td class="auto-style27" width="115">ESİN SETOL</td>
                <td align="right" class="auto-style28" width="118">1.01.2018</td>
                <td class="auto-style29" width="619">PAZARLAMA MÜDÜRÜ: TÜM MARKALARIN VE ÜRÜNLERİN MARKA- PAZARLAMA FAALİYETLERİNİ YÖNETMEKTEDİR. MAİL YOLUYLA İLETİŞİM</td>
                <td class="auto-style30" style="text-underline-style: single;" width="147">esinsetol@tibet.com.tr</td>
                <td class="auto-style31" width="98">0533 699 78 38</td>
            </tr>
            <tr height="51" style="height:38.25pt">
                <td class="auto-style32" height="51" width="115">İSLAM YILDIZ</td>
                <td align="right" class="auto-style33" width="118">1.01.2016</td>
                <td class="auto-style34" width="619">ÜRGE MD.İHRACAT ÜRÜN YÖNETİCİSİ. YENİ ÜRÜN FİKİRLERİ İÇİN <font class="font6">birfikrimvar@sultanlar.com.tr</font><font class="font5"> ADRESİ ÜZERİNDEN BİLGİ GEÇİLEBİLİR. BİR FİKRİM VAR ÜZERİNDEN İŞİMİZİN İLERLEMESİ VE GELİŞMESİ AMACIYLA HER TÜRLÜ ÜRÜN VE YENİ FİKİRLERİNİZİ BEKLİYORUZ.<span style="mso-spacerun:yes">&nbsp;</span></font></td>
                <td class="auto-style35" style="text-underline-style: single;" width="147"><a href="mailto:islamyildiz@tibet.com.tr"><span style="font-size:9.0pt">islamyildiz@tibet.com.tr</span></a></td>
                <td class="auto-style36" width="98">0216 595 05 00</td>
            </tr>
            <tr height="34" style="height:25.5pt">
                <td class="auto-style37" height="34" width="115">SALİH BIÇAK</td>
                <td align="right" class="auto-style33" width="118">1.01.2014</td>
                <td class="auto-style34" width="619">ERNET-PİKNİK ÜRÜN MÜDÜRÜ:&nbsp; PİKNİK MARKASI VE ÜRÜNLERİ İLE ALAKALI TÜM MARKA-PAZARLAMA FAALİYETLERİNİ YÜRÜTMEKTEDİR. MAİL YOLUYLA İLETİŞİM<span style="mso-spacerun:yes">&nbsp;</span></td>
                <td class="auto-style35" style="text-underline-style: single;" width="147"><a href="mailto:salihbicak@tibet.com.tr"><span style="font-size:9.0pt">salihbicak@tibet.com.tr</span></a></td>
                <td class="auto-style36" width="98">0216 595 05 00</td>
            </tr>
            <tr height="51" style="height:38.25pt">
                <td class="auto-style38" height="51" width="115">YASİN KARTAL</td>
                <td align="right" class="auto-style39" width="118">1.01.2014</td>
                <td class="auto-style34" width="619">KENTON-ARI-BÜNSA VE ALTIN ÜRÜN MÜDÜRÜ:<span style="mso-spacerun:yes">&nbsp; </span>MARKALARINDAN SORUMLUDUR. KENDİSİNE BAĞLI MARKALAR VE ÜRÜNLER İLE İLGİLİ TÜM MARKA-PAZARLAMA FAALİYETLERİNİ YÜRÜTMEKTEDİR. ÜRÜN GÖRSELLERİ, ÜRÜNLE İLGİLİ SORUNLAR MAİL YOLUYLA<span style="mso-spacerun:yes">&nbsp;</span></td>
                <td class="auto-style35" style="text-underline-style: single;" width="147"><a href="mailto:ykartal@tibet.com.tr"><span style="font-size:9.0pt">ykartal@tibet.com.tr</span></a></td>
                <td class="auto-style36" width="98">0530 394 53 53</td>
            </tr>
            <tr height="51" style="height:38.25pt">
                <td class="auto-style32" height="51" width="115">GÜLSUN SEDA DEMIRHAN</td>
                <td align="right" class="auto-style33" width="118">1.01.2018</td>
                <td class="auto-style34" width="619">SALOON-CAMSİL-TİBTRAP-AİDA ÜRÜN MÜDÜRÜ: KENDİSİNE BAĞLI MARKALAR VE ÜRÜNLER İLE İLGİLİ TÜM MARKA- PAZARLAMA FAALİYETLERİNİ YÜRÜTMEKTEDİR. ÜRÜN GÖRSELLERİ, ÜRÜNLE İLGİLİ SORUNLAR MAİL YOLUYLA</td>
                <td class="auto-style35" style="text-underline-style: single;" width="147"><a href="javascript:OpenNewWindow('/Mondo/lang/sys/Forms/MAI/compose.aspx?MsgTo=gulsunsedademirhan%40tibet.com.tr&amp;MsgSubject=&amp;MsgCc=&amp;MsgBcc=&amp;MsgBody=',570,450)"><span style="font-size:9.0pt">gulsunsedademirhan@tibet.com.tr<span style="mso-spacerun:yes">&nbsp;</span></span></a></td>
                <td class="auto-style36" width="98">0216 595 05 00</td>
            </tr>
            <tr height="52" style="height:39.0pt">
                <td class="auto-style40" height="52" width="115">TURGAY YILMAZ</td>
                <td align="right" class="auto-style33" width="118">28.11.2019</td>
                <td class="auto-style34" width="619">TÜM MARKALARDAN SORUMLU ASİSTAN ÜRÜN MÜDÜRÜ TÜM MARKALARIMIZLA ALAKALI BEDELSİZ NUMUNE, STAND, P.O.P, TADIM, BELGE GİBİ TÜM TALEPLERİNİZİ TURGAY BEY’E, İLGİLİ ÜRÜN MÜDÜRLERİNİ VE PAZARLAMA MÜDÜRÜNÜ CC’YE KOYARAK İLETEBİLİR</td>
                <td class="auto-style35" style="text-underline-style: single;" width="147"><a href="mailto:turgayyilmaz@tibet.com.tr"><span style="font-size:9.0pt">turgayyilmaz@tibet.com.tr</span></a></td>
                <td class="auto-style36" width="98">0216 595 05 00</td>
            </tr>
            <tr height="21" style="mso-height-source:userset;height:15.75pt">
                <td class="auto-style41" height="21" width="128"></td>
                <td class="auto-style21" width="115"></td>
                <td class="auto-style22" width="118"></td>
                <td class="auto-style23" width="619"></td>
                <td class="auto-style24" style="text-underline-style: single;" width="147"></td>
                <td class="auto-style25" width="98"></td>
            </tr>
            <tr height="68" style="height:51.0pt">
                <td class="auto-style42" height="136" rowspan="2" width="128">İSTANBUL VE BATI TRAKYA TİCARİ PAZARLAMA</td>
                <td class="auto-style43" width="115">DEMET DOĞAN</td>
                <td align="right" class="auto-style33" width="118">1.12.2018</td>
                <td class="auto-style34" width="619">AKTİVİTE FİYATLANDIRILMASI, ÜRÜN FİYATI VERİLMESİ, ANLAŞMA ONAYLARI MAİL YOLUYLA HİZMET FATURALARI KONTROL, FATURADA İSKONTO ÇIKMAMIŞ TALEPLERİ FATURA NUMARALARIYLA BİRLİKTE TALEP EDİLEBİLİR. MÜŞTERİMİN MALİYETİ NE KADAR, GÜNCEL FİYAT LİSTESİ , MÜŞTERİ CİRO PRİMLERİ SORULACAK, 500&#39;LÜ KODLARIN TANIMLANMASI,500&#39;LÜ GÖRÜNMEYEN FİYATLAR,MÜŞTERİ MALİYETLERİ MAİL YOLUYLA</td>
                <td class="auto-style35" style="text-underline-style: single;" width="147"><a href="mailto:demetdogan@tibet.com.tr"><span style="font-size:9.0pt">demetdogan@tibet.com.tr&nbsp;</span></a></td>
                <td class="auto-style36" width="98">0530 324 71 44 -0216 595 05 00</td>
            </tr>
            <tr height="68" style="height:51.0pt">
                <td class="auto-style44" height="68" width="115">NESLİHAN DEMİRBAŞ<br />
                    (ULUSAL ZİNCİR)</td>
                <td align="right" class="auto-style33" width="118">1.12.2018</td>
                <td class="auto-style34" width="619">ULUSAL SİPARİŞ GİRİŞİ, HİZMET FATURALARI KONTROL, FATURADA İSKONTO ÇIKMAMIŞ TALEPLERİ FATURA NUMARALARIYLA BİRLİKTE TALEP EDİLEBİLİR. GÜNCEL FİYAT LİSTESİ , MÜŞTERİ CİRO PRİMLERİ SORULACAK, 500&#39;LÜ KODLARIN TANIMLANMASI,500&#39;LÜ GÖRÜNMEYEN FİYATLAR GÜNCEL ULUSAL FİYAT LİSTESİ, ULUSAL İADE FATURA TAKİBİ<span style="mso-spacerun:yes">&nbsp;</span></td>
                <td class="auto-style35" style="text-underline-style: single;" width="147"><a href="mailto:ndemirbas@tibet.com.tr"><span style="font-size:9.0pt">ndemirbas@tibet.com.tr</span></a></td>
                <td class="auto-style36" width="98">0216 595 05 00</td>
            </tr>
            <tr height="34" style="height:25.5pt">
                <td class="auto-style45" height="34" width="128">TİC.PAZARLAMA /ADANA</td>
                <td class="auto-style43" width="115">MEHMET GÜLEKOĞLU</td>
                <td align="right" class="auto-style33" width="118">1.12.2018</td>
                <td class="auto-style34" width="619">TÜM BAYİLERİN BÜTÇE İŞLEMLERİ &nbsp;İLE İLGİLİ<span style="mso-spacerun:yes">&nbsp;</span></td>
                <td class="auto-style35" style="text-underline-style: single;" width="147"><a href="mailto:mgulekoglu@stgrup.com.tr"><span style="font-size:9.0pt">mgulekoglu@stgrup.com.tr</span></a></td>
                <td class="auto-style36" width="98">0533 957 80 34<span style="mso-spacerun:yes">&nbsp;&nbsp;</span></td>
            </tr>
            <tr height="21" style="height:15.75pt">
                <td class="auto-style46" height="21" width="128">İADE KABUL</td>
                <td class="auto-style47" width="115">&nbsp;</td>
                <td align="right" class="auto-style48" width="118">1.08.2018</td>
                <td class="auto-style49" width="619">HER TÜRLÜ İADE İŞLEMLERİ (NEDEN DÜŞÜLMEDİ VS.) İADELER İLE İLGİLİ ÖNCELİKLİ</td>
                <td class="auto-style50" style="text-underline-style: single;" width="147"><u style="visibility:hidden;mso-ignore:visibility">&nbsp;</u></td>
                <td class="auto-style36" width="98"><span style="mso-spacerun:yes">&nbsp;</span>0216 595 05 00</td>
            </tr>
            <tr height="20" style="height:15.0pt">
                <td class="auto-style51" height="20" width="128">&nbsp;</td>
                <td class="auto-style52" width="115">&nbsp;</td>
                <td class="auto-style39" width="118">&nbsp;</td>
                <td class="auto-style53" width="619">&nbsp;</td>
                <td class="auto-style54" style="text-underline-style: single;" width="147"><u style="visibility:hidden;mso-ignore:visibility">&nbsp;</u></td>
                <td class="auto-style36" width="98">&nbsp;</td>
            </tr>
            <tr height="51" style="height:38.25pt">
                <td class="auto-style55" height="51" width="128">TİC.PAZARLAMA /EGE VE GÜNEY MARMARA</td>
                <td class="auto-style43" width="115">MÜGE ÖZDEMİR</td>
                <td align="right" class="auto-style33" width="118">1.12.2018</td>
                <td class="auto-style34" width="619">AKTİVİTE FİYATLANDIRILMASI, ÜRÜN FİYATI VERİLMESİ, ANLAŞMA ONAYLARI MAİL YOLUYLA HİZMET FATURALARI KONTROL, FATURADA İSKONTO ÇIKMAMIŞ TALEPLERİ FATURA NUMARALARIYLA BİRLİKTE TALEP EDİLEBİLİR. MÜŞTERİMİN MALİYETİ NE KADAR, MÜŞTERİ CİRO PRİMLERİ SORULACAK, BÖLGE SİPARİŞ GİRİŞLERİ</td>
                <td class="auto-style35" style="text-underline-style: single;" width="147">mugeozdemir@tibet.com.tr</td>
                <td class="auto-style36" width="98">0533 957 80 32 -
                    <br />
                    0232 390 91 00</td>
            </tr>
            <tr height="52" style="height:39.0pt">
                <td class="auto-style56" height="52" width="128">TİC.PAZARLAMA /İÇ ANADOLU VE KARADENİZ</td>
                <td class="auto-style14" width="115">SELÇUK TONYALI</td>
                <td align="right" class="auto-style33" width="118">1.10.2018</td>
                <td class="auto-style34" width="619">AKTİVİTE FİYATLANDIRILMASI, ÜRÜN FİYATI VERİLMESİ, ANLAŞMA ONAYLARI MAİL YOLUYLA HİZMET FATURALARI KONTROL, FATURADA İSKONTO ÇIKMAMIŞ TALEPLERİ FATURA NUMARALARIYLA BİRLİKTE TALEP EDİLEBİLİR. MÜŞTERİMİN MALİYETİ NE KADAR, MÜŞTERİ CİRO PRİMLERİ SORULACAK</td>
                <td class="auto-style17" style="text-underline-style: single;" width="147">selcuktonyali@tibet.com.tr</td>
                <td class="auto-style36" width="98">0312 397 82 14
                    <br />
                    0530 320 87 12</td>
            </tr>
            <tr height="21" style="height:15.75pt">
                <td class="auto-style57" height="21" width="128">SİPARİŞ GİRİŞİ</td>
                <td class="auto-style27" width="115">TUBA POLAT</td>
                <td align="right" class="auto-style28" width="118">1.01.2014</td>
                <td class="auto-style29" width="619">SİPARİŞ GİRİŞİ SİPARİŞ KONTROLÜ GİBİ KONULARDA ARANACAK</td>
                <td class="auto-style30" style="text-underline-style: single;" width="147"><a href="mailto:tubapolat@tibet.com.tr"><span style="font-size:9.0pt">tubapolat@tibet.com.tr</span></a></td>
                <td class="auto-style31" width="98">0216 595 05 00</td>
            </tr>
            <tr height="21" style="height:15.75pt">
                <td class="auto-style58" height="21" width="128">&nbsp;</td>
                <td class="auto-style59" width="115">&nbsp;</td>
                <td class="auto-style60" width="118">&nbsp;</td>
                <td class="auto-style61" width="619">&nbsp;</td>
                <td class="auto-style30" style="text-underline-style: single;" width="147"><u style="visibility:hidden;mso-ignore:visibility">&nbsp;</u></td>
                <td class="auto-style62" width="98">&nbsp;</td>
            </tr>
            <tr height="52" style="height:39.0pt">
                <td class="auto-style63" height="52" width="128">DANIŞMAN RAPORLAMA</td>
                <td class="auto-style8" width="115">YÜCEL KAVANOZ</td>
                <td align="right" class="auto-style9" width="118">1.02.2016</td>
                <td class="auto-style10" width="619">TÜM RAPORLAMALARDAN SORUMLU, MÜŞTERİ AKTİF PASİF (YÖN.ONAY DAHİLİNDE), MÜŞTERİ AKTARIMI, (YÖN.ONAY DAHİLİNDE), HEDEF VE PRİMLERİN DÜZENLENMESİ, AÇIK BARKOD LİSTELERİ DÜZENLEME VE DEĞİŞİKLİĞİNDE İŞLEMLERİNDE ARANACAK.<span style="mso-spacerun:yes">&nbsp;</span></td>
                <td class="auto-style30" style="text-underline-style: single;" width="147"><a href="mailto:yucelk@sultanlar.com.tr"><span style="font-size:9.0pt">yucelk@sultanlar.com.tr</span></a></td>
                <td class="auto-style19" width="98">0553 235 02 30</td>
            </tr>
            <tr height="21" style="height:15.75pt">
                <td class="auto-style64" height="21" width="128">&nbsp;</td>
                <td class="auto-style59" width="115">&nbsp;</td>
                <td class="auto-style60" width="118">&nbsp;</td>
                <td class="auto-style61" width="619">&nbsp;</td>
                <td class="auto-style30" style="text-underline-style: single;" width="147"><u style="visibility:hidden;mso-ignore:visibility">&nbsp;</u></td>
                <td class="auto-style62" width="98">&nbsp;</td>
            </tr>
            <tr height="34" style="height:25.5pt">
                <td class="auto-style65" height="34" width="128">BİLGİ İŞLEM WEB YAZILIM</td>
                <td class="auto-style27" width="115">MEHMET İSTİF</td>
                <td align="right" class="auto-style28" width="118">1.01.2014</td>
                <td class="auto-style29" width="619">WEB İLE İLGİLİ TÜM KONULAR , WEB SİSTEM AKSAKLILARI ÇÖZÜMÜ, <font class="font6">MAİL YOLUYLA CEVAPLANIR</font></td>
                <td class="auto-style30" style="text-underline-style: single;" width="147"><a href="mailto:mehmetistif@tibet.com.tr"><span style="font-size:9.0pt">mehmetistif@tibet.com.tr</span></a></td>
                <td class="auto-style31" width="98">0555 436 65 50</td>
            </tr>
            <tr height="35" style="height:26.25pt">
                <td class="auto-style66" height="35" width="128">BİLGİ İŞLEM DONANIM</td>
                <td class="auto-style47" width="115">NURETTİN GÜNAY</td>
                <td align="right" class="auto-style48" width="118">1.01.2014</td>
                <td class="auto-style49" width="619">BİLGİ İŞLEM MD. BİLGİSAYAR DONANIMLARI, TELEFON YAZILIMI HAKKINDAKİ KONULARDA MAİL YADA TELEFON YOLUYLA CEVAPLANIR</td>
                <td class="auto-style67" style="text-underline-style: single;" width="147"><a href="mailto:ngunay@sultanlar.com.tr"><span style="font-size:9.0pt">ngunay@sultanlar.com.tr</span></a></td>
                <td class="auto-style68" width="98">0533 141 32 41</td>
            </tr>
            <tr height="20" style="height:15.0pt">
                <td class="auto-style69" height="20" width="128">&nbsp;</td>
                <td class="auto-style14" width="115">&nbsp;</td>
                <td class="auto-style15" width="118">&nbsp;</td>
                <td class="auto-style16" width="619">&nbsp;</td>
                <td class="auto-style17" style="text-underline-style: single;" width="147"><u style="visibility:hidden;mso-ignore:visibility">&nbsp;</u></td>
                <td class="auto-style70" width="98">&nbsp;</td>
            </tr>
            <tr height="36" style="mso-height-source:userset;height:27.0pt">
                <td class="auto-style71" height="88" rowspan="2" width="128">LOJİSTİK</td>
                <td class="auto-style43" width="115">SİNAN YUTSEVER</td>
                <td align="right" class="auto-style33" width="118">1.01.2014</td>
                <td class="auto-style34" width="619">ÜRÜNLER TESLİM EDİLMEMİŞ, EKSİK TESLİM EDİLMİŞ GİBİ LOJİSTİK KONULARI, ÜRÜN MÜŞTERİYE GİTMEDİ FATURA GİTTİ. HAMMALİYE FATULARI LOJİSİK İLE İLGİLİ KONULARDA ARANACAK</td>
                <td class="auto-style35" style="text-underline-style: single;" width="147"><a href="mailto:syurtsever@tibet.com.tr"><span style="font-size:9.0pt">syurtsever@tibet.com.tr</span></a></td>
                <td class="auto-style36" width="98">0530 320 67 20- 0216 595 05 00</td>
            </tr>
            <tr height="52" style="height:39.0pt">
                <td class="auto-style72" height="52" width="115">ERTUĞRUL DUYSAK<span style="mso-spacerun:yes">&nbsp; </span>- MURAT FETTAH</td>
                <td align="right" class="auto-style48" width="118">1.01.2014</td>
                <td class="auto-style49" width="619">YANLIŞ KESİLEN FATURALARDA ÖNCELİKLİ ARANMALI, FATURA GERİ DÖNÜŞLERİ ÜRÜNLERİ KİM TESLİM ALMIŞ GİBİ SORULARA CEVAP ALINABİLİR. İRSALİYE OLAN FATURA GÖRÜNTÜLERİ, SEVKİYAT ŞOFÖRÜNE TELEFON İLE ULAŞILAMADIĞINDAN, ÜRÜNLER SEVKİYATA ÇIKTIMI SORULARIDAN ARANACAK</td>
                <td class="auto-style67" style="text-underline-style: single;" width="147"><a href="mailto:mfettah@tibet.com.tr"><span style="font-size:9.0pt">ertugrulduysak@tibet.com.tr mfettah@tibet.com.tr</span></a></td>
                <td class="auto-style68" width="98">0530 370 61 73- 0532 769 81 12<span style="mso-spacerun:yes">&nbsp;&nbsp;&nbsp; </span>0216 595 05 00</td>
            </tr>
            <tr height="21" style="mso-height-source:userset;height:15.75pt">
                <td class="auto-style41" height="21" width="128"></td>
                <td class="auto-style21" width="115"></td>
                <td class="auto-style22" width="118"></td>
                <td class="auto-style23" width="619"></td>
                <td class="auto-style24" style="text-underline-style: single;" width="147"></td>
                <td class="auto-style25" width="98"></td>
            </tr>
            <tr height="40" style="mso-height-source:userset;height:30.0pt">
                <td class="auto-style73" height="172" rowspan="4" width="128">MALİ İŞLER</td>
                <td class="auto-style27" width="115">GÖKHAN ÇELİK</td>
                <td align="right" class="auto-style28" width="118">1.01.2014</td>
                <td class="auto-style29" width="619">MUHASEBE MÜDÜRÜ BİRİM PERSONELLERİNE ULAŞILAMADIĞINDA , AVUKATLIK MÜŞTERİLER İLE İLGİLİ BİLGİ VERİLECEK</td>
                <td class="auto-style11" style="text-underline-style: single;" width="147"><a href="mailto:gokhancelik@tibet.com.tr"><span style="font-size:9.0pt">gokhancelik@tibet.com.tr</span></a></td>
                <td class="auto-style31" width="98">0530 825 19 80- 0216 595 05 00</td>
            </tr>
            <tr height="40" style="mso-height-source:userset;height:30.0pt">
                <td class="auto-style74" height="40" width="115">UFUK YIKICI</td>
                <td align="right" class="auto-style15" width="118">1.01.2018</td>
                <td class="auto-style16" width="619">MASRAFLARIN İŞLENMESİ, YOL MASRAFLARI VE DİĞER MASRAFLAR</td>
                <td class="auto-style75" style="text-underline-style: single;" width="147"><a href="mailto:ufukyikici@tibet.com.tr">ufukyikici@tibet.com.tr</a></td>
                <td class="auto-style31" width="98">0216 595 05 00</td>
            </tr>
            <tr height="40" style="mso-height-source:userset;height:30.0pt">
                <td class="auto-style76" height="40" width="115">EYÜP SERTKAYA</td>
                <td align="right" class="auto-style15" width="118">1.01.2020</td>
                <td class="auto-style16" width="619">E-FATURALAR KONUSUNDA TÜM SORUNLARDA ÖNCELLİKLİ ARANACAK.</td>
                <td class="auto-style11" style="text-underline-style: single;" width="147"><a href="mailto:eyupsertkaya@tibet.com.tr"><span style="font-size:9.0pt">eyupsertkaya@tibet.com.tr</span></a></td>
                <td class="auto-style68" width="98">0216 595 05 00</td>
            </tr>
            <tr height="52" style="mso-height-source:userset;height:39.0pt">
                <td class="auto-style72" height="52" width="115">ZEHRA AKGÜL</td>
                <td align="right" class="auto-style48" width="118">1.05.2016</td>
                <td class="auto-style49" width="619">TÜM İADE VE MÜŞTERİ HİZMET FATURALARININ İŞLENMESİ, TAKİBİ GERİ DÖNÜŞLERİ. İSKONTO ÇIKMAMIŞLAR TİC.PAZ. TARAFINDAN BELİRLENDİKTEN SONRA MÜŞTERİYE FAT.GERİ DÖNÜŞÜ YAPAR. E-FATURALAR MÜŞTERİDE GÖZÜKMÜYOR SORULARI İÇİN.<span style="mso-spacerun:yes">&nbsp; </span>İMHA FATURALARI,BABS İÇİN ARAYANLARA CEVAP VERİLMESİ</td>
                <td class="auto-style67" style="text-underline-style: single;" width="147"><a href="mailto:zehraakgul@tibet.com.tr"><span style="font-size:9.0pt">zehraakgul@tibet.com.tr</span></a></td>
                <td class="auto-style68" width="98">0216 595 05 00</td>
            </tr>
            <tr height="30" style="mso-height-source:userset;height:22.5pt">
                <td class="auto-style77" height="30" width="128">İADE KABUL</td>
                <td class="auto-style47" width="115">MAHMUT AKDOĞAN</td>
                <td class="auto-style48" width="118">&nbsp;</td>
                <td class="auto-style49" width="619">HER TÜRLÜ İADE İŞLEMLERİ (NEDEN DÜŞÜLMEDİ VS.) İADELER İLE İLGİLİ TÜM AŞAMLAR İÇİN ÖNCELİKLİ ARANACAK</td>
                <td class="auto-style67" style="text-underline-style: single;" width="147"><a href="mailto:mahmutakdogan@tibet.com.tr"><span style="font-size:9.0pt">mahmutakdogan@tibet.com.tr</span></a></td>
                <td class="auto-style68" width="98">0537 287 47 86 0216 595 05 00</td>
            </tr>
            <tr height="21" style="mso-height-source:userset;height:15.75pt">
                <td class="auto-style41" height="21" width="128"></td>
                <td class="auto-style21" width="115"></td>
                <td class="auto-style22" width="118"></td>
                <td class="auto-style23" width="619"></td>
                <td class="auto-style24" style="text-underline-style: single;" width="147"></td>
                <td class="auto-style25" width="98"></td>
            </tr>
            <tr height="34" style="height:25.5pt">
                <td class="auto-style78" height="55" rowspan="2" width="128">FİNANS</td>
                <td class="auto-style27" width="115">İSMAİL DERECİ</td>
                <td align="right" class="auto-style28" width="118">1.01.2014</td>
                <td class="auto-style29" width="619">ŞEF, FİNANS İLE İLGİLİ ÖNCELİKLİ SORUMLU<span style="mso-spacerun:yes">&nbsp;</span></td>
                <td class="auto-style30" style="text-underline-style: single;" width="147"><a href="mailto:ismaildereci@tibet.com.tr"><span style="font-size:9.0pt">ismaildereci@tibet.com.tr</span></a></td>
                <td class="auto-style31" width="98">0536 239 99 22 - 0216 595 05 00</td>
            </tr>
            <tr height="21" style="height:15.75pt">
                <td class="auto-style79" height="21" width="115">ÖZLEM AVCI</td>
                <td align="right" class="auto-style48" width="118">1.01.2014</td>
                <td class="auto-style49" width="619">FİNANS ELEMANI, MAİL ORDER,<span style="mso-spacerun:yes">&nbsp; </span>ÇEKLERİN SİSTEME İŞLENMESİ, MAİL VEYA TELEFON İLETİŞİME GEÇİLECEK</td>
                <td class="auto-style67" style="text-underline-style: single;" width="147"><a href="mailto:ozlemavci@tibet.com.tr"><span style="font-size:9.0pt">ozlemavci@tibet.com.tr</span></a></td>
                <td class="auto-style68" width="98">0216 595 05 00</td>
            </tr>
            <tr height="21" style="height:15.75pt">
                <td class="auto-style41" height="21" width="128"></td>
                <td class="auto-style21" width="115"></td>
                <td class="auto-style22" width="118"></td>
                <td class="auto-style23" width="619"></td>
                <td class="auto-style24" style="text-underline-style: single;" width="147"></td>
                <td class="auto-style25" width="98"></td>
            </tr>
            <tr height="34" style="height:25.5pt">
                <td class="auto-style65" height="34" width="128">İDARİ İŞLER</td>
                <td class="auto-style27" width="115">AHMET FETTAH</td>
                <td align="right" class="auto-style28" width="118">1.01.2016</td>
                <td class="auto-style29" width="619">İDARİ İŞLER MÜDÜR</td>
                <td class="auto-style30" style="text-underline-style: single;" width="147"><a href="mailto:afettah@tibet.com.tr"><span style="font-size:9.0pt">afettah@tibet.com.tr</span></a></td>
                <td class="auto-style31" width="98">0533 699 78 56 -0216 595 05 00</td>
            </tr>
            <tr height="35" style="height:26.25pt">
                <td class="auto-style80" height="35" width="128">İDARİ İŞLER</td>
                <td class="auto-style43" width="115">MUHSİN HUT</td>
                <td align="right" class="auto-style33" width="118">1.01.2017</td>
                <td class="auto-style34" width="619">İDARİ İŞLER KONULARINDA<font class="font6"> ÖNCELİKLİ ARANACAK. </font><font class="font7">ARAÇ SORUNLARI GİBİ KONULAR</font></td>
                <td class="auto-style35" style="text-underline-style: single;" width="147"><a href="mailto:muhsinhut@tibet.com.tr"><span style="font-size:9.0pt">muhsinhut@tibet.com.tr</span></a></td>
                <td class="auto-style36" width="98">0532 318 45 44 -0216 595 05 00</td>
            </tr>
            <tr height="20" style="height:15.0pt">
                <td class="auto-style81" height="20" width="128">İDARİ İŞLER</td>
                <td class="auto-style43" width="115">ÖMER DIKAN</td>
                <td align="right" class="auto-style33" width="118">1.01.2019</td>
                <td class="auto-style34" width="619">İDARİ İŞLER KONULARINDA<font class="font6"> ÖNCELİKLİ ARANACAK. </font><font class="font7">ARAÇ SORUNLARI GİBİ KONULAR</font></td>
                <td class="auto-style30" style="text-underline-style: single;" width="147">omerdikan@tibet.com.tr</td>
                <td class="auto-style31" width="98">0216 595 05 00</td>
            </tr>
            <tr height="35" style="height:26.25pt">
                <td class="auto-style80" height="35" width="128">İDARİ İŞLER</td>
                <td class="auto-style43" width="115">ZEKİ ÜNAL -YELİZ TOPAL</td>
                <td class="auto-style33" width="118">&nbsp;</td>
                <td class="auto-style34" width="619">YEMEK ÇEKLERİ-YOL ÜCRETLERİ- (<font class="font6">MARKET LİDERLERİ</font><font class="font5">) TELEFON HAT SORUNLARI-İNTERNET AZALMASIYLA İLGİLİ SORUN YAŞANDIĞINDA ARANACAK.</font></td>
                <td class="auto-style67" style="text-underline-style: single;" width="147"><a href="mailto:zunal@sultanlar.com.tr"><span style="font-size:9.0pt">zunal@sultanlar.com.tr</span></a></td>
                <td class="auto-style36" width="98">0543 441 24 36</td>
            </tr>
            <tr height="21" style="height:15.75pt">
                <td class="auto-style82" height="21" width="128">&nbsp;</td>
                <td class="auto-style14" width="115">&nbsp;</td>
                <td class="auto-style15" width="118">&nbsp;</td>
                <td class="auto-style16" width="619">&nbsp;</td>
                <td class="auto-style17" style="text-underline-style: single;" width="147"><u style="visibility:hidden;mso-ignore:visibility">&nbsp;</u></td>
                <td class="auto-style70" width="98">&nbsp;</td>
            </tr>
            <tr height="34" style="mso-height-source:userset;height:25.5pt">
                <td class="auto-style83" height="103" rowspan="2" width="128">İNSAN KAYNAKLARI</td>
                <td class="auto-style27" width="115">ŞEREF TUNA -<span style="mso-spacerun:yes">&nbsp; </span>ADNAN NARAT</td>
                <td align="right" class="auto-style28" width="118">1.01.2016</td>
                <td class="auto-style29" width="619">ÖDÜL BİLGİLERİ, SGK İLE İLGİLİ BİLGİLER</td>
                <td class="auto-style30" style="text-underline-style: single;" width="147"><a href="mailto:stuna@tibet.com.tr;anarat@tibet.com.tr"><span style="font-size:
  9.0pt">stuna@tibet.com.tr;anarat@tibet.com.tr</span></a></td>
                <td class="auto-style31" width="98">0216 595 05 00</td>
            </tr>
            <tr height="69" style="height:51.75pt">
                <td class="auto-style84" height="69" width="115">MUHARREM GÜNDOĞDU -<span style="mso-spacerun:yes">&nbsp;&nbsp;&nbsp; </span>YASEMİN NARAT-YASEMİN YÜCEALAN</td>
                <td align="right" class="auto-style48" width="118">1.01.2014</td>
                <td class="auto-style49" width="619">ÖZLÜK HAKLARI BİLGİSİ, İZİNLER İLE İLGİLİ TALEPLER, YEMEK ÜCRETLERİ, YAKA KARTLARI, TŞÖRT TALEPLERİ</td>
                <td class="auto-style67" style="text-underline-style: single;" width="147"><a href="mailto:yyucalan@tibet.com.tr;mgundogdu@tibet.com.tr;ynarat@tibet.com.tr"><span style="font-size:9.0pt">yyucalan@tibet.com.tr;mgundogdu@tibet.com.tr;ynarat@tibet.com.tr</span></a></td>
                <td class="auto-style68" width="98">0216 595 05 00</td>
            </tr>
            <tr height="20" style="height:15.0pt">
                <td class="auto-style85" height="20" width="128"></td>
                <td class="auto-style21" width="115"></td>
                <td class="auto-style22" width="118"></td>
                <td class="auto-style23" width="619"></td>
                <td class="auto-style24" style="text-underline-style: single;" width="147"></td>
                <td class="auto-style25" width="98"></td>
            </tr>
            <tr height="51" style="height:38.25pt">
                <td class="auto-style86" height="51" width="128">İADE FİYATLAMA, MÜŞTERİ AÇILIŞI,RUT<span style="mso-spacerun:yes">&nbsp; </span>PLANLAMA</td>
                <td class="auto-style43" width="115">FAHRETTİN KAYA</td>
                <td align="right" class="auto-style33" width="118">1.01.2014</td>
                <td class="auto-style34" width="619">İADE FİYATLANDIRMA, YENİ MÜŞTERİ VE ŞUBE AÇILIŞLARI, MÜŞTERİ BLOKAJA ALMA - MÜŞTERİ BLOKAJI AÇMA YÖNETİCİ ONAYLI, HALK GÜNLERİNİN TANIMLANMASI MAİL YOLUYLA İLETİŞİM RUT İLE İLGİLİ İŞLEMLER ADRES DEĞİŞİKLERİ MAİL OLARAK YÖN.ONAYLI, RUT GİRİŞ ÇIKIŞINLARINDA İZİNLERDE BİLGİ VERİLMELİ</td>
                <td class="auto-style35" style="text-underline-style: single;" width="147"><a href="mailto:fkaya@sultanlar.com.tr"><span style="font-size:9.0pt">fkaya@sultanlar.com.tr</span></a></td>
                <td class="auto-style87" width="98">0554 349 65 65- 0216 561 50 00</td>
            </tr>
            <tr height="34" style="height:25.5pt">
                <td class="auto-style88" height="34" width="128">MUTABAKAT</td>
                <td class="auto-style43" width="115">TÜMAY İLBEYLİ</td>
                <td align="right" class="auto-style33" width="118">1.02.2016</td>
                <td class="auto-style34" width="619">MUTABAKAT YAPILMASI</td>
                <td class="auto-style35" style="text-underline-style: single;" width="147"><a href="mailto:tilbeyli@sultanlar.com.tr"><span style="font-size:9.0pt">tilbeyli@sultanlar.com.tr</span></a></td>
                <td class="auto-style87" width="98">0532 377 85 02 -0216 561 50 00</td>
            </tr>
            <tr height="53" style="mso-height-source:userset;height:39.75pt">
                <td class="auto-style89" height="53" width="128">MÜŞTERİ İLİŞKİLERİ MOBİL RUT</td>
                <td class="auto-style43" width="115">İBRAHİM BAĞDATLI</td>
                <td align="right" class="auto-style33" width="118">1.02.2016</td>
                <td class="auto-style34" width="619">MÜŞTERİLERİMİZİN, ŞİRKETİMİZİN İŞ YAPIŞ ŞEKLİYLE İLGİLİ ŞİKAYET VE ÖNERİLERİ. (sikayetkutusu@sultanlar.com.tr)MOBİL RUT RAPORU. RUT GİRİŞ ÇIKIŞ KONTROLERİNDE SORUN OLDUMU SORULACAK. RUT GİRİŞ HATALARINDA İZİNLERDE BİLGİ VERİLMELİ</td>
                <td class="auto-style35" style="text-underline-style: single;" width="147"><a href="mailto:ibagdatli@sutanlar.com.tr"><span style="font-size:9.0pt">ibagdatli@sutanlar.com.tr</span></a></td>
                <td class="auto-style90" width="98">0533 498 35 65</td>
            </tr>
        </table>
    </body>
</html>
