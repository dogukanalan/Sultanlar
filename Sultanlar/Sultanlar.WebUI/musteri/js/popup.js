<!--

    //Pop up information box II (Mike McGrath (mike_mcgrath@lineone.net,  http://website.lineone.net/~mike_mcgrath))
    //Permission granted to Dynamicdrive.com to include script in archive
    //For this and 100's more DHTML scripts, visit http://dynamicdrive.com

    Xoffset = -60;    // modify these values to ...
    Yoffset = 20;    // change the popup position.

    var old, skn, iex = (document.all), yyy = -1000;

    var ns4 = document.layers
    var ns6 = document.getElementById && !document.all
    var ie4 = document.all

    if (ns4)
        skn = document.dek
    else if (ns6)
        skn = document.getElementById("dek").style
    else if (ie4)
        skn = document.all.dek.style
    if (ns4) document.captureEvents(Event.CLICK);
    else {
        skn.visibility = "visible"
        skn.display = "none"
    }
    document.onclick = get_mouse;

    function popup(msg, bak) {
        var content = "<TABLE BORDER=0 BORDERCOLOR=black CELLPADDING=5 CELLSPACING=0 " +
"BGCOLOR=" + bak + " onclick='kill();'><tr><TD ALIGN=left><FONT COLOR=black SIZE=2>" + 
msg + "</FONT></TD></tr><tr><td align=center><span class='hotspotCizgisiz' onclick='kill();'>Kapat</span></td></tr></TABLE>";
        yyy = Yoffset;
        if (ns4) { skn.document.write(content); skn.document.close(); skn.visibility = "visible" }
        if (ns6) { document.getElementById("dek").innerHTML = content; skn.display = '' }
        if (ie4) { document.all("dek").innerHTML = content; skn.display = '' }
        scroll(0,0);
    }

        function popup(msg) {
        var content = "<TABLE BORDER=0 BORDERCOLOR=black CELLPADDING=5 CELLSPACING=0 " +
"BGCOLOR=white onclick='kill();' style='font-size: 12px; font-family: Verdana'><tr><TD ALIGN=left><FONT COLOR=black SIZE=2>" + 
msg + "</FONT></TD></tr><tr><td align=center><span class='hotspotCizgisiz' onclick='kill();'><b>Kapat</b></span><div style='padding-top: 300px; filter: alpha(opacity=60); -moz-opacity: .60; opacity: .60; background-color: #000000; position: fixed; width: 100%; height: 100%; z-index: -1; left: 0; top: 0;'></div></td></tr></TABLE>";
        yyy = Yoffset;
        if (ns4) { skn.document.write(content); skn.document.close(); skn.visibility = "visible" }
        if (ns6) { document.getElementById("dek").innerHTML = content; skn.display = '' }
        if (ie4) { document.all("dek").innerHTML = content; skn.display = '' }
        scroll(0,0);
    }

    function get_mouse(e) {
        var x = (ns4 || ns6) ? e.pageX : event.x + document.body.scrollLeft;
        skn.left = x + Xoffset;
        var y = (ns4 || ns6) ? e.pageY : event.y + document.body.scrollTop;
        skn.top = y + yyy;
    }

    function kill() {
        yyy = -1000;
        if (ns4) { skn.visibility = "hidden"; }
        else if (ns6 || ie4)
            skn.display = "none"
    }

//-->