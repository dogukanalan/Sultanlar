
function jsload() {
    for (var i = 0; i < arguments.length; i++) {
        var head = document.getElementsByTagName('head')[0];
        var script = document.createElement('script');
        script.type = 'text/javascript';
        if (arguments[i].startsWith("http")) {
            script.src = arguments[i];
        }
        else {
            script.src = '/aassets/js/' + arguments[i] + '.js';
        }
        head.appendChild(script);
    }
}

function cssload() {
    for (var i = 0; i < arguments.length; i++) {
        var link = document.createElement('link');
        link.setAttribute('rel', 'stylesheet');
        link.type = 'text/css';
        if (arguments[i].startsWith("http")) {
            link.href = arguments[i];
        }
        else {
            link.href = '/aassets/css/' + arguments[i] + '.css';
        }
        document.head.appendChild(link);
    }
}

function add_header(page_header, page_subheader) {
    
    if (arguments.length == 2) {
        document.title = page_header + ': ' + page_subheader;

        var header = document.getElementById('header');

        jQuery.ajax({
            url: "/aassets/templates/header.html",
            async: true,
            success: function (data) {
                place_in_outerHTML(header, data);
            }
        });
    }
}

function add_footer() {
    var footer = document.getElementById('footer');

    jQuery.ajax({
        url: "/aassets/templates/footer.html",
        async: true,
        success: function (data) {
            place_in_outerHTML(footer, data);

            jQuery.ajax({
                url: 'https://ajax.aspnetcdn.com/ajax/bootstrap/3.3.7/bootstrap.min.js',
                dataType: 'script',
                async: true
            });
        }
    });
}

function place_in_outerHTML(element, contents) {
    if (element.outerHTML) {
        element.outerHTML = contents;
    }
    else {
        element.innerHTML = contents;
    }
}
